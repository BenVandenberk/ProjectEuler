using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PE43___Sub_string_divisibility
{
    class Program
    {
        static void Main(string[] args)
        {
            PandigRecurser pr = new PandigRecurser();
            List<long> vang = new List<long>();
            long som = 0;
            Stopwatch sw = new Stopwatch();            

            sw.Start();

            vang = pr.GetSubStringDivisiblePandigitals();
            foreach (long x in vang)
            {
                Console.WriteLine(x);
                som += x;
            }
            Console.WriteLine("\nSom: {0}", som);

            sw.Stop();

            Console.WriteLine("Computatietijd: {0} ms",sw.ElapsedMilliseconds);
        }
    }
}
