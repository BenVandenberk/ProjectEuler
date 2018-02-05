using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PE49___Prime_permutations
{
    class Program
    {
        static List<int> permutations = new List<int>();
        static List<int> result = new List<int>();
        
        static void Main(string[] args)
        {
            PrimeGenerator pg = new PrimeGenerator(9999, 1000);
            Stopwatch sw = new Stopwatch();

            sw.Start();

            for (int i = 0; i < pg.Primes.Count; i++)
            {
                Permutations(pg.Primes[i].ToString(), 4, "");
                removeNonPrimes();
                permutations.Sort();
                if (containsArithmethicSeries())
                {
                    foreach (int g in result)
                    {
                        Console.Write(g + "\t");
                    }
                    Console.WriteLine();
                }
                foreach (int perm in permutations)
                {
                    pg.Primes.Remove(perm);
                }
                permutations.Clear();
                result.Clear();
            }

            sw.Stop();
            Console.WriteLine("Computatietijd: {0} ms", sw.ElapsedMilliseconds);
        }

        static void Permutations(string x, int length, string current)
        {
            if (length == 1)
            {
                current += x;
                permutations.Add(int.Parse(current));
            }
            else
            {
                for (int i = 0; i < x.Length; i++)
                {
                    current += x.Substring(i, 1);
                    string y = x.Remove(i, 1);                    
                    Permutations(y, length - 1, current);
                    current = current.Substring(0, current.Length - 1);
                }
            }
        }

        static bool containsArithmethicSeries()
        {
            int difference;
            
            for (int i = 0; i < permutations.Count - 2; i++)
            {
                for (int j = i + 1; j < permutations.Count - 1; j++)
                {
                    difference = permutations[j] - permutations[i];
                    if (difference < 1000)
                    {
                        continue;
                    }
                    for (int k = j + 1; k < permutations.Count; k++)
                    {
                        if (permutations[j] + difference == permutations[k])
                        {
                            result.Add(permutations[i]);
                            result.Add(permutations[j]);
                            result.Add(permutations[k]);
                            return true;
                        }
                    }
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

        static void removeNonPrimes()
        {
            for (int i = permutations.Count - 1; i >= 0; i--)
            {
                if (!isPrime(permutations[i]) || permutations[i] < 1000) // de permutaties die begonnen met een '0' zijn na de int.Parse getallen onder 1000 geworden
                {
                    permutations.RemoveAt(i);
                }
            }
        }
    
    }
}
