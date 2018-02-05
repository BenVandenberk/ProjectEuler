using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace PE24___Lexicographic_permutations
{
    class Program
    {
        static void Main(string[] args)
        {
            int lengte = 0;
            BigInteger volgNr;
            Lijst l;
            string antwoord = "";

            try
            {
                do
                {
                    Console.Write("Hoeveel elementen bevat de lijst? (max 36) ");
                    lengte = int.Parse(Console.ReadLine());
                    l = new Lijst(lengte);

                    Console.WriteLine("\nDe lijst: ");
                    l.Schrijf();

                    Console.Write("\nDe hoeveelste permutatie wens je? ");
                    volgNr = BigInteger.Parse(Console.ReadLine());

                    Console.WriteLine("De {0}e permutatie is: {1}\n", volgNr, l.Permutatie(volgNr));
                    Console.Write("Nogmaals? (j/n): ");
                    antwoord = Console.ReadLine();
                    Console.WriteLine("----------------------------------------------");
                } while (antwoord != "n" && antwoord != "N");
            }
            catch (Exception)
            {
                Console.WriteLine("Oops, foutje!");
            }


        }
    }
}
