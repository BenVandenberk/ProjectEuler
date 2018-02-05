using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PE47___Distinct_primes_factors
{
    class Program
    {
        static List<int> primes = new List<int>();
        static List<int> primefactors = new List<int>();

        static void Main()
        {
            int count = 0;
            int result = 0;
            Stopwatch sw = new Stopwatch();

            sw.Start();

            PrimeGenerator pg = new PrimeGenerator(4000);
            primes = pg.Primes;

            for (int i = 644; count < 4; i++)
            {                
                if (distinctPrimeFactors(i) == 4)
                {
                    count++;
                }
                else
                {
                    count = 0;
                }
                if (count == 4)
                {
                    result = i - 3;
                }                             
            }

            sw.Stop();

            Console.WriteLine(result);
            Console.WriteLine("Computatietijd: " + sw.ElapsedMilliseconds + " ms");
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


        static int distinctPrimeFactors(int x)
        {
            primefactors.Clear();

            for (int i = 0; x > 1 && i < primes.Count; i++)
            {
                if (x % primes[i] == 0)
                {
                    x /= primes[i];
                    if (!primefactors.Contains(primes[i]))
                    {
                        primefactors.Add(primes[i]);
                    }
                    i--;
                }
            }

            return primefactors.Count;
        }
    }  
}
