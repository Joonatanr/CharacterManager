using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterManager.UserControls
{
    public partial class AlignmentChoice : UserControl
    {
        public AlignmentChoice()
        {
            InitializeComponent();
        }

        public PlayerCharacter.PlayerAlignment getSelectedAlignment()
        {
            if (radioButtonChaoticEvil.Checked)
            {
                return PlayerCharacter.PlayerAlignment.ChaoticEvil;
            }

            if (radioButtonNeutralEvil.Checked)
            {
                return PlayerCharacter.PlayerAlignment.NeutralEvil;
            }

            if (radioButtonLawfulEvil.Checked)
            {
                return PlayerCharacter.PlayerAlignment.LawfulEvil;
            }

            if (radioButtonChaoticNeutral.Checked)
            {
                return PlayerCharacter.PlayerAlignment.ChaoticNeutral;
            }

            if (radioButtonTrueNeutral.Checked)
            {
                return PlayerCharacter.PlayerAlignment.TrueNeutral;
            }

            if (radioButtonLawfulNeutral.Checked)
            {
                return PlayerCharacter.PlayerAlignment.LawfulNeutral;
            }

            if (radioButtonChaoticGood.Checked)
            {
                return PlayerCharacter.PlayerAlignment.ChaoticGood;
            }

            if (radioButtonNeutralGood.Checked)
            {
                return PlayerCharacter.PlayerAlignment.NeutralGood;
            }

            if (radioButtonLawfulGood.Checked)
            {
                return PlayerCharacter.PlayerAlignment.LawfulGood;
            }

            //Should not happen.
            return PlayerCharacter.PlayerAlignment.LawfulGood;
        }
    }
}
