using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PE40___Champernowne_s_constant
{
    class Program
    {
        static void Main(string[] args)
        {                       
            int result = 1;
            Stopwatch sw = new Stopwatch();

            sw.Start();
            for (int i = 1; i < 1000001; i *= 10)
            {
                result *= nThChampernowneDigit(i);
            }
            sw.Stop();

            Console.WriteLine("Het product van d1, d10, d100, d1000, d10000, d100000 en d1000000 is: {0}", result);
            Console.WriteLine("Computatietijd: {0} ms", sw.ElapsedMilliseconds);
        }

        static int nThChampernowneDigit(int n)
        {
            int qDigits = 1;
            int number;

            for (int i = 9, k = 1; n - i * k > 0; i *= 10, k++)
            {
                n -= i * k;
                qDigits++;
            }

            if (n % qDigits == 0)
            {
                number = nThNumberOfLength(n / qDigits, qDigits);
                return int.Parse(number.ToString().Substring(number.ToString().Length - 1, 1));
            }
            else
            {
                number = nThNumberOfLength(n / qDigits + 1, qDigits);
                return int.Parse(number.ToString().Substring(n % qDigits - 1, 1));
            }
        }

        static int nThNumberOfLength(int n, int length)
        {
            double result = 0.1;

            for (int i = length; i > 0; i--)
            {
                result *= 10;
            }

            return (int)result + n - 1;
        }
    }
}
