using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterManager.Items
{
    public partial class FormAddItem : Form
    {
        private List<PlayerWeapon> myWeapons;
        private List<PlayerArmor> myArmor;
        private List<PlayerItem> myMiscItems;
        private PlayerItem currentItem;

        private UserControlWeaponCustomizer myWeaponProperties = null;
        private UserControlArmorCustomizer myArmorProperties = null;

        public PlayerItem SelectedItem = null;

        public FormAddItem()
        {
            InitializeComponent();

            myWeapons = CharacterFactory.getAllWeapons();
            myArmor = CharacterFactory.getAllArmor();
            myMiscItems = CharacterFactory.getAllGenericItems();
            
            foreach(PlayerWeapon w in myWeapons)
            {
                listBoxWeapons.Items.Add(w);

                /* Lets experiment with adding magical variants of these weapons automatically. */
                PlayerWeapon PlusOne = w.Clone();
                PlusOne.IsMagical = true;
                PlusOne.MagicalBonus = 1;
                PlusOne.ItemName += " +1";
                PlayerWeapon PlusTwo = w.Clone();
                PlusTwo.IsMagical = true;
                PlusTwo.MagicalBonus = 2;
                PlusTwo.ItemName += " +2";
                PlayerWeapon PlusThree = w.Clone();
                PlusThree.ItemName += " +3";
                PlusThree.IsMagical = true;
                PlusThree.MagicalBonus = 3;

                listBoxWeapons.Items.Add(PlusOne);
                listBoxWeapons.Items.Add(PlusTwo);
                listBoxWeapons.Items.Add(PlusThree);
            }

            foreach (PlayerArmor a in myArmor)
            {
                listBoxArmor.Items.Add(a);
                PlayerArmor PlusOne = a.Clone();
                PlusOne.IsMagical = true;
                PlusOne.MagicalAcBonus = 1;
                PlusOne.ItemName += " +1";
                PlayerArmor PlusTwo = a.Clone();
                PlusTwo.IsMagical = true;
                PlusTwo.MagicalAcBonus = 2;
                PlusTwo.ItemName += " +2";
                PlayerArmor PlusThree = a.Clone();
                PlusThree.IsMagical = true;
                PlusThree.MagicalAcBonus = 3;
                PlusThree.ItemName += " +3";

                listBoxArmor.Items.Add(PlusOne);
                listBoxArmor.Items.Add(PlusTwo);
                listBoxArmor.Items.Add(PlusThree);
            }

            foreach (PlayerItem i in myMiscItems)
            {
                listBoxMisc.Items.Add(i);
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (currentItem is PlayerWeapon)
            {
                if (myWeaponProperties != null)
                {
                    /* We replace the default object with the one from the Weapon specific user control. */
                    currentItem = myWeaponProperties.getConnectedItem();
                }
            }
            else if(currentItem is PlayerArmor)
            {
                if (myArmorProperties != null)
                {
                    currentItem = myArmorProperties.getConnectedItem();
                }
            }
            else
            {
                /* TODO */
            }


            if (currentItem == null)
            {
                currentItem = new PlayerItem();
            }

            /* Here we update the item's general properties. */
            currentItem.ItemName = textBoxItemName.Text;
            currentItem.Description = richTextBoxItemDescription.Text;

            int cost;
            if (int.TryParse(textBoxPrice.Text, out cost) == true)
            {
                currentItem.Cost = cost;
            }

            SelectedItem = currentItem;
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void listBoxWeapons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxWeapons.SelectedIndex > -1)
            {
                currentItem = (PlayerItem)listBoxWeapons.SelectedItem;
                updateItemDisplayedData();
                myWeaponProperties = new UserControlWeaponCustomizer();
                myWeaponProperties.Location = new Point(5, 10);
                myWeaponProperties.setConnectedItem((PlayerWeapon)currentItem);
                groupBox1.Controls.Add(myWeaponProperties);

                listBoxArmor.SelectedIndex = -1;
                listBoxMisc.SelectedIndex = -1;
            }
        }

        private void listBoxArmor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxArmor.SelectedIndex > -1)
            {
                currentItem = (PlayerItem)listBoxArmor.SelectedItem;
                updateItemDisplayedData();
                myArmorProperties = new UserControlArmorCustomizer();
                myArmorProperties.Location = new Point(5, 10);
                myArmorProperties.setConnectedItem((PlayerArmor)currentItem);
                groupBox1.Controls.Add(myArmorProperties);

                listBoxWeapons.SelectedIndex = -1;
                listBoxMisc.SelectedIndex = -1;
            }
        }

        private void listBoxMisc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxMisc.SelectedIndex > -1)
            {
                groupBox1.Controls.Clear();
                currentItem = (PlayerItem)listBoxMisc.SelectedItem;
                updateItemDisplayedData();
                listBoxArmor.SelectedIndex = -1;
                listBoxWeapons.SelectedIndex = -1;
            }
        }


        private void updateItemDisplayedData()
        {
            /* We clear any extra data that might still be displayed. */
            groupBox1.Controls.Clear();
            textBoxItemName.Text = currentItem.ItemName;
            richTextBoxItemDescription.Text = currentItem.Description;
            textBoxPrice.Text = currentItem.Cost.ToString();
        }
    }
}
