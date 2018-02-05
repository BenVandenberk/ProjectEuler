using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE38___Pandigital_multiples
{
    static class Helper
    {
        static public string ConcatenateInts(int g1, int g2)
        {
            return g1.ToString() + g2.ToString();
        }

        static public bool CheckPandigital(string s)
        {
            List<int> tempL = new List<int>();
            bool pandigital = true;

            if (s.Length != 9 || s.Contains("0"))
            {
                return false;
            }

            for (int i = 0; i < s.Length && pandigital; i++)
            {
                if (!tempL.Contains(int.Parse(s.Substring(i, 1))))
                {
                    tempL.Add(int.Parse(s.Substring(i, 1)));
                }
                else
                {
                    pandigital = false;
                }
            }

            return pandigital;
        }

        static public bool CheckVerschillendeCijfers(int x)
        {
            List<int> temp = new List<int>();
            char[] arr = x.ToString().ToCharArray();
            bool result = true;

            for (int i = 0; i < arr.Length; i++)
            {
                if (result && !temp.Contains((int)arr[i]))
                {
                    temp.Add((int)arr[i]);
                }
                else
                {
                    result = false;
                }
            }

            return result;
        }
    }
}
