using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using CharacterManager.Spells;


namespace SpellEditor
{
    public partial class Form1 : Form
    {
        private static List<PlayerSpell> SpellList = new List<PlayerSpell>();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void parseSpellsFromXml(String filepath)
        {
            try
            {
                XmlSerializer reader = new XmlSerializer(typeof(List<PlayerSpell>));
                StreamReader file = new System.IO.StreamReader(filepath);
                SpellList = (List<PlayerSpell>)reader.Deserialize(file);

                foreach(PlayerSpell spell in SpellList)
                {
                    listView1.Items.Add(spell.SpellName);
                }

                file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open file : " + ex.Message);
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                parseSpellsFromXml(filePath);
            }
        }
    }
}
