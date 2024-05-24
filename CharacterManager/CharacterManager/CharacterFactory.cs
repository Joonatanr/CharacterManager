using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using CharacterManager.Items;
using CharacterManager.SpecialAttributes;
using CharacterManager.Spells;
using static CharacterManager.PlayerCharacter;

namespace CharacterManager
{
    public static class CharacterFactory
    {
        private static TextBoxWriter errorReporter;
        private static List<PlayerRace> Races;
        private static List<PlayerClass> Classes;
        private static List<PlayerAbility> AttributesList;
        private static List<PlayerAbility> FeatsList = new List<PlayerAbility>();
        private static List<CharacterManager.SpecialAttributes.SpecialAttribute> SpecialAttributeList = new List<CharacterManager.SpecialAttributes.SpecialAttribute>();
        private static List<Spells.PlayerSpell> SpellList = new List<Spells.PlayerSpell>();
        
        private static List<CharacterBackGround> CharacterBackGroundList;

        private static Boolean isInitialized = false;

        private static List<Items.PlayerArmor> ArmorList;
        private static List<Items.PlayerWeapon> WeaponList;
        private static List<Items.PlayerItem> GenericItemList;
        private static List<Items.PlayerToolKit> ToolKitItemList;
        private static List<Items.PlayerItem> MagicItemList;
        private static List<Language> LanguageList;
        private static List<CombatManeuver> CombatManeuverList;

        public static List<String> getMainRacesList()
        {
            List<String> res = new List<string>();
            foreach(PlayerRace race in Races)
            {
                res.Add(race.RaceName);
            }

            return res;
        }

        public static PlayerSpell getPlayerSpellFromString(string str)
        {
            PlayerSpell res = SpellList.Find(s => s.SpellName.ToLower() == str.ToLower());
            return res;
        }

        public static List<PlayerSpell> getSpellsOfLevelAndLower(int level)
        {
            return SpellList.FindAll(sp => sp.SpellLevel <= level);
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
                parseAttributesFromXml("Resources/PlayerAttributes.xml", "Resources/Feats.xml");
                parseBackGroundsFromXml("Resources/PlayerBackgrounds.xml");
                parseItemsFromXml("Resources/PlayerItems/PlayerItems.xml");
                parseArmorFromXml("Resources/PlayerItems/PlayerArmor.xml");
                parseWeaponsFromXml("Resources/PlayerItems/PlayerWeapon.xml");
                parseToolkitsFromXml("Resources/PlayerItems/PlayerTools.xml");
                parseMagicItemsFromXml("Resources/PlayerItems/MagicItems.xml");
                parseLanguagesFromXml("Resources/Languages.xml");
                parseCombatManeuversFromXml("Resources/CombatManeuvers.xml");
                parseSpellsFromXml("Resources/PlayerSpells.xml");

                foreach (PlayerRace race in Races)
                {
                    try
                    {
                        race.Initialize(AttributesList, SpellList);
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
            PlayerRace mainRace = Races.Find(r => r.RaceName == main);

            if(mainRace == null)
            {
                return null;
            }
            else
            {
                return mainRace.SubRaces.Find(s => s.RaceName == sub);
            }
        }

        public static PlayerClass getPlayerClassByName(String name)
        {
            PlayerClass res = Classes.Find(c => c.PlayerClassName == name);

            return res;
        }

        public static PlayerClassArchetype getPlayerSubClassByName(string className, string subclassName)
        {
            PlayerClass mainClass = getPlayerClassByName(className);
            List<PlayerClassArchetype> archeTypes = mainClass.ArcheTypes;

            return archeTypes.Find(at => at.ArcheTypeName == subclassName);
        }

        public static Items.PlayerItem getPlayerItemByName(String name)
        {
            Items.PlayerItem res = null;

            if (!isInitialized)
            {
                throw new Exception("Error : Character Factory not initialized.");
            }

            res = WeaponList.Find(w => w.Name == name);

            if (res == null)
            {
                res = ArmorList.Find(a => a.Name == name);
            }

            if (res == null)
            {
                res = GenericItemList.Find(i => i.Name == name);
            }

            if (res == null)
            {
                res = ToolKitItemList.Find(t => t.Name == name);
            }

            if (res == null)
            {
                res = MagicItemList.Find(t => t.Name == name);
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
           
            if (res != null)
            {
                if (resolveCharacterData(res) == false)
                {
                    logError("Failed to resolve character data correctly");
                }
            }
           
           return res;
        }

        public static int getAbilityModifierValue(int score)
        {
            Decimal modifier = Math.Floor(((Decimal)score - 10) / 2);
            return (int)modifier;
        }

        public static String getAbilityWithModifierString(int score)
        {
            Decimal modifier = getAbilityModifierValue(score);

            String txt = score + " " + "(";
            if (modifier >= 0)
            {
                txt += "+";
            }

            txt += modifier + ")";
            return txt;
        }

        public static PlayerAbility getPlayerAbilityFromString(string s)
        {
            PlayerAbility res = AttributesList.Find(a => a.Name == s);
            return res;
        }

        public static List<PlayerAbility> getAllAvailableFeats()
        {
            return FeatsList;
        }

        public static List<Language> getAllLanguages()
        {
            return LanguageList;
        }

        public static List<CombatManeuver> getAllCombatManeuvers()
        {
            return CombatManeuverList;
        }


        public static List<CharacterBackGround> getAllBackGrounds()
        {
            return CharacterBackGroundList;
        }

        public static List<PlayerWeapon> getAllWeapons()
        {
            return WeaponList;
        }

        public static List<PlayerArmor> getAllArmor()
        {
            return ArmorList;
        }

        public static List<PlayerItem> getAllGenericItems()
        {
            return GenericItemList;
        }

        public static List<PlayerToolKit> getAllToolSets()
        {
            return ToolKitItemList;
        }

        public static List<PlayerItem> getAllMagicItems()
        {
            return MagicItemList;
        }


        public static SpellcastingAbility GetSpellCastingAbilityOfClass(string mainClassName, string subClassName)
        {
            PlayerClass mainClass = CharacterFactory.getPlayerClassByName(mainClassName);
            PlayerClassArchetype subClass = CharacterFactory.getPlayerSubClassByName(mainClassName, subClassName);
            return GetSpellCastingAbilityOfClass(mainClass, subClass);
        }
        
        /// <summary>
        /// Returns the spellcasting ablity of a class and subclass. Since these are static, then they are returned by the
        /// characterfactory.
        /// </summary>
        /// <param name="className"></param>
        /// <param name="subClassName"></param>
        /// <returns></returns>
        public static SpellcastingAbility GetSpellCastingAbilityOfClass(PlayerClass mainClass, PlayerClassArchetype subClass)
        {
            if (mainClass == null)
            {
                return null;
            }

            if (mainClass.SpellCasting != null)
            {
                return mainClass.SpellCasting;
            }
            else if (subClass != null)
            {
                return subClass.SpellCasting;
            }
            else
            {
                return null;
            }
        }

        //Basically we try to resolve the item from string.
        /* The idea for this function is that a string might contain some special 
         magic words that indicate a choice between multiple items. */
        public static Items.PlayerItem resolveItemChoiceFromString(string str)
        {
            Items.PlayerItem res = null;

            if (str == "AnyMartialMelee")
            {
                res = new Items.PlayerWeapon();
                res.Name = "AnyMartialMelee"; //Special case.
                res.IsMultipleChoice = true;
                return res;
            }

            if (str == "AnyMartial")
            {
                res = new Items.PlayerWeapon();
                res.Name = "AnyMartial"; //Special case.
                res.IsMultipleChoice = true;
                return res;
            }

            if (str == "AnySimple")
            {
                res = new Items.PlayerWeapon();
                res.Name = "AnySimple"; //Special case.
                res.IsMultipleChoice = true;
                return res;
            }

            if (str == "AnyArtisans")
            {
                res = new Items.PlayerItem();
                res.Name = "AnyArtisans";
                res.IsMultipleChoice = true;
                return res;
            }
            if (str == "AnyMusical")
            {
                res = new Items.PlayerItem();
                res.Name = "AnyMusical";
                res.IsMultipleChoice = true;
                return res;
            }
            if (str == "AnyGaming")
            {
                res = new Items.PlayerItem();
                res.Name = "AnyGaming";
                res.IsMultipleChoice = true;
                return res;
            }

            res = CharacterFactory.getPlayerItemByName(str);

            return res;
        }

        private static Boolean resolveCharacterData(PlayerCharacter raw)
        {
            PlayerRace mainRace;
            PlayerRace subRace;

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
                    subRace = mainRace.SubRaces.First(r => r.RaceName == raw.SubRaceName);
                }
                catch (Exception)
                {
                    logError("Unknown subrace : " + raw.SubRaceName);
                    return false;
                }
            }
            else
            {
                subRace = null;
            }

            raw.setMainAndSubrace(mainRace, subRace);

            PlayerClass pClass = raw.GetPlayerClass();
            PlayerClassArchetype pSubclass = raw.GetPlayerSubClass();

            //Lets resolve the character attribute list.
            List<PlayerAbility> resultList = new List<PlayerAbility>();
            foreach (PlayerAbilityDescriptor attribDesc in raw.CharacterAbilities)
            {
                PlayerAbility member = null;
                
                if (attribDesc.AbilityName.ToLower() == "spellcasting")
                {
                    /* We search for this from the class description instead. */ 
                    member = CharacterFactory.GetSpellCastingAbilityOfClass(pClass, pSubclass);
                }
                else
                {
                    member = AttributesList.Find(attrib => attrib.Name == attribDesc.AbilityName);

                    if (member == null)
                    {
                        /* We might be dealing with an archetype... */
                        PlayerClassArchetype aType = pClass.ArcheTypes.Find(at => at.ArcheTypeName == attribDesc.AbilityName);
                        member = aType;
                    }

                    if (member != null)
                    {
                        member.ResolveFromDescriptor(attribDesc);
                    }
                }
                
                if(member == null)
                {
                    logError("Failed to resolve ability : " + attribDesc.AbilityName);
                }
                else
                {
                    resultList.Add(member);
                }
            }
            raw.setCharacterAbilitiesList(resultList, false);

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

            if (Races == null || Races.Count == 0)
            {
                throw new Exception("Failed to parse races");
            }
        }

        private static void parseClassesFromXml(String filefolder)
        {
            string[] filepaths = Directory.GetFiles(filefolder);

            Classes = new List<PlayerClass>();
            PlayerClass curr;
            foreach (string filepath in filepaths)
            {
                try
                {
                    XmlSerializer reader = new XmlSerializer(typeof(PlayerClass));
                    StreamReader file = new System.IO.StreamReader(filepath);

                    curr = ((PlayerClass)reader.Deserialize(file));
                    Classes.Add(curr);

                    file.Close();
                }
                catch (Exception ex)
                {
                    logError("Failed to open file : " + ex.Message);
                }
            }

            if (Classes == null || Classes.Count == 0)
            {
                throw new Exception("Failed to parse player classes from XML");
            }
        }

        private static void parseAttributesFromXml(String mainFilepath, string featsFilePath)
        {
            try
            {
                Type[] ExtraTypes = { typeof(PlayerManeuverAbility) };
                XmlSerializer reader = new XmlSerializer(typeof(List<PlayerAbility>), ExtraTypes);
                StreamReader file = new System.IO.StreamReader(mainFilepath);

                AttributesList = (List<PlayerAbility>)reader.Deserialize(file);
                file.Close();
            }
            catch (Exception ex)
            {
                logError("Failed to open file : " + mainFilepath + " " + ex.Message);
                return;
            }

            /* Feats are stored in a separate XML file*/
            try
            {
                Type[] ExtraTypes = { typeof(PlayerManeuverAbility) };
                XmlSerializer reader = new XmlSerializer(typeof(List<PlayerAbility>), ExtraTypes);
                StreamReader file = new System.IO.StreamReader(featsFilePath);

                FeatsList = (List<PlayerAbility>)reader.Deserialize(file);
            }
            catch (Exception ex)
            {
                logError("Failed to parse feats from file : " + featsFilePath + " " + ex.Message);
                //We still continue though... 
            }

            AttributesList.AddRange(FeatsList);

            //Lets resolve the special attributes.
            for (int i = 0; i < AttributesList.Count; i++)
            {
                PlayerAbility attrib = AttributesList[i];
                SpecialAttribute specialAttribute = SpecialAttributeList.Find(spec => spec.Name == attrib.Name);
                if (specialAttribute != null)
                {
                    //We found a matching special attribute.
                    specialAttribute.CopyValuesFromBaseClass(attrib);
                    AttributesList[i]= specialAttribute; //We basically replace the original prototype with a SpecialAttribute object.
                }
            }

            if (AttributesList == null || AttributesList.Count == 0)
            {
                throw new Exception("Failed to parse Player Attributes list");
            }
        }

        private static void parseItemsFromXml(string filepath)
        {
            try
            {
                XmlSerializer reader = new XmlSerializer(typeof(List<Items.PlayerItem>), new Type[] { typeof(ItemContainer) });
                StreamReader file = new System.IO.StreamReader(filepath);

                GenericItemList = (List<Items.PlayerItem>)reader.Deserialize(file);

                file.Close();
            }
            catch (Exception ex)
            {
                logError("Failed to open file : " + ex.Message);
            }

            if (GenericItemList == null || GenericItemList.Count == 0)
            {
                throw new Exception("Failed to parse item list from xml");
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

            if (ArmorList == null || ArmorList.Count == 0)
            {
                throw new Exception("Failed to parse armor list from xml");
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

            if (WeaponList == null || WeaponList.Count == 0)
            {
                throw new Exception("Failed to parse weapon list from XML");
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

        private static void parseMagicItemsFromXml(String filepath)
        {
            try
            {
                XmlSerializer reader = new XmlSerializer(typeof(List<Items.PlayerItem>));
                StreamReader file = new System.IO.StreamReader(filepath);

                MagicItemList = (List<Items.PlayerItem>)reader.Deserialize(file);
                file.Close();
            }
            catch (Exception ex)
            {
                logError("Failed to open file : " + ex.Message);
            }
        }

        private static void parseLanguagesFromXml(String filepath)
        {
            try
            {
                XmlSerializer reader = new XmlSerializer(typeof(List<Language>));
                StreamReader file = new System.IO.StreamReader(filepath);

                LanguageList = (List<Language>)reader.Deserialize(file);
                file.Close();
            }
            catch (Exception ex)
            {
                logError("Failed to open file : " + ex.Message);
            }
        }

        private static void parseCombatManeuversFromXml(string filepath)
        {
            try
            {
                XmlSerializer reader = new XmlSerializer(typeof(List<CombatManeuver>));
                StreamReader file = new System.IO.StreamReader(filepath);

                CombatManeuverList = (List<CombatManeuver>)reader.Deserialize(file);
                file.Close();
            }
            catch (Exception ex)
            {
                logError("Failed to open file : " + ex.Message);
            }
        }

        private static void parseSpellsFromXml(String filepath)
        {
            try
            {
                XmlSerializer reader = new XmlSerializer(typeof(List<PlayerSpell>));
                StreamReader file = new System.IO.StreamReader(filepath);

                SpellList = (List<PlayerSpell>)reader.Deserialize(file);
                file.Close();
            }
            catch (Exception ex)
            {
                logError("Failed to open file : " + ex.Message);
            }
        }

        private static void parseBackGroundsFromXml(String filepath)
        {
            try
            {
                XmlSerializer reader = new XmlSerializer(typeof(List<CharacterBackGround>));
                StreamReader file = new System.IO.StreamReader(filepath);

                CharacterBackGroundList = (List<CharacterBackGround>)reader.Deserialize(file);
                file.Close();
            }
            catch (Exception ex)
            {
                logError("Failed to open file : " + ex.Message);
            }

            if (CharacterBackGroundList == null || CharacterBackGroundList.Count == 0)
            {
                throw new Exception("Failed to parse character background list");
            }
        }

        private static void InitializeSpecialAttributes()
        {
            //All C# described attributes need to be added here.
            SpecialAttributeList.Add(new DwarvenToughness());


            //Lets add all the special attributes from class abilities here. Not sure if we need a separate structure though..
            SpecialAttributeList.Add(new FightingStyleArchery());
            SpecialAttributeList.Add(new FightingStyleDefense());
            SpecialAttributeList.Add(new FightingStyleDueling());
            SpecialAttributeList.Add(new FightingStyleGreatWeapon());
            SpecialAttributeList.Add(new FightingStyleProtection());
            SpecialAttributeList.Add(new FightingStyleTwoWeapon());
            SpecialAttributeList.Add(new SecondWindAbility());
            SpecialAttributeList.Add(new StudentOfWarAbility());
            SpecialAttributeList.Add(new ImprovedCriticalAbility());
            SpecialAttributeList.Add(new RemarkableAthleteAbility());
            SpecialAttributeList.Add(new SurvivorAbility());

            SpecialAttributeList.Add(new RageAbility());
            SpecialAttributeList.Add(new UnarmoredDefenseAbility());
            SpecialAttributeList.Add(new FastMovementAbility());
            SpecialAttributeList.Add(new BrutalCriticalAbility());

            SpecialAttributeList.Add(new ArcaneWardAbility());
            SpecialAttributeList.Add(new ImprovedAbjurationAbility());
            SpecialAttributeList.Add(new BenignTranspositionAbility());
            SpecialAttributeList.Add(new PortentAbility());

            SpecialAttributeList.Add(new JackOfAllTradesAbility());
            SpecialAttributeList.Add(new FontOfInspiration());

            SpecialAttributeList.Add(new RogueExpertise());
            SpecialAttributeList.Add(new SneakAttack());

            SpecialAttributeList.Add(new DivineSmite());
            SpecialAttributeList.Add(new ImprovedDivineSmite());
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
