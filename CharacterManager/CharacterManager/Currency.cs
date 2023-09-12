using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager
{   
    public class Currency
    {
        public int CopperPieces = 0;
        public int SilverPieces = 0;
        public int GoldPieces = 0;
        public int ElectrumPieces = 0;
        public int PlatinumPieces = 0;

        public Currency()
        {

        }

        public Currency(int gp)
        {
            this.GoldPieces = gp;
        }

        public void ConvertToGoldPieces()
        {
            /* The idea is to convert the whole stack to GP and leave fractions of copper and silver over. */
            int totalCopperPieces = GetTotalAmountOfCopperPieces();

            this.CopperPieces = totalCopperPieces % 10;
            totalCopperPieces -= this.CopperPieces;

            this.SilverPieces = (totalCopperPieces % 100) / 10;
            totalCopperPieces -= this.SilverPieces * 10;

            this.GoldPieces = totalCopperPieces / 100;

            this.PlatinumPieces = 0;
            this.ElectrumPieces = 0;
        }
        
        public bool SpendAmountOfGold(double gold)
        {
            int totalCopperPiecesSpend = (int)(gold * 100);
            int totalCopperPiecesExisting = GetTotalAmountOfCopperPieces();
            int remainingCopperPieces = 0;

            if (totalCopperPiecesExisting < totalCopperPiecesSpend)
            {
                return false;
            }
            else
            {
                remainingCopperPieces = totalCopperPiecesExisting - totalCopperPiecesSpend;
                this.CopperPieces = remainingCopperPieces % 10;
                remainingCopperPieces /= 10;
                this.SilverPieces = remainingCopperPieces % 10;
                remainingCopperPieces /= 10;
                this.GoldPieces = remainingCopperPieces;

                /* Could be that we might want to preserve these somehow.... TODO : Consider more complex approach. */
                this.PlatinumPieces = 0;
                this.ElectrumPieces = 0;

                return true;
            }
        }

        public double GetTotalAmountOfGoldPieces()
        {
            return (double)GetTotalAmountOfCopperPieces() / 100;
        }


        public int GetTotalAmountOfCopperPieces()
        {
            int totalCopperPieces = CopperPieces;
            totalCopperPieces += SilverPieces * 10;
            totalCopperPieces += GoldPieces * 100;
            totalCopperPieces += ElectrumPieces * 500;
            totalCopperPieces += PlatinumPieces * 1000;

            return totalCopperPieces;
        }
    }
}
