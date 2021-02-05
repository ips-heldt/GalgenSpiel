using System;

namespace GalgenSpiel
{
    class Program
    {
        static void Main(string[] args)
        {
            do {
                bool geloest = false;
                int versuche = 1;

                string spAWort = EingabeA();
                char[] spBArray = new char[spAWort.Length];
                do
                {
                    char spBZeichen = EingabeB()[0];

                    geloest = spAWort.Length == Vergleich(spAWort, spBArray, spBZeichen);
                    
                    Anzeige(spBArray);
                    if (geloest)
                    {
                        Console.WriteLine("\n\nHerzlichen Glückwunsch, du hast das Wort erraten\nweiter mit beliebiger Taste...");
                        Console.ReadKey();
                        break;
                    }

                    if (!geloest && AbfrageLoesen())
                    {
                        geloest = spAWort == EingabeLoesungswort(spAWort.Length);
                    }

                } while (versuche++ < 10 && !geloest);

                Console.Clear();
                Console.Write("Neues Spiel? :");
            } while (Console.ReadKey().Key == ConsoleKey.J);
        }

        static string EingabeA()
        {
            string input;
            do
            {
                Console.Clear();
                Console.Write("Spieler A bitte Wort eingeben: ");

            } while ((input = Console.ReadLine()).Length == 0);
            return input.ToUpper();
        }

        static string EingabeB()
        {
            string input;
            do
            {
                Console.Clear();
                Console.Write("Spieler B: ");

            } while ((input = Console.ReadKey().KeyChar.ToString()).Length != 1);
            return input.ToUpper();
        }

        static string EingabeLoesungswort(int wortLaenge)
        {
            string input;
            do
            {
                Console.Clear();
                Console.Write("Lösungswort: ");

            } while ((input = Console.ReadLine()).Length != wortLaenge);
            return input.ToUpper();
        }

        static bool AbfrageLoesen()
        {
            ConsoleKey e;
            do
            {
                Console.Write("\n\nSpieler B möchtest du lösen? ");
                e = Console.ReadKey().Key;
                if ((e == ConsoleKey.J) || (e == ConsoleKey.N)) break;
            } while (true);
            return e == ConsoleKey.J;
        }

        static int Vergleich(string wort, char[] zeichenKette, char zeichen)
        {
            int treffer = 0;
            for(int i =0; i < wort.Length; i++)
            {
                if(wort[i] == zeichen || wort[i] == zeichenKette[i])
                {
                    zeichenKette[i] = wort[i];
                    treffer++;
                }
            }
            return treffer;
        }

        static void Anzeige(char[] zeichenKette)
        {
            Console.Clear();
            ConsoleColor color = Console.ForegroundColor;
            
            foreach (char b in zeichenKette)
            {
                if (b != '\0')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("{0} ", b);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("_ ");
                }
            }
            Console.ForegroundColor = color;
        }
    }
}
