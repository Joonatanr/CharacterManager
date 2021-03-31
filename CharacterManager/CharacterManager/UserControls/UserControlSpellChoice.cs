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

            public Boolean isChecked { get { return _chkBox.Checked; } }
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

        /* Properties */
        private String _titleString = "Spells:";
        public String TitleString
        {
            get { return _titleString;   }
            set { _titleString = value;  this.Invalidate(); }
        }

        public bool IsMultipleLevel { get; set; } = false;
        public bool IsCheckBoxed { get; set; } = false;

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
            if (IsMultipleLevel) 
            {
                drawTextOnLine(gfx, _titleString, 0, FontStyle.Bold);
                /* TODO : Functionality first, then another look at the fonts. */
                drawTextOnLine(gfx, "Cantrips:", 1, FontStyle.Bold);

                int y = 2;

                foreach(SpellHandleControl ctrl in myControlList)
                {
                    if (ctrl.Spell.SpellLevel == 0)
                    {
                        drawTextOnLine(gfx, ctrl.Spell.DisplayedName, y);
                        y++;
                    }
                }

                for (int level = 1; level <= 9; level++)
                {
                    if (myControlList.Find(c => c.Spell.SpellLevel == level) != null)
                    {
                        y++;
                        drawTextOnLine(gfx, "Level " + level.ToString() + " spells", y, FontStyle.Bold);
                        y++;

                        foreach (SpellHandleControl ctrl in myControlList)
                        {
                            if (ctrl.Spell.SpellLevel == level)
                            {
                                drawTextOnLine(gfx, ctrl.Spell.SpellName, y);
                                y++;
                            }
                        }
                    }
                }
            }
            else
            {
                drawTextOnLine(gfx, _titleString, 0, FontStyle.Bold);
                int y = 1;
                foreach (SpellHandleControl ctrl in myControlList)
                {
                    drawTextOnLine(gfx, ctrl.Spell.DisplayedName, y);
                    y++;
                }
            }
        }

        private void UpdateValues()
        {
            this.Controls.Clear(); /* Remove any existing controls. */
            myControlList = new List<SpellHandleControl>();

            int y = 0;

            List<PlayerSpell> combinedSpellList = mySpellList.Union(myLockedSpellList).ToList(); /* TODO : Use this list. */


            foreach (PlayerSpell s in combinedSpellList)
            {
                CustomButton iBtn = new CustomButton();
                iBtn.Size = new Size(40, 18);
                iBtn.ButtonText = "Info";
                SpellHandleControl ctrl = new SpellHandleControl(s, iBtn);
                myControlList.Add(ctrl);

                AddButtonOnLine(iBtn, y, 3);

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
                    AddControlOnLine(myCheckBox, y, 3 + iBtn.Width);
                }

                y++;
            }
        }

        private void Ctrl_SpellCheckedChanged(PlayerSpell spell, bool isChecked)
        {
            if(SpellSelectionChanged != null)
            {
                SpellSelectionChanged(spell, isChecked);
            }
        }

        public UserControlSpellChoice() : base()
        {

        }
    }
}
