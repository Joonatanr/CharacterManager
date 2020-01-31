using CharacterManager.SpecialAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public override void updateCharacterDuringCreation(PlayerCharacter character)
        {
            //throw new NotImplementedException();
        }

        public override void updateCharacterDuringLevelUp(PlayerCharacter character)
        {
            //throw new NotImplementedException();
        }

        /* TODO : Create mechanics for actually taking this ability into account. */
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
                c.AcBonus++;
            }
        }

        public override void updateCharacterDuringCreation(PlayerCharacter character)
        {
            //throw new NotImplementedException();
        }

        public override void updateCharacterDuringLevelUp(PlayerCharacter character)
        {
            //throw new NotImplementedException();
        }

        /* TODO : Create mechanics for actually taking this ability into account. */
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

        public override void updateCharacterDuringCreation(PlayerCharacter character)
        {
            //throw new NotImplementedException();
        }

        public override void updateCharacterDuringLevelUp(PlayerCharacter character)
        {
            //throw new NotImplementedException();
        }

        /* TODO : Create mechanics for actually taking this ability into account. */
    }

    public class FightingStyleDueling : SpecialAttribute
    {
        public override string DisplayedName { get { return "Dueling Fighting Style"; } }

        public FightingStyleDueling()
        {
            this.AttributeName = "Dueling Fighting Style";
            this.Description = "When you are wielding a melee w eapon in one hand and no other w eapons, you gain a +2 bonus to damage rolls " +
                "with that weapon.";
        }

        public override void updateCharacterDuringCreation(PlayerCharacter character)
        {
            //throw new NotImplementedException();
        }

        public override void updateCharacterDuringLevelUp(PlayerCharacter character)
        {
            //throw new NotImplementedException();
        }

        /* TODO : Create mechanics for actually taking this ability into account. */
    }

    public class FightingStyleProtection : SpecialAttribute
    {
        public override string DisplayedName { get { return "Protection Fighting Style"; } }

        public FightingStyleProtection()
        {
            this.AttributeName = "Protection Fighting Style";
            this.Description = "When a creature you can see attacks a target other than you that is within 5 feet of you, you can use your reaction to impose disadvantage on the attack roll. You must be wielding a shield.";
        }

        public override void updateCharacterDuringCreation(PlayerCharacter character)
        {
            //throw new NotImplementedException();
        }

        public override void updateCharacterDuringLevelUp(PlayerCharacter character)
        {
            //throw new NotImplementedException();
        }

        /* TODO : Create mechanics for actually taking this ability into account. */
    }

    public class FightingStyleTwoWeapon : SpecialAttribute
    {
        public override string DisplayedName { get { return "Two-Weapon Fighting"; } }

        public FightingStyleTwoWeapon()
        {
            this.AttributeName = "Two-Weapon Fighting Style";
            this.Description = "When you engage in two-weapon fighting, you can add your ability modifier to the damage of the second attack.";
        }

        public override void updateCharacterDuringCreation(PlayerCharacter character)
        {
            //throw new NotImplementedException();
        }

        public override void updateCharacterDuringLevelUp(PlayerCharacter character)
        {
            //throw new NotImplementedException();
        }

        /* TODO : Create mechanics for actually taking this ability into account. */
    }
}
