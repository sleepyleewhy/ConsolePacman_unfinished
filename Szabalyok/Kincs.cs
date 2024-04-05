using OE.Prog2.Jatek.JatekTer;
using OE.Prog2.Jatek.Meglelenites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OE.Prog2.Jatek.Szabalyok
{
     public class Kincs : RogzitettJatekElem, IKirajzolhato
    {
        public Kincs(int x, int y, Jatekter ter) : base(x, y, ter)
        {
        }
        public override double Meret => 1;
        
        public char Alak
        {
            get { return '\u2666'; }
        }
        public override void Utkozes(JatekElem elem)
        {
            if (elem is Jatekos)
            {
                (elem as Jatekos).Utkozes(this);
                if (KincsFelvetel != null)
                {
                    KincsFelvetel(this, elem as Jatekos);
                }               
                (elem as Jatekos).PontotSzerez(50);
                ter.Torles(this);
            }

        }
        public event KincsFelvetelKezelo KincsFelvetel;

    }

}
