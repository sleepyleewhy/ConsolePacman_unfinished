using OE.Prog2.Jatek.JatekTer;
using OE.Prog2.Jatek.Meglelenites;
using OE.Prog2.Jatek.Szabalyok;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OE.Prog2.Jatek.JatekTer
{
    public abstract class MozgoJatekElem : JatekElem
    {
        public MozgoJatekElem(int x, int y, Jatekter ter) : base(x, y, ter)
        {

        }

        private bool aktiv = true;
        public bool Aktiv
        {
            get { return aktiv; }
            set { aktiv = value; }
        }
        public void Athelyez(int ujx, int ujy)
        {
            JatekElem[] itt = ter.MegadottHelyenLevok(ujx, ujy);
            for (int i = 0; i < itt.Length; i++)
            {
                itt[i].Utkozes(this);
                Utkozes(itt[i]);
                if (!aktiv)
                {
                    throw new MozgasHalalMiattNemSikerultKivetel(this, ujx, ujy);
                }
            }
            if (aktiv)
            {
                itt = ter.MegadottHelyenLevok(ujx, ujy);
                double osszmer = 0;
                for (int i = 0; i < itt.Length; i++)
                {
                    osszmer += itt[i].Meret;
                }
                if (osszmer + Meret <=1)
                {
                    X = ujx;
                    Y = ujy;
                }
                else
                {
                    throw new MozgasHelyHianyMiattNemSikerultKivetel(this, ujx, ujy, itt);
                }
            }
            

        }

    }
}