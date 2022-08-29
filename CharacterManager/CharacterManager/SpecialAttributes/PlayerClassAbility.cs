using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharacterManager.Items;
using CharacterManager.SpecialAttributes;
using CharacterManager.UserControls;

namespace CharacterManager
{
    /* Soo this is pretty experimental. We are going to be trying this out. */

    /******* Fighter class abilities. ********/

    /* Fighting Styles */
    public class FightingStyleArchery : SpecialAttribute
    {
        public FightingStyleArchery()
        {
            this.AttributeName = "Archery Fighting Style";
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
            this.AttributeName = "Defense Fighting Style";
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
            this.AttributeName = "Great Weapon Fighting Style";
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

    public class FightingStyleDueling : SpecialAttribute
    {
        public override string DisplayedName { get { return "Dueling Fighting Style"; } }

        public FightingStyleDueling()
        {
            this.AttributeName = "Dueling Fighting Style";
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
            foreach(PlayerWeapon weapon in c.CharacterWeapons)
            {
                if (weapon.IsEquipped && weapon != w)
                {
                    isOnlyOneEquipped = false;
                }
            }

            if (isOnlyOneEquipped && (w.IsEquippedTwoHanded == false))
            {
                //c.BonusValues.AttackRollBonus += 2;
                c.BonusValues.AttackRollBonusModifiers.Add(new BonusValueModifier("Dueling Fighting Style", 2));
            }
        }
    }

    public class FightingStyleProtection : SpecialAttribute
    {
        public override string DisplayedName { get { return "Protection Fighting Style"; } }

        public FightingStyleProtection()
        {
            this.AttributeName = "Protection Fighting Style";
            this.Description = "When a creature you can see attacks a target other than you that is within 5 feet of you, you can use your reaction to impose disadvantage on the attack roll. You must be wielding a shield.";
        }
    }

    public class FightingStyleTwoWeapon : SpecialAttribute
    {
        public override string DisplayedName { get { return "Two-Weapon Fighting"; } }

        public FightingStyleTwoWeapon()
        {
            this.AttributeName = "Two-Weapon Fighting Style";
            this.Description = "When you engage in two-weapon fighting, you can add your ability modifier to the damage of the second attack.";
        }

        /* TODO : Create mechanics for actually taking this ability into account. - This will need two weapon wielding to be implemented first. */
    }

    public class SecondWindAbility : SpecialAttribute
    {
        public SecondWindAbility()
        {
            this.AttributeName = "Second Wind";
        }

        public override bool UseAbility(PlayerCharacter c)
        {
            FormUseAbility myForm = new FormUseAbility();

            /* TODO : Can't we get this in some other manner??? The ability itself should have the description... */
            myForm.Description = "Restore 1d10 + your fighter level";
            myForm.AbilityName = "Second Wind";

            List<BonusValueModifier> rollComponents = new List<BonusValueModifier>();
            rollComponents.Add(new BonusValueModifier("Level", c.Level));
            rollComponents.Add(new BonusValueModifier("Second wind die", "1d10"));
            myForm.DieRollModifiers = rollComponents;

            if (myForm.ShowDialog() == DialogResult.OK)
            {
                c.CurrentHitPoints = Math.Min(c.MaxHitPoints, myForm.RollResult + c.CurrentHitPoints);
                return true;
            }
            else
            {
                return false;
            }
        }
    }


    /*********************************************************************************************/

    /******* Barbarian class abilities. ********/
    public class RageAbility : SpecialAttribute
    {
        public RageAbility()
        {
            this.AttributeName = "Rage";
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
                else if(c.Level >= 16)
                {
                    bonus = 4;
                }

                if (!w.IsRanged)
                {
                    //c.BonusValues.AttackDamageBonus += bonus;
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
            this.AttributeName = "Unarmored Defense";
        }

        public override void InitializeSubscriptions(PlayerCharacter c)
        {
            c.ArmorDonned += C_ArmorDonned;
        }

        private void C_ArmorDonned(PlayerCharacter c)
        {
            if (!c.isArmorWorn)
            {
                //c.BonusValues.AcBonus += c.getModifier("CON");
                c.BonusValues.AcBonusModifiers.Add(new BonusValueModifier("Unarmored Defense", c.getModifier("CON")));
            }
        }
    }

}
