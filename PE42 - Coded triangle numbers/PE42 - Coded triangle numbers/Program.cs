using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace PE42___Coded_triangle_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputfile, huidig = "";
            List<string> words = new List<string>();
            List<double> triangleNumbers = new List<double>();
            bool tekst = false;
            const int limit = 27;
            int count = 0;
            Stopwatch sw = new Stopwatch();

            sw.Start();

            inputfile = File.ReadAllText(@"C:\Users\Ben\Documents\Ben\Programmeren\C#\ProjectEuler\PE42 - Coded triangle numbers\words.txt");            

            char[] inputarr = inputfile.ToCharArray();
            for (int i = 0; i < inputarr.Length; i++)
            {
                if (inputarr[i] < 65 || inputarr[i] > 90)
                {
                    if (tekst)
                    {
                        words.Add(huidig);
                        tekst = false;
                        huidig = "";
                    }                    
                }
                else 
                {
                    huidig += inputarr[i];
                    tekst = true;
                }
            }

            for (int i = 1; i < limit; i++)
            {
                triangleNumbers.Add(nThTriangleNumber(i));
            }

            for (int i = 0; i < words.Count; i++)
            {
                if (triangleNumbers.Contains(alphValue(words[i])))
                {
                    count++;
                    Console.WriteLine(words[i]);
                }
            }

            /*for (int i = 0; i < words.Count; i++)  |-**-| TWEEDE MANIER, KIJKEN OF [  0.5n(n+1) - woordwaarde  ] EEN GEHEEL NULPUNT HEEFT. EVEN SNEL |-**-|
            {
                if (GeheelPosNulpunt(alphValue(words[i])))
                {
                    count++;
                    Console.WriteLine(words[i]);
                }
            }*/

            sw.Stop();

            Console.WriteLine("\nDe lijst bevat {0} triangle words!", count);
            Console.WriteLine("Computatietijd: {0} ms", sw.ElapsedMilliseconds);
        }

        static int alphValue(string x)
        {
            int som = 0;
            char[] xArr = x.ToCharArray();

            for (int i = 0; i < xArr.Length; i++)
            {
                som += xArr[i] - 64;
            }

            return som;
        }

        static double nThTriangleNumber(int n)
        {
            return (n + 1) * ((double)n / 2);
        }

        static bool GeheelPosNulpunt(int woordwaarde) // |-**-| TWEEDE MANIER, KIJKEN OF [  0.5n(n+1) - woordwaarde  ] EEN GEHEEL NULPUNT HEEFT. EVEN SNEL |-**-|
        {
            double disc = (1d / 4d) + (2d * woordwaarde);

            if (disc <= 0)
            {
                return false;
            }
            else if ((Math.Sqrt(disc) + 0.5d) % 1d == 0 || (Math.Sqrt(disc) - 0.5d) % 1 == 0)
            {
                return true;
            }

            return false;
        }
    }
}
