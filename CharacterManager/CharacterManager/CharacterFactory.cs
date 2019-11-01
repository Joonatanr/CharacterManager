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
        private Boolean isInitialized = false;

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
                parseRacesFromXml("Resources/PlayerRaces.xml");
                parseClassesFromXml("Resources/PlayerClasses.xml");
                parseAttributesFromXml("Resources/PlayerAttributes.xml");

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

            try
            {
                SubRace = mainRace.SubRaces.First(r => r.RaceName == raw.SubRaceName);
            }
            catch(Exception)
            {
                logError("Unknown subrace : " + raw.SubRaceName);
                return false;
            }

            raw.setMainAndSubrace(mainRace, SubRace);

            return true;
        }

        private void parseRacesFromXml(String filepath)
        {
            //Lets just test if we can parse one initially... 
            try
            {
                XmlSerializer reader = new XmlSerializer(typeof(List<PlayerRace>));
                StreamReader file = new System.IO.StreamReader(filepath);

                Races = (List<PlayerRace>)reader.Deserialize(file);
                file.Close();

                //foreach (PlayerRace race in Races)
                //{
                    //logMessage("Parsed : " + race.RaceName + " STR : " + race.BonusAttributes.STR);
                //}
            }
            catch (Exception ex)
            {
                logError("Failed to open file : " + ex.Message);
            }
        }

        private void parseClassesFromXml(String filepath)
        {
            try
            {
                XmlSerializer reader = new XmlSerializer(typeof(List<PlayerClass>));
                StreamReader file = new System.IO.StreamReader(filepath);

                Classes = (List<PlayerClass>)reader.Deserialize(file);
                file.Close();
            }
            catch (Exception ex)
            {
                logError("Failed to open file : " + ex.Message);
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
