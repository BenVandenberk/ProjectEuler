using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PE57___Square_root_convergents
{
    class Program
    {
        static void Main(string[] args)
        {
            string teller = "3";
            string noemer = "2";
            string temp;
            int counter = 0;
            Stopwatch sw = new Stopwatch();

            sw.Start();            

            for (int i = 0; i < 999; i++)
            {
                teller = Sub(teller, noemer);
                teller = Sum(teller, noemer);
                teller = Sum(teller, noemer);
                temp = teller;
                teller = noemer;
                noemer = temp;
                teller = Sum(teller, noemer);              
                counter += teller.Length > noemer.Length ? 1 : 0;
            }

            sw.Stop();

            Console.WriteLine(counter);
            Console.WriteLine("Computatietijd: " + sw.ElapsedMilliseconds + " ms.");
        }

        static string Sub(string getal1, string getal2)
        {
            long[] getal1Arr = toArrayL(getal1, getal1.Length);
            long[] getal2Arr = toArrayL(getal2, getal1.Length);
            long[] result = new long[getal1Arr.Length];
            bool stop = false;
            int terug = 1;
            long temp = 0;
            int index = 0;

            for (int i = getal1Arr.Length - 1; i >= 0; i--)
            {
                if (getal1Arr[i] - getal2Arr[i] < 0)
                {
                    while (!stop)
                    {
                        if (getal1Arr[i - terug] != 0)
                        {
                            getal1Arr[i - terug]--;
                            stop = true;
                        }
                        else
                        {
                            terug++;
                        }
                    }
                    getal1Arr[i] += (long)Math.Pow(10, terug);
                    terug = 1;
                    stop = false;
                }
                result[i] = getal1Arr[i] - getal2Arr[i];
                if (result[i] > 9)
                {
                    temp = result[i];
                    result[i] %= 10;
                    index = i - 1;
                    while (temp > 9)
                    {
                        temp /= 10;
                        getal1Arr[index] += temp % 10;
                        index--;
                    }
                }
            }

            return arrayToStringL(result);
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


        static long[] toArrayL(string x, int length)
        {
            long[] result = new long[length];

            for (int i = length - 1, j = x.Length - 1; j >= 0; i--, j--)
            {
                result[i] = long.Parse(x.Substring(j, 1));
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

        static string arrayToStringL(long[] input)
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
 