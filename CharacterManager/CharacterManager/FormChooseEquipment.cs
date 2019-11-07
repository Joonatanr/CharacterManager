using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterManager
{
    public partial class FormChooseEquipment : Form
    {

        private PlayerClass _selectedClass;
        public PlayerClass SelectedClass { get { return _selectedClass; } set { _selectedClass = value; textBoxClass.Text = _selectedClass.PlayerClassName; } }
        
        public FormChooseEquipment()
        {
            InitializeComponent();
        }
    }
}
