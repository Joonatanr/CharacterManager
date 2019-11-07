using CharacterManager.SpecialAttributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CharacterManager
{
    public class CharacterFactory
    {
        private TextBoxWriter errorReporter;
        private List<PlayerRace> Races;
        private List<PlayerClass> Classes;
        private List<PlayerAttribute> AttributesList;
        private List<CharacterManager.SpecialAttributes.SpecialAttribute> SpecialAttributeList = new List<CharacterManager.SpecialAttributes.SpecialAttribute>();
        private Boolean isInitialized = false;

        private List<Items.PlayerArmor> ArmorList;
        private List<Items.PlayerWeapon> WeaponList;
        private List<Items.PlayerItem> GenericItemList;

        public List<String> getMainRacesList()
        {
            List<String> res = new List<string>();
            foreach(PlayerRace race in Races)
            {
                res.Add(race.RaceName);
            }

            return res;
        }

        public List<String> getSubRaceList(String mainRaceName)
        {
            List<String> res = new List<string>();

            PlayerRace race = Races.Find(r => r.RaceName == mainRaceName);
            if(race != null)
            {
                foreach(PlayerRace sub in race.SubRaces)
                {
                    res.Add(sub.RaceName);
                }
            }

            return res;
        }

        public List<String> getClassList()
        {
            List<String> res = new List<String>();
            foreach(PlayerClass c in Classes)
            {
                res.Add(c.PlayerClassName);
            }

            return res;
        }

        /* Initializes the factory and loads all the necessary resources. */
        public CharacterFactory()
        {
            //Base constructor. Add extra things here.
            Races = new List<PlayerRace>();
        }

        public CharacterFactory(TextBoxWriter errHandler) : this()
        {
            this.errorReporter = errHandler;
        }

        public Boolean Initialize()
        {
            if (!this.isInitialized)
            {
                InitializeSpecialAttributes();

                parseRacesFromXml("Resources/PlayerRaces");
                parseClassesFromXml("Resources/PlayerClasses");
                parseAttributesFromXml("Resources/PlayerAttributes.xml");
                parseItemsFromXml("Resources/PlayerItems/PlayerItems.xml");
                parseArmorFromXml("Resources/PlayerItems/PlayerArmor.xml");
                parseWeaponsFromXml("Resources/PlayerItems/PlayerWeapon.xml");

                foreach (PlayerRace race in Races)
                {
                    try
                    {
                        race.Initialize(this.AttributesList);
                    }
                    catch (Exception ex)
                    {
                        logError("Failed to initialize race " + race.RaceName + " : " + ex.Message);
                    }
                }

                this.isInitialized = true;
            }
            return this.isInitialized;
        }



        public PlayerRace getRaceByName(String name)
        {
            return Races.Find(r => r.RaceName == name);
        }

        public PlayerRace getSubRaceByName(String main, String sub)
        {
            PlayerRace _mainRace = Races.Find(r => r.RaceName == main);

            if(_mainRace == null)
            {
                return null;
            }
            else
            {
                return _mainRace.SubRaces.Find(s => s.RaceName == sub);
            }
        }

        public PlayerClass getPlayerClassByName(String name)
        {
            PlayerClass res = Classes.Find(c => c.PlayerClassName == name);

            return res;
        }

        public PlayerCharacter LoadFromXml(String filename)
        {
            if (!this.isInitialized)
            {
                logError("Error : CharacterFactory not initialized");
                return null;
            }

            PlayerCharacter res = null;

            try
            {
                XmlSerializer reader = new XmlSerializer(typeof(PlayerCharacter));
                StreamReader file = new System.IO.StreamReader(filename);

                res = (PlayerCharacter)reader.Deserialize(file);
                file.Close();
           }
           catch (Exception ex)
           {
                logError("Failed to open file : " + ex.Message);
           }
           
            if(res != null)
            {
                if(resolveCharacterData(res) == false)
                {
                    logError("Failed to resolve character data correctly");
                }
            }
           
           return res;
        }

        public static int getAbilityModifierValue(int score)
        {
            /* TODO : Move this modifier elsewhere. */
            Decimal modifier = Math.Floor(((Decimal)score - 10) / 2);
            return (int)modifier;
        }

        public static String getAbilityWithModifierString(Decimal score)
        {
            /* TODO : Move this modifier elsewhere. */
            Decimal modifier = Math.Floor(((Decimal)score - 10) / 2);

            String txt = score + " " + "(";
            if (modifier >= 0)
            {
                txt += "+";
            }

            txt += modifier + ")";
            return txt;
        }

        private Boolean resolveCharacterData(PlayerCharacter raw)
        {
            PlayerRace mainRace;
            PlayerRace SubRace;

            //Lets check the race first.
            try
            {
                mainRace = Races.First(r => r.RaceName == raw.MainRaceName);
            }
            catch (Exception)
            {
                logError("Unknown race : " + raw.MainRaceName);
                return false;
            }

            if (raw.SubRaceName != null)
            {
                try
                {
                    SubRace = mainRace.SubRaces.First(r => r.RaceName == raw.SubRaceName);
                }
                catch (Exception)
                {
                    logError("Unknown subrace : " + raw.SubRaceName);
                    return false;
                }
            }
            else
            {
                SubRace = null;
            }

            raw.setMainAndSubrace(mainRace, SubRace);

            //Lets resolve the character attribute list.
            List<PlayerAttribute> resultList = new List<PlayerAttribute>();
            foreach (String attribName in raw.CharacterAttributes)
            {
                PlayerAttribute member = AttributesList.Find(attrib => attrib.AttributeName == attribName);
                if (member != null)
                {
                    resultList.Add(member);
                }
                else
                {
                    return false;
                }
            }
            raw.setCharacterAttributesList(resultList);

            return true;
        }

        private void parseRacesFromXml(String filefolder)
        {
            //Lets create a list of existing files.
            string[] filepaths = Directory.GetFiles(filefolder);
            Races = new List<PlayerRace>();

            foreach (string filepath in filepaths)
            {
                try
                {
                    XmlSerializer reader = new XmlSerializer(typeof(PlayerRace));
                    StreamReader file = new System.IO.StreamReader(filepath);

                    Races.Add((PlayerRace)reader.Deserialize(file));
                    file.Close();
                }
                catch (Exception ex)
                {
                    logError("Failed to open file : " + ex.Message);
                }
            }
        }

        private void parseClassesFromXml(String filefolder)
        {
            string[] filepaths = Directory.GetFiles(filefolder);

            Classes = new List<PlayerClass>();
            foreach (string filepath in filepaths)
            {
                try
                {
                    XmlSerializer reader = new XmlSerializer(typeof(PlayerClass));
                    StreamReader file = new System.IO.StreamReader(filepath);

                    Classes.Add((PlayerClass)reader.Deserialize(file));
                    file.Close();
                }
                catch (Exception ex)
                {
                    logError("Failed to open file : " + ex.Message);
                }
            }
        }

        private void parseAttributesFromXml(String filepath)
        {
            try
            {
                XmlSerializer reader = new XmlSerializer(typeof(List<PlayerAttribute>));
                StreamReader file = new System.IO.StreamReader(filepath);

                AttributesList = (List<PlayerAttribute>)reader.Deserialize(file);
                file.Close();
            }
            catch (Exception ex)
            {
                logError("Failed to open file : " + ex.Message);
            }


            //Lets resolve the special attributes.
            for (int i = 0; i < AttributesList.Count; i++)
            {
                PlayerAttribute attrib = AttributesList[i];
                SpecialAttribute specialAttribute = SpecialAttributeList.Find(spec => spec.AttributeName == attrib.AttributeName);
                if (specialAttribute != null)
                {
                    //We found a matching special attribute.
                    specialAttribute.CopyValuesFromBaseClass(attrib);
                    AttributesList[i]= specialAttribute; //We basically replace the original prototype with a SpecialAttribute object.
                }
            }
        }

        private void parseItemsFromXml(string filepath)
        {
            try
            {
                XmlSerializer reader = new XmlSerializer(typeof(List<Items.PlayerItem>));
                StreamReader file = new System.IO.StreamReader(filepath);

                GenericItemList = (List<Items.PlayerItem>)reader.Deserialize(file);
                file.Close();
            }
            catch (Exception ex)
            {
                logError("Failed to open file : " + ex.Message);
            }
        }

        private void parseArmorFromXml(String filepath)
        {
            try
            {
                XmlSerializer reader = new XmlSerializer(typeof(List<Items.PlayerArmor>));
                StreamReader file = new System.IO.StreamReader(filepath);

                ArmorList = (List<Items.PlayerArmor>)reader.Deserialize(file);
                file.Close();
            }
            catch (Exception ex)
            {
                logError("Failed to open file : " + ex.Message);
            }

            /*
            logMessage("Parsed Armor\n");
            foreach(Items.PlayerArmor armor in ArmorList)
            { 
                logMessage(armor.ToString() + Environment.NewLine);
            }
            */
        }

        private void parseWeaponsFromXml(String filepath)
        {
            try
            {
                XmlSerializer reader = new XmlSerializer(typeof(List<Items.PlayerWeapon>));
                StreamReader file = new System.IO.StreamReader(filepath);

                WeaponList = (List<Items.PlayerWeapon>)reader.Deserialize(file);
                file.Close();
            }
            catch (Exception ex)
            {
                logError("Failed to open file : " + ex.Message);
            }

            
            logMessage("Parsed Weapons\n");
            foreach(Items.PlayerWeapon weapon in WeaponList)
            {
                //logMessage(armor.ToString() + Environment.NewLine);
                logMessage(weapon.ItemName + " : ");
                logMessage(weapon.Damage.DamageValue + " :->");
                //logMessage(weapon.rollDamage().ToString());
                String log;
                int value = weapon.rollDamage(out log);
                logMessage("Rolled : " + log + " -> " + value.ToString() + "\n");
            }
            
        }


        private void InitializeSpecialAttributes()
        {
            //All C# described attributes need to be added here.
            SpecialAttributeList.Add(new DwarvenToughness());
        }

        private void logError(String err)
        {
            if (errorReporter != null)
            {
                errorReporter.WriteColoredLine(err, ConsoleColor.DarkRed);
            }
        }

        private void logMessage(String message)
        {
            if (errorReporter != null)
            {
                errorReporter.WriteColoredLine("Log : " + message, ConsoleColor.Black);
            }
        }
    }
}
