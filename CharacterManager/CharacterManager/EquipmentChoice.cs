using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CharacterManager
{
    [Serializable]
    public class EquipmentChoice
    {
        [XmlIgnore]
        private Items.PlayerItem ChoiceItem;

        [XmlIgnore]
        private String _equipment;

        public string Equipment { get { return _equipment; }set { _equipment = value; } }
        public int Quantity = 1;

        public EquipmentChoice()
        {
            _equipment = "UNKNOWN";
        }

        public Items.PlayerItem getObjectReference()
        {
            return resolveItemFromString(_equipment);
        }

        //Basically we try to resolve the item from string.
        private Items.PlayerItem resolveItemFromString(string str)
        {
            //Formats:
            //Greataxe
            //AnyMartial
            //AnySimple

            Items.PlayerItem res = null;

            if (str == "AnyMartialMelee")
            {
                res = new Items.PlayerWeapon();
                res.ItemName = "AnyMartialMelee"; //Special case.
                return res;
            }

            if (str == "AnyMartial")
            {
                res = new Items.PlayerWeapon();
                res.ItemName = "AnyMartial"; //Special case.
                return res;
            }

            if (str == "AnySimple")
            {
                res = new Items.PlayerWeapon();
                res.ItemName = "AnySimple"; //Special case.
                return res;
            }

            res = CharacterFactory.getPlayerItemByName(str);

            return res;
        }
    }

    [Serializable]
    public class EquipmentChoiceList
    {
        public List<EquipmentChoice> OptionA = null;
        public List<EquipmentChoice> OptionB = null;
        public List<EquipmentChoice> OptionC = null;
        public List<EquipmentChoice> OptionD = null;

        public int getNumberOfOptions()
        {
            int numberOfChoices = 4;

            if (OptionA == null)
            {
                numberOfChoices--;
            }

            if (OptionB == null)
            {
                numberOfChoices--;
            }

            if (OptionC == null)
            {
                numberOfChoices--;
            }

            if (OptionD == null)
            {
                numberOfChoices--;
            }

            return numberOfChoices;
        }
    }
}
