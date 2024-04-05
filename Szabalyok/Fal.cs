using OE.Prog2.Jatek.JatekTer;
using OE.Prog2.Jatek.Meglelenites;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OE.Prog2.Jatek.Szabalyok
{
    public delegate void KincsFelvetelKezelo(Kincs felvkincs, Jatekos felvjatekos);
    public delegate void JatekosValtozasKezelo(Jatekos jatekos, int ujpont, int ujhp);
    public class Fal : RogzitettJatekElem, IKirajzolhato
    {
        public Fal(int x, int y, Jatekter asd) : base(x, y, asd)
        {

        }
        public override double Meret => 1;
        public override void Utkozes(JatekElem elem)
        {
            
        }
        public char Alak
        {
            get
            {
                return '\u2593';
            }
        }

    }
}
