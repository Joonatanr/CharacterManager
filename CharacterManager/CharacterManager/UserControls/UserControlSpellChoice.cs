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

            public CheckBox chkBox { get { return _chkBox; } set { _chkBox = value; _chkBox.CheckedChanged += _chkBox_CheckedChanged; } }

            private void _chkBox_CheckedChanged(object sender, EventArgs e)
            {
                SpellCheckedChanged?.Invoke(Spell, _chkBox.Checked);
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

        /* TODO : Use this. */
        public bool addSpellToList(PlayerSpell spell)
        {
            bool res;

            if (mySpellList.Find(s => s.SpellName == spell.SpellName) == null)
            {
                /* Spell does not exist already. */
                mySpellList.Add(spell);
                UpdateValues();
                res = true;
            }
            else
            {
                /* Spell exists, cannot add twice. */
                res = false;
            }

            return res;
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
                if (!control.chkBox.Checked)
                {
                    control.chkBox.Enabled = !isLock;
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

            foreach (PlayerSpell s in mySpellList)
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
                    ctrl.chkBox = myCheckBox;
                    ctrl.SpellCheckedChanged += Ctrl_SpellCheckedChanged;
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
