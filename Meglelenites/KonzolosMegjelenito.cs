using OE.Prog2.Jatek.Automatizmus;
using OE.Prog2.Jatek.Megjelenites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OE.Prog2.Jatek.Meglelenites
{
    public class KonzolosMegjelenito : IAutomatikusanMukodo
    {
        private IMegjelenitheto forras;
        private int pozX;
        private int pozY;
        public KonzolosMegjelenito(IMegjelenitheto forras, int pozX, int pozY)
        {
            this.forras = forras;
            this.pozX = pozX;
            this.pozY = pozY;
        }
        public void Megjelenites()
        {
            IKirajzolhato[] kirajz =  forras.MegjelenitendoElemek();
            int[] kirajzmeret = forras.MegjelenitendoMeret;
            bool rajzolte = false;
            for (int i = 0; i < kirajzmeret[0]; i++)
            {
                for (int j = 0; j < kirajzmeret[1]; j++)
                {
                    rajzolte = false;
                    for (int k = 0; k < kirajz.Length; k++)
                    {
                        if (kirajz[k].X == i && kirajz[k].Y == j)
                        {
                            SzalbiztosKonzol.KiirasXY(i+pozX, j+pozY, kirajz[k].Alak);
                            rajzolte = true;
                        }

                    }
                    if (!rajzolte)
                    {
                        SzalbiztosKonzol.KiirasXY(i + pozX, j + pozY, ' ');
                    }
                }
            }

        }
        public void Mukodik()
        {
            Megjelenites();
        }
        public int MukodesIntervallum { get { return 1; } }
    }
}
