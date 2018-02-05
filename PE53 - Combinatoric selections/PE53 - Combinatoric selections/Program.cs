using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PE53___Combinatoric_selections
{
    class Program
    {
        const long LIMIT = 1000000;
        const int N = 100;
        
        static void Main(string[] args)
        {
            List<long> oldL = new List<long>();
            List<long> newL = new List<long>();
            int count = 0;
            Stopwatch sw = new Stopwatch();

            sw.Start();

            oldL.Add(1);            

            for (int i = 0; i <= N; i++)
            {
                count += nrOfElemenentsGreaterThanMillion(oldL);
                updateLists(oldL, newL);
                oldL = new List<long>(newL);
                newL.Clear();
            }

            sw.Stop();

            Console.WriteLine(count);
            Console.WriteLine("Computatietijd: {0} ms", sw.ElapsedMilliseconds);
        }

        static void updateLists(List<long> oldL, List<long> newL)
        {
            newL.Add(1);
            for (int i = 0; i < oldL.Count - 1; i++)
            {
                if ((long)oldL[i] + oldL[i + 1] < LIMIT)
                {
                    newL.Add((long)oldL[i] + oldL[i + 1]);
                }
                else
                {
                    newL.Add(LIMIT + 1);
                }
            }
            newL.Add(1);
        }

        static int nrOfElemenentsGreaterThanMillion(List<long> l)
        {
            int count = 0;

            foreach (long i in l)
            {
                count += i > LIMIT ? 1 : 0;
            }

            return count;
        }
    }
}
