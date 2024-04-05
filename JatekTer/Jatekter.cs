using OE.Prog2.Jatek.JatekTer;
using OE.Prog2.Jatek.Meglelenites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OE.Prog2.Jatek.JatekTer
{
     public class Jatekter : IMegjelenitheto
    {
        static int MAX_ELEMSZAM = 1000;
        private int elemN;
        private JatekElem[] elemek = new JatekElem[MAX_ELEMSZAM];
        private int meretX;
        public int MeretX
        {
            get
            {
                return meretX;
            }
        }
        private int meretY;
        public int MeretY
        {
            get { return meretY; }
        }
        public Jatekter(int meretX, int meretY)
        {
            this.meretX = meretX;
            this.meretY = meretY;
        }
        public void Felvetel(JatekElem elem)
        {
            int index = 0;
            while (elemek[index] !=null && index < MAX_ELEMSZAM)
            {
                index++;
            }
            if (index < MAX_ELEMSZAM)
            {
                elemek[index] = elem;
            }
            elemN++;

        }
        public void Torles(JatekElem elem)
        {
            int index = -1;
            int talalt = 0;
            while (talalt == 0 && index < MAX_ELEMSZAM)
            {               
                index++;
                if (elemek[index] == elem)
                {
                    talalt = index;
                }
            }
            elemek[index] = null;
            elemN--;
        }
        public JatekElem[] MegadottHelyenLevok(int x, int y, int tav)
        {
            int[] indexek = new int[elemek.Length];
            int szaml = 0;
            for (int i = 0; i < elemek.Length; i++)
            {
                if (elemek[i] != null && (elemek[i].X <= x + tav && elemek[i].X >= x - tav
                    && elemek[i].Y <= y + tav && elemek[i].Y >= y - tav))
                {
                    indexek[szaml] = i;
                    szaml++;
                }
            }
            JatekElem[] ret = new JatekElem[szaml];
            for (int i = 0; i < szaml; i++)
            {
                ret[i] = elemek[indexek[i]];
            }
            return ret;
        }
        public JatekElem[] MegadottHelyenLevok(int x, int y)
        {
            JatekElem[] ret = new JatekElem[elemN];
            int szaml = 0;
            for (int i = 0; i < elemek.Length; i++)
            {
                if (elemek[i] != null)
                {
                    if (x == elemek[i].X && y == elemek[i].Y)
                    {
                        ret[szaml] = elemek[i];
                        szaml++;
                    }
                }
            }
            JatekElem[] veg = new JatekElem[szaml];
            for (int i = 0; i < szaml; i++)
            {
                veg[i] = ret[i];
            }
            return veg;
        }
        public int[] MegjelenitendoMeret
        {
            get
            {
                int[] ret = {meretX,meretY};
                return ret;
            }
        }
        public IKirajzolhato[] MegjelenitendoElemek()
        {
            int kirajzcount = 0;
            for (int i = 0; i < elemek.Length; i++)
            {
                if (elemek[i] is IKirajzolhato)
                {
                    kirajzcount++;
                }
            }
            IKirajzolhato[] vissza = new IKirajzolhato[kirajzcount];
            int index = 0;
            for (int i = 0; i < elemek.Length; i++)
            {
                if (elemek[i] is IKirajzolhato)
                {
                    vissza[index] = (elemek[i] as IKirajzolhato);
                    index++;
                }
            }
            return vissza;
        }



    }
}
