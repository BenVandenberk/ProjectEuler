using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(generateTriangularWith500Divisors());
        }

        static int aantalDelers(int input)
        {
            int aantal = 0;

            for (int i = 1; i < Math.Sqrt(input); i++)
            {
                if ((input % i) == 0)
                    aantal += 2;
            }

            return aantal;
        }

        static int generateTriangularWith500Divisors()
        {
            int huidig = 0;
            int teller = 1;

            while (aantalDelers(huidig) < 500)
            {
                huidig += teller;
                teller++;
            }

            return huidig;
        }
    }
}
