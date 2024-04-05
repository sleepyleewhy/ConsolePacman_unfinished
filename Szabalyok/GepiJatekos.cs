using OE.Prog2.Jatek.Automatizmus;
using OE.Prog2.Jatek.JatekTer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OE.Prog2.Jatek.Szabalyok
{
    public  class GepiJatekos : Jatekos, IAutomatikusanMukodo
    {
        public GepiJatekos(string nev, int x, int y, Jatekter ter) : base(nev, x, y, ter)
        {
            
        }
        static Random r = new Random();
         public void Mozgas()
        {
            int irany = r.Next(0, 4);
            int probaszam = 0;
            bool mente = false;
            while (probaszam < 4 && !mente)
            {
                if (irany == 0)
                {
                    try
                    {
                        Megy(1, 0);
                        mente = true;
                    }
                    catch (MozgasHelyHianyMiattNemSikerultKivetel)
                    {
                        if (probaszam < 4)
                        {
                            probaszam++;
                            irany = 1;
                        }
                    }
                }
                if (irany == 1)
                {
                    try
                    {
                        Megy(-1, 0);
                        mente = true;
                    }
                    catch (MozgasHelyHianyMiattNemSikerultKivetel)
                    {
                        if (probaszam < 4)
                        {
                            probaszam++;
                            irany = 2;
                        }
                    }
                }
                if (irany == 2)
                {
                    try
                    {
                        Megy(0, 1);
                        mente = true;
                    }
                    catch (MozgasHelyHianyMiattNemSikerultKivetel)
                    {
                        if (probaszam < 4)
                        {
                            probaszam++;
                            irany = 3;
                        }

                    }
                }
                if (irany == 3)
                {
                    try
                    {
                        Megy(0, -1);
                        mente = true;
                    }
                    catch (MozgasHelyHianyMiattNemSikerultKivetel)
                    {
                        if (probaszam < 4)
                        {
                            probaszam++;
                            irany = 0;
                        }
                    }
                }                           
            }            
        }
        public override char Alak
        {
            get { return '\u2640'; }
        }
        public void Mukodik()
        {
            
            Mozgas();
        }
        public int MukodesIntervallum { get { return 2; } }
    }
}
