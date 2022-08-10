﻿using CharacterManager.Spells;
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
        
        public UserControlMagicHandler()
        {
            InitializeComponent();
        }

        public void setCharSpellcastingStatus(CharacterSpellcastingStatus stat)
        {
            myStat = stat;
            /* TODO : Placeholder. */
        }
    }
}