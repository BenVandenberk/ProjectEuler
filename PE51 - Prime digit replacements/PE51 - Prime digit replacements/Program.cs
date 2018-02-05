using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PE51___Prime_digit_replacements
{
    class Program
    {
        static Dictionary<int, List<int[]>> PrimeFamilies = new Dictionary<int,List<int[]>>();
        const int FAMILYSIZE = 8;
        const int min = 56003;
        const int max = 200000;
        
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            
            bool hit = false;
            int familyNumber = 0;
            int resultingPrime = 0;
            int transformed;

            sw.Start();
                        
            List<int[]> Trans5 = GetAllTransformations(5);
            List<int[]> Trans6 = GetAllTransformations(6);
            PrimeGenerator pg = new PrimeGenerator(min, max);

            for (int i = 0; i < pg.Primes.Count; i++)
            {
                if (pg.Primes[i] < 100000)
                {
                    PrimeFamilies.Add(pg.Primes[i], new List<int[]>(Trans5));
                }
                else
                {
                    PrimeFamilies.Add(pg.Primes[i], new List<int[]>(Trans6));
                }
            }

            for (int i = 0; !hit && i < pg.Primes.Count; i++)
            {
                for (int j = 0; !hit && j < PrimeFamilies[pg.Primes[i]].Count; j++)
                {
                    hit = isOfDesiredFamilySize(pg.Primes[i], PrimeFamilies[pg.Primes[i]][j]);
                    if (hit)
                    {
                        familyNumber = j;
                    }
                }
                if (hit)
                {
                    resultingPrime = pg.Primes[i];
                }
            }

            Console.WriteLine("De eerste prime in een familie van 8 is {0}", resultingPrime);
            Console.WriteLine("De familie ziet er als volgt uit: ");
            for (int i = 0; i < 10; i++)
            {
                transformed = Transform(resultingPrime, i, PrimeFamilies[resultingPrime][familyNumber]);
                if (isPrime(transformed))
                {
                    Console.Write(transformed + " ");
                }
            }
            Console.WriteLine();

            sw.Stop();

            Console.WriteLine("Computatietijd: {0} ms", sw.ElapsedMilliseconds);
        }

        static bool isOfDesiredFamilySize(int prime, int[] transformation)
        {
            int stopValue = 10 - FAMILYSIZE + 1;
            int count = 0;
            int transformed;
            int start;

            if (transformation[0] == 1)
            {
                count++;
                start = 1;
            }
            else
            {
                start = 0;
            }

            for (int i = start; count < stopValue && i < 10; i++)
            {
                transformed = Transform(prime, i, transformation);
                if (!isPrime(transformed))
                {
                    count++;
                }
                else 
                {
                    if (transformed <= max && transformed > prime)
                    {
                        PrimeFamilies[transformed].Remove(transformation);
                    }
                }
            }

            return count >= stopValue ? false : true;
        }

        static int Transform(int prime, int replacingDigit, int[] transformation)
        {
            string primeS = prime.ToString();
            string Transformed = "";

            for (int i = 0; i < transformation.Length; i++)
            {
                if (transformation[i] == 0)
                {
                    Transformed += primeS.Substring(i, 1);
                }
                else
                {
                    Transformed += replacingDigit;
                }
            }
            Transformed += primeS.Substring(primeS.Length - 1, 1);

            return int.Parse(Transformed);
        }


        /* For an n-digit number we need transformation matrices of length n-1. There is no point in replacing the last digit of a prime since all even
         * numbers will not create primes and thus the maximum family size of any family obtained through replacing the last digit is 5.
         * A transformation matrix is of the form {0,1,1,0,0} (this being a replacement of digit 2 and 3 of a 6-digit number)
         * The number of such transformation matrices is 2^(n-1) - 1. The minus one because {0,0,0,0,0} is the identity transformation and is not valid
         * for this problem */

        static List<int[]> GetAllTransformations(int numberLength) // Iterative method to generate all binary combinations of length numberlength - 1
        {
            List<int[]> Transformations = new List<int[]>();
            int[] current = new int[numberLength - 1];
            bool stop = false;

            current[0] = 1; // Start with matrix {1,0,0,...,0}

            for (int i = 0; i <= ((int)Math.Pow(2, numberLength - 1) - 1) / 2; i++) // Add matrices {1,0,0,...,0} up to {1,1,1,...,1}
            {
                Transformations.Add(new int[numberLength - 1]);
                current.CopyTo(Transformations[i], 0);
                if (current[current.Length - 1] == 0)
                {
                    current[current.Length - 1] = 1;
                }
                else
                {
                    for (int j = current.Length - 1; !stop && j >= 0; j--)
                    {
                        if (current[j] == 1)
                        {
                            current[j] = 0;
                        }
                        else
                        {
                            current[j] = 1;
                            stop = true;
                        }
                    }
                }
                stop = false;
            }

            for (int i = ((int)Math.Pow(2, numberLength - 1) - 1) / 2 + 1, j = 0; i < (int)Math.Pow(2, numberLength - 1) - 1; i++, j++) // The next half is simply the inverse of the previous half
            {
                for (int k = 0; k < Transformations[j].Length; k++)
                {
                    current[k] = Transformations[j][k] == 0 ? 1 : 0;
                }
                Transformations.Add(new int[numberLength - 1]);
                current.CopyTo(Transformations[i], 0);
            }

            return Transformations;
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
                for (int i = 3; isPrime && i <= Math.Sqrt(x); i+=2)
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
