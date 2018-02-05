using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE37___Truncatable_primes
{
    static class Helper
    {
        static public bool PriemCheck (long x)
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

            for (long i = 2; i <= Math.Sqrt(x); i++)
            {
                if (x % i == 0)
                {
                    priem = false;
                }
            }

            return priem;
        }

        static public List<long> verwijder1(List<long> x)
        {
            List<long> result = new List<long>();

            foreach (int y in x)
            {
                if (y > 9)
                {
                    result.Add(y);
                }
            }

            return result;
        }

        static public List<long> verwijderNietRechtsTruncatable(List<long> leftT)
        {
            List<long> result = new List<long>();

            foreach (int lt in leftT)
            {
                if (RT(lt))
                {
                    result.Add(lt);
                }
            }

            return result;
        }

        static private bool RT(long x)
        {
            bool result = true;
            string xS = x.ToString();

            for (int i = 1; i <= xS.Length && result; i++)
            {
                if (!PriemCheck(long.Parse(xS.Substring(0, i))))
                {
                    result = false;
                }
            }

            return result;
        }
    }
}
