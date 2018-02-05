using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE9
{
    class Program
    {
        static int a = 0;
        static int b = 0;
        static int c = 0;

        static void Main(string[] args)
        {
            test();
            Console.WriteLine(a * b * c);
        }

        static void test ()
        {
            for (int i = 1; i < 500; i++)
                for (int j = i; j < 500; j++)
                {
                    if ((test(i, j)))
                    {
                        a = i;
                        b = j;
                        c = 1000 - i - j;
                    }
                }
        }

        static bool test(int inpt1, int inpt2)
        {
            int cee = 1000 - inpt1 - inpt2;

            return ( (inpt1 * inpt1) + (inpt2 * inpt2) ) == (cee * cee);
        }
    }
}
