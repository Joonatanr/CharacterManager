using CharacterManager.Spells;
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
    public partial class UserControlMagicHandler : UserControl
    {
        private CharacterSpellcastingStatus myStat;
        private List<PlayerSpell> myKnownSpells = new List<PlayerSpell>();
        private List<PlayerSpell> myKnownCantrips = new List<PlayerSpell>();
        private PlayerCharacter _connectedCharacter;
        
        public UserControlMagicHandler()
        {
            InitializeComponent();
        }

        public void setConnectedCharacter(PlayerCharacter c)
        {
            _connectedCharacter = c;
            if (_connectedCharacter != null)
            {
                setCharSpellcastingStatus(_connectedCharacter.CharacterSpellCastingStatus);
                /* TODO : This will be a huge mess, if multiclassing ever gets implemented. */
                if (_connectedCharacter.SpellCasting.SubType == "(Wizard)")
                {
                    buttonCopySpells.Visible = true;
                    buttonCopySpells.Enabled = true;
                }
                else
                {
                    buttonCopySpells.Visible = false;
                    buttonCopySpells.Enabled = false;
                }
            }
        }

        private void setCharSpellcastingStatus(CharacterSpellcastingStatus stat)
        {
            myStat = stat;

            myKnownSpells = new List<PlayerSpell>();
            myKnownCantrips = new List<PlayerSpell>();

            if (stat == null)
            {
                //Nothing to add here... 
                return;
            }

            if (stat.KnownSpells != null)
            {
                foreach (string sp in stat.KnownSpells)
                {
                    PlayerSpell obj = CharacterFactory.getPlayerSpellFromString(sp);
                    if (obj == null)
                    {
                        /* TODO : Report error */

                    }
                    else if (obj.SpellLevel == 0)
                    {
                        myKnownCantrips.Add(obj);
                    }
                    else
                    {
                        myKnownSpells.Add(obj);
                    }
                }
            }

            userControlCantripList.setSpellList(myKnownCantrips);
            userControlKnownSpells.setSpellList(myKnownSpells);

            string abilityString = myStat.SpellCastingAbility + "(";

            if (myStat.SpellAbilityModifier > 0)
            {
                abilityString += "+";
            }
            abilityString += myStat.SpellAbilityModifier.ToString();
            abilityString += ")";

            userControlSpellcastingAbility.Value = abilityString;

            string atckBonus = "";
            if(myStat.SpellAttackBonus >= 0) 
            {
                atckBonus += "+";
            }

            atckBonus+= myStat.SpellAttackBonus.ToString();
            userControlSpellAttackBonus.Value = atckBonus;
            userControlSpellAttackBonus.ToolTip = BonusValueModifier.getToolTipStringFromList(myStat.SpellAttackBonusModifiers);
            userControlSpellsaveDc.Value = myStat.SpellSaveDC.ToString();
            userControlSpellsaveDc.ToolTip = BonusValueModifier.getToolTipStringFromList(myStat.SpellSaveDcModifiers);

            /* Simplistic approach first, TODO */
            int maxPreparedSpells = myStat.MaxNumberOfPreparedSpells;
            if (maxPreparedSpells > 0)
            {
                userControlMaxPreparedSpells.Value = myStat.MaxNumberOfPreparedSpells.ToString();
                userControlMaxPreparedSpells.ToolTip = BonusValueModifier.getToolTipStringFromList(myStat.MaxNumberOfPreparedModifiers);
                userControlKnownSpells.MaximumAvailableChoices = myStat.MaxNumberOfPreparedSpells;

                if (myStat.PreparedSpells != null)
                {
                    foreach (string sp in myStat.PreparedSpells)
                    {
                        /* We must programmatically set the selected spells... */
                        userControlKnownSpells.setSpellSelection(sp, true);
                    }
                }
            }
            else
            {
                userControlMaxPreparedSpells.Value = "N/A";
                /* TODO : Should somehow hide or disable the user control for preparing spells. */
            }

            /* Lets update the spell slot data. */
            userControlSpellSlotsArea1.setSpellSlotData(stat);
        }

        public bool IsSpellSlotsAvailableOfLevel(int level)
        {
            if (level == 0)
            {
                return true;
            }

            CharacterSpellcastingStatus.SpellSlotData data = myStat.getSpellSlotDataForLevel(level);
            return (data.ActiveCount > 0) ? true : false;
        }

        public void UpdateAllDisplayedData()
        {
            userControlSpellSlotsArea1.updateSpellSlotDisplay();
        }

        private void userControlSpellChoice1_Load(object sender, EventArgs e)
        {

        }

        private void UserControlMagicHandler_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void userControlKnownSpells_SpellSelectionChanged(PlayerSpell Spell, bool isChosen)
        {
            List<PlayerSpell> preparedSpells = userControlKnownSpells.getSelectedSpells();
            myStat.PreparedSpells = getSpellNamesFromList(preparedSpells);
            userControlPreparedSpells.setSpellList(preparedSpells);
        }

        private static List<string> getSpellNamesFromList(List<PlayerSpell> spells)
        {
            List<String> res = new List<string>();

            foreach(PlayerSpell sp in spells)
            {
                res.Add(sp.SpellName);
            }

            return res;
        }

        private void buttonCopySpells_Click(object sender, EventArgs e)
        {
            CharacterCreator.FormChooseSpells myForm = new CharacterCreator.FormChooseSpells();

            /* First lets get a list of spells that are already known. */
            List<PlayerSpell> KnownSpells = _connectedCharacter.GetKnownSpells();

            myForm.setFixedSpells(KnownSpells, 0);

            List<PlayerSpell> SpellsAvailableForLearning = _connectedCharacter.SpellCasting.GetSpellsThatCanBeLearnedAtLevel(_connectedCharacter.Level);

            /* Add spells */
            /* TODO : Here we have a special case, as we have no limit really to how many spells can be copied. The cost will only be relevant. */
            myForm.setSpellChoices(SpellsAvailableForLearning, 0, -1);
            myForm.IsSpellCostDisplayed = true;

            myForm.ShowDialog();

            if (myForm.DialogResult == DialogResult.OK)
            {
                List<PlayerSpell> res = myForm.getChosenPlayerSpells();
                List<string> resStrings = new List<string>();
                foreach(PlayerSpell sp in res)
                {
                    resStrings.Add(sp.Name);
                }

                _connectedCharacter.CharacterSpellCastingStatus.KnownSpells.AddRange(resStrings);
                /* Update all displayed data. */
                setConnectedCharacter(this._connectedCharacter);
            }
        }
    }
}
