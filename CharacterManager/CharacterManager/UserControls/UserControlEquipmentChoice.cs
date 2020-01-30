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
using CharacterManager.Items;

namespace CharacterManager.UserControls
{
    
    public partial class UserControlEquipmentChoice : UserControl
    {
        private EquipmentChoiceList _eqChoice = null;
        public EquipmentChoiceList EqChoice { get { return _eqChoice; } set { _eqChoice = value; updateControlFields(); } }

        private const int RadioButtonInterval = 240;


        private struct ChoiceControlPair
        {
            //public List<EquipmentChoice> equipment;
            public List<UserControlChoiceBoxSingle> equipmentControls;
            public RadioButton btn;
        }

        private List<ChoiceControlPair> myControlList = new List<ChoiceControlPair>();

        public UserControlEquipmentChoice()
        {
            InitializeComponent();
        }
        

        /* TODO : What if some selections are incomplete? Handle that case. */
        public List<PlayerItem> getSelectedEquipmentList()
        {
            foreach (ChoiceControlPair pair in myControlList)
            {
                if (pair.btn.Checked)
                {
                    List<PlayerItem> res = new List<PlayerItem>();
                    foreach (UserControlChoiceBoxSingle single in pair.equipmentControls)
                    {
                        res.Add(single.getSelectedItem());
                    }
                    return res;
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
                    myButton.Size = new Size(20, 20);
                    yloc = 10;
                    myButton.Location = new Point(xloc, yloc);

                    yloc = 30;

                    List<UserControlChoiceBoxSingle> singleControlList = new List<UserControlChoiceBoxSingle>();
                    foreach (EquipmentChoice choice in obj)
                    {
                        UserControlChoiceBoxSingle singleControl = new UserControlChoiceBoxSingle();
                        singleControl.Choice = choice;
                        singleControl.Location = new Point(xloc, yloc);
                        groupBox1.Controls.Add(singleControl);
                        singleControlList.Add(singleControl);

                        yloc += singleControl.Height;
                        yloc += 1;
                    }


                    groupBox1.Controls.Add(myButton);
                    xloc += (RadioButtonInterval + myButton.Width);

                    ChoiceControlPair pair;
                    pair.btn = myButton;
                    pair.equipmentControls = singleControlList;

                    myControlList.Add(pair);
                }
            }
        }
    }
}
