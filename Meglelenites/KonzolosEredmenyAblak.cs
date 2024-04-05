using OE.Prog2.Jatek.Megjelenites;
using OE.Prog2.Jatek.Szabalyok;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OE.Prog2.Jatek.Meglelenites
{
    internal class KonzolosEredmenyAblak
    {
        int pozX;
        int pozY;
        int maxSorSzam;
        int sor = 0;
        public KonzolosEredmenyAblak(int pozX, int pozY, int maxSorSzam)
        {
            this.pozX = pozX;
            this.pozY = pozY;
            this.maxSorSzam = maxSorSzam;
        }

        private void JatekosValtozasTortent(Jatekos jatekos, int pont, int hp)
        {
            SzalbiztosKonzol.KiirasXY(pozX , pozY+sor, $"játékos neve: {jatekos.Nev}, életereje: {hp}, pontszáma: {pont} ");

            if (sor++ > maxSorSzam)
            {
                sor = 0;
            }


        }
        public void JatekosFeliratkozas(Jatekos jatekos)
        {
            jatekos.JatekosValtozas += JatekosValtozasTortent;

        }
    }

}
