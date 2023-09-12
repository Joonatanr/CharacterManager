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
            int totalCopperPieces = CopperPieces;
            totalCopperPieces += SilverPieces * 10;
            totalCopperPieces += GoldPieces * 100;
            totalCopperPieces += ElectrumPieces * 500;
            totalCopperPieces += PlatinumPieces * 1000;

            this.CopperPieces = totalCopperPieces % 10;
            totalCopperPieces -= this.CopperPieces;

            this.SilverPieces = (totalCopperPieces % 100) / 10;
            totalCopperPieces -= this.SilverPieces * 10;

            this.GoldPieces = totalCopperPieces / 100;

            this.PlatinumPieces = 0;
            this.ElectrumPieces = 0;
        }

    }
}
