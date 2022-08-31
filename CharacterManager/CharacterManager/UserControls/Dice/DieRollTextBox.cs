using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterManager.UserControls
{
    public class DieRollTextBox : TextBox
    {

        private Boolean isProgram = false;
        private Boolean isModified = false;

        private DieRollEquation _myDieRoll;
        
        public DieRollEquation DieRollObject
        {
            get
            {
                return _myDieRoll;
            }
            set
            {
                if (value != null)
                {
                    isProgram = true;
                    this.Text = value.DieRollString;
                }
                else
                {
                    isProgram = true;
                    this.Text = "";
                }
                _myDieRoll = value;
            }
        }
        


        public DieRollTextBox() : base()
        {
            this.TextChanged += DieRollTextBox_TextChanged;
        }

        public int Roll(out string log)
        {
            if (isModified)
            {
                isModified = false;

                string dieRollString = this.Text;
                try
                {
                    _myDieRoll = new DieRollEquation(dieRollString);
                }
                catch (Exception ex)
                {
                    /* If we fail to parse, then lets return a -1 */
                    log = ex.Message;
                    return -1;
                }
            }

            if(_myDieRoll == null)
            {
                log = "Die Roll object was null";
                return -1;
            }

            return _myDieRoll.RollValue(out log);
        }

        /* The idea is that if somebody changes the text of this textbox then it would know to convert it into a die roll later on. */

        public override string Text 
        { 
            get => base.Text; set 
            {
                base.Text = value;
                isModified = true;
            }
        }

        private void DieRollTextBox_TextChanged(object sender, EventArgs e)
        {
            /* Lets try to catch only user edits. */
            if (isProgram)
            {
                isProgram = false;
            }
            else
            {
                /* Formula has been changed manually, so we will need to reparse it. */
                isModified = true;
            }
        }
    }
}
