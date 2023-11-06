using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager
{
    [Serializable]
    public class PlayerAbilityUpgrade
    {
        public int Level { get; set; }

        public string Dice = null;
        public int MaximumCharges = 0;
        public string AdditionalDescription = "";

        public List<string> AdditionalSpellsAddedByAbility = new List<string>();
    }
}
