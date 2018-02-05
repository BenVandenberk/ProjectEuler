using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace PE23___Non_abundant_sums
{
    class Program
    {
        static void Main(string[] args)
        {
            int grens = 0;
            ArrayList abundant = new ArrayList();            
            
            Console.Write("Geef het getal waaronder het programma alle getallen die niet te schrijven zijn als een som van 2 abundante getallen sommeert: ");
            grens = int.Parse(Console.ReadLine());

            for (int i = 12; i < 28112; i++)
            {
                if (somVanGeheleDelers(i) > i)
                {
                    abundant.Add(i);
                }
            }
            
            int[] abundanteTermen = new int[abundant.Count];
            int index = 0;
            foreach (int getal in abundant)
            {
                abundanteTermen[index++] = getal;
            }

            Console.WriteLine(somNietAbundant(grens, abundanteTermen));
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

        static int somNietAbundant(int bovenGrens, int[] abundanteLijst)
        {
            int som = 0;

            for (int i = 1; i <= bovenGrens; i++)
            {
                som += xSomVan2ElementenVanLijstY(abundanteLijst, i) ? 0 : i;
            }

            return som;
        }

        static bool deelVanLijst(int[] lijst, int startIndex, int zoek)
        {
            bool result = false;

            for (int i = startIndex; result == false && zoek >= lijst[i] && i < lijst.Length - 1; i++)
            {
                result = lijst[i] == zoek ? true : false;
            }

            return result;
        }

        static bool xSomVan2ElementenVanLijstY(int[] lijst, int x)
        {
            int huidigeIndex = 0;
            bool result = false;

            while (x > lijst[huidigeIndex] && result == false && huidigeIndex < lijst.Length)
            {
                if (deelVanLijstSneller(lijst, huidigeIndex, x - lijst[huidigeIndex]))
                {
                    result = true;
                }
                else
                {
                    huidigeIndex++;
                }
            }

            return result;
        }

        static bool deelVanLijstSneller(int[] lijst, int startIndex, int zoek)
        {
            int huidigeIndex = startIndex;
            int vorigeIndex = -1;
            bool result = false;

            if (zoek >= lijst[huidigeIndex])
            {
                while (result == false && huidigeIndex != vorigeIndex)
                {
                    if (zoek > lijst[huidigeIndex])
                    {
                        vorigeIndex = huidigeIndex;
                        huidigeIndex = up(lijst.Length, huidigeIndex);
                    }
                    else if (zoek < lijst[huidigeIndex])
                    {
                        huidigeIndex = down(vorigeIndex, huidigeIndex);
                        vorigeIndex = huidigeIndex;
                    }
                    else
                    {
                        result = true;
                    }
                }
            }
            
            return result;
        }

        static int up(int lijstLengte, int huidig)
        {
            double result = 0.0;

            result = huidig + Math.Ceiling((lijstLengte - 1 - huidig) / 2.0);

            return (int)result;
        }

        static int down(int vorige, int huidig)
        {
            double result = 0.0;

            result = huidig - Math.Floor((huidig - vorige) / 2.0);

            return (int)result;
        }
    }
}
