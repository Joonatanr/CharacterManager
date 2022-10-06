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


        private struct ChoiceControlPair
        {
            //public List<EquipmentChoice> equipment;
            public List<UserControlEquipmentChoiceSingle> equipmentControls;
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
                    foreach (UserControlEquipmentChoiceSingle single in pair.equipmentControls)
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

                    int EdgeOfControl = 0;

                    List<UserControlEquipmentChoiceSingle> singleControlList = new List<UserControlEquipmentChoiceSingle>();
                    foreach (EquipmentChoice choice in obj)
                    {
                        UserControlEquipmentChoiceSingle singleControl = new UserControlEquipmentChoiceSingle();
                        singleControl.Choice = choice;
                        singleControl.Location = new Point(myButton.Right + 5, yloc);
                        groupBox1.Controls.Add(singleControl);
                        singleControlList.Add(singleControl);

                        yloc += singleControl.Height;
                        yloc += 1;
                        EdgeOfControl = singleControl.Right;
                    }


                    groupBox1.Controls.Add(myButton);
                    xloc = (EdgeOfControl + myButton.Width);

                    ChoiceControlPair pair;
                    pair.btn = myButton;
                    pair.equipmentControls = singleControlList;

                    myControlList.Add(pair);
                }
            }
        }
    }
}
