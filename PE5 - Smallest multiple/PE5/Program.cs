using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(biggestEvenlyDivisible1To20());
        }

        static bool testTot11(int input)
        {
            for (int i = 18; i > 10; i--)
            {
                if ((input % i) != 0)
                    return false;
            }
            return true;
        }

        static int biggestEvenlyDivisible1To20()
        {
            int tussen = 380;
            while (!testTot11(tussen))
            {
                tussen += 380;
            }
            return tussen;
        }

    }
}
