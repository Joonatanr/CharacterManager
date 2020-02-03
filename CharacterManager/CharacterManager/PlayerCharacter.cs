﻿using CharacterManager.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CharacterManager
{
    [Serializable]
    public class PlayerCharacter
    {
        /* This is just for very initial testing. */
        public struct CharacterBaseAttributes
        {
            public int STR;
            public int DEX;
            public int INT;
            public int CHA;
            public int CON;
            public int WIS;
        }

        /* TODO : Maybe this can be done differently... */
        public enum PlayerAlignment
        {
            LawfulGood,
            LawfulNeutral,
            LawfulEvil,
            NeutralGood,
            TrueNeutral,
            NeutralEvil,
            ChaoticGood,
            ChaoticNeutral,
            ChaoticEvil
        }

        public struct PlayerSize
        {
            public enum SizeDescriptor
            {
                Tiny,
                Small,
                Medium,
                Large,
                Huge,
                Gargantuan
            }

            public int height;
            public int weight;
            public SizeDescriptor sizeType;
        }

        public static readonly String[] CharacterSkillProficiencies = new String[]
        {
            "Acrobatics","Animal Handling","Arcana","Athletics","Deception","History","Insight","Intimidation","Investigation",
            "Medicine","Nature","Perception","Performance","Persuasion","Religion","Sleight Of Hand","Stealth","Survival"
        };
        

        private CharacterBaseAttributes _baseAttributes;
        private PlayerRace MainRace; //This contains the actual object of the race of the character. 
        private PlayerRace SubRace;  ////This contains the actual object of the subrace of the character. 

        /* These are the properties that are to be stored in XML. Actual objects will be loaded through the factory. */
        public String MainRaceName { get; set; }
        public String SubRaceName { get; set; }

        public String ClassName { get; set; }

        public CharacterBaseAttributes BaseAttributes { get { return _baseAttributes; } set { _baseAttributes = value; } }

        public List<String> SkillProficiencies = new List<String>();
        public List<String> Languages = new List<String>();
        public List<String> WeaponProficiencies = new List<String>();
        public List<String> ArmorProficiencies = new List<String>();
        public List<String> SavingThrowProficiencies = new List<String>();
        public List<String> CharacterAbilities = new List<String>();

        public List<PlayerWeapon> CharacterWeapons = new List<PlayerWeapon>();
        public List<PlayerArmor> CharacterArmors = new List<PlayerArmor>();
        public List<PlayerItem> CharacterGeneralEquipment = new List<PlayerItem>();

        public int Level;
        public int ProficiencyBonus;
        public int ExperiencePoints;
        public int MaxHitPoints;
        public int CurrentHitPoints;

        public PlayerSize Size;
        public PlayerAlignment Alignment;

        [XmlIgnore]
        public int AcBonus = 0; /* Current bonus to AC from abilities and magical effects etc. */

        /* TODO : These could be made into properties with proper getters. */
        [XmlIgnore]
        public Boolean isArmorWorn = false;

        [XmlIgnore]
        public Boolean isShieldWorn = false;

        public String CharacterName
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        [XmlIgnore]
        public List<PlayerAbility> CharacterAbilitiesObjectList = new List<PlayerAbility>();

        [XmlIgnore]
        public int StrengthAttribute
        {
            get
            {
                return _baseAttributes.STR;
            }

            set
            {
                _baseAttributes.STR = value;
            }
        }

        [XmlIgnore]
        public int IntAttribute
        {
            get
            {
                return _baseAttributes.INT;
            }

            set
            {
                _baseAttributes.INT = value;
            }
        }

        [XmlIgnore]
        public int WisAttribute
        {
            get
            {
                return _baseAttributes.WIS;
            }

            set
            {
                _baseAttributes.WIS = value;
            }
        }

        [XmlIgnore]
        public int DexAttribute
        {
            get
            {
                return _baseAttributes.DEX;
            }

            set
            {
                _baseAttributes.DEX = value;
            }
        }


        [XmlIgnore]
        public int CharAttribute
        {
            get
            {
                return _baseAttributes.CHA;
            }

            set
            {
                _baseAttributes.CHA = value;
            }
        }

        [XmlIgnore]
        public int ConAttribute
        {
            get
            {
                return _baseAttributes.CON;
            }

            set
            {
                _baseAttributes.CON = value;
            }
        }

        [XmlIgnore]
        public int PassivePerception
        {
            get
            {
                //TODO : Maybe there are some other bonuses to passive perception?
                int res = getModifier("WIS") + 10;
                if (isSkillProficientIn("Perception"))
                {
                    res += ProficiencyBonus;
                }
                return res;
            }
        }


        private String _name;


        /*** Lets test with some events here. ***/
        public delegate void PlayerEvent(PlayerCharacter c);

        public event PlayerEvent ArmorDonned;
        public event PlayerEvent CharacterCreated;

        public PlayerCharacter()
        {
            this._name = "UNKNOWN";
            this._baseAttributes.STR = 10;
        }

        public PlayerCharacter(String name)
        {
            this._name = name;
            this.StrengthAttribute =    10;
            this.IntAttribute =         10;
            this.CharAttribute =        10;
            this.WisAttribute =         10;
            this.DexAttribute =         10;
            this.ConAttribute =         10;
        }

        public PlayerCharacter(String name, CharacterBaseAttributes attrib)
        {
            this._name = name;
            this._baseAttributes = attrib;
        }

        public void finalizeCharacterCreation()
        {
            /* Should be called only when creating a new character. */
            CharacterCreated?.Invoke(this);
        }

        public void setMainAndSubrace(PlayerRace race, PlayerRace subrace)
        {
            this.MainRace = race;
            this.SubRace = subrace;

            this.MainRaceName = race.RaceName;
            if (subrace != null)
            {
                this.SubRaceName = subrace.RaceName;
            }
            else
            {
                this.SubRaceName = null;
            }
        }


        public void setCharacterAbilitiesList(List<PlayerAbility> abilityList)
        {
            CharacterAbilitiesObjectList = abilityList;
            CharacterAbilities = new List<String>();
            foreach (PlayerAbility obj in abilityList)
            {
                CharacterAbilities.Add(obj.AttributeName);
                obj.InitializeSubscriptions(this);
            }
        }

        public int getModifier(string attribute)
        {
            switch (attribute)
            {
                case ("STR"):
                    return CharacterFactory.getAbilityModifierValue(this.BaseAttributes.STR);
                case ("INT"):
                    return CharacterFactory.getAbilityModifierValue(this.BaseAttributes.INT);
                case ("DEX"):
                    return CharacterFactory.getAbilityModifierValue(this.BaseAttributes.DEX);
                case ("CON"):
                    return CharacterFactory.getAbilityModifierValue(this.BaseAttributes.CON);
                case ("WIS"):
                    return CharacterFactory.getAbilityModifierValue(this.BaseAttributes.WIS);
                case ("CHA"):
                    return CharacterFactory.getAbilityModifierValue(this.BaseAttributes.CHA);
                default:
                    return 0;
            }
        }

        public bool isSavingThrowProficientIn(string attribute)
        {
            return (this.SavingThrowProficiencies.Contains(attribute));
        }

        public bool isSkillProficientIn(string skill)
        {
            foreach(string s in SkillProficiencies)
            {
                if(skill == s)
                {
                    return true;
                }
            }

            return false;
        }

        public int getCurrentArmorClass()
        {
            isArmorWorn = false;
            isShieldWorn = false;
            PlayerArmor wornArmor = null;
            AcBonus = 0;

            foreach (PlayerArmor armor in CharacterArmors)
            {
                if (armor.IsEquipped)
                {
                    if (armor.IsShield)
                    {
                        if (isShieldWorn)
                        {
                            /* We are trying to use more than 1 shield??? Something has gone wrong. */
                        }
                        else
                        {
                            isShieldWorn = true;
                        }
                    }
                    else
                    {
                        if (isArmorWorn)
                        {
                            /* We are trying to wear two armors??? Something has gone wrong. */
                        }
                        else
                        {
                            wornArmor = armor;
                        }
                        isArmorWorn = true;
                    }
                }
            }


            int ac = 0;

            if (!isArmorWorn)
            {
                /* Unarmed is quite simple. */
                ac = getModifier("DEX") + 10;
            }
            else
            {
                /* We are wearing armor. */
                ac = wornArmor.ArmorClass;

                if (wornArmor.IsDexterityModifier)
                {
                    int dexBonus = getModifier("DEX");

                    if (wornArmor.MaxDexModifier > 0)
                    {
                        dexBonus = Math.Min(dexBonus, wornArmor.MaxDexModifier);
                    }
                    ac += dexBonus;
                }

            }

            if (isShieldWorn)
            {
                ac += 2;
            }

            /* Fire the event. */
            ArmorDonned?.Invoke(this);

            ac += AcBonus;

            return ac;
        }
    }
}
