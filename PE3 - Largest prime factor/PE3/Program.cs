using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE3
{
    class Program
    {
        static double priemfactor;
        static int deler = 2;

        static void Main(string[] args)
        {
            double origineel;
            
            Console.Write("Voer een getal in waarvan het programma de grootste priemfactor berekent: ");
            origineel = double.Parse(Console.ReadLine());
            priemfactor = origineel;

            grootstePriemfactor();
            Console.WriteLine("\nDe grootste priemfactor van {0} is {1}!",origineel, priemfactor);
        }

        static void grootstePriemfactor()
        {
            while (deler < Math.Sqrt(priemfactor))
            {
                updatePriemfactor();
            }
        }

        static void updateDeler(int vorigeDeler)
        {
            if (vorigeDeler == 2)
                deler = 3;
            else
                deler += 2;
        }

        static void updatePriemfactor()
        {
            while (priemfactor % deler == 0)
            {
                priemfactor /= deler;
            }
            updateDeler(deler);
        }
    }
}
