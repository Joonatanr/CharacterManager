using CharacterManager.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager
{
    [Serializable]
    public class ToolProficiencyChoice
    {
        public enum ToolProficiencyChoiceType
        {
            TYPE_LIST,                  /* Choose from a list of proficiencies. Might also be used for a single choice  */
            TYPE_MUSICAL_INSTRUMENT,    /* Choose any musical instrument proficiency                                    */
            TYPE_ARTISAN_TOOL,          /* Choose any artisan tool                                                      */
            TYPE_ARTISAN_OR_MUSICAL,    /* Choose any musical instrument OR artisan tool                                */
            TYPE_GAMING,                /* Choose any gaming set                                                        */
        }

        public ToolProficiencyChoiceType ChoiceType = ToolProficiencyChoiceType.TYPE_LIST; /* Default is a list of possibilities. */
       
        /* TODO : This should be private, but are private variables serialized??? */
        public List<string> AvailableChoices = new List<string>();
        
        public ToolProficiencyChoice()
        {
            ChoiceType = ToolProficiencyChoiceType.TYPE_LIST;
            AvailableChoices = new List<string>();
            AvailableChoices.Add("NONE");
        }

        public static ToolProficiencyChoice parseFromString(string str)
        {
            ToolProficiencyChoice res = new ToolProficiencyChoice();

            if(str == "AnyGaming")
            {
                res.ChoiceType = ToolProficiencyChoiceType.TYPE_GAMING;
            }
            else if(str == "AnyMusical")
            {
                res.ChoiceType = ToolProficiencyChoiceType.TYPE_MUSICAL_INSTRUMENT;
            }
            else if(str == "AnyArtisanProficiency")
            {
                res.ChoiceType = ToolProficiencyChoiceType.TYPE_ARTISAN_TOOL;
            }
            else
            {
                res.ChoiceType = ToolProficiencyChoiceType.TYPE_LIST;
                res.AvailableChoices = new List<string>();
                res.AvailableChoices.Add(str);
            }


            return res;
        }

        public List<string> getAllAvailableChoices()
        {
            List<string> res = new List<string>();

            List<PlayerToolKit> ExistingToolKits = CharacterFactory.getAllToolSets();
            List<PlayerToolKit> musicalInstruments = ExistingToolKits.FindAll(t => t.ToolType == PlayerToolKit.PlayerToolType.TYPE_MUSICAL);
            List<PlayerToolKit> artisanTools = ExistingToolKits.FindAll(t => t.ToolType == PlayerToolKit.PlayerToolType.TYPE_ARTISAN);
            List<PlayerToolKit> gamingTools = ExistingToolKits.FindAll(t => t.ToolType == PlayerToolKit.PlayerToolType.TYPE_GAMING);

            switch (ChoiceType)
            {
                case ToolProficiencyChoiceType.TYPE_LIST:
                    /* Simplest case. */
                    res = AvailableChoices;
                    break;
                case ToolProficiencyChoiceType.TYPE_MUSICAL_INSTRUMENT:
                    foreach(PlayerToolKit t in musicalInstruments)
                    {
                        res.Add(t.Name);
                    }
                    break;
                case ToolProficiencyChoiceType.TYPE_ARTISAN_TOOL:
                    foreach (PlayerToolKit t in artisanTools)
                    {
                        res.Add(t.Name);
                    }
                    break;
                case ToolProficiencyChoiceType.TYPE_ARTISAN_OR_MUSICAL:
                    foreach (PlayerToolKit t in musicalInstruments)
                    {
                        res.Add(t.Name);
                    }
                    foreach (PlayerToolKit t in artisanTools)
                    {
                        res.Add(t.Name);
                    }
                    break;
                case ToolProficiencyChoiceType.TYPE_GAMING:
                    foreach (PlayerToolKit t in gamingTools)
                    {
                        res.Add(t.Name);
                    }
                    break;
                default:
                    break;
            }

            return res;
        }
    }
}
