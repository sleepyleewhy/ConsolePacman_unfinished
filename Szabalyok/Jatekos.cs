using OE.Prog2.Jatek.JatekTer;
using OE.Prog2.Jatek.Meglelenites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OE.Prog2.Jatek.Szabalyok
{
    public class Jatekos : MozgoJatekElem, IMegjelenitheto, IKirajzolhato
    {
        private string nev;
        public string Nev
        {
            get { return nev; }
        }
        public Jatekos(string nev, int x, int y,Jatekter ter) : base(x,y,ter)
        {
            this.nev = nev;
        }
        virtual public char Alak
        {
            get
            {
                if (Aktiv)
                {
                    return '\u263A';
                }
                else
                {
                    return '\u263B';
                }
            }
        }
        public int[] MegjelenitendoMeret
        {
            get
            {
                return ter.MegjelenitendoMeret;
            }
        }
        
        public override double Meret => 0.2;
        public override void Utkozes(JatekElem elem)
        {
            
        }
        private int eletero = 100;
        public void Serul(int dmg)
        {
            if (eletero > 0)
            {
                eletero -= dmg;
                if (eletero <= 0)
                {
                    Aktiv = false;
                }
                if (JatekosValtozas != null)
                {
                    JatekosValtozas(this, pontszam, eletero);
                }
            }            
        }
        private int pontszam = 0;
        public void PontotSzerez(int pont)
        {
            pontszam += pont;
            if (JatekosValtozas != null)
            {
                JatekosValtozas(this, pontszam, eletero);
            }
        }
        public void Megy(int x, int y)
        {

            int modx = X + x;
            int mody = Y + y;
            Athelyez(modx, mody);
        }
        public IKirajzolhato[] MegjelenitendoElemek()
        {
            JatekElem[] belat = ter.MegadottHelyenLevok(X, Y, 5);
            int kirajzcount = 0;
            for (int i = 0; i < belat.Length; i++)
            {
                if (belat[i] is IKirajzolhato)
                {
                    kirajzcount++;
                }
            }
            IKirajzolhato[] vissza = new IKirajzolhato[kirajzcount];
            int index = 0;
            for (int i = 0; i < belat.Length; i++)
            {
                if (belat[i] is IKirajzolhato)
                {
                    vissza[index] = (belat[i] as IKirajzolhato);
                    index++;
                }
            }
            return vissza;
        }
        public event JatekosValtozasKezelo JatekosValtozas;



    }
}
