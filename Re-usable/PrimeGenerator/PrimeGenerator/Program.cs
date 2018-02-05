using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PrimeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> primes;
            Stopwatch sw = new Stopwatch();

            sw.Start();

            PrimeGenerator pg = new PrimeGenerator(10000000);
            primes = pg.Primes;

            sw.Stop();

            Console.WriteLine("Computatietijd: " + sw.ElapsedMilliseconds + " ms");
        }
    }
}
