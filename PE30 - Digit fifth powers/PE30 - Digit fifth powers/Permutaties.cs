using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace PE30___Digit_fifth_powers
{
    class Permutaties
    {
        private string result = "";
        private int niveau = 0;
        private ArrayList permutaties = null;
        private int[] reeks;

        private void reset()
        {
            result = "";
            niveau = 1;
            permutaties = new ArrayList();
        }       

        private void genereerPermutaties(int lengte)
        {
            for (int i = 0; i < reeks.Length; i++)
            {
                result += reeks[i];
                if (niveau == lengte)
                {
                    permutaties.Add(result);
                    result = result.Remove(result.Length - 1);
                    niveau--;
                }
                else
                {
                    niveau++;
                    genereerPermutaties(lengte);
                }
                if (i == reeks.Length - 1)
                {
                    result = result.Length != 0 ? result.Remove(result.Length - 1) : "";
                    niveau--;
                }
                else
                {
                    niveau++;
                }
            }
        }

        public ArrayList Permuteer(int[] invoer, int lengte, bool leadingZeros)
        {
            reset();
            reeks = invoer;
            genereerPermutaties(lengte);
            if (leadingZeros)
            {
                return permutaties;
            }
            else
            {
                for (int i = 0; i < permutaties.Count; i++)
                {
                    if (permutaties[i].ToString().StartsWith("0"))
                    {
                        permutaties.RemoveAt(i);
                        i--;
                    }
                }
                return permutaties;
            }
        }
       
    }
}
