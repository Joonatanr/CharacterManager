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
    class CharacterFactory
    {
        private TextBoxWriter errorReporter;
        private List<PlayerRace> Races;
        private Boolean isInitialized = false;

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
            parseRacesFromXml("Resources/PlayerRaces.xml");
            this.isInitialized = true;
            return true;
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

                foreach (PlayerRace race in Races)
                {
                    //logMessage("Parsed : " + race.RaceName + " STR : " + race.BonusAttributes.STR);
                }
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
