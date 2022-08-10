using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharacterManager.Spells;

namespace CharacterManager.UserControls
{
    public class UserControlSpellChoice : UserControlGenericListBase
    {
        private class SpellHandleControl
        {
            public PlayerSpell Spell;
            public CustomButton InfoBtn;
            
            private CheckBox _chkBox;

            public delegate void SpellCheckedChangedListener(PlayerSpell spell, bool isChecked);
            public event SpellCheckedChangedListener SpellCheckedChanged;

            public Boolean isChecked { get { return _chkBox.Checked; } set { _chkBox.Checked = value; } }
            public Boolean isEnabled { get { return _chkBox.Enabled; } set { if (!IsLocked) { _chkBox.Enabled = value; } } }
            public Boolean IsLocked { get { return _isLocked;  } set { _isLocked = value; if (_isLocked) { _chkBox.Checked = true; _chkBox.Enabled = false; } } }

            private Boolean _isLocked = false; //If this is true, then this Spell is always chosen as it derives from race or subrace etc...

            private void _chkBox_CheckedChanged(object sender, EventArgs e)
            {
                SpellCheckedChanged?.Invoke(Spell, _chkBox.Checked);
            }

            public void setCheckBox(CheckBox box)
            {
                _chkBox = box;
                if (IsLocked)
                {
                    _chkBox.Checked = true;
                    _chkBox.Enabled = false;
                }
                else
                {
                    _chkBox.CheckedChanged += new EventHandler(_chkBox_CheckedChanged);
                }
            }

            public SpellHandleControl(PlayerSpell s, CustomButton btn)
            {
                this.Spell = s;
                this.InfoBtn = btn;
                btn.Click += Btn_Click;
            }

            private void Btn_Click(object sender, EventArgs e)
            {
                Spellcard card = new Spellcard();
                card.setSpell(Spell);
                card.ShowDialog();
            }
        }

        private List<PlayerSpell> mySpellList = new List<PlayerSpell>();
        private List<PlayerSpell> myLockedSpellList = new List<PlayerSpell>(); /* These are spells that are already chosen because they come from racial abilities etc... */
        private List<SpellHandleControl> myControlList = new List<SpellHandleControl>();

        /* This dictionary should contain the line number for each spell... Needed to sync visual data. Might not be the perfect solution, but maybe this will work. */
        private Dictionary<PlayerSpell, int> mySpellDictionary = new Dictionary<PlayerSpell, int>();

        /* Properties */
        private String _titleString = "Spells:";
        public String TitleString
        {
            get { return _titleString;   }
            set { _titleString = value;  this.Invalidate(); }
        }

        public bool IsMultipleLevel { get; set; } = false;
        public bool IsCheckBoxed { get; set; } = false;
        public bool IsAvailabilityCount { get; set; } = true;
        public int MaximumAvailableChoices { get; set; } = 0;
        
        /* Delegates. */
        public delegate void SpellChoiceChangedListener(PlayerSpell Spell, bool isChosen);
        public event SpellChoiceChangedListener SpellSelectionChanged;

        public void setSpellList(List<PlayerSpell> spells)
        {
            mySpellList = spells;
            UpdateValues();
        }

        
        /* We add a fixed spell to the list that is always selected. */
        public void setFixedSpellListList(List<PlayerSpell> spellList)
        {
            myLockedSpellList = spellList;
            UpdateValues();
        }

        public void setSpellSelection(string spell, bool isSelected)
        {
            foreach(SpellHandleControl ctrl in myControlList)
            {
                if (ctrl.Spell.SpellName == spell)
                {
                    ctrl.isChecked = isSelected;
                    break;
                }
            }
        }

        public bool removeSpellFromList(PlayerSpell spell)
        {
            bool res;
            PlayerSpell toRemove = mySpellList.Find(s => s.SpellName == spell.SpellName);
            
            
            if (toRemove == null)
            {
                /* Spell does not exist soo nothing to remove? */
                res = false;
            }
            else
            {
                mySpellList.Remove(toRemove);
                UpdateValues();
                res = true;
            }

            return res;
        }

        public List<PlayerSpell> getSelectedSpells()
        {
            List<PlayerSpell> selectedSpells = new List<PlayerSpell>();
            
            foreach(SpellHandleControl ctrl in myControlList)
            {
                if (ctrl.isChecked)
                {
                    selectedSpells.Add(ctrl.Spell);
                }
            }

            return selectedSpells;
        }

        public void setSelectionsLocked(Boolean isLock)
        {
            foreach (SpellHandleControl control in myControlList)
            {
                if (!control.isChecked)
                {
                    control.isEnabled = !isLock;
                }   
            }
        }


        protected override void drawData(Graphics gfx, Font font)
        {
            drawTextOnLine(gfx, _titleString, 0, FontStyle.Bold);

            if (IsMultipleLevel) 
            {
                /* TODO : Functionality first, then another look at the fonts. */

                /* Check if we have any cantrips... */
                if (myControlList.Find(c => c.Spell.SpellLevel == 0) != null)
                {
                    drawTextOnLine(gfx, "Cantrips:", 2, FontStyle.Bold);
                }
                foreach (PlayerSpell sp in mySpellDictionary.Keys)
                {
                    drawTextOnLine(gfx, sp.DisplayedName, mySpellDictionary[sp]);
                }

                for (int level = 1; level <= 9; level++)
                {
                    List<SpellHandleControl> spellControlsOfLevel = myControlList.FindAll(c => c.Spell.SpellLevel == level);

                    if (spellControlsOfLevel.Count > 0)
                    {
                        int topIndex = 99999;
                        foreach (SpellHandleControl ctrl in spellControlsOfLevel)
                        {
                            topIndex = Math.Min(topIndex, mySpellDictionary[ctrl.Spell]);
                        }

                        topIndex--;

                        drawTextOnLine(gfx, "Level " + level.ToString() + " spells", topIndex, FontStyle.Bold);
                    }
                }
            }
            else
            {
                foreach (PlayerSpell sp in mySpellDictionary.Keys)
                {
                    drawTextOnLine(gfx, sp.DisplayedName, mySpellDictionary[sp]);
                }
            }

            if (IsAvailabilityCount)
            {
                int lastLine = getNumberOfLines() - 2;
                drawTextOnLine(gfx, "Available : " + MaximumAvailableChoices.ToString(), lastLine);
            }
        }

        private void UpdateValues()
        {
            this.Controls.Clear(); /* Remove any existing controls. */
            myControlList = new List<SpellHandleControl>();

            int y;

            if (IsMultipleLevel)
            {
                y = 2;
            }
            else 
            {
                y = 1;
             };

            List<PlayerSpell> combinedSpellList = mySpellList.Union(myLockedSpellList).ToList(); /* TODO : Use this list. */
            mySpellDictionary = new Dictionary<PlayerSpell, int>();

            if (IsMultipleLevel)
            {
                for (int level = 0; level <= 9; level++)
                {
                    if (combinedSpellList.Find(c => c.SpellLevel == level) != null)
                    {
                        y++;

                        foreach (PlayerSpell spell in combinedSpellList)
                        {
                            if (spell.SpellLevel == level)
                            {
                                mySpellDictionary.Add(spell, y);
                                y++;
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (PlayerSpell s in combinedSpellList)
                {
                    mySpellDictionary.Add(s, y);
                    y++;
                }
            }

            foreach (PlayerSpell s in mySpellDictionary.Keys)
            {
                CustomButton iBtn = new CustomButton();
                iBtn.Size = new Size(40, 18);
                iBtn.ButtonText = "Info";
                SpellHandleControl ctrl = new SpellHandleControl(s, iBtn);
                myControlList.Add(ctrl);

                AddButtonOnLine(iBtn, mySpellDictionary[s] - 1, 3); /*TODO : Looks like adding controls begins with line index 1, but text uses index 0... <sigh>*/

                if (IsCheckBoxed)
                {
                    CheckBox myCheckBox = new CheckBox();
                    myCheckBox.Size = new Size(16, 16);
                    ctrl.setCheckBox(myCheckBox);
                    
                    if (myLockedSpellList.Find(lockedSpell => lockedSpell.SpellName == s.SpellName) != null)
                    {
                        //Spell is already learned because of racial attributes or otherwise.
                        ctrl.IsLocked = true;
                    }
                    else
                    {
                        //We only add the external listener if this control is going to be modified by the user.
                        ctrl.SpellCheckedChanged += Ctrl_SpellCheckedChanged;
                    }
                    AddControlOnLine(myCheckBox, mySpellDictionary[s] - 1, 3 + iBtn.Width);
                }
            }

            this.Invalidate();
        }

        private void Ctrl_SpellCheckedChanged(PlayerSpell spell, bool isChecked)
        {
            if (isChecked)
            {
                MaximumAvailableChoices--;

                if (MaximumAvailableChoices == 0)
                {
                    //We lock the ability to choose more spells...
                    setSelectionsLocked(true);
                }
            }
            else
            {
                MaximumAvailableChoices++;
                if (MaximumAvailableChoices == 1)
                {
                    //We unlock the ability to choose more spells.
                    setSelectionsLocked(false);
                }
            }

            this.Invalidate();

            if (SpellSelectionChanged != null)
            {
                SpellSelectionChanged(spell, isChecked);
            }
        }

        public UserControlSpellChoice() : base()
        {

        }
    }
}
