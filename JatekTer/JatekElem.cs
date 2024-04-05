using OE.Prog2.Jatek.JatekTer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OE.Prog2.Jatek.JatekTer
{
    public abstract class JatekElem
    {
        private int x;
        private int y;
        public int X
        {
            get { return x; }
            set
            {
                x = value;
            }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        protected Jatekter ter;
        public abstract double Meret { get; }


        public JatekElem(int x, int y, Jatekter ter)
        {
            this.x = x;
            this.y = y;
            this.ter = ter;
            ter.Felvetel(this);
        }
    
        public abstract void Utkozes(JatekElem elem);
    }

}
