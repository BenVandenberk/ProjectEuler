using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PE48___Self_powers
{
    class Program
    {
        static int[][] termen;
        
        static void Main(string[] args)
        {
            int hoogsteSelfPower, aantalCijfers;
            bool gelukt = false;
            int[] som;
            Stopwatch sw = new Stopwatch();

            do 
            {
                Console.Write("Tot welke self power wil je gaan? ");
                gelukt = int.TryParse(Console.ReadLine(), out hoogsteSelfPower);
            } while (!gelukt);

            gelukt = false;
            do
            {
                Console.Write("Hoeveel cijfers van de som wil je kennen? ");
                gelukt = int.TryParse(Console.ReadLine(), out aantalCijfers);
            } while (!gelukt);

            sw.Start();
            
            termen = new int[hoogsteSelfPower][];
            som = new int[aantalCijfers];

            for (int i = 1; i <= hoogsteSelfPower; i++)
            {
                selfPowerCijferen(i, aantalCijfers);
            }

            foreach (int[] term in termen)
            {
                for (int i = 0; i < term.Length; i++)
                {
                    som[i] += term[i];
                }
            }
            modulusOperaties(som);

            sw.Stop();

            Console.WriteLine("De laatste {0} cijfers van de som van de eerste {1} selfpowers zijn: {2}", aantalCijfers, hoogsteSelfPower, append(som));
            Console.WriteLine("Computatietijd: {0} ms", sw.ElapsedMilliseconds);

        }

        static void selfPowerCijferen(int x, int aantalCijfers)
        {
            int[] updateFactor = new int[aantalCijfers];
            int[] origFactor = new int[x.ToString().Length];
            int[] tussenResultaat = new int[aantalCijfers];

            for (int i = 0, j = aantalCijfers - 1, k = x.ToString().Length - 1; i < x.ToString().Length; i++, j--, k--) // x in de arrays origFactor en updateFactor steken
            {
                origFactor[i] = int.Parse(x.ToString().Substring(i, 1));
                updateFactor[j] = int.Parse(x.ToString().Substring(k, 1));
            }

            for (int i = 1; i < x; i++) // x - 1 keren vermenigvuldigen met x
            {
                for (int factorPos = origFactor.Length - 1, plus = 0; factorPos >= 0; factorPos--, plus++) // Beginnende bij de eenheden alle cijfers van de factor afgaan. 'plus' is om bij het cijferen van bijvoorbeeld de tientallen te beginnen bijtellen bij de tientallen en niet de eenheden
                {
                    for (int updateFactorPos = updateFactor.Length - 1; updateFactorPos >= 0 + plus; updateFactorPos--) // Beginnende bij de eenheden alle cijfers van de updateFactor afgaan
                    {
                        tussenResultaat[updateFactorPos - plus] += origFactor[factorPos] * updateFactor[updateFactorPos];
                    }
                }
                modulusOperaties(tussenResultaat);
                tussenResultaat.CopyTo(updateFactor, 0);
                leegMaken(tussenResultaat);
            }

            termen[x - 1] = new int[aantalCijfers];
            termen[x - 1] = updateFactor;
        }

        static void leegMaken(int[] x)
        {
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = 0;
            }
        }

        static void modulusOperaties(int[] x)
        {
            for (int i = x.Length - 1; i > 0; i--)
            {
                x[i - 1] += x[i] / 10;
                x[i] %= 10;
            }
            x[0] %= 10;
        }

        static string append(int[] x)
        {
            string result = "";

            foreach (int y in x)
            {
                result += y;
            }

            return result;
        }
    }
}
