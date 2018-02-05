using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE31___Coin_sums
{
    class Coinsums2
    {
        private int[] Coins { get; set; }
        private int Bedrag { get; set; }            

        public Coinsums2(int[] coins, int bedrag)
        {
            Coins = coins;
            Bedrag = bedrag;                                   
        } 

        private bool test(int[] munten)
        {
            int som = 0;

            foreach (int munt in munten)
            {
                som += munt;
            }

            return som > Bedrag ? false : true;
        }

        public int mogelijkheden(int[] munten) // geen lijst van 1 element in voeren - is triviaal geval
        {
            int c = 0;
            int temp = Bedrag;
            List<int> indices = new List<int>();
            int[] aantalKeren = new int[munten.Length];

            for (int i = 0; i < aantalKeren.Length; i++) // Initialisatie van indices en aantalKeren
            {
                aantalKeren[i] = 1;
            }
            indices.Add(1);

            while (aantalKeren[aantalKeren.Length - 1] * munten[munten.Length - 1] < Bedrag)
            {
                for (int i = munten.Length - 1; i > 0; i--) // Munten aftrekken en aantalKeren[1] ophogen voor volgende keer
                {
                    temp -= aantalKeren[i] * munten[i];

                    if (temp <= 0 && !indices.Contains(i)) // Testen of de reset niet uitgebreid moet worden
                    {
                        indices.Add(i);
                    }
                }
                aantalKeren[1]++;

                if (temp <= 0) // Er dient zich een reset aan
                {
                    foreach (int index in indices)
                    {
                        aantalKeren[index] = 1;
                    }
                    aantalKeren[indices[indices.Count - 1] + 1]++; // Een volgende munt wordt met 1 opgehoogd
                }
                else if (temp % munten[0] == 0) // Kijken of de kleinste munt het bedrag kan afmaken
                {
                    c++;
                }

                temp = Bedrag; // Beginwaarde herstellen
            }

            return c;
        }        
    }
}
