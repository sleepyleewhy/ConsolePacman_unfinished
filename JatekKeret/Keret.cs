using OE.Prog2.Jatek.Automatizmus;
using OE.Prog2.Jatek.JatekTer;
using OE.Prog2.Jatek.Meglelenites;
using OE.Prog2.Jatek.Szabalyok;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OE.Prog2.Jatek.JatekKeret
{
    class Keret
    {
        int PALYA_MERET_X = 21;
        int PALYA_MERET_Y = 11;
        int KINCSEK_SZAMA = 10;
        private Jatekter ter;
        OrajelGenerator generator;
        private void PalyaGeneralas()
        {
            ter = new Jatekter(21, 11);
            for (int i = 0; i < ter.MeretX; i++)
            {
                for (int y = 0; y < ter.MeretY; y++)
                {
                    if (i == 0 || i == ter.MeretX - 1 || y == 0 || y == ter.MeretY - 1)
                    {
                        Fal fal = new Fal(i, y, ter);
                    }
                }

            }
            for (int i = 0; i < KINCSEK_SZAMA; i++)
            {
                Random r = new Random();
                int randx = r.Next(1, 20);
                int randy = r.Next(1, 11);
                JatekElem[] pos = ter.MegadottHelyenLevok(randx, randy);
                double meret = 0;
                for (int y = 0; y < pos.Length; y++)
                {
                    meret += pos[y].Meret;
                }
                while (meret >= 1)
                {
                    randx = r.Next(1, 20);
                    randy = r.Next(1, 11);
                    pos = ter.MegadottHelyenLevok(randx, randy);
                    meret = 0;
                    for (int y = 0; y < pos.Length; y++)
                    {
                        meret += pos[y].Meret;
                    }

                }
                Kincs newkincs = new Kincs(randx, randy, ter);
                newkincs.KincsFelvetel += KincsFelvetelTortent;
            }
        }
        public Keret()
        {
            ter = new Jatekter(PALYA_MERET_X, PALYA_MERET_Y);
            generator = new OrajelGenerator();
            PalyaGeneralas();
        }
        private bool JatekVege = false;
        public void Futtatas()
        {
            KonzolosEredmenyAblak eredmblak = new KonzolosEredmenyAblak(0, 12, 5);
            KonzolosMegjelenito megj = new KonzolosMegjelenito(ter, 0, 0);
            Jatekos jatekos = new Jatekos("Bela", 1, 1, ter);
            GepiJatekos gepijat1 = new GepiJatekos("Kati", 1, 2, ter);
            GonoszGepiJatekos gongepijat1 = new GonoszGepiJatekos("Laci", 7, 7, ter);
            generator.Felvetel(gepijat1);
            generator.Felvetel(gongepijat1);
            generator.Felvetel(megj);
            KonzolosMegjelenito megj2 = new KonzolosMegjelenito(jatekos, 25, 0);
            generator.Felvetel(megj2);
            eredmblak.JatekosFeliratkozas(jatekos);
            jatekos.JatekosValtozas += JatekosValtozasTortent;
            try
            {
                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.LeftArrow) jatekos.Megy(-1, 0);
                    if (key.Key == ConsoleKey.RightArrow) jatekos.Megy(1, 0);
                    if (key.Key == ConsoleKey.UpArrow) jatekos.Megy(0, -1);
                    if (key.Key == ConsoleKey.DownArrow) jatekos.Megy(0, 1);
                    if (key.Key == ConsoleKey.Escape) JatekVege = true;
                } while (!JatekVege);
            }
            catch (MozgasHelyHianyMiattNemSikerultKivetel x)
            {
                Console.Beep(500 + x.Elemek.Length * 100, 10);
            }            
        }
        int megtalaltKincsek;
        private void KincsFelvetelTortent(Kincs kincs, Jatekos jatekos)
        {
            megtalaltKincsek++;
            if (megtalaltKincsek == KINCSEK_SZAMA)
            {
                JatekVege = true;
            }
        }
        private void JatekosValtozasTortent(Jatekos jatekos, int pont, int hp)
        {
            if (hp == 0)
            {
                JatekVege = true;
            }
        }
        
    }

}
