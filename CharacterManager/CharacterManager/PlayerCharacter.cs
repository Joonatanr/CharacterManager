﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CharacterManager.Items;
using CharacterManager.Spells;
using static CharacterManager.Spells.CharacterSpellcastingStatus;

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
            public List<BonusValueModifier> AcBonusModifiers = new List<BonusValueModifier>();
            public List<BonusValueModifier> AttackRollBonusModifiers = new List<BonusValueModifier>();
            public List<BonusValueModifier> AttackDamageBonusModifiers = new List<BonusValueModifier>();

            public string AttackNoteString = string.Empty;

            /* Values that might be accessed during levelup. */
            public List<BonusValueModifier> HitPointLevelupModifiers = new List<BonusValueModifier>();

            public int AttackRollBonus
            {
                get
                {
                    return getModifierTotalValue(AttackRollBonusModifiers);
                }
            }

            public int AttackDamageBonus
            {
                get
                {
                    return getModifierTotalValue(AttackDamageBonusModifiers);
                }
            }

            public int AcBonus
            {
                get
                {
                    return getModifierTotalValue(AcBonusModifiers);
                }
            }


            private int getModifierTotalValue(List<BonusValueModifier> modList)
            {
                int res = 0;

                foreach (BonusValueModifier mod in modList)
                {
                    res += mod.modifierValue;
                }

                return res;
            }

            public CharacterBonusValues()
            {
               
            }

            internal void ResetAttackModifiers()
            {
                AttackNoteString = "";
                AttackRollBonusModifiers = new List<BonusValueModifier>();
                AttackDamageBonusModifiers = new List<BonusValueModifier>();
            }

            internal void ResetLevelUpModifiers()
            {
                HitPointLevelupModifiers = new List<BonusValueModifier>();
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

        public String SubClassName { get; set; } /* Describes the Archetype of the chosen class. */

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
        public int Speed = 0;
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

        public void setupCharacterLevelup()
        {
            CharacterLevelup?.Invoke(this);
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
            CharacterAbilities = new List<PlayerAbilityDescriptor>();
            foreach (PlayerAbility ability in CharacterAbilitiesObjectList)
            {
                CharacterAbilities.Add(ability.ConvertToDescriptor());
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

        
        public void getWeaponAttackModifiers(PlayerWeapon w, out List<BonusValueModifier> attackModifiers, out List<BonusValueModifier> damageModifiers)
        {
            attackModifiers = new List<BonusValueModifier>();
            damageModifiers = new List<BonusValueModifier>();


           /* First set up the attack roll */
           /* We begin with a simple d20 always. */
           attackModifiers.Add(new BonusValueModifier("base", "1d20"));
           
           /* Add ability and proficiency bonuses */
           List<BonusValueModifier> hitbonuses = getHitBonuses(w);
           attackModifiers.AddRange(hitbonuses);

           /* Now we look at the damage bonus. */
           /* First lets get the base damage. */
           damageModifiers.Add(new BonusValueModifier("base damage", w.getBaseDamage()));

           /* Now lets get the damage bonuses */

           List<BonusValueModifier> damageBonuses = getDamageBonus(w);
           damageModifiers.AddRange(damageBonuses);

           /* We add all miscallenous bonuses from abilities and such. */
           BonusValues.ResetAttackModifiers();
           AttackRoll?.Invoke(this, w);

           attackModifiers.AddRange(BonusValues.AttackRollBonusModifiers);
           damageModifiers.AddRange(BonusValues.AttackDamageBonusModifiers);
        }

        internal void PerformLongRest()
        {
            /* 1. Heal */
            CurrentHitPoints = MaxHitPoints;

            /* 2. Recharge lost abilities. */
            foreach (PlayerAbility ability in CharacterAbilitiesObjectList)
            {
                if (ability.RechargeAtLongRest)
                {
                    ability.RemainingCharges = ability.MaximumCharges;
                }
            }

            /* 3. Restore spell points. */
            this.CharacterSpellCasting.RechargeAllSpellSlots();
        }

        internal void PerformShortRest()
        {
            /* TODO : Allow the spending of hit dice. */

            foreach (PlayerAbility ability in CharacterAbilitiesObjectList)
            {
                if (ability.RechargeAtShortRest)
                {
                    ability.RemainingCharges = ability.MaximumCharges;
                }
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
                    obj.RemainingCharges = obj.MaximumCharges;
                    CharacterAbilities.Add(obj.ConvertToDescriptor());
                }
                obj.connectToCharacter(this);
                obj.InitializeSubscriptions(this);
                obj.AbilityUsed += new PlayerAbility.PlayerAbilityUsedListener(abilityUsed);
                obj.IsActiveChanged += new PlayerAbility.PlayerAbilityIsActiveChanged(abilityActiveChanged);
                
            }
        }

        private void abilityUsed(PlayerAbility ability)
        {
            /* TODO Placeholder. */
        }

        private void abilityActiveChanged(bool isActive)
        {
            /* TODO Placeholder */
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

        public int getCurrentArmorClassModifiers(out List<BonusValueModifier> acMods)
        {
            isArmorWorn = false;
            isShieldWorn = false;
            PlayerArmor wornArmor = null;

            BonusValues.AcBonusModifiers = new List<BonusValueModifier>();


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


            if (!isArmorWorn)
            {
                /* Unarmed is quite simple. */
                BonusValues.AcBonusModifiers.Add(new BonusValueModifier("Unarmed", 10));
                BonusValues.AcBonusModifiers.Add(new BonusValueModifier("DEX bonus", getModifier("DEX")));
            }
            else
            {
                /* We are wearing armor. */
                //ac = wornArmor.ArmorClass;
                BonusValues.AcBonusModifiers.Add(new BonusValueModifier(wornArmor.getDisplayedName(), wornArmor.ArmorClass));


                if (wornArmor.IsDexterityModifier)
                {
                    int dexBonus = getModifier("DEX");

                    if (wornArmor.MaxDexModifier > 0)
                    {
                        dexBonus = Math.Min(dexBonus, wornArmor.MaxDexModifier);
                    }

                    //ac += dexBonus;
                    BonusValues.AcBonusModifiers.Add(new BonusValueModifier("DEX bonus", dexBonus));
                }

            }

            if (isShieldWorn)
            {
                /* TODO : Take shield armor bonus into account (could be +1 shield for example). */
                BonusValues.AcBonusModifiers.Add(new BonusValueModifier("Shield", 2));
            }

            /* Fire the event. */
            ArmorDonned?.Invoke(this);

            //ac += BonusValues.AcBonus;

            acMods = BonusValues.AcBonusModifiers;
            return BonusValues.AcBonus;
        }

        public void UpdateAbilityConnections()
        {
            /* We update all connections of the abilities to the player object itself. */
            foreach(PlayerAbility ability in CharacterAbilitiesObjectList)
            {
                ability.connectToCharacter(this);
            }
        }


        public PlayerClass GetPlayerClass()
        {
            /* TODO : If ever we add multiclassing, then this needs to be refactored. */
            /* We return the actual object in this case. */
            return CharacterFactory.getPlayerClassByName(this.ClassName);
        }

        public PlayerClassArchetype GetPlayerSubClass()
        {
            return CharacterFactory.getPlayerSubClassByName(this.ClassName, this.SubClassName);
        }


        public void setSpellSlotData(int level, SpellSlotData data)
        {
            this.CharacterSpellCasting.setSpellSlotDataForLevel(level, data);
        }

        public SpellSlotData getSpellSlotData(int level)
        {
            return this.CharacterSpellCasting.getSpellSlotDataForLevel(level);
        }

        public List<PlayerSpell> GetKnownSpells()
        {
            List<PlayerSpell> res = new List<PlayerSpell>();

            if(this.CharacterSpellCasting != null)
            {
                foreach(string spString in CharacterSpellCasting.KnownSpells)
                {
                    res.Add(CharacterFactory.getPlayerSpellFromString(spString));
                }
            }

            return res;
        }


        /*************************** Private functions **************************/
        private List<BonusValueModifier> getHitBonuses(PlayerWeapon w)
        {
            List<BonusValueModifier> res = new List<BonusValueModifier>();

            int abilityModifier;
            string abilityDescriptor;
            
            if (w.IsRanged)
            {
                abilityModifier = this.getModifier("DEX");
                abilityDescriptor = "DEX bonus";
            }
            else
            {
                abilityModifier = this.getModifier("STR");
                abilityDescriptor = "STR bonus";
            }

            if (w.IsFinesse)
            {
                int dexBonus = this.getModifier("DEX");
                int strBonus = this.getModifier("STR");

                if (dexBonus > strBonus)
                {
                    abilityModifier = dexBonus;
                    abilityDescriptor = "DEX bonus";
                }
                else
                {
                    abilityModifier = strBonus;
                    abilityDescriptor = "STR bonus";
                }
            }

            res.Add(new BonusValueModifier(abilityDescriptor,abilityModifier));

            /* Handle the proficiency bonus here. */
            if (isProficientWithWeapon(w))
            {
                res.Add(new BonusValueModifier("Prof. bonus" ,ProficiencyBonus));
            }

            /* Add magical effects if any */
            /* TODO */

            return res;
        }


        private List<BonusValueModifier> getDamageBonus(PlayerWeapon w)
        {
            List<BonusValueModifier> res = new List<BonusValueModifier>();
            int abilityModifier;
            string abilityDescriptor;

            if (w.IsRanged)
            {
                abilityModifier = this.getModifier("DEX");
                abilityDescriptor = "DEX bonus";
            }
            else
            {
                abilityModifier = this.getModifier("STR");
                abilityDescriptor = "STR bonus";
            }

            if (w.IsFinesse)
            {
                int dexBonus = this.getModifier("DEX");
                int strBonus = this.getModifier("STR");

                if (dexBonus > strBonus)
                {
                    abilityModifier = dexBonus;
                    abilityDescriptor = "DEX bonus";
                }
                else
                {
                    abilityModifier = strBonus;
                    abilityDescriptor = "STR bonus";
                }
            }

            res.Add(new BonusValueModifier(abilityDescriptor, abilityModifier));

            return res;

            /* TODO : Check for additional effects. */
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
