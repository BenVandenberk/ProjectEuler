using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PE60___Prime_pair_sets
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch s = new Stopwatch();
            s.Start();

            PrimeConcatSetGenerator pcsg = new PrimeConcatSetGenerator(5, 10000);
            pcsg.Generate();

            s.Stop();

            foreach (int[] set in pcsg.ConcatSets)
            {
                foreach (int i in set)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(pcsg.ConcatSets[0].Sum());
            Console.WriteLine(s.ElapsedMilliseconds / 1000.0 + " s");
        }        
    }
}


