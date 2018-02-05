using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE41___Pandigital_prime
{
    static class Helper
    {
        static public bool PrimeCheck(int x)
        {
            bool priem = true;

            if (x == 1)
            {
                return false;
            }

            if (x == 2)
            {
                return true;
            }

            for (int i = 2; i <= Math.Sqrt(x); i++)
            {
                if (x % i == 0)
                {
                    priem = false;
                }
            }

            return priem;
        }        
    }
}
