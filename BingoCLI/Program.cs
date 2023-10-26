using System;
using System.Collections.Generic;
using System.IO;

namespace BingoCLI
{
    internal class Program
    {
        static List<BingoJatekos> jatekosok;

        static void Main()
        {
            jatekosok = InitJatekosok(@"..\..\src");

            Console.WriteLine($"4. feladat: játékosok száma: {jatekosok.Count}");


            Console.ReadKey();
        }

        private static List<BingoJatekos> InitJatekosok(string path)
        {
            var lista = new List<BingoJatekos>();
            string[] fileok = Directory.GetFiles(path);
            foreach (var file in fileok)
            {
                if (file.Contains(".txt"))
                {
                    using (var sr = new StreamReader(file))
                    {
                        string nev = file.Split('\\')[3].Split('.')[0];
                        int[,] kartya = new int[5, 5];
                        int si = 0;
                        while (!sr.EndOfStream)
                        {
                            string[] sor = sr.ReadLine().Split(';');
                            int oi = 0;
                            foreach (var szam in sor)
                            {
                                if (szam != "X") kartya[si, oi] = int.Parse(szam);
                                oi++;
                            }
                            si++;
                        }
                        lista.Add(new BingoJatekos(nev, kartya));
                    }
                }
            }
            return lista;
        }
    }
}
