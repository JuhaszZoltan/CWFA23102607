using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoCLI
{
    internal class BingoJatekos
    {
        public string Nev { get; private set; }
        public int[,] Kartya { get; private set; }
        private bool[,] Jelolesek { get; set; } = new bool[5, 5];

        public void SorsoltSzamotJelol(int sorsoltSzam)
        {
            for (int s = 0; s < 5; s++)
            {
                for (int o = 0; o < 5; o++)
                {
                    if (Kartya[s, o] == sorsoltSzam)
                    {
                        Jelolesek[s, o] = true;
                    }
                }
            }
        }

        public bool BingoEll
        {
            get
            {
                //sorok
                for (int s = 0; s < 5; s++)
                {
                    int talalatS = 0;
                    for (int o = 0; o < 5; o++)
                    {
                        if (Jelolesek[s, o]) talalatS++;
                    }
                    if (talalatS == 5) return true;
                }

                //oszlopok
                for (int o = 0; o < 5; o++)
                {
                    int talalatO = 0;
                    for (int s = 0; s < 5; s++)
                    {
                        if (Jelolesek[s, o]) talalatO++;
                    }
                    if (talalatO == 5) return true;
                }

                //egyik atlo:
                int talalatA1 = 0;
                for (int c = 0; c < 5; c++)
                {
                    if (Jelolesek[c, c]) talalatA1++;
                }
                if (talalatA1 == 5) return true;

                //masik atlo
                int talalatA2 = 0;
                for (int c = 0; c < 5; c++)
                {
                    if (Jelolesek[c, 4 - c]) talalatA2++;
                }
                if (talalatA2 == 5) return true;

                //egyébként
                return false;
            }
        }

        public BingoJatekos(string nev, int[,] kartya)
        {
            Nev = nev;
            Kartya = kartya;
            Jelolesek[2, 2] = true;
        }
    }
}
