using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE37___Truncatable_primes
{
    class LeftTruncatable
    {
        private int[] beginwaarden = { 2, 3, 5, 7 };
        private int[] toevoegen = { 1, 2, 3, 5, 7, 9 };
        
        private int qCijfers { get; set; }
        public List<long> LeftTruncatablePrimes { get; private set; }        

        public LeftTruncatable(int qCijfers)
        {
            this.qCijfers = qCijfers;
            LeftTruncatablePrimes = new List<long>();
            for (int i = 0; i < beginwaarden.Length; i++)
            {
                LeftTruncatablePrimes.Add(beginwaarden[i]);
            }
        }

        public List<long> Get()
        {
            vullen();
            return LeftTruncatablePrimes;
        }

        private void vullen()
        {
            string huidig = "";
            int start = 0;
            int volgendeStart = LeftTruncatablePrimes.Count;

            for (int i = qCijfers; i > 2; i--)
            {
                for (int j = start, stop = LeftTruncatablePrimes.Count; j < stop; j++)
                {
                    for (int k = 0; k < toevoegen.Length; k++)
                    {
                        huidig += String.Format("{0}{1}", toevoegen[k], LeftTruncatablePrimes[j]);
                        if (Helper.PriemCheck(long.Parse(huidig)))
                        {
                            LeftTruncatablePrimes.Add(long.Parse(huidig));
                        }
                        huidig = "";
                    }
                }
                start = volgendeStart;
                volgendeStart = LeftTruncatablePrimes.Count;
            }

            for (int j = start, stop = LeftTruncatablePrimes.Count; j < stop; j++)
            {
                for (int k = 0; k < beginwaarden.Length; k++)
                {
                    huidig += String.Format("{0}{1}", beginwaarden[k], LeftTruncatablePrimes[j]);
                    if (Helper.PriemCheck(long.Parse(huidig)))
                    {
                        LeftTruncatablePrimes.Add(long.Parse(huidig));
                    }
                    huidig = "";
                }
            }
        }
    }
}
