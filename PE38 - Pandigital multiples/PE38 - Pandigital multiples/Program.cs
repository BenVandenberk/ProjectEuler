using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PE38___Pandigital_multiples
{
    class Program
    {
        static void Main(string[] args)
        {
            int grootste = 0;
            Stopwatch sw = new Stopwatch();

            sw.Start();
            for (int i = 9181; i < 9877; i++)
            {
                if (!Helper.CheckVerschillendeCijfers(i))
                {
                    continue;
                }
                
                if (Helper.CheckPandigital(Helper.ConcatenateInts(i, i * 2)))
                {
                    grootste = int.Parse(Helper.ConcatenateInts(i, i * 2));
                    Console.WriteLine(i + "\t" + i * 2 + "\t" + grootste);
                }
            }
            sw.Stop();
            Console.WriteLine("\nComputatietijd: {0} ms", sw.ElapsedMilliseconds);
        }
    }
}
