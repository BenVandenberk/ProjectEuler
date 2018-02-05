using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE43___Sub_string_divisibility
{
    class PandigRecurser
    {              
        private List<int> digits { get; set; }
        private List<long> subStringDivisible { get; set; }
        private int[] priemgetallen = { 2, 3, 5, 7, 11, 13, 17 };
        private Stack<int> indices { get; set; }

        public PandigRecurser()
        {            
            digits = new List<int>();
            subStringDivisible = new List<long>();
            indices = new Stack<int>();         
        }

        public List<long> GetSubStringDivisiblePandigitals()
        {
            for (int i = 1; i < 10; i++)
            {
                digits.Clear();
                indices.Clear();
                for (int j = 0; j < 10; j++)
                {
                    if (j != i)
                    {
                        digits.Add(j);
                    }
                }
                pandigitalRec(i.ToString());
            }

            return subStringDivisible;
        }

        private void pandigitalRec(string current)
        {
            if (current.Length == 9)
            {
                for (int i = 0; i < digits.Count; i++)
                {
                    if (!indices.Contains(i))
                    {
                        current += digits[i];
                        break;
                    }
                }                
                if (isSubstringDivisible(current))
                {
                    subStringDivisible.Add(long.Parse(current));
                }
            }
            else
            {
                switch (current.Length)
                {
                    case 4:
                        if (current.ElementAt(3) % 2 != 0)
                        {
                            return;
                        }
                        break;
                    case 5:
                        if (int.Parse(current.Substring(2, 3)) % 3 != 0)
                        {
                            return;
                        }
                        break;
                    case 6:
                        if (int.Parse(current.Substring(3, 3)) % 5 != 0)
                        { 
                            return;
                        }
                        break;
                    case 7:
                        if (int.Parse(current.Substring(4, 3)) % 7 != 0)
                        {
                            return;
                        }
                        break;
                    case 8:
                        if (int.Parse(current.Substring(5, 3)) % 11 != 0)
                        {
                            return;
                        }
                        break;
                    case 9:
                        if (int.Parse(current.Substring(6, 3)) % 13 != 0)
                        {
                            return;
                        }
                        break;
                    case 10:
                        if (int.Parse(current.Substring(7, 3)) % 17 != 0)
                        {
                            return;
                        }
                        break;
                }
                for (int i = 0; i < digits.Count; i++)
                {
                    if (!indices.Contains(i))
                    {
                        current += digits[i];
                        indices.Push(i);
                        pandigitalRec(current);
                        current = current.Substring(0, current.Length - 1);
                        indices.Pop();
                    }
                }
            }
        }

        public bool isSubstringDivisible(string pandigital)
        {
            bool result = true;

            for (int i = 1; result && i < 8; i++)
            {
                if (int.Parse(pandigital.Substring(i, 3)) % priemgetallen[i - 1] != 0)
                {
                    result = false;
                }
            }

            return result;
        }
    }
}



