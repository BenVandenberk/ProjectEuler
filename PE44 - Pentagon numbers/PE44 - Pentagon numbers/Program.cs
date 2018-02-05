using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE44___Pentagon_numbers
{
    class Program
    {        
        /// <summary>
        /// Uit de vergelijking Pn = n(3n - 1) / 2 volgt dat een getal x pentagonaal is als n(3n - 1) - 2x een positieve gehele wortel heeft. (1)
        /// Bovendien heb ik vastgesteld dat Pn+a - Pn = 3an + Pa. (2)
        /// m.a.w. de reeks pentagonale getallen volgen elkaar regelmatig op: het verschil tussen twee opeenvolgende pentagonale getallen wordt bij elke stap 3 hoger.
        /// We zoeken naar twee pentagonale getallen Pn en Pn+a zodat Pn+a - Pn EN Pn+a + Pn beide zelf pentagonaal zijn.
        /// 
        /// We krijgen volgend stelsel
        /// 
        /// 3an + Pa    moet pentagonaal zijn   (X)
        /// Pn+a + Pn   moet pentagonaal zijn   (Y)
        /// 
        /// Uitgewerkt m.b.v. de gegeven vergelijking voor pentagonale getallen:
        /// 
        /// 3an + (3a^2 - a)/2                  (X)
        /// (6n^2 + 6an - 2n + 3a^2 - a)/2      (Y)      
        /// 
        /// Nu gaan we koppels gehele getallen (a, n) pluggen in X en Y tot we voor beide vergelijkingen een geheel antwoord krijgen
        /// </summary>   
        
        static void Main(string[] args)
        {                      
            for (int n = 1; n < 100000; n++)
            {
                for (int a = 1; a < 100000; a++)
                {
                    if (vergelijkingX(a, n) && vergelijkingY(a, n))
                    {
                        Console.WriteLine("P" + n + ": " + nThPentagonalNumber(n) + "\t" + "P" + (n + a) + ": " + nThPentagonalNumber(n + a) + "\t\tVerschil: " + (nThPentagonalNumber(n + a) - nThPentagonalNumber(n)));
                    }
                }
            }            
        }

        static bool vergelijkingX(int a, int n)
        {
            double disc;
            double opl1;
            double opl2;

            disc = 1d + 12d * (6d * a * n + 3d * a * a - a);
            opl1 = (1d + Math.Sqrt(disc)) / 6d;
            opl2 = (1d - Math.Sqrt(disc)) / 6d;

            return (opl1 > 0 && opl1 % 1.0 == 0) || (opl2 > 0 && opl2 % 1.0 == 0);
        }

        static bool vergelijkingY(int a, int n)
        {
            double disc;
            double opl1;
            double opl2;

            disc = 1d + 12d * (6d * n * n + 6d * a * n - 2d * n + 3d * a * a - a);
            opl1 = (1d + Math.Sqrt(disc)) / 6d;
            opl2 = (1d - Math.Sqrt(disc)) / 6d;

            return (opl1 > 0 && opl1 % 1.0 == 0) || (opl2 > 0 && opl2 % 1.0 == 0);
        }

        static double nThPentagonalNumber(int n)
        {
            return (3d / 2d) * n * n - (1d / 2d) * n;
        }

        static bool isPentagonaal(long x)
        {
            double disc = 1d + 4d * 2 * x * 3;
            double opl1;
            double opl2;

            if (disc < 0)
            {
                return false;
            }
            opl1 = (1 + Math.Sqrt(disc)) / 6d;
            opl2 = (1 - Math.Sqrt(disc)) / 6d;

            return (opl1 > 0 && opl1 % 1.0 == 0) || (opl2 > 0 && opl2 % 1.0 == 0);
        }
    }
}

