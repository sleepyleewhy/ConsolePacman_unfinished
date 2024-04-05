using OE.Prog2.Jatek.JatekTer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OE.Prog2.Jatek.Szabalyok
{
    public class MozgasNemSikerultKivetel : Exception
    {
        JatekElem jatekElem;
        public JatekElem JatekElem
        {
            get { return jatekElem; }
        }
        int x;
        public int X
        {
            get { return x; }
        }
        int y;
        public int Y
        {
            get { return Y; }
        }
        public MozgasNemSikerultKivetel(JatekElem jatekElem, int x, int y)
        {
            this.jatekElem = jatekElem;
            this.x = x;
            this.y = y;
        }
    }
    public class MozgasHalalMiattNemSikerultKivetel : MozgasNemSikerultKivetel
    {
        public MozgasHalalMiattNemSikerultKivetel(JatekElem j, int x, int y)  : base(j, x, y)
        {

        }
    }
    public class MozgasHelyHianyMiattNemSikerultKivetel : MozgasNemSikerultKivetel
    {
        JatekElem[] elemek;
        public JatekElem[] Elemek
        {
            get { return elemek; }
        }
        public MozgasHelyHianyMiattNemSikerultKivetel(JatekElem j, int x, int y, JatekElem[] elemek) : base(j, x, y)
        {
            this.elemek = elemek;
        }
    }
}
