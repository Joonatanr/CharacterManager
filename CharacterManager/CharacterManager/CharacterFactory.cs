﻿using System;
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
            return true;
        }

        private void parseRacesFromXml(String filepath)
        {
            //Lets just test if we can parse one initially... 
            PlayerRace test;
            try
            {
                XmlSerializer reader = new XmlSerializer(typeof(PlayerRace));
                StreamReader file = new System.IO.StreamReader(filepath);

                test = (PlayerRace)reader.Deserialize(file);
                file.Close();

                logMessage("Parsed : " + test.RaceName + " STR : " + test.BonusAttributes.STR);
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
