using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PE46___Goldbach_s_other_conjecture
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            bool stop = false;
            Stopwatch sw = new Stopwatch();

            sw.Start();

            for (int i = 9; !stop; i += 2)
            {
                if (!isPrime(i))
                {
                    stop = !sumOfPrimeTwiceSquare(i);
                }
                if (stop)
                {
                    result = i;
                }
            }

            sw.Stop();

            Console.WriteLine(result);
            Console.WriteLine("Computatietijd: " + sw.ElapsedMilliseconds + " ms");
        }

        static bool sumOfPrimeTwiceSquare(int x)
        {
            for (int i = 1; 2 * i * i <= x - 2; i++)
            {
                if (isPrime(x - 2 * i * i))
                {
                    return true;
                }
            }
            return false;
        }

        static bool isPrime(int x)
        {
            bool isPrime = true;
            
            if (x == 1)
            {
                return false;
            }
            else if (x == 2)
            {
                return true;
            }
            else
            {
                for (int i = 2; isPrime && i <= Math.Sqrt(x); i++)
                {
                    if (x % i == 0)
                    {
                        isPrime = false;
                    }
                }
            }

            return isPrime;
        }
    }
}
