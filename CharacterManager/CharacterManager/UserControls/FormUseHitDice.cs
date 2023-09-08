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
    public partial class FormUseHitDice : Form
    {
        private PlayerCharacter _connectedCharacter = null;
        
        public FormUseHitDice()
        {
            InitializeComponent();
        }

        public void setConnectedCharacter(PlayerCharacter c)
        {
            
            _connectedCharacter = c;
            if (_connectedCharacter != null)
            {
                _connectedCharacter.CharacterHitDieChanged += _connectedCharacter_CharacterHitDieChanged;
                _connectedCharacter.CharacterHPChanged += _connectedCharacter_CharacterHPChanged;

                updateDisplayedData();
            }
        }

        private void updateDisplayedData()
        {
            if (_connectedCharacter != null)
            {
                userControlHitPoints1.MaxHitPoints = _connectedCharacter.MaxHitPoints;
                userControlHitPoints1.CurrentHitPoints = _connectedCharacter.CurrentHitPoints;

                userControlhitDice1.MaxHitDice = _connectedCharacter.Level;
                userControlhitDice1.RemainingHitDice = _connectedCharacter.CurrentHitDice;
                userControlhitDice1.DieType = _connectedCharacter.HitDieType;
            }
        }

        private void _connectedCharacter_CharacterHPChanged(PlayerCharacter c)
        {
            updateDisplayedData();
        }

        private void _connectedCharacter_CharacterHitDieChanged(PlayerCharacter c)
        {
            updateDisplayedData();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonRollHitDice_Click(object sender, EventArgs e)
        {
            if(_connectedCharacter != null)
            {
                string rollResult;
                bool res;
                res = _connectedCharacter.RollHitDie(out rollResult);
                
                if (res)
                {
                    textBoxRollResult.Text = rollResult;
                    GlobalEvents.ReportRollGlobal("Hit die : " + rollResult, Color.Black, false);
                }
                else
                {
                    MessageBox.Show(rollResult);
                }
            }
        }
    }
}
