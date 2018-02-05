using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace PE21
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList amicables = new ArrayList();
            int som = 0;
            int aantal = 0;
            int somDelers = 0;
            
            Console.Write("Het programma berekent de som van alle amicable numbers onder: ");
            aantal = int.Parse(Console.ReadLine());

            for (int i = 1; i < aantal; i++)
            {
                somDelers = somVanGeheleDelers(i);
                if (somVanGeheleDelers(somDelers) == i && somDelers != i)
                {
                    amicables.Add(i);
                }                
            }

            foreach (int amicable in amicables)
            {
                som += amicable;
            }

            Console.WriteLine("\nDe som van alle amicable numbers onder {0} is {1}", aantal, som);
        }

        static int somVanGeheleDelers(int invoer)
        {
            int som = 1;

            for (int deler = 2; deler < Math.Sqrt(invoer); deler++)
            {
                som += invoer % deler == 0 ? deler + invoer / deler : 0;
            }
            som += Math.Sqrt(invoer) % 1 == 0 && invoer != 1 ? (int)Math.Sqrt(invoer) : 0;

            return som;
        }
    }
}
