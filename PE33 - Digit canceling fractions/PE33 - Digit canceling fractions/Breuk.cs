using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE33___Digit_canceling_fractions
{
    struct Breuk
    {
        public int Teller;
        public int Noemer;

        public Breuk(int teller, int noemer)
        {
            Teller = teller;
            Noemer = noemer;
        }

        public double Value()
        {
            return (double)Teller / Noemer;
        }

        public bool CancelingFraction()
        {            
            if (Teller.ToString().Substring(0, 1) == Noemer.ToString().Substring(0, 1) && Noemer % 10 != 0)
            {
                if ((double)(Teller % 10) / (Noemer % 10) == Value())
                {
                    return true;
                }
            }

            if (Teller.ToString().Substring(0, 1) == Noemer.ToString().Substring(1, 1))
            {
                if ((double)(Teller % 10) / (Noemer / 10) == Value())
                {
                    return true;
                }
            }

            if (Teller.ToString().Substring(1, 1) == Noemer.ToString().Substring(0, 1))
            {
                if ((double)(Teller / 10) / (Noemer % 10) == Value() && Noemer % 10 != 0)
                {
                    return true;
                }
            }

            if (Teller.ToString().Substring(1, 1) == Noemer.ToString().Substring(1, 1))
            {
                if ((double)(Teller / 10) / (Noemer / 10) == Value())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
