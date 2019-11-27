using CharacterManager.Items;
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
    public static class CharacterFactory
    {
        private static TextBoxWriter errorReporter;
        private static List<PlayerRace> Races;
        private static List<PlayerClass> Classes;
        private static List<PlayerAbility> AttributesList;
        private static List<CharacterManager.SpecialAttributes.SpecialAttribute> SpecialAttributeList = new List<CharacterManager.SpecialAttributes.SpecialAttribute>();
        private static Boolean isInitialized = false;

        private static List<Items.PlayerArmor> ArmorList;
        private static List<Items.PlayerWeapon> WeaponList;
        private static List<Items.PlayerItem> GenericItemList;
        private static List<Items.PlayerToolKit> ToolKitItemList;

        public static List<String> getMainRacesList()
        {
            List<String> res = new List<string>();
            foreach(PlayerRace race in Races)
            {
                res.Add(race.RaceName);
            }

            return res;
        }

        public static List<String> getSubRaceList(String mainRaceName)
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

        public static List<String> getClassList()
        {
            List<String> res = new List<String>();
            foreach(PlayerClass c in Classes)
            {
                res.Add(c.PlayerClassName);
            }

            return res;
        }

        public static void setErrorHandler(TextBoxWriter errHandler)
        {
            errorReporter = errHandler;
        }

        public static Boolean Initialize()
        {
            if (!isInitialized)
            {
                InitializeSpecialAttributes();

                parseRacesFromXml("Resources/PlayerRaces");
                parseClassesFromXml("Resources/PlayerClasses");
                parseAttributesFromXml("Resources/PlayerAttributes.xml");
                parseItemsFromXml("Resources/PlayerItems/PlayerItems.xml");
                parseArmorFromXml("Resources/PlayerItems/PlayerArmor.xml");
                parseWeaponsFromXml("Resources/PlayerItems/PlayerWeapon.xml");
                parseToolkitsFromXml("Resources/PlayerItems/PlayerTools.xml");

                foreach (PlayerRace race in Races)
                {
                    try
                    {
                        race.Initialize(AttributesList);
                    }
                    catch (Exception ex)
                    {
                        logError("Failed to initialize race " + race.RaceName + " : " + ex.Message);
                    }
                }

                //Add reference to the Equipment choices.
                //EquipmentChoice.InitializeEquipmentChoices(this);

                isInitialized = true;
            }
            return isInitialized;
        }



        public static PlayerRace getRaceByName(String name)
        {
            return Races.Find(r => r.RaceName == name);
        }

        public static PlayerRace getSubRaceByName(String main, String sub)
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

        public static PlayerClass getPlayerClassByName(String name)
        {
            PlayerClass res = Classes.Find(c => c.PlayerClassName == name);

            return res;
        }

        public static Items.PlayerItem getPlayerItemByName(String name)
        {
            Items.PlayerItem res = null;

            if (!isInitialized)
            {
                throw new Exception("Error : Character Factory not initialized.");
            }

            res = WeaponList.Find(w => w.ItemName == name);

            if (res == null)
            {
                res = ArmorList.Find(a => a.ItemName == name);
            }

            if (res == null)
            {
                res = GenericItemList.Find(i => i.ItemName == name);
            }

            if (res == null)
            {
                res = ToolKitItemList.Find(t => t.ItemName == name);
            }

            return res;
        }

        public static PlayerCharacter LoadFromXml(String filename)
        {
            if (!isInitialized)
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

        public static List<PlayerWeapon> getAllWeapons()
        {
            return WeaponList;
        }

        public static List<PlayerArmor> getAllArmor()
        {
            return ArmorList;
        }

        private static Boolean resolveCharacterData(PlayerCharacter raw)
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
            List<PlayerAbility> resultList = new List<PlayerAbility>();
            foreach (String attribName in raw.CharacterAbilities)
            {
                PlayerAbility member = AttributesList.Find(attrib => attrib.AttributeName == attribName);
                if (member != null)
                {
                    resultList.Add(member);
                }
                else
                {
                    return false;
                }
            }
            raw.setCharacterAbilitiesList(resultList);

            return true;
        }

        private static void parseRacesFromXml(String filefolder)
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

        private static void parseClassesFromXml(String filefolder)
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

            PlayerClass barbClass = Classes.Find(r => r.PlayerClassName == "Barbarian");
            logMessage("Barbarian has " + barbClass.AvailableEquipment.Count.ToString() + " equipment choices\n");

            foreach(EquipmentChoiceList baseList in barbClass.AvailableEquipment)
            {
                if(baseList.optionA.Count > 0)
                {
                    logMessage("Option A : ");
                    foreach(EquipmentChoice choice in baseList.optionA)
                    {
                        logMessage(choice.ToString() + ",");
                    }
                    logMessage("\n");
                }

                if (baseList.optionB.Count > 0)
                {
                    logMessage("Option B : ");
                    foreach (EquipmentChoice choice in baseList.optionB)
                    {
                        logMessage(choice.ToString() + ",");
                    }
                    logMessage("\n");
                }

                if (baseList.optionC.Count > 0)
                {
                    logMessage("Option C : ");
                    foreach (EquipmentChoice choice in baseList.optionC)
                    {
                        logMessage(choice.ToString() + ",");
                    }
                    logMessage("\n");
                }

                if (baseList.optionD.Count > 0)
                {
                    logMessage("Option D : ");
                    foreach (EquipmentChoice choice in baseList.optionD)
                    {
                        logMessage(choice.ToString() + ",");
                    }
                    logMessage("\n");
                }
            }
        }

        private static void parseAttributesFromXml(String filepath)
        {
            try
            {
                XmlSerializer reader = new XmlSerializer(typeof(List<PlayerAbility>));
                StreamReader file = new System.IO.StreamReader(filepath);

                AttributesList = (List<PlayerAbility>)reader.Deserialize(file);
                file.Close();
            }
            catch (Exception ex)
            {
                logError("Failed to open file : " + ex.Message);
            }


            //Lets resolve the special attributes.
            for (int i = 0; i < AttributesList.Count; i++)
            {
                PlayerAbility attrib = AttributesList[i];
                SpecialAttribute specialAttribute = SpecialAttributeList.Find(spec => spec.AttributeName == attrib.AttributeName);
                if (specialAttribute != null)
                {
                    //We found a matching special attribute.
                    specialAttribute.CopyValuesFromBaseClass(attrib);
                    AttributesList[i]= specialAttribute; //We basically replace the original prototype with a SpecialAttribute object.
                }
            }
        }

        private static void parseItemsFromXml(string filepath)
        {
            try
            {
                XmlSerializer reader = new XmlSerializer(typeof(List<Items.PlayerItem>), new Type[] { typeof(ItemContainer) });
                StreamReader file = new System.IO.StreamReader(filepath);

                GenericItemList = (List<Items.PlayerItem>)reader.Deserialize(file);

                foreach (Items.PlayerItem item in GenericItemList)
                {
                    logMessage("Parsed item ->" + item.ItemName + "\n");
                }

                file.Close();
            }
            catch (Exception ex)
            {
                logError("Failed to open file : " + ex.Message);
            }
        }

        private static void parseArmorFromXml(String filepath)
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
        }

        private static void parseWeaponsFromXml(String filepath)
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
        }

        private static void parseToolkitsFromXml(String filepath)
        {
            try
            {
                XmlSerializer reader = new XmlSerializer(typeof(List<Items.PlayerToolKit>));
                StreamReader file = new System.IO.StreamReader(filepath);

                ToolKitItemList = (List<Items.PlayerToolKit>)reader.Deserialize(file);
                file.Close();
            }
            catch (Exception ex)
            {
                logError("Failed to open file : " + ex.Message);
            }
        }


        private static void InitializeSpecialAttributes()
        {
            //All C# described attributes need to be added here.
            SpecialAttributeList.Add(new DwarvenToughness());
        }

        private static void logError(String err)
        {
            if (errorReporter != null)
            {
                errorReporter.WriteColoredLine(err, ConsoleColor.DarkRed);
            }
        }

        private static void logMessage(String message)
        {
            if (errorReporter != null)
            {
                errorReporter.WriteColoredLine("Log : " + message, ConsoleColor.Black);
            }
        }
    }
}
