using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE34___Digit_factorials
{
    class Program
    {
        static int[] fact = { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880 };
        
        static void Main(string[] args)
        {
            int som = 0;

            for (int i = 10; i < 9999999; i++)
            {
                if (digitFact(i))
                {
                    Console.WriteLine(i);
                    som += i;
                }
            }

            Console.WriteLine(som);
        }

        static bool digitFact(int x)
        {
            int som = 0;
            string xS = x.ToString();

            for (int i = 0; i < xS.Length; i++)
            {
                som += fact[int.Parse(xS.Substring(i, 1))];
            }

            return som == x;
        }
    }
}
