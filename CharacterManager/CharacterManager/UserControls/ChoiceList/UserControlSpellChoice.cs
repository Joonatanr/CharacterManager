using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharacterManager.Items;
using CharacterManager.Spells;

namespace CharacterManager.UserControls
{
    public class UserControlSpellChoice : UserControlBaseChoice<PlayerSpell>
    {        
        public bool IsMultipleLevel { get; set; } = false;

        private bool _isCastingInfoEnabled = false;
        
        public bool IsCastingInfoEnabled
        {
            get
            {
                return _isCastingInfoEnabled;
            }
            set
            {
                _isCastingInfoEnabled = value;
                ItemDescriptionArgs[0] = _isCastingInfoEnabled;
            }
        }


        /* Keeping this delegate to preserve the API */
        public delegate void SpellChoiceChangedListener(PlayerSpell Spell, bool isChosen);
        public event SpellChoiceChangedListener SpellSelectionChanged;


        /* Keeping these public functions to keep external API mostly intact. */
        public void setSpellList(List<PlayerSpell> spells)
        {
            setItemList(spells);
        }

     
        /* We add a fixed spell to the list that is always selected. */
        public void setFixedSpellListList(List<PlayerSpell> spellList, int number_of_replacements)
        {
            setFixedItemList(spellList, number_of_replacements);
        }


        public bool removeSpellFromList(PlayerSpell spell)
        {
            return removeItemFromList(spell);
        }

        public List<PlayerSpell> getSelectedSpells()
        {
            return getSelectedItems();
        }

        
        internal void setSpellSelection(string spell, bool isSelected, bool isLocked)
        {
            setItemSelection(spell, isSelected, isLocked);
        }

        public UserControlSpellChoice() : base()
        {
            this.DoubleBuffered = true;
            ItemSelectionChanged += new ItemChoiceChangedListener(SpellSelectionChangedHandler);
            ItemDescriptionArgs = new object[1];
        }

        protected override void setItemPositions(List<PlayerSpell> items, out Dictionary<int, PlayerSpell> itemDictionary, out Dictionary<int, StringContainer> textDictionary)
        {
            if (IsMultipleLevel == false)
            {
                base.setItemPositions(items, out itemDictionary, out textDictionary);
            }
            else
            {
                Dictionary<int, PlayerSpell> itemLocations = new Dictionary<int, PlayerSpell>();
                Dictionary<int, StringContainer> textLocations = new Dictionary<int, StringContainer>();
                int y = 1;

                for(int level = 0; level <= 9; level++)
                {
                    List<PlayerSpell> spellsOfThisLevel = items.FindAll(sp => sp.SpellLevel == level);

                    if (spellsOfThisLevel.Count > 0)
                    {
                        /* Lets first add the title */

                        string title;
                        if (level == 0)
                        {
                            title = "Cantrips: ";
                        }
                        else
                        {
                            title = "Level " + level.ToString() + ":";
                        }

                        StringContainer titleContainer = new UserControlBaseChoice<PlayerSpell>.StringContainer(title, new Font("Arial", 12, FontStyle.Bold));

                        textLocations.Add(y, titleContainer);
                        y++;

                        foreach(PlayerSpell spell in spellsOfThisLevel)
                        {
                            textLocations.Add(y, new UserControlBaseChoice<PlayerSpell>.StringContainer(spell.DisplayedName));
                            itemLocations.Add(y, spell);
                            y++;
                        }

                    }
                }

                itemDictionary = itemLocations;
                textDictionary = textLocations;
            }
        }

        protected override string getInfoButtonLabel()
        {
            if (IsCastingInfoEnabled)
            {
                return "Cast";
            }
            else
            {
                return base.getInfoButtonLabel();
            }
        }

        private void SpellSelectionChangedHandler(PlayerSpell spell, bool isChosen)
        {
            if(SpellSelectionChanged != null)
            {
                SpellSelectionChanged.Invoke(spell, isChosen);
                this.updateBackgroundImage();
            }
        }
    }
}
