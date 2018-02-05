using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE32___Pandigital_products
{
    static class Helper
    {                             
        static private List<int> combos;
        static private string temp;
        
        static public List<int> Overblijvers(int deeltal)
        {
            List<int> result = new List<int>();
            string deeltalS = deeltal.ToString();
            int[] copy = new int[deeltalS.Length];

            for (int i = 0; i < deeltalS.Length; i++)
            {
                copy[i] = int.Parse(deeltalS.Substring(i, 1));
            }

            for (int i = 1; i < 10; i++)
            {
                if (!copy.Contains(i))
                {
                    result.Add(i);
                }
            }

            return result;
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

        static public string ConcatenateInts(int g1, int g2, int g3)
        {
            return g1.ToString() + g2.ToString() + g3.ToString();
        }

        static public List<int> GeefCombinaties(List<int> getallen, int qGetallen)
        {
            combos = new List<int>();
            temp = "";
            combosRec(getallen, qGetallen);
            return combos;
        }

        static public bool CheckDeeltal(int deeltal)
        {
            bool ok = true;
            string deeltalS = deeltal.ToString();
            int[] lijst = new int[deeltalS.Length];
            int index = 0;

            for (int i = 0; i < deeltalS.Length && ok; i++)
            {
                if (deeltalS.Substring(i, 1) == "0" || lijst.Contains(int.Parse(deeltalS.Substring(i, 1))))
                {
                    ok = false;
                }
                else
                {
                    lijst[index++] = int.Parse(deeltalS.Substring(i, 1));                    
                }
            }

            return ok;
        }

        static private void combosRec(List<int> getallen, int qGetallen)
        {
            List<int> l = new List<int>();
            
            if (qGetallen == 1)
            {
                foreach (int getal in getallen)
                {
                    temp += getal;
                    combos.Add(int.Parse(temp));
                    temp = temp.Substring(0, temp.Length - 1); 
                }
            }
            else
            {
                for (int i = 0; i < getallen.Count; i++)
                {
                    l = new List<int>();
                    temp += getallen[i];
                    for (int j = 0; j < getallen.Count; j++)
                    {
                        if (!temp.Contains(getallen[j].ToString()))
                        {
                            l.Add(getallen[j]);
                        }
                    }
                    combosRec(l, qGetallen - 1);
                    temp = temp.Substring(0, temp.Length - 1); 
                }
            }
        }
    }
}
