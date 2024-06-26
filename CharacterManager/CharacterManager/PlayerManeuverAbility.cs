﻿using CharacterManager.SpecialAttributes;
using CharacterManager.UserControls;
using CharacterManager.UserControls.Levelup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static CharacterManager.CharacterCreator.UserControlClassFeature;

namespace CharacterManager
{
    [Serializable]
    public class PlayerManeuverAbility : PlayerAbility
    {
        public List<string> AvailableManeuvers = new List<string>();
        public List<string> ChosenManeuvers = new List<string>();


        public string DcAbility = "STR";
        public string ManeuverListTitle = "Maneuvers";
        public string ChargesDisplayedName = "Charges";

        /* Some maneuver abilities are static. By default we assume that choices are available. */
        public bool IsManeuverChoiceAvailable = true;

        public int AvailableManeuversAtLevel1 = 0;
        public int AvailableManeuversAtLevel2 = 0;
        public int AvailableManeuversAtLevel3 = 0;
        public int AvailableManeuversAtLevel4 = 0;
        public int AvailableManeuversAtLevel5 = 0;
        public int AvailableManeuversAtLevel6 = 0;
        public int AvailableManeuversAtLevel7 = 0;
        public int AvailableManeuversAtLevel8 = 0;
        public int AvailableManeuversAtLevel9 = 0;
        public int AvailableManeuversAtLevel10 = 0;
        public int AvailableManeuversAtLevel11 = 0;
        public int AvailableManeuversAtLevel12 = 0;
        public int AvailableManeuversAtLevel13 = 0;
        public int AvailableManeuversAtLevel14 = 0;
        public int AvailableManeuversAtLevel15 = 0;
        public int AvailableManeuversAtLevel16 = 0;
        public int AvailableManeuversAtLevel17 = 0;
        public int AvailableManeuversAtLevel18 = 0;
        public int AvailableManeuversAtLevel19 = 0;
        public int AvailableManeuversAtLevel20 = 0;

        [XmlIgnore]
        public List<CombatManeuver> AvailableManeuverObjects
        {
            get
            {
                List<CombatManeuver> res = new List<CombatManeuver>();
                foreach(string maneuverString in AvailableManeuvers)
                {
                    res.Add(CharacterFactory.getCombatManeuverByName(maneuverString));
                }

                return res;
            }
        }

        [XmlIgnore]
        public List<CombatManeuver> ChosenManeuverObjects
        {
            get
            {
                List<CombatManeuver> res = new List<CombatManeuver>();
                foreach (string maneuverString in ChosenManeuvers)
                {
                    res.Add(CharacterFactory.getCombatManeuverByName(maneuverString));
                }

                return res;
            }
        }


        /* TODO : We should notifiy if the user has not selected all available maneuvers. */

        public override bool ExtraChoiceOptions(out string btnText, out ExtraChoiceEventHandler clickHandler)
        {
            if (IsManeuverChoiceAvailable)
            {
                btnText = "Choose Maneuvers";
                clickHandler = new ExtraChoiceEventHandler(handleManeuverChoice);
                return true;
            }
            else
            {
                /* Static maneuver ability. No choices to be made here. */
                clickHandler = null;
                btnText = "";
                return false;
            }
        }


        /* So somehow we should return a list of new maneuvers through this interface.... */
        public override List<PlayerClassAbilityChoice> GetUpgradeChoicesForLevel(int level)
        {
            List<PlayerClassAbilityChoice> res = new List<PlayerClassAbilityChoice>();
            if (getAvailableChoicesAtLevel(level) > 0)
            {
                PlayerClassAbilityChoice choice = new PlayerClassAbilityChoice();
                choice.ClassAbilityName = this.Name;
                choice.Description = this.Description;
                choice.AvailableChoices.Add(this.Name);
                res.Add(choice);
            }

            res.AddRange(base.GetUpgradeChoicesForLevel(level));
            return res;
        }


        public int getAvailableChoicesAtLevel(int level)
        {
            switch (level)
            {
                case 1:
                    return AvailableManeuversAtLevel1;
                case 2:
                    return AvailableManeuversAtLevel2;
                case 3:
                    return AvailableManeuversAtLevel3;
                case 4:
                    return AvailableManeuversAtLevel4;
                case 5:
                    return AvailableManeuversAtLevel5;
                case 6:
                    return AvailableManeuversAtLevel6;
                case 7:
                    return AvailableManeuversAtLevel7;
                case 8:
                    return AvailableManeuversAtLevel8;
                case 9:
                    return AvailableManeuversAtLevel9;
                case 10:
                    return AvailableManeuversAtLevel10;
                case 11:
                    return AvailableManeuversAtLevel11;
                case 12:
                    return AvailableManeuversAtLevel12;
                case 13:
                    return AvailableManeuversAtLevel13;
                case 14:
                    return AvailableManeuversAtLevel14;
                case 15:
                    return AvailableManeuversAtLevel15;
                case 16:
                    return AvailableManeuversAtLevel16;
                case 17:
                    return AvailableManeuversAtLevel17;
                case 18:
                    return AvailableManeuversAtLevel18;
                case 19:
                    return AvailableManeuversAtLevel19;
                case 20:
                    return AvailableManeuversAtLevel20;
                default:
                    return 0;
            }
        }

        public override PlayerAbilityDescriptor ConvertToDescriptor()
        {
            PlayerAbilityDescriptor desc = base.ConvertToDescriptor();

            desc.Options1 = new List<string>();

            List<CombatManeuver> chosenManeuvers = GetAllChosenManeuvers();

            if (chosenManeuvers != null)
            {
                foreach (CombatManeuver maneuver in chosenManeuvers)
                {
                    desc.Options1.Add(maneuver.ManeuverName);
                }
            }

            return desc;
        }

        public override void ResolveFromDescriptor(PlayerAbilityDescriptor desc)
        {
            base.ResolveFromDescriptor(desc);
            ChosenManeuvers = desc.Options1;
        }

        public override void HandleInfoButtonClicked(object sender, EventArgs e)
        {
            FormUseCombatManeuver myInfoForm = new FormUseCombatManeuver();
            myInfoForm.ManeuverAbility = this;
            myInfoForm.Show();
        }

        public override List<BonusValueModifier> getDifficultyClass()
        {
            List<BonusValueModifier> modifiers = new List<BonusValueModifier>();

            if (_connectedCharacter != null)
            {
                modifiers.Add(new BonusValueModifier("Base", 8));
                if (DcAbility == "STR") /* For combat maneuvers we use highest value of either STR or DEX*/
                {
                    int dexMod = _connectedCharacter.getModifier("DEX");
                    int strMod = _connectedCharacter.getModifier("STR");                    

                    if (strMod >= dexMod)
                    {
                        modifiers.Add(new BonusValueModifier("STR bonus", strMod));
                    }
                    else
                    {
                        modifiers.Add(new BonusValueModifier("DEX bonus", dexMod));
                    }
                }
                else
                {
                    int abilityMod = _connectedCharacter.getModifier(DcAbility);
                    modifiers.Add(new BonusValueModifier(DcAbility + "bonus", abilityMod));
                }

                modifiers.Add(new BonusValueModifier("Proficiency Bonus", _connectedCharacter.ProficiencyBonus));
            }
            return modifiers;
        }

        public void AddNewManeuver(CombatManeuver maneuver)
        {
            AddNewManeuver(maneuver.ManeuverName);
        }

        public void AddNewManeuver(string name)
        {
            if (!ChosenManeuvers.Contains(name))
            {
                ChosenManeuvers.Add(name);
            }
        }

        public void SetManeuverList(List<string> maneuvers)
        {
            ChosenManeuvers = maneuvers;
        }

        public List<CombatManeuver> GetAllChosenManeuvers()
        {
            if (IsManeuverChoiceAvailable)
            {
                return ChosenManeuverObjects;
            }
            else
            {
                /* We return all available maneuvers. The thing is we might have received some extra maneuvers here through abilities etc. */
                List<CombatManeuver> res = new List<CombatManeuver>();
                res.AddRange(AvailableManeuverObjects);
                res.AddRange(ChosenManeuverObjects);
                res = res.Distinct().ToList();

                return res;
            }
        }


        public override List<BonusValueModifier> getSituationalDamageModifiers()
        {
            List<BonusValueModifier> res = new List<BonusValueModifier>();

            res.Add(new BonusValueModifier("Superiority Die", this.Dice));

            return res;
        }

        private void handleManeuverChoice(PlayerCharacter Character)
        {
            FormChooseCombatManeuvers myForm = new FormChooseCombatManeuvers();
            myForm.ManeuverAbility = this;
            myForm.Character = Character;
            myForm.Show();
        }
    }
}
