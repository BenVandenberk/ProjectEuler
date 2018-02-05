using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PE55___Lynchrel_numbers
{
    class Program
    {
        // Op Groep T: rond 200 ms

        static void Main(string[] args)
        {
            int aantal = 0;
            Stopwatch sw = new Stopwatch();

            sw.Start();

            for (int i = 1; i < 10000; i++)
            {
                if (isLynchrel(i.ToString()))
                {
                    aantal++;
                }
            }

            sw.Stop();

            Console.WriteLine(aantal);
            Console.WriteLine("Computatietijd: " + sw.ElapsedMilliseconds + " ms");
        }

        static bool isLynchrel(string input)
        {
            bool isLynchrel = true;

            for (int i = 0; isLynchrel && i < 50; i++)
            {
                input = Sum(input, Reverse(input));
                if (isPalindroom(input))
                {
                    isLynchrel = false;
                }
            }

            return isLynchrel;
        }

        static bool isPalindroom(string input)
        {
            return input == Reverse(input);
        }

        static string Reverse(string x)
        {
            char[] xC = x.ToCharArray();
            Array.Reverse(xC);
            return new string(xC);
        }

        static string Sum(string getal1, string getal2)
        {
            int overloop = 0;
            int[] langste = getal1.Length >= getal2.Length ? toArray(getal1, getal1.Length + 1) : toArray(getal2, getal2.Length + 1);
            int[] kortste = getal2.Length <= getal1.Length ? toArray(getal2, langste.Length) : toArray(getal1, langste.Length);
            int[] result = new int[langste.Length];

            for (int i = result.Length - 1; i >= 0; i--)
            {
                result[i] = (kortste[i] + langste[i] + overloop) % 10;
                overloop = (kortste[i] + langste[i] + overloop) / 10;
            }

            return arrayToString(result);
        }

        static int[] toArray(string x, int length)
        {
            int[] result = new int[length];

            for (int i = length - 1, j = x.Length - 1; j >= 0; i--, j--)
            {
                result[i] = int.Parse(x.Substring(j, 1));
            }

            return result;
        }

        static string arrayToString(int[] input)
        {
            string result = "";
            int index = 0;

            if (input[0] == 0)
            {
                index = 1;
            }

            for (int i = index; i < input.Length; i++)
            {
                result += input[i];
            }

            return result;
        }
    }
}
