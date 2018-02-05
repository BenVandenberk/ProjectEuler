using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE33___Digit_canceling_fractions
{
    static class Helper
    {
        public static int GGD(int g1, int g2)
        {
            int big = g1 >= g2 ? g1 : g2;
            int small = g1 == big ? g2 : g1;

            for (int i = small; i > 0; i--)
            {
                if (big % i == 0)
                {
                    return i;
                }
            }

            return 1;
        }
    }
}
