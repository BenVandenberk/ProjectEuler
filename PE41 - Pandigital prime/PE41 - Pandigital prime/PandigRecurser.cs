using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE41___Pandigital_prime
{
    class PandigRecurser
    {
        private bool stop { get; set; }
        private int primePandigital { get; set; }
        private int length { get; set; }
        private List<int> digits { get; set; }      
       
        public PandigRecurser(int length)
        {
            this.length = length;
            digits = new List<int>();            
            stop = false;
            for (int i = 1; i <= length; i++)
            {
                digits.Add(i);
            }
        }

        public int BiggestPandigitalPrime()
        {
            pandigitalRec("");
            return primePandigital;
        }

        private void pandigitalRec(string current)
        {
            if (digits.Count == 1)
            {
                current += digits[0];
                if (Helper.PrimeCheck(int.Parse(current)))
                {
                    primePandigital = int.Parse(current);                    
                    stop = true;
                }
            }
            else
            {
                for (int i = digits.Count - 1; i >= 0 && !stop; i--)
                {
                    current += digits[i];
                    digits.RemoveAt(i);
                    pandigitalRec(current);
                    if (i == 0)
                    {
                        digits.Insert(0, int.Parse(current.Substring(current.Length - 1, 1)));
                    }
                    else
                    {
                        digits.Add(int.Parse(current.Substring(current.Length - 1, 1)));
                    }
                    current = current.Substring(0, current.Length - 1);
                }
            }
        }
    }
}
