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

        public FormAddItem()
        {
            InitializeComponent();

            myWeapons = CharacterFactory.getAllWeapons();
            myArmor = CharacterFactory.getAllArmor();
            myMiscItems = CharacterFactory.getAllGenericItems();
            
            foreach(PlayerWeapon w in myWeapons)
            {
                listBoxWeapons.Items.Add(w);
            }

            foreach (PlayerArmor a in myArmor)
            {
                listBoxArmor.Items.Add(a);
            }

            foreach (PlayerItem i in myMiscItems)
            {
                listBoxMisc.Items.Add(i);
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
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
                groupBox1.Controls.Clear();
                UserControlWeaponCustomizer myWeaponProperties = new UserControlWeaponCustomizer();
                myWeaponProperties.Location = new Point(5, 10);
                groupBox1.Controls.Add(myWeaponProperties);


                /* TODO : Connect the actual weapon. */
                listBoxArmor.SelectedIndex = -1;
                listBoxMisc.SelectedIndex = -1;
            }
        }

        private void listBoxArmor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxArmor.SelectedIndex > -1)
            {
                groupBox1.Controls.Clear();
                listBoxWeapons.SelectedIndex = -1;
                listBoxMisc.SelectedIndex = -1;
            }
        }

        private void listBoxMisc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxMisc.SelectedIndex > -1)
            {
                groupBox1.Controls.Clear();
                listBoxArmor.SelectedIndex = -1;
                listBoxWeapons.SelectedIndex = -1;
            }
        }
    }
}
