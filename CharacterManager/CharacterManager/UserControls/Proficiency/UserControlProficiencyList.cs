﻿using CharacterManager.Items;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager.UserControls
{
    public class PlayerProficiency : PlayerBaseItem
    {
        /* TODO : Move this to a separate file. */
    }
    
    public class UserControlProficiencyList : UserControlGenericListBase<PlayerProficiency>
    {
        private string _titleString = "Proficiencies";
        
        public string TitleString { get { return _titleString; } set { _titleString = value; this.Invalidate(); this.updateBackgroundImage(); } }
        
        private List<string> _proficiencies = new List<string>();

        public UserControlProficiencyList() : base()
        {

        }

        public void setProficiencylist(List<string> proficiencies)
        {
            _proficiencies = proficiencies;

            this.updateBackgroundImage();
            this.Invalidate();
        }

        public List<string> getProficiencies()
        {
            return _proficiencies;
        }

        protected override void drawDisplayedData(Graphics gfx, Font font)
        {
            int y = 0;

            drawTextOnLine(gfx, _titleString, y, FontStyle.Bold);
            y++;

            foreach (string proficiency in _proficiencies)
            {
                drawTextOnLine(gfx, proficiency, y);
                y++;
            }
        }
    }
}
