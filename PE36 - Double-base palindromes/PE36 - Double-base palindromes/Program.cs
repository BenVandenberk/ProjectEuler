using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PE36___Double_base_palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            int som = 0;
            Stopwatch sw = new Stopwatch();

            sw.Start();
            for (int i = 1; i < 1000000000; i++)
            {
                if (palindroomCheck(i) && palindroomCheck(toBinary(i)))
                {
                    Console.WriteLine(i + "\t" + toBinary(i));
                    som += i;
                }
            }
            sw.Stop();

            Console.WriteLine(som);
            Console.WriteLine(sw.ElapsedMilliseconds);
        }

        static string toBinary(int x)
        {
            int pow = 0;
            string result = "";

            for (int i = x; i > 1; i /= 2)
            {
                pow++;
            }

            for (int i = pow, j = x; i >= 0; i--)
            {
                if (j - Math.Pow(2, i) >= 0)
                {
                    result += "1";
                    j -= (int)Math.Pow(2, i);
                }
                else
                {
                    result += "0";
                }
            }

            return result;
        }

        static bool palindroomCheck(int x)
        {
            string xS = x.ToString();
            bool pal = true;

            if (xS.Length == 1)
            {
                return true;
            }
            
            for (int i = 0; i <= (xS.Length / 2) - 1 && pal; i++)
            {
                if (xS.Substring(i, 1) != xS.Substring(xS.Length - i - 1, 1))
                {
                    pal = false;
                }
            }

            return pal;
        }

        static bool palindroomCheck(string x)
        {
            string xS = x;
            bool pal = true;

            if (xS.Length == 1)
            {
                return true;
            }

            for (int i = 0; i <= (xS.Length / 2) - 1 && pal; i++)
            {
                if (xS.Substring(i, 1) != xS.Substring(xS.Length - i - 1, 1))
                {
                    pal = false;
                }
            }

            return pal;
        }
    }
}
