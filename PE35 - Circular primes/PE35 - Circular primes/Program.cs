using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE35___Circular_primes
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 13;

            for (int i = 100; i < 1000000; i++)
            {
                if (priemCheck(i))
                {
                    if (circularCheck(i))
                    {
                        Console.WriteLine(i);
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }

        static bool priemCheck(int x)
        {
            bool priem = true;

            for (int i = 2; i <= Math.Sqrt(x) && priem; i++)
            {
                if (x % i == 0)
                {
                    priem = false;
                }
            }

            return priem;
        }

        static bool circularCheck(int x)
        {
            bool circularPriem = true;
            string xS = x.ToString();

            for (int i = 1; i < xS.Length && circularPriem; i++)
            {
                circularPriem = priemCheck(int.Parse(xS.Substring(i, xS.Length - i) + xS.Substring(0, i)));
            }

            return circularPriem;
        }
    }
}
