using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringArithmeticLibrary
{
    public static class StringArithmetic
    {
        public static string Multiply(string value1, string value2)
        {
            int[] shortest, longest;

            if (value1.isShorterThan(value2))
            {
                shortest = toIntArray(value1);
                longest = toIntArray(value2);
            }
            else
            {
                shortest = toIntArray(value2);
                longest = toIntArray(value1);
            }

            string[] terms = new string[shortest.Length];
            int temp, spillOver;            
            string currentTerm;

            for (int i = shortest.Length - 1, amountOfZeroes = 0; i >= 0; i--, amountOfZeroes++)
            {
                currentTerm = "";
                spillOver = 0;

                for (int j = 0; j < amountOfZeroes; j++)
                {
                    currentTerm += "0";
                }

                for (int j = longest.Length - 1; j >= 0; j--)
                {
                    temp = shortest[i] * longest[j] + spillOver;
                    currentTerm = currentTerm.Insert(0, (temp % 10).ToString());                    
                    spillOver = temp / 10;
                }

                if (spillOver != 0)
                {
                    currentTerm = currentTerm.Insert(0, spillOver.ToString());                    
                }

                terms[i] = currentTerm;                
            }

            string result = "";
            if (terms.Length > 0)
            {
                result = terms[0];
                for (int i = 1; i < terms.Length; i++)
                {
                    result = Add(result, terms[i]);
                }
            }

            return result;
        }

        public static string Add(string value1, string value2)
        {
            int[] shortest, longest;

            if (value1.isShorterThan(value2))
            {
                shortest = toIntArray(value1);
                longest = toIntArray(value2);
            }
            else
            {
                shortest = toIntArray(value2);
                longest = toIntArray(value1);
            }

            int[] result = new int[longest.Length + 1];
            int indexShort = shortest.Length - 1;
            int indexLong = longest.Length - 1;
            int temp;

            for (int i = result.Length - 1, spillOver = 0; i >= 0; i--, indexLong--, indexShort--)
            {
                if (indexShort >= 0)
                {
                    temp = shortest[indexShort] + longest[indexLong] + spillOver;
                    result[i] += temp % 10;
                    spillOver = temp / 10;
                }
                else if (indexLong >= 0)
                {
                    temp = longest[indexLong] + spillOver;
                    result[i] += temp % 10;
                    spillOver = temp / 10;
                }
                else
                {
                    result[i] = spillOver;
                }
            }

            if (result[0] == 0)
            {
                int[] resultWithoutLeadingZero = new int[result.Length - 1];
                for (int i = 1; i < result.Length; i++)
                {
                    resultWithoutLeadingZero[i - 1] = result[i];
                }
                return resultWithoutLeadingZero.customToString();
            }
            else
            {
                return result.customToString();
            }            
        }

        //internal static int[] removeLeadingZeroes(this int[] inputArray)
        //{
        //    bool stop = false;
        //    int counter = 0;

        //    for (int i = 0; i < inputArray.Length && !stop; i++)
        //    {
        //        if (inputArray[i] == 0)
        //        {
        //            counter++;
        //        }
        //        else
        //        {
        //            stop = true;                
        //        }
        //    }

        //    if (counter != 0)
        //    {
        //        return inputArray.Skip(counter).ToArray();
        //    }
        //    else
        //    {
        //        return inputArray;
        //    }
        //}

        internal static string customToString(this int[] inputArray)
        {
            string result = "";

            foreach (int i in inputArray)
            {
                result += i;
            }

            return result;
        }

        internal static int[] toIntArray(string inputString)
        {          
            int[] result = new int[inputString.Length];

            for (int i = 0; i < inputString.Length; i++)
            {
                result[i] = int.Parse(inputString.Substring(i, 1));
            }

            return result;
        }

        internal static bool isShorterThan(this string s1, string s2)
        {
            return s1.Length < s2.Length;
        }

        //internal static string reverse(this string inputString)
        //{
        //    string result = "";

        //    for (int i = inputString.Length - 1; i >= 0; i--)
        //    {
        //        result += inputString.Substring(i, 1);
        //    }

        //    return result;
        //}
    }
}
