using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterManager;

namespace CharacterManager.SpecialAttributes
{
    public class DwarvenToughness : SpecialAttribute
    {
        public DwarvenToughness()
        {
            this.AttributeName = "Dwarven Toughness";
        }

        /* TODO : We should really change this into a subscription based system. */
        public override void updateCharacterDuringCreation(PlayerCharacter character)
        {
            character.MaxHitPoints++;
        }

        public override void updateCharacterDuringLevelUp(PlayerCharacter character)
        {
            character.MaxHitPoints++;
        }
    } 
}
