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
        protected int _value;


        public int ConstantValue
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        public DieRollConstant(int value)
        {
            this._value = value;
        }

        public override int getValue(out String log)
        {
            log = this._value.ToString() + " ";
            return this._value;
        }

        public override string ToString()
        {
            return this._value.ToString();
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
    public class DieRollEquation
    {
        public String DieRollString
        {
            get
            {
                return this.ToString();
            }
            set
            {
                myComponents = parseText(value);
            }
        }

        //Contains the necessary components to calculate the value.
        [XmlIgnore]
        private List<DieRollComponent> myComponents = new List<DieRollComponent>();


        public List<DieRollComponent> DieRollComponents
        {
            get
            {
                return myComponents;
            }

            set
            {
                myComponents = value;
            }
        }

        public DieRollEquation()
        {
            myComponents = new List<DieRollComponent>();
        }

        public DieRollEquation(String val)
        {
            this.DieRollString = val;
        }

        public DieRollEquation(List<DieRollComponent> componentList)
        {
            myComponents = componentList;
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
            string logRes;

            foreach (DieRollComponent c in myComponents)
            {
                res += c.getValue(out logRes);
                log += logRes + " + ";
            }

            log = log.Remove(log.Length - 2);
            log += " = " + res.ToString();

            /* We have to take care of negative variables. Otherwise we will get results like 1d20 + -10 */
            log = log.Replace("+ -", " - ");


            return res;
        }


        /* Reduces all constant dieroll components to one value. */
        public void ReduceConstants()
        {
            List<DieRollComponent> reducedList = new List<DieRollComponent>();
            int totalConstantValue = 0;
            int constantCount = 0;
            
            foreach(DieRollComponent component in myComponents)
            {
                if(component is DieRollConstant)
                {
                    totalConstantValue += (component as DieRollConstant).ConstantValue;
                    constantCount++;
                }
                else 
                {
                    reducedList.Add(component);
                }    
            }

            if (constantCount > 0)
            {
                DieRollConstant totalConstant = new DieRollConstant(totalConstantValue);
                reducedList.Add(totalConstant);
            }
            this.DieRollComponents = reducedList;
        }

        private List<DieRollComponent> parseText(String text)
        {
            return parseComponentListFromString(text);
        }

        /* Lets make sure that all parsing of strings is done here. We return a list of DieRollComponent type objects */
        public static List<DieRollComponent> parseComponentListFromString(string str)
        {
            List<DieRollComponent> res = new List<DieRollComponent>();
            if (!string.IsNullOrEmpty(str))
            {
                //Lets do this simply. Pattern is something like 2d10 + 4
                str = str.Replace(" ", string.Empty);

                if (str[0] == '+' || str[0] == '-')
                {
                    str = str.Insert(0, "0");
                }

                /* Lets try a simple hack here...*/
                for (int x = 0; x < str.Length; x++)
                {
                    if (str[x] == '-')
                    {
                        str = str.Insert(x, "+");
                        x++;
                    }
                }

                string[] components = str.Split('+');


                foreach (String component in components)
                {
                    res.Add(DieRoll.parseFromString(component));
                }
            }

            return res;
        }

        /* Here we create a string representation. If separate is set to true, then each component is written out separately. */
        public static string createStringFromDieRollComponents(List<DieRollComponent> input, bool separate)
        {
            string modifierString = "";
            string dummy;
            int totalConstantValue = 0;


            if (input != null)
            {
                if (input.Count > 0)
                {
                    bool isFirst = true;
                    foreach (DieRollComponent component in input)
                    {
                        if (isFirst)
                        {
                            modifierString += component.ToString() + " ";
                        }
                        else
                        {
                            if (component is DieRollConstant)
                            {
                                if (separate == true)
                                {
                                    if (component.getValue(out dummy) >= 0)
                                    {
                                        modifierString += "+ ";
                                    }
                                    modifierString += component.ToString() + " ";
                                }
                                else
                                {
                                    totalConstantValue += component.getValue(out dummy);
                                }
                            }
                            else if (component is DieRoll)
                            {
                                modifierString += "+ ";
                                modifierString += component.ToString() + " ";
                            }
                        }

                        isFirst = false;
                    }

                    if (separate == false)
                    {
                        /* We add all the constants with one separate modifier. */
                        if (totalConstantValue >= 0)
                        {
                            modifierString += "+ ";
                        }
                        modifierString += totalConstantValue.ToString();
                    }
                }
            }

            return modifierString;
        }

        /* Here we create a string representation of the DieRollEquation object itself. */
        public override string ToString()
        {
            return createStringFromDieRollComponents(this.myComponents, true);
        }
    }
}
