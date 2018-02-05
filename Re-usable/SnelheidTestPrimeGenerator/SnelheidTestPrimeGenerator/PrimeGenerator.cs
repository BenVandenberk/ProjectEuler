using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnelheidTestPrimeGenerator
{
    class PrimeGenerator
    {
        public List<int> Primes { get; private set; }
        public int Max { get; private set; }

        public PrimeGenerator(int max)
        {
            this.Max = max;
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

            for (int i = 2; i <= Max; i++)
            {
                if (!composite[i])
                {
                    Primes.Add(i);
                }
            }
        }
    }
}
