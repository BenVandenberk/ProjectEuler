using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE14
{
    class Program
    {
        static int counter = 0;
        static long langsteCollatz = 0;
                
        static void Main(string[] args)
        {
            collatz1TotX(int.Parse(Console.ReadLine()));
            Console.WriteLine(langsteCollatz);
            Console.WriteLine(counter);
        }

        static bool even(long test)
        {
            return (test % 2) == 0;
        }

        static long updateCollatz(long teUpdaten)
        {
            if (even(teUpdaten))
                return (teUpdaten / 2);
            else
                return ((3 * teUpdaten) + 1);
        }

        static void collatz1TotX(int grens)
        {
            for (int i = 2; i < grens; i++)
            {
                long huidig = i;
                int counter2 = 1;
                while (huidig > 1)
                {
                    huidig = updateCollatz(huidig);
                    counter2++;
                }
                checkEnUpdate(counter2, i);
             }
        }

        static void checkEnUpdate(int counterTest, int collatzTest)
        {
            if (counterTest > counter)
            {
                counter = counterTest;
                langsteCollatz = collatzTest;
            }                       
        }
    }
}
