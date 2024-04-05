using OE.Prog2.Jatek.JatekTer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OE.Prog2.Jatek.Szabalyok
{
    internal class GonoszGepiJatekos : GepiJatekos
    {
        public GonoszGepiJatekos(string nev, int x, int y, Jatekter ter) : base(nev,x,y,ter)
        {

        }
        public override char Alak
        {
            get
            {
                return '\u2642';
            }
        }
        public override void Utkozes(JatekElem elem)
        {
            base.Utkozes(elem);
            if (Aktiv)
            {
                if (elem is Jatekos)
                {
                    (elem as Jatekos).Serul(10);
                }
            }
        }


    }
}
