using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PE58___Spiral_primes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> diagonalNumbers = new List<int>();
            diagonalNumbers.Add(1);
            int nrOfPrimes = 0;
            int sideLength = 1;
            int term = 2;
            int current = 1;
            Stopwatch sw = new Stopwatch();

            sw.Start();

            do
            {
                sideLength += 2;
                for (int i = 0; i < 4; i++)
                {
                    current += term;
                    if (isPrime(current))
                    {
                        nrOfPrimes++;
                    }
                    diagonalNumbers.Add(current);
                }
                term += 2;
            } while ((double)nrOfPrimes / (double)diagonalNumbers.Count * 100 > 10.0 && current > 0);

            sw.Stop();

            Console.WriteLine(sideLength);
            Console.WriteLine("Computatietijd: " + sw.ElapsedMilliseconds + " ms.");
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
            else if (x % 2 == 0)
            {
                return false;
            }
            else
            {
                for (int i = 3; isPrime && i <= Math.Sqrt(x); i += 2)
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
