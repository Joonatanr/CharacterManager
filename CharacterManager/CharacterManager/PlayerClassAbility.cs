using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterManager
{
    /* Soo this is pretty experimental. We are going to be trying this out. */
    public abstract class PlayerClassAbility : PlayerAbility
    {
        public static PlayerClassAbility resolveFromString(String s, String Description)
        {
            object raw;
            try
            {
                Type t = Type.GetType("CharacterManager." + s);
                if (t == null)
                {
                    return new GenericClassAbility(s, Description);
                }

                /* Lets try to actually create the instance of this particular class. */
                raw = Activator.CreateInstance(t);

                /* If this is not true, then something has gone really wrong. */
                if (raw is PlayerClassAbility)
                {
                    return (PlayerClassAbility)raw;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); /* TODO : Remove this. */
                /* It seems we do not have a corresponding type. Return generic instead. */
                return null;
            }
        }
    }

    public class GenericClassAbility : PlayerClassAbility
    {
        //public override string Title { get { return AttributeName; } }
        
        public GenericClassAbility(String name, String Description)
        {
            this.AttributeName = name;
            this.Description = Description;
        }
    }

    /******* Fighter class abilities. ********/

    /* Fighting Styles */
    public class FightingStyleArchery : PlayerClassAbility
    {
        public override string DisplayedName { get { return "Archery"; } }

        public FightingStyleArchery()
        {
            this.AttributeName = "FightingStyleArchery";
            this.Description = "You gain a +2 bonus to attack rolls you make with ranged weapons.";
        }

        /* TODO : Create mechanics for actually taking this ability into account. */
    }

    public class FightingStyleDefense : PlayerClassAbility
    {
        public override string DisplayedName { get { return "Defense"; } }

        public FightingStyleDefense()
        {
            this.AttributeName = "FightingStyleDefense";
            this.Description = "While you are wearing armor, you gain a +1 bonus to AC.";
        }

        /* TODO : Create mechanics for actually taking this ability into account. */
    }

    public class FightingStyleGreatWeapon : PlayerClassAbility
    {
        public override string DisplayedName { get { return "Great Weapon Fighting"; } }

        public FightingStyleGreatWeapon()
        {
            this.AttributeName = "FightingStyleGreatWeapon";
            this.Description = "When you roll a 1 or 2 on a damage die for an attack you make with a melee weapon that you are wielding with two hands, you can reroll the die and must use the new roll, even if the new roll is a 1 or a 2. " +
                "The weapon must have the two-handed or versatile property for you to gain this benefit.";
        }

        /* TODO : Create mechanics for actually taking this ability into account. */
    }

    public class FightingStyleProtection : PlayerClassAbility
    {
        public override string DisplayedName { get { return "Protection"; } }

        public FightingStyleProtection()
        {
            this.AttributeName = "FightingStyleProtection";
            this.Description = "When a creature you can see attacks a target other than you that is within 5 feet of you, you can use your reaction to impose disadvantage on the attack roll. You must be wielding a shield.";
        }

        /* TODO : Create mechanics for actually taking this ability into account. */
    }

    public class FightingStyleTwoWeapon : PlayerClassAbility
    {
        public override string DisplayedName { get { return "Two-Weapon Fighting"; } }

        public FightingStyleTwoWeapon()
        {
            this.AttributeName = "FightingStyleTwoWeapon";
            this.Description = "When you engage in two-weapon fighting, you can add your ability modifier to the damage of the second attack.";
        }

        /* TODO : Create mechanics for actually taking this ability into account. */
    }
}
