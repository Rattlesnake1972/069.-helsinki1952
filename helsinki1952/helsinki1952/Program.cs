using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace helsinki1952
{

    class Program
    {
        static List<eredmeny> eredmenylista = new List<eredmeny>();
        static void Main(string[] args)


        {
            StreamReader sr = new StreamReader("helsinki.txt", encoding: Encoding.UTF7);
            while(!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] darabok = sor.Split(' ');
                eredmeny e = new eredmeny();

                e.helyezes = Convert.ToInt32(darabok[0]);
                e.letszam = Convert.ToInt32(darabok[1]);
                e.kategoria = darabok[2];
                e.sportag = darabok[3];

                eredmenylista.Add(e);
            }

            sr.Close();

            // adatok

            /*foreach(var item in eredmenylista)
            {
                Console.WriteLine(item.letszam);
            }*/

            // 3. feladat

            Console.WriteLine("3. feladat: ");

            Console.WriteLine("A pontszerző helyezések száma: " +eredmenylista.Count);

            // 4. feladat

            Console.WriteLine("4. feladat:");

            int aranydb = 0;
            int ezustdb = 0;
            int bronzdb = 0;

            foreach(var item in eredmenylista)
            {
                if(item.helyezes==1)
                {
                    aranydb++;
                }

                if (item.helyezes == 2)
                {
                    ezustdb++;
                }

                if (item.helyezes == 3)
                {
                    bronzdb++;
                }
            }

            Console.WriteLine("aranydb: " +aranydb);
            Console.WriteLine("ezustdb: " + ezustdb);
            Console.WriteLine("bronzdb: " + bronzdb);
            Console.WriteLine("összesen: " +(aranydb+ezustdb+bronzdb));

            // 5. feladat

            Console.WriteLine("5. feladat: ");

            int pontok = 0;

            foreach(var item in eredmenylista)
            {
                if (item.helyezes == 1)
                {
                    pontok += 7;
                }

                if (item.helyezes == 2)
                {
                    pontok += 5;
                }

                if (item.helyezes == 3)
                {
                    pontok += 4;
                }

                if (item.helyezes == 4)
                {
                    pontok += 3;
                }

                if (item.helyezes == 5)
                {
                    pontok += 2;
                }

                if (item.helyezes == 6)
                {
                    pontok += 1;
                }
            }

            Console.WriteLine("A pontok száma: " +pontok);

            // 6. feladat

            Console.WriteLine("6. feladat");

            int uszasdb = 0;
            int tornadb = 0;

            foreach(var item in eredmenylista)
            {
                if (item.kategoria== "uszas")
                {
                    uszasdb++;
                }

                if (item.kategoria == "torna")
                {
                    tornadb++;
                }
            }

            // kiírás eldöntése

            if(uszasdb>tornadb)
            {
                Console.WriteLine("Az úszás sportágban szereztek több érmet.");
            }

            if (uszasdb < tornadb)
            {
                Console.WriteLine("A torna sportágban szereztek több érmet.");
            }

            if (uszasdb == tornadb)
            {
                Console.WriteLine("Az úszás sportágban és a torna sportágban ugyanannyi érmet szereztek.");
            }

            // 7. feladat

            Console.WriteLine("7. feladat");

            StreamWriter sw = new StreamWriter("helsinki2.txt");

            foreach(var item in eredmenylista)
            {
                int pont = 7 - item.helyezes;
                if(pont==6)
                {
                    pont = 7;
                }

                string segedkategoria = item.kategoria;
                if(item.kategoria=="kajakkenu")
                {
                    segedkategoria = "kajak-kenu";
                }

                sw.WriteLine(item.helyezes+" "+item.letszam+" "+pont+" "+segedkategoria+" "+item.sportag);

            }

            sw.Close();

            // 8. feladat

            Console.WriteLine("8. feladat: ");

            eredmeny maxletszam = eredmenylista[0];

            foreach (var item in eredmenylista)
            {
                if (item.letszam>maxletszam.letszam)
                {
                    maxletszam = item;
                }
            }
            
            Console.WriteLine("Helyezés: " +maxletszam.helyezes);
            Console.WriteLine("Sportolók száma: " +maxletszam.letszam);
            Console.WriteLine("Sportág: " +maxletszam.kategoria);
            Console.WriteLine("Versenyszám: " +maxletszam.sportag);


            Console.ReadLine();

        }

    }
}
