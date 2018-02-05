using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE26___Reciprocal_cycles
{
    class Deling
    {
        private int deeltal = 0;
        private int deler = 0;
        private int beduidendeCijfers = 0;
        private string quotient = "";

        public string QUOTIENT
        {
            get { return this.quotient = xNauwkeurig(beduidendeCijfers); }
        }

        public Deling(int deeltal, int deler, int beduidendeCijfers)
        {
            this.deeltal = deeltal;
            this.deler = deler;
            this.beduidendeCijfers = beduidendeCijfers;
        }

        private string xNauwkeurig(int n)
        {
            string result = "";

            for (int i = n; deeltal % deler != 0 && i > 0; i--)
            {
                result += (deeltal / deler);
                deeltal -= (deeltal / deler) * deler;
                deeltal *= 10;
            }
            result += (deeltal / deler);

            return result;
        }
    }
}
