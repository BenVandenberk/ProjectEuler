using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Het programma berekent het verschil tussen de som van de kwadraten en het kwadraat van de som van de natuurlijke getallen tot en met: ");
            int boven = int.Parse(Console.ReadLine());
            
            Console.WriteLine(abs(somVanKwadraten(boven) - kwadraatVanSom(boven)));
        }

        static int somVanKwadraten(int bovenGrens)
        {
            int som = 0;
            for (int i = 1; i <= bovenGrens; i++)
                som += i * i;
            return som;
        }

        static int kwadraatVanSom(int bovenGrens)
        {
            int som = 0;
            for (int i = 1; i <= bovenGrens; i++)
                som += i;
            return som * som;
        }

        static int abs(int input)
        {
            if (input >= 0)
                return input;
            else
                return -input;
        }
    }
}
