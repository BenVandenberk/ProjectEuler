using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PE50___Consecutive_prime_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            int tempSum = 0;
            int count = 0;
            int maxPrime = 0;
            int maxCount = 0;

            sw.Start();

            PrimeGenerator pg = new PrimeGenerator(100000);

            for (int i = 0; i < pg.Primes.Count; i++)
            {
                tempSum += pg.Primes[i];
                count++;
                for (int j = i + 1; tempSum < 1000000 && j < pg.Primes.Count; j++)
                {
                    tempSum += pg.Primes[j];
                    count++;
                    if (count > maxCount && isPrime(tempSum))
                    {
                        maxPrime = tempSum;
                        maxCount = count;
                    }
                }
                tempSum = 0;
                count = 0;
            }

            sw.Stop();

            Console.WriteLine("{0} is het priemgetal onder 1,000,000 dat geschreven kan worden als de som van {1} opeenvolgende priemgetallen", maxPrime, maxCount);
            Console.WriteLine("Computatietijd: {0} ms", sw.ElapsedMilliseconds);
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
