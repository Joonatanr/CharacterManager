using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager
{
    [Serializable]
    public class PlayerClass
    {
        public String PlayerClassName;
        public int HitDie;

        public List<String> WeaponProficiencies = new List<String>();
        public List<String> ArmorProficiencies = new List<String>();
        public List<String> SavingThrowProficiencies = new List<String>();
        public List<String> AvailableSkillProficiencies = new List<String>();
        public int NumberOfSkillsToChoose;

        public PlayerClass()
        {
            PlayerClassName = "UNKNOWN";
        }
    }
}
