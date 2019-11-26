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


        private struct ChoiceControlPair
        {
            public List<EquipmentChoice> equipment;
            public RadioButton btn;
        }

        private List<ChoiceControlPair> myControlList = new List<ChoiceControlPair>();

        public UserControlEquipmentChoice()
        {
            InitializeComponent();
        }
        

        public List<EquipmentChoice> getSelectedEquipmentList()
        {
            foreach (ChoiceControlPair pair in myControlList)
            {
                if (pair.btn.Checked)
                {
                    return pair.equipment;
                }
            }

            /* Return null if nothing is selected.*/
            return null;
        }

        private void updateControlFields()
        {
            int numberOfChoices = _eqChoice.getNumberOfOptions();

            int xloc = 10;
            int yloc = 10;

            groupBox1.Controls.Clear();

            /* Populate the radio button controls. */
            for (int x = 0; x < numberOfChoices; x++)
            {
                List<EquipmentChoice> obj;
                obj = _eqChoice.getOptionFromNumber(x);
                
                if (obj.Count > 0)
                {
                    RadioButton myButton = new RadioButton();
                    myButton.Size = new Size(140, 30);
                    yloc = ((groupBox1.Height / 2) - (myButton.Height / 2)) + 2;
                    myButton.Location = new Point(xloc, yloc);

                    String descriptions = "";

                    foreach (EquipmentChoice choice in obj)
                    {
                        descriptions += choice.ToString() + "\n";
                    }

                    //MessageBox.Show(descriptions);

                    myButton.Text = descriptions;
                    groupBox1.Controls.Add(myButton);
                    xloc += (RadioButtonInterval + myButton.Width);

                    ChoiceControlPair pair;
                    pair.btn = myButton;
                    pair.equipment = obj;

                    myControlList.Add(pair);
                }
            }
        }
    }
}
