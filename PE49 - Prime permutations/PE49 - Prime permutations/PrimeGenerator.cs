using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE49___Prime_permutations
{
    class PrimeGenerator
    {
        public List<int> Primes { get; private set; }
        public int Max { get; private set; }
        public int Min { get; private set; }

        public PrimeGenerator(int max, int min)
        {
            this.Max = max;
            this.Min = min;
            this.Primes = new List<int>();
            generator();
        }

        private void generator()
        {
            bool[] composite = new bool[Max + 1];

            for (int i = 2; i * i <= Max; i++)
            {
                for (int j = i; i * j <= Max; j++)
                {
                    composite[i * j] = true;
                }
            }

            for (int i = Min; i <= Max; i++)
            {
                if (!composite[i])
                {
                    Primes.Add(i);
                }
            }
        }
    }
}
