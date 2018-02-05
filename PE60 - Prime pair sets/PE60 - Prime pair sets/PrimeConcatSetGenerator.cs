using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE60___Prime_pair_sets
{
    public class PrimeConcatSetGenerator
    {
        private PrimeGenerator pg;
        private CustomDictionary<int, List<int>> concatSetsOf2;

        private List<int> currentKeys;
        private bool isContainedInAllPreviousSets;

        public int SetSize { get; private set; }
        public int PrimeLimit { get; private set; }
        public List<int[]> ConcatSets { get; private set; }

        public PrimeConcatSetGenerator(int setSize, int primeLimit)
        {
            this.SetSize = setSize;
            this.PrimeLimit = primeLimit;

            currentKeys = new List<int>();
            concatSetsOf2 = new CustomDictionary<int, List<int>>();
        }

        public void Generate()
        {
            ConcatSets = new List<int[]>();
            pg = new PrimeGenerator(PrimeLimit);

            generateSetsOf2();
            lookForSetsOfSetSize(3, 1, 1);
        }

        private void lookForSetsOfSetSize(int currentKey, int keyIndex, int depth)
        {                     
            if (depth == SetSize)
            {
                currentKeys.Add(currentKey);
                ConcatSets.Add(currentKeys.ToArray());
                //Console.WriteLine("nu!");
                currentKeys.Remove(currentKey);
            }
            else
            {
                if (concatSetsOf2[currentKey].Count == 0)
                {
                    try
                    {
                        lookForSetsOfSetSize(concatSetsOf2.CustomKeys[keyIndex + 1], keyIndex + 1, depth);
                    }
                    catch
                    { }
                }
                else
                {
                    if (depth == 1)
                    {
                        for (int x = 1; x < concatSetsOf2.CustomKeys.Count - SetSize; x++)
                        {
                            currentKey = concatSetsOf2.CustomKeys[x];
                            currentKeys.Add(currentKey);
                            lookForSetsOfSetSize(concatSetsOf2.CustomKeys[x + 1], keyIndex + 1, depth + 1);
                            currentKeys.Remove(currentKey);
                        }
                    }
                    else
                    {
                        for (int ki = keyIndex; ki < concatSetsOf2.CustomKeys.Count - (SetSize - depth); ki++)
                        {
                            currentKey = concatSetsOf2.CustomKeys[ki];
                            for (int i = 0; i < concatSetsOf2[currentKey].Count; i++)
                            {
                                isContainedInAllPreviousSets = true;                                
                                for (int j = 0; j < currentKeys.Count && isContainedInAllPreviousSets; j++)
                                {
                                    if (!concatSetsOf2[currentKeys[j]].Contains(currentKey) || !concatSetsOf2[currentKeys[j]].Contains(concatSetsOf2[currentKey][i]))
                                    {
                                        isContainedInAllPreviousSets = false;
                                    }
                                }
                                if (isContainedInAllPreviousSets)
                                {
                                    currentKeys.Add(currentKey);
                                    lookForSetsOfSetSize(concatSetsOf2[currentKey][i], ki, depth + 1);                                    
                                    currentKeys.Remove(currentKey);
                                }
                            }
                        }
                    }
                }
            }
        }


        private void generateSetsOf2()
        {
            for (int i = 0; i < pg.Primes.Count; i++)
            {
                concatSetsOf2.Add(pg.Primes[i], new List<int>());
                for (int j = i + 1; j < pg.Primes.Count; j++)
                {
                    if (areConcatanablePrimes(pg.Primes[i], pg.Primes[j]))
                    {
                        concatSetsOf2[pg.Primes[i]].Add(pg.Primes[j]);
                    }
                }
            }
        }

        private bool areConcatanablePrimes(int prime1, int prime2)
        {
            bool result = true;

            for (int kant = 0; kant <= 1 && result; kant++)
            {
                if (kant == 0) // links
                {
                    result = isPrime(concat(prime1, prime2));
                }
                else // rechts
                {
                    result = isPrime(concat(prime2, prime1));
                }
            }

            return result;
        }

        private bool areConcatanablePrimes(int[] concatSet1, int[] concatSet2)
        {
            bool result = true;

            for (int i = 0; i < concatSet1.Length && result; i++)
            {
                for (int j = 0; j < concatSet2.Length && result; j++)
                {
                    for (int kant = 0; kant <= 1 && result; kant++)
                    {
                        if (kant == 0) // links
                        {
                            result = isPrime(concat(concatSet1[i], concatSet2[j]));
                        }
                        else // rechts
                        {
                            result = isPrime(concat(concatSet2[j], concatSet1[i]));
                        }
                    }
                }
            }

            return result;
        }

        private int concat(int x, int y)
        {
            return int.Parse(x.ToString() + y.ToString());
        }

        private bool isPrime(int x)
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
