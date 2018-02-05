using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PE56___Powerful_digit_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = 0;
            int dsum = 0;
            Stopwatch sw = new Stopwatch();

            sw.Start();

            for (int i = 1; i < 100; i++)
            {
                for (int j = 1; j < 100; j++)
                {
                    dsum = digitalSum(power(i.ToString(), j.ToString()));
                    max = dsum > max ? dsum : max;
                }
            }

            sw.Stop();

            Console.WriteLine(max);
            Console.WriteLine("Computatietijd: " + sw.ElapsedMilliseconds / 1000.0 + " s.");
        }

        static string power(string _base, string power)
        {
            string result = _base;
            
            for (int i = int.Parse(power); i > 0; i--)
            {
                result = Multiply(result, _base);
            }

            return result;
        }

        static int digitalSum(string getal)
        {
            int sum = 0;

            for (int i = getal.Length - 1; i >= 0; i--)
            {
                sum += int.Parse(getal.Substring(i, 1));
            }

            return sum;
        }

        static string Multiply(string getal1, string getal2)
        {
            int overloop = 0;
            int[] langste = getal1.Length >= getal2.Length ? toArray(getal1, getal1.Length) : toArray(getal2, getal2.Length);
            int[] kortste = getal2.Length <= getal1.Length ? toArray(getal2, getal2.Length) : toArray(getal1, getal1.Length);
            int[][] termen = new int[kortste.Length][];
            int nullen = 0;
            int huidigeIndex = 0;
            string product = "";

            for (int i = kortste.Length - 1; i >= 0; i--)
            {
                termen[i] = new int[langste.Length + kortste.Length];
                huidigeIndex = termen[i].Length - 1 - nullen;
                for (int j = langste.Length - 1; j >= 0; j--, huidigeIndex--)
                {                    
                    termen[i][huidigeIndex] = (kortste[i] * langste[j] + overloop) % 10;
                    overloop = (kortste[i] * langste[j] + overloop) / 10;
                }
                nullen++;
                termen[i][huidigeIndex] = overloop;
                overloop = 0;
                huidigeIndex = 0;
            }

            if (kortste.Length == 1)
            {
                return arrayToString(termen[0]);
            }
            else
            {
                product = Sum(arrayToString(termen[0]), arrayToString(termen[1]));

                for (int i = 2; i < termen.Length; i++)
                {
                    product = Sum(product, arrayToString(termen[i]));
                }
            }

            return product;
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
    }
}
