using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CharacterManager.Items;
using CharacterManager.Spells;

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


        /* All bonuses that are determined by special abilities should be defined here. */
        public class CharacterBonusValues
        {
            public int AcBonus = 0; /* Current bonus to AC from abilities and magical effects etc. */
            public int AttackRollBonus = 0;
            public int AttackDamageBonus = 0;
            public string AttackNoteString = string.Empty;

            public CharacterBonusValues()
            {
                
            }
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
            ChaoticEvil,
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
                Gargantuan,
            }

            public int height;
            public int weight;
            public SizeDescriptor sizeType;
        }

        [Serializable]
        public class PlayerAbilityDescriptor
        {
            public string AbilityName;
            public int RemainingCharges = 0;
            public Boolean IsActive = false;

            [XmlIgnore]
            public PlayerAbility ConnectedObject = null;

            public PlayerAbilityDescriptor()
            {
                AbilityName = "UNKNOWN";
            }
            
            public PlayerAbilityDescriptor(String name)
            {
                AbilityName = name;
            }
        }

        public static readonly String[] CharacterSkillProficiencies = new String[]
        {
            "Acrobatics","Animal Handling","Arcana","Athletics","Deception","History","Insight","Intimidation","Investigation",
            "Medicine","Nature","Perception","Performance","Persuasion","Religion","Sleight Of Hand","Stealth","Survival",
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
        public List<PlayerAbilityDescriptor> CharacterAbilities = new List<PlayerAbilityDescriptor>();
        
        /// <summary>
        /// Contains a list of currently known spells
        /// </summary>
        //public List<String> CharacterSpells = new List<String>(); /* TODO : Move these under the spellcastingstatus object. */
        /// <summary>
        /// Contains a list of currently prepared spells. 
        /// </summary>
        //public List<String> PreparedSpells = new List<String>();

        public List<PlayerWeapon> CharacterWeapons = new List<PlayerWeapon>();
        public List<PlayerArmor> CharacterArmors = new List<PlayerArmor>();
        public List<PlayerItem> CharacterGeneralEquipment = new List<PlayerItem>();

        public CharacterSpellcastingStatus CharacterSpellCasting = new CharacterSpellcastingStatus();

        public int Level;
        public int ProficiencyBonus;
        public int ExperiencePoints;
        public int MaxHitPoints;
        private int _CurrentHitPoints;

        public PlayerSize Size;
        public PlayerAlignment Alignment;

        [XmlIgnore]
        public List<string> KnownSpells
        {
            get { return CharacterSpellCasting.KnownSpells;     }
            set { CharacterSpellCasting.KnownSpells = value;    }
        }

        [XmlIgnore]
        public List<string> PreparedSpells
        {
            get { return CharacterSpellCasting.PreparedSpells;  }
            set { CharacterSpellCasting.PreparedSpells = value; }        
        }

        [XmlIgnore]
        public CharacterBonusValues BonusValues = new CharacterBonusValues();

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


        public int CurrentHitPoints
        {
            get
            {
                return _CurrentHitPoints;
            }
            set
            {
                _CurrentHitPoints = value;
                CharacterHPChanged?.Invoke(this);
            }
        }


        private String _name;


        /*** Lets test with some events here. ***/
        public delegate void PlayerEvent(PlayerCharacter c);
        public delegate void PlayerAttackEvent(PlayerCharacter c, PlayerWeapon w);

        public event PlayerEvent ArmorDonned;
        public event PlayerAttackEvent AttackRoll;

        public event PlayerEvent CharacterCreated;
        public event PlayerEvent CharacterLevelup;

        public event PlayerEvent CharacterHPChanged;
        public event PlayerEvent CharacterAbilityStatsUpdated;

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

        public Boolean IsCharacterSpellCasting()
        {
            Boolean res = false;
            PlayerClass myClass = this.GetPlayerClass();
            
            if (myClass.SpellCasting != null)
            {
                if (myClass.SpellCasting.SpellCastingAttribute != null)
                {
                    res = true;
                }       
            }

            return res;
        }

        internal void PrepareDataForSaving()
        {
            /* This is necessary because we use descriptors not raw objects to save ability data. */
            /* Lets create whole new descriptors here.  */
            CharacterAbilities = new List<PlayerCharacter.PlayerAbilityDescriptor>();
            foreach (PlayerAbility ability in CharacterAbilitiesObjectList)
            {
                PlayerCharacter.PlayerAbilityDescriptor desc = new PlayerCharacter.PlayerAbilityDescriptor();
                desc.AbilityName = ability.AttributeName;
                desc.RemainingCharges = ability.RemainingCharges;
                desc.IsActive = ability.IsActive;

                CharacterAbilities.Add(desc);
            }
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


        public String MakeWeaponAttack(PlayerWeapon w)
        {
            String res = "";
            BonusValues.AttackRollBonus = 0;
            BonusValues.AttackDamageBonus = 0;
            BonusValues.AttackNoteString = "";

            AttackRoll?.Invoke(this, w);

            if (!w.IsEquipped)
            {
                res = "Weapon not equipped.";
            }
            else
            {
                int hitBonus = getHitBonus(w) + BonusValues.AttackRollBonus;
                if (hitBonus < 0)
                {
                    res += "1d20 " + hitBonus.ToString();
                }
                else
                {
                    res += "1d20 + " + hitBonus.ToString();
                }

                res += " : " + w.getBaseDamage();
                res += " + ";

                int damageBonus = getDamageBonus(w);
                damageBonus += BonusValues.AttackDamageBonus;
                res += damageBonus.ToString();
                res += " " + w.Damage.Type + " damage";

                if (w.IsRanged)
                {
                    res += "\n";
                    res += "Range : " + w.Range.NormalRange.ToString() + "/" + w.Range.LongRange.ToString();
                }
                else
                {
                    res += "\n";
                    res += "Reach : " + w.Reach.ToString() + "ft";
                }

                if (w.IsAmmunition)
                {
                    if (!isRangedAmmoOk(w))
                    {
                        res = "No ammunition";
                    }
                }

                if (BonusValues.AttackNoteString.Length > 0)
                {
                    res += "\n" + BonusValues.AttackNoteString;
                }
                /*TODO : Ranged weapons will probably be more complicated... */
                /*TODO : Should also consider thrown weapons. --- We really need a form for this. */
                /*TODO : Take ammo into account. */
            }

            return res;
        }

        internal void PerformLongRest()
        {
            /* 1. Heal */
            CurrentHitPoints = MaxHitPoints;

            /* 2. Recharge lost abilities. */
            foreach (PlayerAbility ability in CharacterAbilitiesObjectList)
            {
                ability.RemainingCharges = ability.MaximumCharges;
            }
        }

        internal void UpdateSpellModifiers()
        {
            if (this.IsCharacterSpellCasting())
            {
                string spellcastingAttribute = this.GetPlayerClass().SpellCasting.SpellCastingAttribute;
                int modifier = getModifier(spellcastingAttribute);
                this.CharacterSpellCasting.SpellAttackBonus = modifier + this.ProficiencyBonus;
                this.CharacterSpellCasting.SpellSaveDC = modifier + this.ProficiencyBonus + 8;
                this.CharacterSpellCasting.SpellCastingAbility = spellcastingAttribute;
                this.CharacterSpellCasting.MaxNumberOfPreparedSpells = this.GetPlayerClass().SpellCasting.GetMaximumNumberOfPreparedSpells(modifier, this.Level);
                this.CharacterSpellCasting.SpellAbilityModifier = modifier;
            }
        }

        public Boolean isProficientWithWeapon(PlayerWeapon w)
        {
            Boolean result = false;

            if (WeaponProficiencies.Contains("Martial Weapons"))
            {
                if (w.Type == PlayerWeapon.WeaponType.Martial)
                {
                    return true;
                }
            }

            if (WeaponProficiencies.Contains("Simple Weapons"))
            {
                if (w.Type == PlayerWeapon.WeaponType.Simple)
                {
                    return true;
                }
            }


            if (WeaponProficiencies.Contains(w.ItemName))
            {
                return true;
            }

            return result;
        }

        public void setCharacterAbilitiesList(List<PlayerAbility> abilityList, Boolean overwriteDescriptors)
        {
            CharacterAbilitiesObjectList = abilityList;
            if (overwriteDescriptors)
            {
                CharacterAbilities = new List<PlayerAbilityDescriptor>();
            }
            foreach (PlayerAbility obj in abilityList)
            {
                if (overwriteDescriptors)
                {
                    PlayerAbilityDescriptor desc = new PlayerAbilityDescriptor(obj.AttributeName);
                    desc.ConnectedObject = obj;
                    desc.RemainingCharges = obj.MaximumCharges; /* Assume we start at full in this case. */
                    desc.IsActive = obj.IsActive;
                    CharacterAbilities.Add(desc);
                }
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
            BonusValues.AcBonus = 0;

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

            ac += BonusValues.AcBonus;

            return ac;
        }


        public PlayerClass GetPlayerClass()
        {
            /* TODO : If ever we add multiclassing, then this needs to be refactored. */
            /* We return the actual object in this case. */
            return CharacterFactory.getPlayerClassByName(this.ClassName);
        }

        /*************************** Private functions **************************/
        private int getHitBonus(PlayerWeapon w)
        {
            int res;

            if (w.IsRanged)
            {
                res = this.getModifier("DEX");
            }
            else
            {
                res = this.getModifier("STR");
            }

            /* Handle the proficiency bonus here. */
            if (isProficientWithWeapon(w))
            {
                res += ProficiencyBonus;
            }

            /* TODO : Check for additional effects... */

            return res;
        }


        private int getDamageBonus(PlayerWeapon w)
        {
            int res = 0;

            if (w.IsRanged)
            {
                res = this.getModifier("DEX");    
            }
            else
            {
                res = this.getModifier("STR");
            }

            /* TODO : Check for additional effects. */
            return res;
        }

        private Boolean isRangedAmmoOk(PlayerWeapon w)
        {
            /* Check if we have ammo and reduce it as applicable. */
            Boolean res = true;
            if (w.IsAmmunition)
            {
                if (w.AmmoType != "")
                {
                    PlayerItem ammoItem = CharacterGeneralEquipment.Find(i => i.ItemName == w.AmmoType);

                    if (ammoItem == null)
                    {
                        return false;
                    }

                    if (ammoItem.Quantity == 0)
                    {
                        /* Something has gone wrong.. */
                        CharacterGeneralEquipment.Remove(ammoItem);
                        res = false;
                    }
                    else
                    {
                        ammoItem.Quantity--;
                        if(ammoItem.Quantity == 0)
                        {
                            CharacterGeneralEquipment.Remove(ammoItem);
                        }
                    }
                }
            }


            return res;
        }

    }
}
