using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharacterManager.Items;

namespace CharacterManager.UserControls
{
    public partial class UserControlEquipmentChoiceSingle : UserControl
    {
        private EquipmentChoice _choice;
        private PlayerItem _equipment;
        private Boolean isMultipleChoice = false;

        public class EquipmentNotSelectedException : Exception
        {

        }

        public EquipmentChoice Choice
        {
            get { return _choice; }
            set
            {
                _choice = value;
                updateChoiceValue();
            }
        }

        public UserControlEquipmentChoiceSingle()
        {
            InitializeComponent();
            comboBox1.Visible = false;
        }


        public void setActive(Boolean isActive)
        {
            if (isActive)
            {
                comboBox1.Enabled = true;
            }
            else
            {
                comboBox1.Enabled = false;
            }
        }


        /* TODO : What happens if there is nothing selected.*/
        public PlayerItem getSelectedItem()
        {
            if (!isMultipleChoice)
            {
                return _equipment;
            }
            else
            {
                if (string.IsNullOrEmpty(comboBox1.Text))
                {
                    throw new EquipmentNotSelectedException();
                }

                String selected = comboBox1.SelectedItem.ToString();
                return CharacterFactory.getPlayerItemByName(selected);
            }
        }


        private void updateChoiceValue()
        {
            _equipment = _choice.getObjectReference();
            _equipment.Quantity = _choice.Quantity;
            List<PlayerItem> multipleChoiceItems = new List<PlayerItem>();
            String displayedText;

            if(_equipment.ItemName == "AnyMartialMelee")
            {
                List<PlayerWeapon> wList = CharacterFactory.getAllWeapons();

                foreach(PlayerWeapon w in wList)
                {
                    if ((w.Type == PlayerWeapon.WeaponType.Martial) && (w.IsRanged == false))
                    {
                        multipleChoiceItems.Add(w);
                    }
                }
                displayedText = "Any Martial Melee Weapon";
                isMultipleChoice = true;
            }
            else if(_equipment.ItemName == "AnyMartial")
            {
                List<PlayerWeapon> wList = CharacterFactory.getAllWeapons();

                foreach (PlayerWeapon w in wList)
                {
                    if (w.Type == PlayerWeapon.WeaponType.Martial)
                    {
                        multipleChoiceItems.Add(w);
                    }
                }
                displayedText = "Any Martial Weapon";
                isMultipleChoice = true;
            }
            else if(_equipment.ItemName == "AnySimple")
            {
                List<PlayerWeapon> wList = CharacterFactory.getAllWeapons();

                foreach (PlayerWeapon w in wList)
                {
                    if ((w.Type == PlayerWeapon.WeaponType.Simple) && (w.IsRanged == false))
                    {
                        multipleChoiceItems.Add(w);
                    }
                }
                displayedText = "Any Simple Weapon";
                isMultipleChoice = true;
            }
            else if (_equipment.ItemName == "AnyArtisans")
            {
                List<PlayerToolKit> tools = CharacterFactory.getAllToolSets();

                foreach (PlayerToolKit tool in tools)
                {
                    if (tool.ToolType == PlayerToolKit.PlayerToolType.TYPE_ARTISAN)
                    {
                        multipleChoiceItems.Add(tool);
                    }
                }

                displayedText = "Any Artisan's Tool";
                isMultipleChoice = true;
            }
            else if(_equipment.ItemName == "AnyMusical")
            {
                List<PlayerToolKit> tools = CharacterFactory.getAllToolSets();

                foreach (PlayerToolKit tool in tools)
                {
                    if (tool.ToolType == PlayerToolKit.PlayerToolType.TYPE_MUSICAL)
                    {
                        multipleChoiceItems.Add(tool);
                    }
                }

                displayedText = "Any musical instrument";
                isMultipleChoice = true;
            }
            else if(_equipment.ItemName == "AnyGaming")
            {
                List<PlayerToolKit> tools = CharacterFactory.getAllToolSets();

                foreach (PlayerToolKit tool in tools)
                {
                    if (tool.ToolType == PlayerToolKit.PlayerToolType.TYPE_GAMING)
                    {
                        multipleChoiceItems.Add(tool);
                    }
                }

                displayedText = "Any gaming set";
                isMultipleChoice = true;
            }
            else
            {
                isMultipleChoice = false;
                displayedText = _choice.Equipment;
                if(_choice.Quantity > 1)
                {
                    displayedText += "(" + _choice.Quantity.ToString() + ")";
                }
            }

            label1.Text = displayedText;

            if (isMultipleChoice == true)
            {
                comboBox1.Items.Clear();
                foreach(PlayerItem item in multipleChoiceItems)
                {
                    comboBox1.Items.Add(item.ItemName);
                }
                comboBox1.Visible = true;
            }
        }
    }
}
