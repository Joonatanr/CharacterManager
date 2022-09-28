using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager.UserControls
{
    public class UserControlProficiencyList : UserControlGenericListBase
    {
        private string _titleString = "Proficiencies";
        
        public string TitleString { get { return _titleString; } set { _titleString = value; this.Invalidate(); } }
        
        private List<string> _proficiencies = new List<string>();

        public UserControlProficiencyList() : base()
        {

        }

        public void setProficiencylist(List<string> proficiencies)
        {
            _proficiencies = proficiencies;
            this.Invalidate();
        }

        protected override void drawData(Graphics gfx, Font font)
        {
            int y = 0;

            //gfx.DrawString(_titleString, font, new SolidBrush(Color.Black), new Point(1, 1));
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
