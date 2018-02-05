using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PE37___Truncatable_primes
{
    class Program
    {
        static void Main(string[] args)
        {
            LeftTruncatable lt = new LeftTruncatable(6);
            List<long> vang = new List<long>();
            long som = 0;
            Stopwatch sw = new Stopwatch();

            sw.Start();
            vang = lt.Get();
            vang = Helper.verwijder1(vang);
            vang = Helper.verwijderNietRechtsTruncatable(vang);
            foreach (long lrt in vang)
            {
                Console.WriteLine(lrt);
            }

            foreach (long lrt in vang)
            {
                som += lrt;
            }
            sw.Stop();

            Console.WriteLine("\nSom: {0}", som);
            Console.WriteLine("Computatietijd: {0} ms", sw.ElapsedMilliseconds);
        }
    }
}
