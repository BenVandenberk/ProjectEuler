using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE28___Number_spirals_diagonals
{
    class Program
    {
        static void Main(string[] args)
        {
            int verhoogMet = 2;
            int a = 1, b = 1, c = 1, d = 1;
            int resultaat = 1;

            for (int i = 0; i < 500; i++)
            {
                a += verhoogMet;
                verhoogMet += 2;
                b += verhoogMet;
                verhoogMet += 2;
                c += verhoogMet;
                verhoogMet += 2;
                d += verhoogMet;
                verhoogMet += 2;
                resultaat += a + b + c + d;
            }

            Console.WriteLine(resultaat);
            
        }
    }
}
