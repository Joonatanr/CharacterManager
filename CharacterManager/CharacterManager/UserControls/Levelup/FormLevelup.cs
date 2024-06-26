﻿using CharacterManager.CharacterCreator;
using CharacterManager.SpecialAttributes;
using CharacterManager.Spells;
using CharacterManager.UserControls.Levelup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterManager.UserControls
{
    public partial class FormLevelup : Form
    {
        private PlayerCharacter _myCharacter;
        private int prevMaxHp;

        private List<PlayerAbility> SelectedPlayerAbilities = new List<PlayerAbility>();
        private List<string> SelectedSpellNames = new List<string>();

        private bool isSettingInitialValuesForBaseAttributes = true;

        private int numberOfSkillProfChoices = 0;
        private int numberOfSkillExpertiseChoices = 0;

        private List<string> newSelectedProficiencies = new List<string>();
        private List<string> newSelectedExpertise = new List<string>();

        public PlayerCharacter Character
        {
            set
            {
                _myCharacter = value;
                setupLevelUp();
            }

            get
            {
                return _myCharacter;
            }
        }
        
        public FormLevelup()
        {
            InitializeComponent();
        }

        public FormLevelup(PlayerCharacter character) : this()
        {
            _myCharacter = character;
            setupLevelUp();
        }



        private void setupLevelUp()
        {
            /* 1. Set up hit points */
            setupHitpoints();

            /* 2. Set up new player abilities. */
            setupNewPlayerAbilities();

            /* 3. Set up already known spells. */
            SelectedSpellNames = _myCharacter.KnownSpells;

            /* 4. Set up base attributes. */
            numericUpDownSTR.Value = _myCharacter.StrengthAttribute;
            numericUpDownSTR.Minimum = _myCharacter.StrengthAttribute;

            numericUpDownDEX.Value = _myCharacter.DexAttribute;
            numericUpDownDEX.Minimum = _myCharacter.DexAttribute;

            numericUpDownCON.Value = _myCharacter.ConAttribute;
            numericUpDownCON.Minimum = _myCharacter.ConAttribute;

            numericUpDownINT.Value = _myCharacter.IntAttribute;
            numericUpDownINT.Minimum = _myCharacter.IntAttribute;

            numericUpDownWIS.Value = _myCharacter.WisAttribute;
            numericUpDownWIS.Minimum = _myCharacter.WisAttribute;

            numericUpDownCHA.Value = _myCharacter.CharAttribute;
            numericUpDownCHA.Minimum = _myCharacter.CharAttribute;

            if (!_myCharacter.GetPlayerClass().IsAbilityScoreImprovementAtLevel(_myCharacter.Level))
            {
                numericUpDownSTR.Enabled = false;
                numericUpDownDEX.Enabled = false;
                numericUpDownCON.Enabled = false;
                numericUpDownINT.Enabled = false;
                numericUpDownWIS.Enabled = false;
                numericUpDownCHA.Enabled = false;
            }
            else
            {
                labelRemainingAttributePoints.Text = "Remaining Points: 2";

                numericUpDownSTR.Maximum = _myCharacter.StrengthAttribute + 2;
                numericUpDownDEX.Maximum = _myCharacter.DexAttribute + 2;
                numericUpDownCON.Maximum = _myCharacter.ConAttribute + 2;
                numericUpDownINT.Maximum = _myCharacter.IntAttribute + 2;
                numericUpDownWIS.Maximum = _myCharacter.WisAttribute + 2;
                numericUpDownCHA.Maximum = _myCharacter.CharAttribute + 2;
            }

            isSettingInitialValuesForBaseAttributes = false;
        }

        private void setupHitpoints()
        {
            prevMaxHp = _myCharacter.MaxHitPoints;
            labelNewMaxHP.Text = prevMaxHp.ToString();

            PlayerClass myClass = _myCharacter.GetPlayerClass();
            int hitDie = myClass.HitDie;

            DieRoll hitDieRoll = new DieRoll(1, hitDie);
            _myCharacter.BonusValues.HitPointLevelupModifiers.Add(new BonusValueModifier("Hit die", hitDieRoll));
            _myCharacter.BonusValues.HitPointLevelupModifiers.Add(new BonusValueModifier("CON bonus", _myCharacter.getModifier("CON")));

            DieRollEquation equation = BonusValueModifier.GetEquationFromList(_myCharacter.BonusValues.HitPointLevelupModifiers);
            equation.ReduceConstants();

            dieRollHitPointsRoll.DieRollObject = equation;
        }

        private void setupNewPlayerAbilities()
        {
            int newLevel = _myCharacter.Level;
            List<PlayerClassAbilityChoice> abilityChoices = _myCharacter.GetPlayerClass().getAvailableClassAbilities(newLevel);

            if (_myCharacter != null)
            {
                PlayerClassArchetype existing = _myCharacter.GetSelectedArchetype();
                if (existing != null)
                {
                    abilityChoices.AddRange(existing.getAbilityChoicesByLevel(_myCharacter.Level));
                }

                foreach(PlayerAbility ability in _myCharacter.CharacterAbilitiesObjectList)
                {
                    abilityChoices.AddRange(ability.GetUpgradeChoicesForLevel(_myCharacter.Level));
                }
            }

            if (abilityChoices.Count > 0)
            {
                /* We set up the current abilities. */
                /* TODO : Add a way to visually distinguish between current and new abilities. */
                userControlGenericAbilitiesList1.setAttributeList(_myCharacter.CharacterAbilitiesObjectList);

                /* Lets add all abilities for which there is only a single choice already to the list. */
                SelectedPlayerAbilities = new List<PlayerAbility>();

                foreach(PlayerClassAbilityChoice choice in abilityChoices)
                {
                    if(choice.AvailableChoices.Count == 1)
                    {
                        SelectedPlayerAbilities.Add(choice.getAllClassAbilityChoices()[0]);
                    }
                }
                setCombinedAbilitiesDisplay();
            } 
            else
            {
                /* TODO : Placeholder. */
                buttonSelectNewAbilities.Enabled = false;
            }
        }

        private void setCombinedAbilitiesDisplay()
        {
            List<PlayerAbility> combinedList = new List<PlayerAbility>();
            combinedList.AddRange(SelectedPlayerAbilities);
            combinedList.AddRange(_myCharacter.CharacterAbilitiesObjectList);
            userControlGenericAbilitiesList1.setAttributeList(combinedList);
        }

        private void finalizeCharacter()
        {
            /* 1. Handle any new language and tool proficiencies that have been added */
            finalizeNewProficiencies();
            /* 2. Handle all the spells that have been chosen by the ordinary spell selection mechanism. */
            finalizeSpellselections();

            /* 3. Handle all new abilities and update the character ability list. */
            _myCharacter.setupCharacterNewAbilitiesList(SelectedPlayerAbilities);

            /* 4. Update character main attributes. */
            finalizeCharacterAttributes();

            /* 5. Update the proficiency bonus if applicable */
            updateProficiencyBonus();
        }


        private void finalizeCharacterAttributes()
        {
            /* Check if CON score has been raised. NOTE that this is a special case. */
            if (CharacterFactory.getAbilityModifierValue((int)numericUpDownCON.Value) > _myCharacter.getModifier("CON"))
            {
                /* In this case we increase the HP for each previous level. */
                _myCharacter.MaxHitPoints += _myCharacter.Level;
            }

            /* Update HP. */
            _myCharacter.CurrentHitPoints += (_myCharacter.MaxHitPoints - prevMaxHp);

            /* Update base attributes. */
            _myCharacter.StrengthAttribute = (int)numericUpDownSTR.Value;
            _myCharacter.DexAttribute = (int)numericUpDownDEX.Value;
            _myCharacter.ConAttribute = (int)numericUpDownCON.Value;
            _myCharacter.IntAttribute = (int)numericUpDownINT.Value;
            _myCharacter.WisAttribute = (int)numericUpDownWIS.Value;
            _myCharacter.CharAttribute = (int)numericUpDownCHA.Value;

            /* We definitely get a new hit die with a new level. */
            _myCharacter.CurrentHitDice++;
        }



        private void finalizeNewProficiencies()
        {
            _myCharacter.SkillProficiencies.AddRange(newSelectedProficiencies);
            _myCharacter.SkillExpertise.AddRange(newSelectedExpertise);
        }

        private void finalizeSpellselections()
        {
            /* Here is the issue : Even if all spells are available, then not all cantrips are...
             Soo.. even if we are rebuilding the whole spell list, then we need to preserve cantrip data for this particular case. */
            List<string> knownCantrips = _myCharacter.KnownCantrips;

            /* We reset the known spells here and start rebuilding this information. 
                Spells will be updated based on player selection as well as abilities that can provide new spells. */
            _myCharacter.ResetAllKnownSpells();

            /* Update spell data. */
            if (_myCharacter.SpellCasting != null)
            { 
                if (_myCharacter.SpellCasting.IsAllSpellsAvailable && (_myCharacter.SpellCasting.GetNewCantripsLearnedAtLevel(_myCharacter.Level) == 0))
                {
                    List<PlayerSpell> allSpells = _myCharacter.SpellCasting.GetSpellsThatCanBeLearnedAtLevel(_myCharacter.Level);

                    foreach (PlayerSpell sp in allSpells)
                    {
                        _myCharacter.AddSpell(sp, false);
                    }

                    foreach(string knownCantrip in knownCantrips)
                    {
                        _myCharacter.AddSpell(knownCantrip, false);
                    }
                }
                else
                {
                    /* Update the spell selections. */
                    foreach (string spellName in SelectedSpellNames)
                    {
                        _myCharacter.AddSpell(spellName, false);
                    }
                }
                /* Update spell slot amount. */
                SpellSlots_T slotsForThisLevel = _myCharacter.SpellCasting.getSpellSlotDataForLevel(_myCharacter.Level);

                for (int SpellLevel = 1; SpellLevel <= 9; SpellLevel++)
                {
                    int numberOfSlots = slotsForThisLevel.getNumberOfSlotsPerLevel(SpellLevel);
                    _myCharacter.setSpellSlotData(SpellLevel, new CharacterSpellcastingStatus.SpellSlotData(numberOfSlots, numberOfSlots));
                }
            }
        }


        private void updateProficiencyBonus()
        {
            /* Update proficiency bonus... Pretty straightforward this one. */
            if (_myCharacter.Level == 5)
            {
                _myCharacter.ProficiencyBonus = 3;
            }

            if (_myCharacter.Level == 9)
            {
                _myCharacter.ProficiencyBonus = 4;
            }

            if (_myCharacter.Level == 13)
            {
                _myCharacter.ProficiencyBonus = 5;
            }

            if (_myCharacter.Level == 17)
            {
                _myCharacter.ProficiencyBonus = 6;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            finalizeCharacter();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string dummy;
            textBoxHPResult.Text = dieRollHitPointsRoll.Roll(out dummy).ToString();
        }

        private void textBoxHPResult_TextChanged(object sender, EventArgs e)
        {
            int val;
            
            if(int.TryParse(textBoxHPResult.Text, out val))
            {
                _myCharacter.MaxHitPoints = val + prevMaxHp;
                labelNewMaxHP.Text = _myCharacter.MaxHitPoints.ToString();
            }
        }


        private void buttonSelectNewAbilities_Click(object sender, EventArgs e)
        {
            /* TODO : Decide on this -> If there are no choices, then is a form really necessary??? 
             Perhaps in this case, we should simply add the new abilities anyway. */
            
            FormChooseClassFeatures myForm = new FormChooseClassFeatures();
            myForm.setPlayerCharacter(_myCharacter);

            myForm.ShowDialog();
            if(myForm.DialogResult == DialogResult.OK)
            {
                /* We don't add the new abilities to the character yet. This we will do when levelup is finalized. */

                List<PlayerAbility> _selectedAbilities = myForm.getAllSelectedAbilities();
                SelectedPlayerAbilities = new List<PlayerAbility>();


                PlayerClass pClass = _myCharacter.GetPlayerClass();
                PlayerClassArchetype sClass = _myCharacter.GetPlayerSubClass();

                /* We might have chosen a new archetype. */
                foreach(PlayerAbility selected in _selectedAbilities)
                {
                    if (selected is PlayerClassArchetype)
                    {
                        sClass = (PlayerClassArchetype)selected;
                        break;
                    }
                }

                foreach(PlayerAbility selected in _selectedAbilities)
                {
                    if(selected.Name.ToLower() == "spellcasting")
                    {
                        /* We need to determine if the spellcasting came from an archetype or not. Half casters might get spellcasting at second level. */
                        SelectedPlayerAbilities.Add(CharacterFactory.GetSpellCastingAbilityOfClass(pClass, sClass));
                    }
                    else
                    {
                        SelectedPlayerAbilities.Add(selected);
                    }
                }
                
                setCombinedAbilitiesDisplay();
                setSkillProficiencyChoicesFromAbilities();
            }
        }



        private void setSkillProficiencyChoicesFromAbilities()
        {
            numberOfSkillProfChoices = 0;
            numberOfSkillExpertiseChoices = 0;

            newSelectedExpertise = new List<string>();
            newSelectedProficiencies = new List<string>();

            foreach (PlayerAbility ab in SelectedPlayerAbilities)
            {
                numberOfSkillProfChoices += ab.AdditionalProficiencyChoices;
                numberOfSkillExpertiseChoices += ab.AdditionalExpertiseChoices;
            }
        }

        private void buttonSelectNewSpells_Click(object sender, EventArgs e)
        {
            PlayerClass _myClass = _myCharacter.GetPlayerClass();
            PlayerClassArchetype _mySubclass = _myCharacter.GetPlayerSubClass();

            /* Lets first check if there are any chosen abilities that could give our character a spellcasting ability... */
            /* For now lets just consider archetypes. */

            PlayerAbility selectedSpellcastingAbility = SelectedPlayerAbilities.Find(a => a.Name.ToLower() == "spellcasting");
            SpellcastingAbility selectedSpellcasting = null;
            
            if (selectedSpellcastingAbility != null)
            {
                /* We have selected an ability (presumably an archetype) that will give us spellcasting. */
                /* TODO : Maybe there is some other way of gaining spellcasting? */
                PlayerAbility archeType = SelectedPlayerAbilities.Find(a => a is PlayerClassArchetype);
                if (archeType != null)
                {
                    _mySubclass = (PlayerClassArchetype)archeType;
                    selectedSpellcasting = _mySubclass.SpellCasting;
                }
                else
                {
                    /* TODO : Analyze this solution. Might not be the best way to solve this.... Maybe things like possible spells and slots should be directly derived from the spellcasting ability itself??? */
                    /* In this case it can be presumed that the spellcasting is NOT dependent on a new archetype.... Assume it came directly from the class attributes. */
                    selectedSpellcasting = _myClass.SpellCasting; 
                }
            }
            else
            {
                /* No change, so we simply use existing spellcasting ability. */
                selectedSpellcasting = _myCharacter.SpellCasting;
            }


            if (selectedSpellcasting != null)
            {
                if (selectedSpellcasting.IsAllSpellsAvailable && (selectedSpellcasting.GetNewCantripsLearnedAtLevel(_myCharacter.Level) == 0))
                {
                    /* This is going to be really fun when implementing multiclassing.... */
                    MessageBox.Show("With current class, all spells are available");
                    return;
                }

                FormChooseSpells myForm = new FormChooseSpells();

                /* First lets get a list of spells that are already known. */
                List<PlayerSpell> KnownSpells = _myCharacter.GetKnownSpells();

                myForm.setFixedSpells(KnownSpells, selectedSpellcasting.SpellsReplacedAtLevelup[_myCharacter.Level - 1]);

                List<PlayerSpell> SpellsAvailableForLearning = selectedSpellcasting.GetSpellsAndCantripsThatCanBeLearnedAtLevel(_myCharacter.Level);

                /* Add spells */
                myForm.setSpellChoices(SpellsAvailableForLearning, selectedSpellcasting.GetNewCantripsLearnedAtLevel(_myCharacter.Level), selectedSpellcasting.GetNewSpellsLearnedAtLevel(_myCharacter.Level), 0);

                myForm.ShowDialog();

                if (myForm.DialogResult == DialogResult.OK)
                {
                    List<PlayerSpell> res = myForm.getChosenPlayerSpells();

                    SelectedSpellNames = new List<string>();

                    foreach(PlayerSpell spellObj in res)
                    {
                        SelectedSpellNames.Add(spellObj.SpellName);
                    }
                }
            }
            else
            {
                MessageBox.Show("No spellcasting for this character");
            }
        }

        private void UpdateRemainingBaseAttributes()
        {
            if (isSettingInitialValuesForBaseAttributes)
            {
                return;
            }
            
            int totalUsedPoints = 0;

            totalUsedPoints += ((int)numericUpDownSTR.Value - (int)numericUpDownSTR.Minimum);
            totalUsedPoints += ((int)numericUpDownDEX.Value - (int)numericUpDownDEX.Minimum);
            totalUsedPoints += ((int)numericUpDownCON.Value - (int)numericUpDownCON.Minimum);
            totalUsedPoints += ((int)numericUpDownINT.Value - (int)numericUpDownINT.Minimum);
            totalUsedPoints += ((int)numericUpDownWIS.Value - (int)numericUpDownWIS.Minimum);
            totalUsedPoints += ((int)numericUpDownCHA.Value - (int)numericUpDownCHA.Minimum);

            int remainingPoints = 2 - totalUsedPoints;

            labelRemainingAttributePoints.Text = "Remaining Points: " + remainingPoints.ToString();

            numericUpDownSTR.Maximum = numericUpDownSTR.Value + remainingPoints;
            numericUpDownDEX.Maximum = numericUpDownDEX.Value + remainingPoints;
            numericUpDownCON.Maximum = numericUpDownCON.Value + remainingPoints;
            numericUpDownINT.Maximum = numericUpDownINT.Value + remainingPoints;
            numericUpDownWIS.Maximum = numericUpDownWIS.Value + remainingPoints;
            numericUpDownCHA.Maximum = numericUpDownCHA.Value + remainingPoints;

        }

        private void numericUpDownSTR_ValueChanged(object sender, EventArgs e)
        {
            UpdateRemainingBaseAttributes();
        }

        private void numericUpDownDEX_ValueChanged(object sender, EventArgs e)
        {
            UpdateRemainingBaseAttributes();
        }

        private void numericUpDownCON_ValueChanged(object sender, EventArgs e)
        {
            UpdateRemainingBaseAttributes();
        }

        private void numericUpDownWIS_ValueChanged(object sender, EventArgs e)
        {
            UpdateRemainingBaseAttributes();
        }

        private void numericUpDownINT_ValueChanged(object sender, EventArgs e)
        {
            UpdateRemainingBaseAttributes();
        }

        private void numericUpDownCHA_ValueChanged(object sender, EventArgs e)
        {
            UpdateRemainingBaseAttributes();
        }

        private void buttonLearnSkillProfs_Click(object sender, EventArgs e)
        {
            if (numberOfSkillProfChoices > 0 || numberOfSkillExpertiseChoices > 0)
            {
                FormChooseSkillProfs myForm = new FormChooseSkillProfs();
                myForm.setCharacter(_myCharacter);
                myForm.setupProficiencyChoices(numberOfSkillProfChoices);
                myForm.setupExpertiseChoices(numberOfSkillExpertiseChoices);

                myForm.ShowDialog();
                if (myForm.DialogResult == DialogResult.OK)
                {
                    List<string> AllProficiencies = myForm.getAllSelectedSkillProficiencies();
                    List<string> AllExpertise = myForm.getAllSelectedSkillExpertise();

                    foreach(string prof in AllProficiencies)
                    {
                        if (!_myCharacter.SkillProficiencies.Contains(prof))
                        {
                            newSelectedProficiencies.Add(prof);
                        }
                    }

                    foreach (string prof in AllExpertise)
                    {
                        if (!_myCharacter.SkillExpertise.Contains(prof))
                        {
                            newSelectedExpertise.Add(prof);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No new skill proficiencies for this level");
            }
        }
    }
}
