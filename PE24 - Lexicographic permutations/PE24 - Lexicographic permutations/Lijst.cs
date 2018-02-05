using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace PE24___Lexicographic_permutations
{
    class Lijst
    {
        private char[] lijst;
        private int lengte;

        public int LENGTE
        {
            get { return lengte; }            
        }

        public Lijst(int aantalElementen)           // Max 36 lang (alle nummers en letters)
        {
            int werkelijkeAantalEl = aantalElementen > 36 ? 36 : aantalElementen;
            this.lijst = new char[werkelijkeAantalEl];
            this.lengte = werkelijkeAantalEl;

            for (int i = 0; i < werkelijkeAantalEl; i++)
            {
                if (i < 10)
                {
                    lijst[i] = (char)(i + 48);
                }
                else
                {
                    lijst[i] = (char)(i + 87);
                }
            }
        }

        public void Schrijf()
        {
            foreach (char kar in lijst)
            {
                Console.Write(kar + " ");
            }
            Console.WriteLine();
        }

        public string Permutatie(BigInteger volgNr)
        {
            char[][] werkLijst = new char[lengte][];
            werkLijst[0] = lijst;
            int aantalElementen = lengte;
            BigInteger x = volgNr;
            int keren = 0;
            string resultaat = "";

            for (int i = 1; aantalElementen > 1; i++, aantalElementen--)
            {
                while (x > faculteit(aantalElementen - 1))
                {
                    x -= faculteit(aantalElementen - 1);
                    keren++;
                }

                resultaat += werkLijst[i - 1][keren];

                werkLijst[i] = new char[aantalElementen - 1];
                for (int j = 0, k = 0; j < werkLijst[i].Length; j++, k++)
                {
                    if (j != keren)
                    {
                        werkLijst[i][j] = werkLijst[i - 1][k];
                    }
                    else
                    {
                        j--;
                        keren = -1;
                    }                    
                }
                keren = 0;
            }

            resultaat += werkLijst[lengte - 1][0];

            return resultaat;
        }

        private BigInteger faculteit(int n)
        {
            BigInteger result = new BigInteger(1);

            for (; n > 1; n--)
            {
                result *= n;
            }

            return result;            
        }
    }
}
