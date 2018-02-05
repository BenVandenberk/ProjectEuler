using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PE41___Pandigital_prime
{
    class Program
    {
        static void Main(string[] args)
        {
            int biggest = 0;
            Stopwatch sw = new Stopwatch();           

            sw.Start();
            for (int i = 7; i > 0; i--)
            {
                PandigRecurser pr = new PandigRecurser(i);
                biggest = pr.BiggestPandigitalPrime();
                if (biggest != 0)
                {
                    Console.WriteLine("The biggest pandigital prime number has length {0} and is: {1}", i, biggest);
                    break;
                }
            }
            sw.Stop();

            Console.WriteLine("Elapsed time: {0} ms", sw.ElapsedMilliseconds);            
        }
    }

    /* Het algoritme dat via een recursieve methode al de pandigitale getallen vormt van hoog naar laag, beginnende bij 987654321 tot 1
     * duurt 107 seconden. Er zijn dan ook n! mogelijke pandigitale getallen van lengte n. Voor n = 9 geeft dit 362880 mogelijkheden. 
     *
     * Via PE forum weet ik nu dat elk getal waarvan de som van de cijfers deelbaar is door 3 zelf ook deelbaar is door 3.
     * Vermits 1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 = 36 + 9 = 45 en 36 en 46 deelbaar zijn door 3, is de grootst mogelijke kandidaat 7654321.
     * Dit geeft een computatietijd van 2 ms. */
     
}
