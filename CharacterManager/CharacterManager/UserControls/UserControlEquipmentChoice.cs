using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharacterManager;

namespace CharacterManager.UserControls
{
    
    public partial class UserControlEquipmentChoice : UserControl
    {
        private EquipmentChoiceList _eqChoice = null;
        public EquipmentChoiceList EqChoice { get { return _eqChoice; } set { _eqChoice = value; updateControlFields(); } }

        private const int RadioButtonInterval = 20;

        public UserControlEquipmentChoice()
        {
            InitializeComponent();
        }
        
        private void updateControlFields()
        {
            int numberOfChoices = _eqChoice.getNumberOfOptions();

            int xloc = 10;
            int yloc = 10;

            groupBox1.Controls.Clear();

            for (int x = 0; x < numberOfChoices; x++)
            {
                List<EquipmentChoice> obj;
                obj = _eqChoice.getOptionFromNumber(x);
                
                if (obj.Count > 0)
                {
                    RadioButton myButton = new RadioButton();
                    myButton.Location = new Point(xloc, yloc);
                    myButton.Size = new Size(140, 40);

                    String descriptions = "";

                    foreach (EquipmentChoice choice in obj)
                    {
                        descriptions += choice.ToString() + "\n";
                    }

                    //MessageBox.Show(descriptions);

                    myButton.Text = descriptions;
                    groupBox1.Controls.Add(myButton);
                    xloc += (RadioButtonInterval + myButton.Width);
                }
            }
        }
    }
}
