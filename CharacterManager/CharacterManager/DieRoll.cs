using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CharacterManager
{
    public abstract class DieRollComponent
    {
        public abstract int getValue(out String log);

        public static DieRollComponent parseFromString(string str)
        {
            /* Lets see if component contains a d. */
            if ((str[0] == 'd') || (str[0] == 'D'))
            {
                int type_of_die;
                if (!int.TryParse(str.TrimStart(new char[] { 'd', 'D' }), out type_of_die))
                {
                    throw new Exception("Failed to parse");
                }

                return(new DieRoll(1, type_of_die));
            }
            else if (str.Contains("d"))
            {
                String[] sub = str.Split('d');

                int number_of_dice;
                int type_of_die;

                if (sub.Length == 2)
                {
                    if (!int.TryParse(sub[0], out number_of_dice))
                    {
                        throw new Exception("Failed to parse");
                    }

                    if (!int.TryParse(sub[1], out type_of_die))
                    {
                        throw new Exception("Failed to parse");
                    }
                }
                else
                {
                    throw new Exception("Failed to parse");
                }

                return new DieRoll(number_of_dice, type_of_die);
            }
            else
            {
                int constval;

                if (!int.TryParse(str, out constval))
                {
                    throw new Exception("Failed to parse");
                }

                return new DieRollConstant(constval);
            }
        }
    }

    public class DieRollConstant : DieRollComponent
    {
        protected int value;

        public DieRollConstant(int value)
        {
            this.value = value;
        }

        public override int getValue(out String log)
        {
            log = this.value.ToString() + " ";
            return this.value;
        }

        public override string ToString()
        {
            return this.value.ToString();
        }
    }

    public class DieRoll : DieRollComponent
    {
        protected int numberOfDice;
        protected int DieType;

        private static Random rnd = new Random();

        public DieRoll(int number_of_dice, int die_value)
        {
            this.numberOfDice = number_of_dice;
            this.DieType = die_value;
        }

        public override int getValue(out String log)
        {
            int sum = 0;
            String logres = String.Empty;

            for (int x = 0; x < numberOfDice; x++)
            {
                int value = rnd.Next(1, DieType + 1);
                sum += value;
                logres += " (D" + this.DieType + ")" + value + " +";
            }

            /* Remove last plus sign.. */
            log = logres.TrimEnd('+');
            return sum;
        }

        public override string ToString()
        {
            return this.numberOfDice + "d" + this.DieType;
        }
    }

    [Serializable]
    public class DieRollValue
    {
        public String DieRollString
        {
            get
            {
                return _dieRollString;
            }
            set
            {
                _dieRollString = value;
                myComponents = parseText(_dieRollString);
            }
        }

        //Contains the necessary components to calculate the value.
        [XmlIgnore]
        private List<DieRollComponent> myComponents = new List<DieRollComponent>();
        [XmlIgnore]
        private String _dieRollString;

        public List<DieRollComponent> DieRollComponents
        {
            get
            {
                return myComponents;
            }
        }

        public DieRollValue()
        {
            this.DieRollString = "0";
        }

        public DieRollValue(String val)
        {
            this.DieRollString = val;
        }
        

        public int RollValue(out String log)
        {
            log = String.Empty;
            if (this.myComponents == null)
            {
                log = "ERROR";
                return 0;
            }

            if (this.myComponents.Count == 0)
            {
                log = "ERROR";
                return 0;
            }

            int res = 0;

            foreach (DieRollComponent c in myComponents)
            {
                res += c.getValue(out log);
            }

            return res;
        }

        private List<DieRollComponent> parseText(String text)
        {
            //Lets do this simply. Pattern is something like 2d10 + 4
            text = text.Replace(" ", string.Empty);

            if(text[0] == '+')
            {
                text = text.Insert(0, "0");
            }

            /* Lets try a simple hack here...*/
            for (int x = 0; x < text.Length; x++)
            {
                if (text[x] == '-')
                {
                    text = text.Insert(x, "+");
                    x++;
                }
            }

            string[] components = text.Split('+');
            List<DieRollComponent> res = new List<DieRollComponent>();

            foreach (String component in components)
            {
                res.Add(DieRoll.parseFromString(component));
            }

            return res;
        }
    }
}
