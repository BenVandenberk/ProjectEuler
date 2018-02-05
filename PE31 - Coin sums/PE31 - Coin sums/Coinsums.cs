using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE31___Coin_sums
{
    class Coinsums
    {
        public List<int> Coins { get; set; }
        public int Bedrag { get; set; }
        public MuntCombinaties MC { get; set; }
        public List<List<int>> Combinaties { get; set; }

        public Coinsums(List<int> coins, int bedrag)
        {
            Coins = coins;
            Bedrag = bedrag;
            MC = new MuntCombinaties(coins);
            Combinaties = MC.GeefCombinaties();
        }

        private int count(List<int> munten)
        {
            int counter = 0;
            int temp = Bedrag;
            int[] factor = new int[munten.Count];
            bool gereset = false;

            for (int i = 0; i < factor.Length; i++)
            {
                factor[i] = 1;
            }

            while (factor[factor.Length - 1] * munten[munten.Count - 1] < Bedrag)
            {
                for (int i = factor.Length - 1; i > 0 && !gereset; i--)
                {
                    temp -= factor[i] * munten[i];
                    if (temp <= 0)
                    {
                        reset(factor, i);
                        gereset = true;
                    }
                }
                if (temp % munten[0] == 0 && !gereset)
                {
                    counter++;
                    factor[1]++;
                }
                else if (!gereset)
                {
                    factor[1]++;
                }
                temp = Bedrag;
                gereset = false;
            }

            return counter;
        }

        private void reset(int[] factor, int wanneer)
        {
            for (int i = 0; i <= wanneer; i++)
            {
                factor[i] = 1;
            }
            factor[wanneer + 1]++;
        }

        public int AantalMogelijkheden()
        {
            int c = 0;

            verwijderFouteCombos();
            foreach (List<int> lijst in Combinaties)
            {
                if (lijst.Count == 1)
                {
                    c += Bedrag % lijst[0] == 0 ? 1 : 0;
                }
                else
                {
                    c += count(lijst);
                }
            }

            return c;
        }

        private void verwijderFouteCombos()
        {
            int som = 0;

            for (int i = Combinaties.Count - 1; i >= 0; i--)
            {
                foreach (int getal in Combinaties[i])
                {
                    som += getal;
                }

                if (som > Bedrag)
                {
                    Combinaties.RemoveAt(i);
                }

                som = 0;
            }
        }    
    }
}
