using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /* Soo this is pretty experimental. We are going to be trying this out. */

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

        public override void HandleAbilitySelected(PlayerCharacter c)
        {
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

        /* TODO : Take into account resistance to bludgeoning, piercing and slashing damage. */
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
            if(c.Level < 13)
            {
                c.BonusValues.ExtraCriticalDamageModifiers.Add(new BonusValueModifier("Brutal critical", damageDie));
            }
            else if(c.Level < 17)
            {

            }
            else
            {

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
}

