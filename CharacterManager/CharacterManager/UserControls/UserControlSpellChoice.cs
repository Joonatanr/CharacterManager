using CharacterManager.Spells;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager.UserControls
{
    public class UserControlSpellChoice : UserControlGenericListBase
    {
        private class SpellHandleControl
        {
            public PlayerSpell Spell;
            public CustomButton InfoBtn;

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

        public void setSpellList(List<PlayerSpell> spells)
        {
            mySpellList = spells;
            UpdateValues();
        }

        protected override void drawData(Graphics gfx, Font font)
        {
            drawTextOnLine(gfx, "Spells: ", 0);
            int y = 1;
            foreach (SpellHandleControl ctrl in myControlList)
            {
                drawTextOnLine(gfx, ctrl.Spell.DisplayedName, y);
                y++;
            }
        }

        private void UpdateValues()
        {
            this.Controls.Clear(); /* Remove any existing controls. */
            myControlList = new List<SpellHandleControl>();

            int y = 1;

            foreach (PlayerSpell s in mySpellList)
            {
                CustomButton iBtn = new CustomButton();
                iBtn.Size = new Size(40, 18);
                SpellHandleControl ctrl = new SpellHandleControl(s, iBtn);
                myControlList.Add(ctrl);

                AddButtonOnLine(iBtn, y, 3);
                y++;
            }
        }

        private List<PlayerSpell> mySpellList = new List<PlayerSpell>();
        private List<SpellHandleControl> myControlList = new List<SpellHandleControl>();

        public UserControlSpellChoice() : base()
        {

        }
    }
}
