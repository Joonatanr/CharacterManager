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
        public string Equipment;
        public int Quantity = 1;


        public EquipmentChoice()
        {
            Equipment = "UNKNOWN";
        }

        public Items.PlayerItem getObjectReference()
        {
            return CharacterFactory.resolveItemFromString(Equipment);
        }

        public override string ToString()
        {
            String res = "";

            res += this.Equipment;
            if(Quantity > 1)
            {
                res += "(";
                res += Quantity.ToString();
                res += ")";
            }

            return res;
        }
    }

    [Serializable]
    public class EquipmentChoiceList
    {
        public List<EquipmentChoice> optionA = null;
        public List<EquipmentChoice> optionB = null;
        public List<EquipmentChoice> optionC = null;
        public List<EquipmentChoice> optionD = null;

        public List<EquipmentChoice> getOptionFromNumber(int nr)
        {
            switch (nr)
            {
                case 0:
                    return optionA;
                case 1:
                    return optionB;
                case 2:
                    return optionC;
                case 3:
                    return optionD;
                default:
                    return null;
            }
        }

        public int getNumberOfOptions()
        {
            int numberOfChoices = 4;

            if (optionA == null)
            {
                numberOfChoices--;
            }

            if (optionB == null)
            {
                numberOfChoices--;
            }

            if (optionC == null)
            {
                numberOfChoices--;
            }

            if (optionD == null)
            {
                numberOfChoices--;
            }

            return numberOfChoices;
        }
    }
}
