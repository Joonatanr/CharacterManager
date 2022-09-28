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

        public List<string> getAllAvailableChoices()
        {
            List<string> res = new List<string>();

            List<PlayerToolKit> ExistingToolKits = CharacterFactory.getAllToolSets();
            List<PlayerToolKit> musicalInstruments = ExistingToolKits.FindAll(t => t.ToolType == PlayerToolKit.PlayerToolType.TYPE_MUSICAL);
            List<PlayerToolKit> artisanTools = ExistingToolKits.FindAll(t => t.ToolType == PlayerToolKit.PlayerToolType.TYPE_ARTISAN);

            switch (ChoiceType)
            {
                case ToolProficiencyChoiceType.TYPE_LIST:
                    /* Simplest case. */
                    res = AvailableChoices;
                    break;
                case ToolProficiencyChoiceType.TYPE_MUSICAL_INSTRUMENT:
                    foreach(PlayerToolKit t in musicalInstruments)
                    {
                        res.Add(t.ItemName);
                    }
                    break;
                case ToolProficiencyChoiceType.TYPE_ARTISAN_TOOL:
                    foreach (PlayerToolKit t in artisanTools)
                    {
                        res.Add(t.ItemName);
                    }
                    break;
                case ToolProficiencyChoiceType.TYPE_ARTISAN_OR_MUSICAL:
                    foreach (PlayerToolKit t in musicalInstruments)
                    {
                        res.Add(t.ItemName);
                    }
                    foreach (PlayerToolKit t in artisanTools)
                    {
                        res.Add(t.ItemName);
                    }
                    break;
                default:
                    break;
            }

            return res;
        }
    }
}
