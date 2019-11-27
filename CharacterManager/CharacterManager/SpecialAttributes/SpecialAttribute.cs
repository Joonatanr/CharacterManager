using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager.SpecialAttributes
{
    //This is basically a special attribute that affects gameplay.
    //In this case the attribute is too complex to describe via XML and requires method descriptions.

    public abstract class SpecialAttribute : PlayerAbility
    {
        //Called during the creation of a character.
        public abstract void updateCharacterDuringCreation(PlayerCharacter character);

        //Called when a character is levelled up.
        public abstract void updateCharacterDuringLevelUp(PlayerCharacter character);

        public void CopyValuesFromBaseClass(PlayerAbility baseObj)
        {
            this.Description = baseObj.Description;
        }
    }
}
