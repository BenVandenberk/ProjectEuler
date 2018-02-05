using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PE64___Odd_period_square_roots
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            
            RootToContinuedFraction rtcf = new RootToContinuedFraction();
            int oddPeriods = 0;

            for (int i = 2; i <= 1000; i++)
            {
                if (Math.Sqrt(i) % 1.0 == 0)
                    continue;

                rtcf.Generate(i);
                oddPeriods += rtcf.Period % 2 == 1 ? 1 : 0;
                Console.WriteLine(rtcf.LongNotation);
            }

            s.Stop();

            Console.WriteLine("\nHet programma telde " + oddPeriods + " oneven periodes.");
            Console.WriteLine("Computatietijd: " + s.ElapsedMilliseconds / 1000.0 + " s");
        }


    }
}
