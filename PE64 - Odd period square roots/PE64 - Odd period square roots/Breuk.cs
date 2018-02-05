using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE64___Odd_period_square_roots
{
    public struct Breuk
    {
        public Expressie Teller;
        public Expressie Noemer;

        public double Value
        {
            get
            {
                if (Noemer.Value == 0)
                    return Teller.Value;
                else
                    return Teller.Value / Noemer.Value;
            }
        }

        public void TakeReciprocal()
        {
            Expressie temp = Teller;
            Teller = Noemer;
            Noemer = temp;
        }

        public void Simplify()
        {
            int ggd = gcd(Teller.Factor, Noemer.Factor);
            Teller.Factor /= ggd;
            Noemer.Factor /= ggd;
        }

        public override string ToString()
        {
            if (Noemer.Value == 1 || Noemer.Value == 0)
                return Teller.ToString();
            else
                return Teller.ToString() + "\n---------------------\n" + Noemer.ToString();
        }

        private int gcd(int a, int b)
        {
            while (a != b)
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }

            return a;
        }
    }
}
