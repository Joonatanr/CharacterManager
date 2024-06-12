using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharacterManager.CharacterCreator;
using CharacterManager.Items;
using CharacterManager.SpecialAttributes;
using CharacterManager.Spells;
using CharacterManager.UserControls;
using CharacterManager.UserControls.Levelup;
using static CharacterManager.CharacterCreator.UserControlClassFeature;

namespace CharacterManager
{
    /******* Fighter class abilities. ********/

    /* Fighting Styles */
    public class FightingStyleArchery : SpecialAttribute
    {
        public FightingStyleArchery()
        {
            this.Name = "Archery Fighting Style";
            this.Description = "You gain a +2 bonus to attack rolls you make with ranged weapons.";
        }

        public override void InitializeSubscriptions(PlayerCharacter c)
        {
            c.AttackRoll += CalculateAttackBonus;
        }

        private void CalculateAttackBonus(PlayerCharacter c, PlayerWeapon w)
        {
            if (w.IsRanged)
            {
                c.BonusValues.AttackRollBonusModifiers.Add(new BonusValueModifier("Archery Fighting Style", 2));
            }
        }
    }

    public class FightingStyleDefense : SpecialAttribute
    {
        public FightingStyleDefense()
        {
            this.Name = "Defense Fighting Style";
            this.Description = "While you are wearing armor, you gain a +1 bonus to AC.";
        }

        public override void InitializeSubscriptions(PlayerCharacter c)
        {
            c.ArmorDonned += UpdateArmorBonus;
        }

        private void UpdateArmorBonus(PlayerCharacter c)
        {
            if (c.isArmorWorn)
            {
                c.BonusValues.AcBonusModifiers.Add(new BonusValueModifier("Defense Fighting Style", 1));
            }
        }
    }

    public class FightingStyleGreatWeapon : SpecialAttribute
    {
        public override string DisplayedName { get { return "Great Weapon Fighting"; } }

        public FightingStyleGreatWeapon()
        {
            this.Name = "Great Weapon Fighting Style";
            this.Description = "When you roll a 1 or 2 on a damage die for an attack you make with a melee weapon that you are wielding with two hands, you can reroll the die and must use the new roll, even if the new roll is a 1 or a 2. " +
                "The weapon must have the two-handed or versatile property for you to gain this benefit.";
        }

        public override void InitializeSubscriptions(PlayerCharacter c)
        {
            c.AttackRoll += AddAttackNote;
        }

        private void AddAttackNote(PlayerCharacter c, PlayerWeapon w)
        {
            if (w.IsEquippedTwoHanded && !w.IsRanged)
            {
                c.BonusValues.AttackNoteString = "Great Weapon Fighting : When you roll a 1 or 2 on a damage die you can reroll the die once.";
            }
        }
    }

    public class RemarkableAthleteAbility : SpecialAttribute
    {
        public RemarkableAthleteAbility()
        {
            this.Name = "Remarkable Athlete";
        }

        public override void InitializeSubscriptions(PlayerCharacter c)
        {
            c.CharacterSkillBonuseUpdated += C_CharacterSkillBonusUpdated;
            c.CharacterSavingThrowBonusUpdated += C_CharacterSavingThrowBonusUpdated;
        }

        private void C_CharacterSavingThrowBonusUpdated(PlayerCharacter c)
        {
            if (!c.isSavingThrowProficientIn("STR"))
            {
                if (!c.BonusValues.CharacterSavingThrowBonusesFromAbilities.Keys.Contains("STR"))
                {
                    c.BonusValues.CharacterSavingThrowBonusesFromAbilities.Add("STR", new List<BonusValueModifier>());
                }
                c.BonusValues.CharacterSavingThrowBonusesFromAbilities["STR"].Add(new BonusValueModifier("Remarkable Athlete", (c.ProficiencyBonus + 1) / 2));
            }

            if (!c.isSavingThrowProficientIn("DEX"))
            {
                if (!c.BonusValues.CharacterSavingThrowBonusesFromAbilities.Keys.Contains("DEX"))
                {
                    c.BonusValues.CharacterSavingThrowBonusesFromAbilities.Add("DEX", new List<BonusValueModifier>());
                }
                c.BonusValues.CharacterSavingThrowBonusesFromAbilities["DEX"].Add(new BonusValueModifier("Remarkable Athlete", (c.ProficiencyBonus + 1) / 2));
            }

            if (!c.isSavingThrowProficientIn("CON"))
            {
                if (!c.BonusValues.CharacterSavingThrowBonusesFromAbilities.Keys.Contains("CON"))
                {
                    c.BonusValues.CharacterSavingThrowBonusesFromAbilities.Add("CON", new List<BonusValueModifier>());
                }
                c.BonusValues.CharacterSavingThrowBonusesFromAbilities["CON"].Add(new BonusValueModifier("Remarkable Athlete", (c.ProficiencyBonus + 1) / 2));
            }
        }

        private void C_CharacterSkillBonusUpdated(PlayerCharacter c)
        {
            String[] CharacterSkillProficiencies = new String[]
            {
                "Acrobatics", "Athletics", "Sleight Of Hand","Stealth",
            };

            BonusValueModifier HalfProfBonusMod = new BonusValueModifier("Remarkable Athlete", (c.ProficiencyBonus + 1) / 2);

            foreach (string skill in CharacterSkillProficiencies)
            {
                if (!c.SkillProficiencies.Contains(skill))
                {
                    if (c.BonusValues.CharacterSkillBonusesFromAbilities.Keys.Contains(skill))
                    {
                        c.BonusValues.CharacterSkillBonusesFromAbilities[skill].Add(HalfProfBonusMod);
                    }
                    else
                    {
                        List<BonusValueModifier> myList = new List<BonusValueModifier>();
                        myList.Add(HalfProfBonusMod);
                        c.BonusValues.CharacterSkillBonusesFromAbilities.Add(skill, myList);
                    }
                }
            }
        }
    }

    public class FightingStyleDueling : SpecialAttribute
    {
        public override string DisplayedName { get { return "Dueling Fighting Style"; } }

        public FightingStyleDueling()
        {
            this.Name = "Dueling Fighting Style";
            this.Description = "When you are wielding a melee weapon in one hand and no other weapons, you gain a +2 bonus to damage rolls " +
                "with that weapon.";
        }

        public override void InitializeSubscriptions(PlayerCharacter c)
        {
            c.AttackRoll += AddAttackBonus;
        }

        private void AddAttackBonus(PlayerCharacter c, PlayerWeapon w)
        {
            Boolean isOnlyOneEquipped = true;
            foreach (PlayerWeapon weapon in c.CharacterWeapons)
            {
                if (weapon.IsEquipped && weapon != w)
                {
                    isOnlyOneEquipped = false;
                }
            }

            if (isOnlyOneEquipped && (w.IsEquippedTwoHanded == false))
            {
                c.BonusValues.AttackDamageBonusModifiers.Add(new BonusValueModifier("Dueling Fighting Style", 2));
            }
        }
    }

    public class FightingStyleProtection : SpecialAttribute
    {
        public override string DisplayedName { get { return "Protection Fighting Style"; } }

        public FightingStyleProtection()
        {
            this.Name = "Protection Fighting Style";
            this.Description = "When a creature you can see attacks a target other than you that is within 5 feet of you, you can use your reaction to impose disadvantage on the attack roll. You must be wielding a shield.";
        }
    }

    public class FightingStyleTwoWeapon : SpecialAttribute
    {
        public override string DisplayedName { get { return "Two-Weapon Fighting"; } }

        public FightingStyleTwoWeapon()
        {
            this.Name = "Two-Weapon Fighting Style";
            this.Description = "When you engage in two-weapon fighting, you can add your ability modifier to the damage of the second attack.";
        }

        /* TODO : Create mechanics for actually taking this ability into account. - This will need two weapon wielding to be implemented first. */
    }

    public class SecondWindAbility : SpecialAttribute
    {
        public SecondWindAbility()
        {
            this.Name = "Second Wind";
        }

        public override bool UseAbilitySpecial()
        {
            FormUseAbility myForm = new FormUseAbility();

            /* TODO : Can't we get this in some other manner??? The ability itself should have the description... */
            myForm.Description = "Restore 1d10 + your fighter level";
            myForm.AbilityName = "Second Wind";

            if (_connectedCharacter != null)
            {
                List<BonusValueModifier> rollComponents = new List<BonusValueModifier>();
                rollComponents.Add(new BonusValueModifier("Second wind die", "1d10"));
                rollComponents.Add(new BonusValueModifier("Level", _connectedCharacter.Level));
                myForm.DieRollModifiers = rollComponents;

                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    _connectedCharacter.CurrentHitPoints = Math.Min(_connectedCharacter.MaxHitPoints, myForm.RollResult + _connectedCharacter.CurrentHitPoints);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }

    public class ImprovedCriticalAbility : SpecialAttribute
    {
        public ImprovedCriticalAbility()
        {
            this.Name = "Improved Critical";
        }

        public override void InitializeSubscriptions(PlayerCharacter c)
        {
            c.AttackRollMade += C_AttackRollMade; ;
        }

        private void C_AttackRollMade(PlayerCharacter c, PlayerWeapon w)
        {
            /* We also strike a critical on 19, so lets add it to the list */
            c.BonusValues.ExtraCritValues.Add(19);
            if (c.Level >= 15)
            {
                c.BonusValues.ExtraCritValues.Add(18);
            }
        }
    }

    public class StudentOfWarAbility : SpecialAttribute
    {
        private string chosenAbility = null;

        public StudentOfWarAbility()
        {
            this.Name = "Student Of War";
        }

        public override bool ExtraChoiceOptions(out string btnText, out UserControlClassFeature.ExtraChoiceEventHandler clickHandler)
        {
            btnText = "Choose Tool Prof.";
            clickHandler = new ExtraChoiceEventHandler(handleToolProficiencyChoice);
            return true;
        }

        public override void HandleAbilitySelected(PlayerCharacter c, out List<PlayerSpell> chosenSpells)
        {
            chosenSpells = new List<PlayerSpell>();

            if (chosenAbility != null)
            {
                c.ToolProficiencies.Add(chosenAbility);
            }
        }

        private void handleToolProficiencyChoice(PlayerCharacter Character)
        {
            GenericListChoiceForm myForm = new GenericListChoiceForm();

            /* First lets get the existing tool proficiencies... */
            List<string> existingToolProficiencies = Character.ToolProficiencies;

            /* Then we need all available artisan tool proficiencies... */
            List<PlayerToolKit> allToolProficiencies = CharacterFactory.getAllToolSets();

            List<string> availableChoices = new List<string>();

            foreach (PlayerToolKit toolkit in allToolProficiencies)
            {
                if (!existingToolProficiencies.Contains(toolkit.Name))
                {
                    if (toolkit.ToolType == PlayerToolKit.PlayerToolType.TYPE_ARTISAN)
                    {
                        availableChoices.Add(toolkit.Name);
                    }
                }
            }

            myForm.setChoiceList(availableChoices);

            if (myForm.ShowDialog() == DialogResult.OK)
            {
                chosenAbility = myForm.getSelectedItem();
            }
        }
    }

    public class SurvivorAbility : SpecialAttribute
    {
        public SurvivorAbility()
        {
            this.Name = "Survivor";
        }

        public override bool UseAbilitySpecial()
        {
            if (_connectedCharacter != null)
            {
                /* We just add the HP, since there is not really any way to detect if a turn has ended. 
                 Lets check the half HP rule though...*/
                if (_connectedCharacter.CurrentHitPoints <= (_connectedCharacter.MaxHitPoints / 2) && (_connectedCharacter.CurrentHitPoints > 0))
                {
                    int value = 5 + _connectedCharacter.getModifier("CON");
                    _connectedCharacter.CurrentHitPoints += value;
                    return true;
                }
            }

            return false;
        }
    }
    /*********************************************************************************************/

    /******* Barbarian class abilities. ********/
    public class RageAbility : SpecialAttribute
    {
        public RageAbility()
        {
            this.Name = "Rage";
        }

        public override void InitializeSubscriptions(PlayerCharacter c)
        {
            c.AttackRoll += C_AttackRoll;
        }

        private void C_AttackRoll(PlayerCharacter c, PlayerWeapon w)
        {
            if (this.IsActive)
            {
                int bonus = 2;
                if (c.Level >= 9 && c.Level < 16)
                {
                    bonus = 3;
                }
                else if (c.Level >= 16)
                {
                    bonus = 4;
                }

                if (!w.IsRanged)
                {
                    c.BonusValues.AttackDamageBonusModifiers.Add(new BonusValueModifier("Rage", bonus));
                }
            }
        }
    }


    public class UnarmoredDefenseAbility : SpecialAttribute
    {
        public UnarmoredDefenseAbility()
        {
            this.Name = "Unarmored Defense";
        }

        public override void InitializeSubscriptions(PlayerCharacter c)
        {
            c.ArmorDonned += C_ArmorDonned;
        }

        private void C_ArmorDonned(PlayerCharacter c)
        {
            if (!c.isArmorWorn)
            {
                c.BonusValues.AcBonusModifiers.Add(new BonusValueModifier("Unarmored Defense", c.getModifier("CON")));
            }
        }
    }

    public class FastMovementAbility : SpecialAttribute
    {
        public FastMovementAbility()
        {
            this.Name = "Fast Movement";
        }

        public override void InitializeSubscriptions(PlayerCharacter c)
        {
            c.ArmorDonned += C_ArmorDonned;
        }

        private void C_ArmorDonned(PlayerCharacter c)
        {
            if (c.isHeavyArmorWorn == false)
            {
                c.BonusValues.SpeedModifiers.Add(new BonusValueModifier("Fast movement", 10));
            }
        }
    }

    public class BrutalCriticalAbility : SpecialAttribute
    {
        public BrutalCriticalAbility()
        {
            this.Name = "Brutal Critical";
        }

        public override void InitializeSubscriptions(PlayerCharacter c)
        {
            c.AttackRoll += C_AttackRoll;
        }

        private void C_AttackRoll(PlayerCharacter c, PlayerWeapon w)
        {
            string dieString = w.Damage.DamageValue;
            DieRollComponent damageDie = DieRollComponent.parseFromString(dieString);
            if (c.Level < 13)
            {
                c.BonusValues.ExtraCriticalDamageModifiers.Add(new BonusValueModifier("Brutal critical", damageDie));
            }
            else if (c.Level < 17)
            {

            }
            else
            {

            }
        }
    }

    /*********************************************************************************************/

    /******* Wizard class abilities. ********/

    public class ArcaneWardAbility : SpecialAttribute
    {
        /* TODO : Consider that when loading or saving, then this data will be lost. Maybe that's OK for now. */
        private bool isInitialCast = true;

        public ArcaneWardAbility()
        {
            this.Name = "Arcane Ward";
        }

        public override void InitializeSubscriptions(PlayerCharacter c)
        {
            c.CharacterSpellCast += C_CharacterSpellCast;
        }

        /// <summary>
        /// In this case, we always begin with an empty arcane ward. 
        /// </summary>
        public override void HandleInit()
        {
            this.RemainingCharges = 0;
        }

        public override void HandleLongRest()
        {
            isInitialCast = true;
            this.RemainingCharges = 0;
        }

        private void C_CharacterSpellCast(PlayerCharacter c, PlayerSpell sp, int level)
        {
            if (sp.School == "Abjuration")
            {
                if (isInitialCast)
                {
                    this.RemainingCharges = GetMaximumCharges(c);
                    isInitialCast = false;
                }
                else
                {
                    /* We restore some charges based on the spell's level.*/
                    this.RemainingCharges = Math.Min(this.MaximumCharges, this.RemainingCharges + (level * 2));
                }
            }
        }

        protected override int GetMaximumCharges(PlayerCharacter c)
        {
            int res = c.Level * 2;
            res += c.getModifier("INT");

            return res;
        }
    }

    public class ImprovedAbjurationAbility : SpecialAttribute
    {
        public ImprovedAbjurationAbility()
        {
            this.Name = "Improved Abjuration";
        }

        public override void InitializeSubscriptions(PlayerCharacter c)
        {
            c.CharacterSetupCastingForSpell += C_CharacterSetupCastingForSpell;
        }

        private void C_CharacterSetupCastingForSpell(PlayerCharacter c, PlayerSpell sp, int level)
        {
            if (sp.School == "Abjuration" && sp.IsSpellCastingModifierAddedToDice)
            {
                c.BonusValues.SpellExtraDiceModifiers.Add(new BonusValueModifier("Improved Abjuration", c.ProficiencyBonus));
            }
        }
    }

    public class BenignTranspositionAbility : SpecialAttribute
    {
        public BenignTranspositionAbility()
        {
            this.Name = "Benign Transposition";
        }

        public override void InitializeSubscriptions(PlayerCharacter c)
        {
            c.CharacterSpellCast += C_CharacterSpellCast;
        }

        private void C_CharacterSpellCast(PlayerCharacter c, PlayerSpell sp, int level)
        {
            if (sp.SpellLevel >= 1 && sp.School == "Conjuration")
            {
                this.RemainingCharges = this.MaximumCharges;
            }
        }
    }

    public class PortentAbility : SpecialAttribute
    {
        private int _portentDie1 = 0;
        private int _portentDie2 = 0;

        public PortentAbility()
        {
            this.Name = "Portent";
        }

        public override void HandleLongRest()
        {
            base.HandleLongRest();
            DieRollEquation myEquation = new DieRollEquation("d20");
            string rollResult;

            _portentDie1 = myEquation.RollValue(out rollResult);
            GlobalEvents.ReportRollGlobal("Portent Die : " + rollResult, Color.Black, true);
            _portentDie2 = myEquation.RollValue(out rollResult);
            GlobalEvents.ReportRollGlobal("Portent Die : " + rollResult, Color.Black, true);
        }

        public override List<PlayerAbilityInfoItem> GetInfoItems()
        {
            List<PlayerAbilityInfoItem> res = base.GetInfoItems();

            PlayerAbilityInfoItem Die1Item = new PlayerAbilityInfoItem("Die 1: " + _portentDie1.ToString());
            PlayerAbilityInfoItem Die2Item = new PlayerAbilityInfoItem("Die 2: " + _portentDie2.ToString());

            Die1Item.IsUsable = true;
            Die2Item.IsUsable = true;

            Die1Item.Value = _portentDie1;
            Die2Item.Value = _portentDie2;

            if (_portentDie1 != 0)
            {
                res.Add(Die1Item);
            }

            if (_portentDie2 != 0)
            {
                res.Add(Die2Item);
            }

            return res;
        }

        public override void UseAbilityInfoItem(PlayerAbilityInfoItem item)
        {
            base.UseAbilityInfoItem(item);
            if (_portentDie1 == item.Value)
            {
                _portentDie1 = 0;
            }
            else if (_portentDie2 == item.Value)
            {
                _portentDie2 = 0;
            }
            else
            {
                /* Huh? */
            }
        }

        public override string GetInfoItemsLabel()
        {
            return "Portent Dice:";
        }

        public override PlayerAbilityDescriptor ConvertToDescriptor()
        {
            PlayerAbilityDescriptor desc = base.ConvertToDescriptor();

            desc.Options1 = new List<string>();
            desc.Options1.Add(_portentDie1.ToString());
            desc.Options1.Add(_portentDie2.ToString());

            return desc;
        }

        public override void ResolveFromDescriptor(PlayerAbilityDescriptor desc)
        {
            base.ResolveFromDescriptor(desc);
            int x = 0;


            foreach (string opt in desc.Options1)
            {
                if (x == 0)
                {
                    int.TryParse(opt, out _portentDie1);
                    x++;
                }
                else if (x == 1)
                {
                    int.TryParse(opt, out _portentDie2);
                    x++;
                }
            }
        }
    }

    /*********************************************************************************************/

    /******* Bard class abilities. ********/
    public class JackOfAllTradesAbility : SpecialAttribute
    {
        public JackOfAllTradesAbility()
        {
            this.Name = "Jack Of All Trades";
        }

        public override void InitializeSubscriptions(PlayerCharacter c)
        {
            c.CharacterSkillBonuseUpdated += C_CharacterSkillBonusUpdated;
        }

        private void C_CharacterSkillBonusUpdated(PlayerCharacter c)
        {
            String[] CharacterSkillProficiencies = new String[]
            {
                "Acrobatics","Animal Handling","Arcana","Athletics","Deception","History","Insight","Intimidation","Investigation",
                "Medicine","Nature","Perception","Performance","Persuasion","Religion","Sleight Of Hand","Stealth","Survival",
            };

            BonusValueModifier HalfProfBonusMod = new BonusValueModifier("Half Prof (Jack of All Trades)", c.ProficiencyBonus / 2);

            foreach (string skill in CharacterSkillProficiencies)
            {
                if (!c.SkillProficiencies.Contains(skill))
                {
                    if (c.BonusValues.CharacterSkillBonusesFromAbilities.Keys.Contains(skill))
                    {
                        c.BonusValues.CharacterSkillBonusesFromAbilities[skill].Add(HalfProfBonusMod);
                    }
                    else
                    {
                        List<BonusValueModifier> myList = new List<BonusValueModifier>();
                        myList.Add(HalfProfBonusMod);
                        c.BonusValues.CharacterSkillBonusesFromAbilities.Add(skill, myList);
                    }
                }
            }
        }
    }

    public class FontOfInspiration : SpecialAttribute
    {
        public FontOfInspiration()
        {
            this.Name = "Font Of Inspiration";
        }

        public override void InitializeSubscriptions(PlayerCharacter c)
        {
            c.ShortRestMade += C_ShortRestMade;
        }

        private void C_ShortRestMade(PlayerCharacter c)
        {
            PlayerAbility inspirationAbility = c.CharacterAbilitiesObjectList.Find(ability => ability.Name == "Bardic Inspiration");

            if (inspirationAbility != null)
            {
                inspirationAbility.RechargeAbility();
            }
        }
    }


    public class SuperiorInspiration : SpecialAttribute
    {
        public SuperiorInspiration()
        {
            this.Name = "Superior Inspiration";
        }

        public override void InitializeSubscriptions(PlayerCharacter c)
        {
            c.InitiativeRollMade += C_InitiativeRollMade;
        }

        private void C_InitiativeRollMade(PlayerCharacter c)
        {
            PlayerAbility inspirationAbility = c.CharacterAbilitiesObjectList.Find(ability => ability.Name == "Bardic Inspiration");

            if (inspirationAbility != null)
            {
                inspirationAbility.RemainingCharges = Math.Max(1, inspirationAbility.RemainingCharges);
            }
        }
    }


    /*********************************************************************************************/
    /******* Rogue class abilities. ********/
    public class RogueExpertise : SpecialAttribute
    {
        /* This ability should affect character creation. It is too specific so lets
           give the user this ability as the final step in creating a rogue. 
        
        Additionally it should affect levelling up at 6th level. 
        
        Things are made more complex by the ability to choose expertise in Thieves' Tools as well as in any
        skill.
        */

        private PlayerCharacter connectedCharacter = null;

        public RogueExpertise()
        {
            this.Name = "Expertise(Rogue)";
        }

        public override void InitializeSubscriptions(PlayerCharacter c)
        {
            c.CharacterFinalize += C_CharacterCreated;
        }

        private void C_CharacterCreated(PlayerCharacter c)
        {
            if (c.ToolExpertise.Contains("Thieves Tools"))
            {
                /* Then we have no other choice. */
                FormChooseSkillProfs myForm = new FormChooseSkillProfs();

                myForm.setCharacter(connectedCharacter);
                myForm.setupProficiencyChoices(0);
                myForm.setupExpertiseChoices(2);

                myForm.ShowDialog();
                if (myForm.DialogResult == DialogResult.OK)
                {
                    List<string> AllExpertise = myForm.getAllSelectedSkillExpertise();
                    foreach (string expertise in AllExpertise)
                    {
                        if (!connectedCharacter.SkillExpertise.Contains(expertise))
                        {
                            connectedCharacter.SkillExpertise.Add(expertise);
                        }
                    }
                }
            }
            else
            {
                FormBinaryChoice myMainForm = new FormBinaryChoice();
                myMainForm.Desription = this.Description;
                myMainForm.ChoiceOne = "Thieves Tools exprt + 1 skill";
                myMainForm.ChoiceTwo = "2 skill expertise";
                myMainForm.ChoiceDialog = ShowChoiceDialog;
                connectedCharacter = c;

                myMainForm.ShowDialog();
            }
        }

        private bool ShowChoiceDialog(int choice_ix)
        {
            FormChooseSkillProfs myForm = new FormChooseSkillProfs();

            myForm.setCharacter(connectedCharacter);
            myForm.setupProficiencyChoices(0);
            myForm.setupExpertiseChoices(choice_ix);

            myForm.ShowDialog();
            if (myForm.DialogResult == DialogResult.OK)
            {
                List<string> AllExpertise = myForm.getAllSelectedSkillExpertise();
                foreach (string expertise in AllExpertise)
                {
                    if (!connectedCharacter.SkillExpertise.Contains(expertise))
                    {
                        connectedCharacter.SkillExpertise.Add(expertise);
                    }
                }

                if (choice_ix == 1)
                {
                    connectedCharacter.ToolExpertise.Add("Thieves Tools");
                }

                return true;
            }
            return false;
        }
    }

    public class SneakAttack : SpecialAttribute
    {
        public SneakAttack()
        {
            this.Name = "Sneak Attack";
        }

        public override void InitializeSubscriptions(PlayerCharacter c)
        {
            c.AttackRoll += C_AttackRoll;
        }

        private void C_AttackRoll(PlayerCharacter c, PlayerWeapon w)
        {
            if (this.IsActive)
            {
                BonusValueModifier sneakAttackBonus = new BonusValueModifier("Sneak Attack", this.Dice);
                c.BonusValues.AttackDamageBonusModifiers.Add(sneakAttackBonus);
            }
        }
    }


    /*********************************************************************************************/

    /******* Paladin class abilities. ********/
    public class DivineSmite : SpecialAttribute
    {
        public DivineSmite()
        {
            this.Name = "Divine Smite";
        }

        public override bool UseAbilitySpecial()
        {
            if (_connectedCharacter != null)
            {
                /* For all intents and purposes Divine Smite functions as a spell. Lets try to treat it just like one. */
                PlayerSpell dummy = new PlayerSpell("Divine Smite");
                dummy.Description = this.GetExtendedDescription();
                dummy.SpellLevel = 1;

                dummy.DiceAtLevel1 = "2d8";
                dummy.DiceAtLevel2 = "3d8";
                dummy.DiceAtLevel3 = "4d8";
                dummy.DiceAtLevel4 = "5d8";

                Spellcard card = new Spellcard();
                card.IsCastingInfoVisible = true;
                card.setSpell(dummy);
                card.ShowDialog();
            }

            return true;
        }
    }

    public class ImprovedDivineSmite : SpecialAttribute
    {
        public ImprovedDivineSmite()
        {
            this.Name = "Improved Divine Smite";
        }

        public override void InitializeSubscriptions(PlayerCharacter c)
        {
            c.AttackRoll += C_AttackRoll;
        }

        private void C_AttackRoll(PlayerCharacter c, PlayerWeapon w)
        {
            if (!w.IsRanged)
            {
                c.BonusValues.AttackDamageBonusModifiers.Add(new BonusValueModifier("Improved Divine Smite", "1d8"));
            }
        }
    }


    /*********************************************************************************************/

    /******* Cleric class abilities. ********/
    public class BlessingsOfKnowledge : SpecialAttribute
    {
        private string chosenLanguage1 = null;
        private string chosenLanguage2 = null;
        private string chosenExpertise1 = null;
        private string chosenExpertise2 = null;

        public BlessingsOfKnowledge()
        {
            this.Name = "Blessings Of Knowledge";
        }

        public override bool ExtraChoiceOptions(out string btnText, out UserControlClassFeature.ExtraChoiceEventHandler clickHandler)
        {
            btnText = "Choose Options";
            clickHandler = new ExtraChoiceEventHandler(handleKnowledgeChoices);
            return true;
        }

        public override void HandleAbilitySelected(PlayerCharacter c, out List<PlayerSpell> chosenSpells)
        {
            /* Not used here. */
            chosenSpells = new List<PlayerSpell>();

            if (chosenLanguage1 != null)
            {
                c.Languages.Add(chosenLanguage1);
            }

            if (chosenLanguage2 != null)
            {
                c.Languages.Add(chosenLanguage2);
            }
        }

        /* Here we need extra handling, because the ability can be selected directly on the Character Creator Form. */
        public override List<string> GetExtraChosenLanguagesGivenByAbility()
        {
            List<string> result = new List<string>();

            if (chosenLanguage1 != null)
            {
                result.Add(chosenLanguage1);
            }

            if (chosenLanguage2 != null)
            {
                result.Add(chosenLanguage2);
            }

            return result;
        }

        public override List<string> GetExtraChosenSkillProficienciesGivenByAbility()
        {
            List<string> result = new List<string>();

            if (chosenExpertise1 != null)
            {
                result.Add(chosenExpertise1);
            }

            if (chosenExpertise2 != null)
            {
                result.Add(chosenExpertise2);
            }

            return result;
        }

        public override List<string> GetExtraChosenSkillExpertiseGivenByAbility()
        {
            return GetExtraChosenSkillProficienciesGivenByAbility();
        }

        private void handleKnowledgeChoices(PlayerCharacter Character)
        {
            /* Basically we can add 2 languages of the player's choice as well as
             choose 2 proficiencies from Arcana, History, Nature, or Religion */
            GenericMultipleListChoiceForm myForm = new GenericMultipleListChoiceForm(2);
            myForm.ChoiceDescriptionText = "Choose 2 extra languages:";

            /* Lets do languages first. */
            List<string> allLanguages = CharacterFactory.getAllLanguageNames();

            /* Now pass these on... */
            myForm.setChoiceList(allLanguages, 0);
            myForm.setChoiceList(allLanguages, 1);

            if (myForm.ShowDialog() == DialogResult.OK)
            {
                chosenLanguage1 = myForm.getSelectedItem(0);
                chosenLanguage2 = myForm.getSelectedItem(1);
            }

            /* Now handle expertise given by this ability. */
            myForm = new GenericMultipleListChoiceForm(2);
            myForm.ChoiceDescriptionText = "Choose 2 doubled skill profs. :";
            List<string> myProfOptions = new List<string> { "Arcana", "History", "Nature", "Religion" };

            myForm.setChoiceList(myProfOptions, 0);
            myForm.setChoiceList(myProfOptions, 1);

            if (myForm.ShowDialog() == DialogResult.OK)
            {
                chosenExpertise1 = myForm.getSelectedItem(0);
                chosenExpertise2 = myForm.getSelectedItem(1);
            }
        }
    }

    public class DiscipleOfLifeAbility : SpecialAttribute
    {
        public DiscipleOfLifeAbility()
        {
            this.Name = "Disciple Of Life";
        }

        public override void InitializeSubscriptions(PlayerCharacter c)
        {
            c.CharacterSetupCastingForSpell += C_CharacterSetupCastingForSpell;
        }

        private void C_CharacterSetupCastingForSpell(PlayerCharacter c, PlayerSpell sp, int level)
        {
            if (sp.IsHealingSpell)
            {
                c.BonusValues.SpellExtraDiceModifiers.Add(new BonusValueModifier("Disciple Of Life", level + 2));
            }
        }
    }

    public class AcolyteOfNature : SpecialAttribute
    {
        public string selectedCantrip;
        public string selectedProficiency;

        public AcolyteOfNature()
        {
            this.Name = "Acolyte Of Nature";
        }

        public override bool ExtraChoiceOptions(out string btnText, out UserControlClassFeature.ExtraChoiceEventHandler clickHandler)
        {
            btnText = "Choose Options";
            clickHandler = new ExtraChoiceEventHandler(handleAcolyteChoices);
            return true;
        }

        public override void HandleAbilitySelected(PlayerCharacter c, out List<PlayerSpell> chosenSpells)
        {
            chosenSpells = new List<PlayerSpell>();
            chosenSpells.Add(CharacterFactory.getPlayerSpellFromString(selectedCantrip));
        }


        public override List<string> GetExtraChosenSkillProficienciesGivenByAbility()
        {
            List<string> result = new List<string>();

            if (selectedProficiency != null)
            {
                result.Add(selectedProficiency);
            }

            return result;
        }

        public override List<string> GetExtraChosenSpellsGivenByAbility()
        {
            List<string> res = new List<string>();
            if (!string.IsNullOrEmpty(selectedCantrip))
            {
                res.Add(selectedCantrip);
            }
            return res;
        }

        private void handleAcolyteChoices(PlayerCharacter Character)
        {
            /* 1. We select one druid cantrip of your choice. */
            GenericListChoiceForm myForm = new GenericListChoiceForm();
            myForm.ChoiceDescriptionText = "Choose 1 druid cantrip:";

            /* TODO : Connect this to the actual class, when the druid class has been implemented!!! */
            List<string> druidCantrips = new List<string> { "Druidcraft", "Guidance", "Mending", "Poison Spray", "Produce Flame", "Resistance", "Shillelagh", "Thorn Whip" };

            /* Now pass these on... */
            myForm.setChoiceList(druidCantrips);

            if (myForm.ShowDialog() == DialogResult.OK)
            {
                selectedCantrip = myForm.getSelectedItem();
            }

            /* 2.  Now handle extra proficiency from this ability  */
            myForm = new GenericListChoiceForm();
            myForm.ChoiceDescriptionText = "Choose 1 extra proficiency:";
            List<string> myProfOptions = new List<string> { "Animal Handling", "Nature", "Survival" };

            myForm.setChoiceList(myProfOptions);

            if (myForm.ShowDialog() == DialogResult.OK)
            {
                selectedProficiency = myForm.getSelectedItem();
            }
        }
    }

    public class PotentSpellcasting : SpecialAttribute
    {
        public PotentSpellcasting()
        {
            this.Name = "Potent Spellcasting";
        }

        public override void InitializeSubscriptions(PlayerCharacter c)
        {
            c.CharacterSetupCastingForSpell += C_CharacterSpellCast;
        }

        private void C_CharacterSpellCast(PlayerCharacter c, PlayerSpell sp, int level)
        {
            /* We add the WIS modifier to damage dealt with any cleric cantrip. */
            if (sp.IsCantrip())
            {
                if (!sp.IsHealingSpell)
                {
                    c.BonusValues.SpellExtraDiceModifiers.Add(new BonusValueModifier(this.Name, c.getModifier("WIS")));
                }
            }
        }
    }

    public class DivineStrikeLifeDomain : SpecialAttribute
    {
        public DivineStrikeLifeDomain()
        {
            this.Name = "Divine Strike(Life Domain)";
        }

        public override void InitializeSubscriptions(PlayerCharacter c)
        {
            c.AttackRoll += C_AttackRoll;
        }

        private void C_AttackRoll(PlayerCharacter c, PlayerWeapon w)
        {
            if (this.IsActive)
            {
                DieRollComponent bonus = DieRollComponent.parseFromString(this.Dice);
                c.BonusValues.AttackDamageBonusModifiers.Add(new BonusValueModifier(this.Name, bonus));
            }
        }
    }

    public class DivineStrikeNatureDomain : SpecialAttribute
    {
        public DivineStrikeNatureDomain()
        {
            this.Name = "Divine Strike(Nature Domain)";
        }

        public override void InitializeSubscriptions(PlayerCharacter c)
        {
            c.AttackRoll += C_AttackRoll;
        }

        private void C_AttackRoll(PlayerCharacter c, PlayerWeapon w)
        {
            if (this.IsActive)
            {
                DieRollComponent bonus = DieRollComponent.parseFromString(this.Dice);
                c.BonusValues.AttackDamageBonusModifiers.Add(new BonusValueModifier(this.Name, bonus));
            }
        }
    }

    public class DivineStrikeTempestDomain : SpecialAttribute
    {
        public DivineStrikeTempestDomain()
        {
            this.Name = "Divine Strike(Tempest Domain)";
        }

        public override void InitializeSubscriptions(PlayerCharacter c)
        {
            c.AttackRoll += C_AttackRoll;
        }

        private void C_AttackRoll(PlayerCharacter c, PlayerWeapon w)
        {
            if (this.IsActive)
            {
                DieRollComponent bonus = DieRollComponent.parseFromString(this.Dice);
                c.BonusValues.AttackDamageBonusModifiers.Add(new BonusValueModifier(this.Name, bonus));
            }
        }
    }

    public class DivineStrikeTrickeryDomain : SpecialAttribute
    {
        public DivineStrikeTrickeryDomain()
        {
            this.Name = "Divine Strike(Trickery Domain)";
        }

        public override void InitializeSubscriptions(PlayerCharacter c)
        {
            c.AttackRoll += C_AttackRoll;
        }

        private void C_AttackRoll(PlayerCharacter c, PlayerWeapon w)
        {
            if (this.IsActive)
            {
                DieRollComponent bonus = DieRollComponent.parseFromString(this.Dice);
                c.BonusValues.AttackDamageBonusModifiers.Add(new BonusValueModifier(this.Name, bonus));
            }
        }
    }

    public class DivineStrikeWarDomain : SpecialAttribute
    {
        public DivineStrikeWarDomain()
        {
            this.Name = "Divine Strike(War Domain)";
        }

        public override void InitializeSubscriptions(PlayerCharacter c)
        {
            c.AttackRoll += C_AttackRoll;
        }

        private void C_AttackRoll(PlayerCharacter c, PlayerWeapon w)
        {
            if (this.IsActive)
            {
                DieRollComponent bonus = DieRollComponent.parseFromString(this.Dice);
                c.BonusValues.AttackDamageBonusModifiers.Add(new BonusValueModifier(this.Name, bonus));
            }
        }
    }

    public class SupremeHealing : SpecialAttribute
    {
        public SupremeHealing()
        {
            this.Name = "Supreme Healing";
        }

        public override void InitializeSubscriptions(PlayerCharacter c)
        {
            c.SpellDiceOverride = new PlayerCharacter.PlayerSpellDiceOverrideEvent(spellDiceOverrideFunc);
        }

        private bool spellDiceOverrideFunc(PlayerSpell spell, int level, PlayerCharacter c, out List<DieRollComponent> roll)
        {
            roll = new List<DieRollComponent>();
            try
            {
                List<DieRollComponent> originalRoll = spell.getDiceForSpellLevel(level);
                if (spell.IsHealingSpell && originalRoll.Count > 0)
                {
                    foreach(DieRollComponent d in originalRoll)
                    {
                        if (d is DieRoll)
                        {
                            DieRoll conv = d as DieRoll;
                            roll.Add(new DieRollConstant(conv.DieType * conv.NumberOfDice));
                        }
                        else
                        {
                            roll.Add(d);
                        }
                    }
                    return true;
                }
                else
                {
                    /* Return empty list */
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

