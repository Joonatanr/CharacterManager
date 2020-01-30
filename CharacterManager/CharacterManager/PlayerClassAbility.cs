using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager
{
    /* Soo this is pretty experimental. We are going to be trying this out. */
    public abstract class PlayerClassAbility : PlayerAbility
    {
        public abstract String Title { get; }

        public static PlayerClassAbility resolveFromString(String s)
        {
            object raw;
            try
            {
                Type t = Type.GetType(s);
                raw = Activator.CreateInstance(t);
            }
            catch (Exception)
            {
                return null;
            }

            if (raw is PlayerClassAbility)
            {
                return (PlayerClassAbility)raw;
            }
            else
            {
                return null;
            }
        }
    }


    /******* Fighter class abilities. ********/

    /* Fighting Styles */
    public class FightingStyleArchery : PlayerClassAbility
    {
        public override string Title { get { return "Archery"; } }

        public FightingStyleArchery()
        {
            this.AttributeName = "Archery Fighting Style";
            this.Description = "You gain a +2 bonus to attack rolls you make with ranged weapons.";
        }

        /* TODO : Create mechanics for actually taking this ability into account. */
    }

    public class FightingStyleDefense : PlayerClassAbility
    {
        public override string Title { get { return "Defense"; } }

        public FightingStyleDefense()
        {
            this.AttributeName = "Defense Fighting Style";
            this.Description = "While you are wearing armor, you gain a +1 bonus to AC.";
        }

        /* TODO : Create mechanics for actually taking this ability into account. */
    }

    public class FightingStyleGreatWeapon : PlayerClassAbility
    {
        public override string Title { get { return "Great Weapon Fighting"; } }

        public FightingStyleGreatWeapon()
        {
            this.AttributeName = "Great Weapon Fighting Style";
            this.Description = "When you roll a 1 or 2 on a damage die for an attack you make with a melee weapon that you are wielding with two hands, you can reroll the die and must use the new roll, even if the new roll is a 1 or a 2. " +
                "The weapon must have the two-handed or versatile property for you to gain this benefit.";
        }

        /* TODO : Create mechanics for actually taking this ability into account. */
    }

    public class FightingStyleProtection : PlayerClassAbility
    {
        public override string Title { get { return "Protection"; } }

        public FightingStyleProtection()
        {
            this.AttributeName = "Protection Fighting Style";
            this.Description = "When a creature you can see attacks a target other than you that is within 5 feet of you, you can use your reaction to impose disadvantage on the attack roll. You must be wielding a shield.";
        }

        /* TODO : Create mechanics for actually taking this ability into account. */
    }

    public class FightingStyleTwoWeapon : PlayerClassAbility
    {
        public override string Title { get { return "Two-Weapon Fighting"; } }

        public FightingStyleTwoWeapon()
        {
            this.AttributeName = "Two Weapon Fighting Style";
            this.Description = "When you engage in two-weapon fighting, you can add your ability modifier to the damage of the second attack.";
        }

        /* TODO : Create mechanics for actually taking this ability into account. */
    }
}
