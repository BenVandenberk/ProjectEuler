using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Diagnostics;

namespace PE30___Digit_fifth_powers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] vijfdeMachten = new int[10] { 0, 1, 32, 243, 1024, 3125, 7776, 16807, 32768, 59049 };
            Sommen s = new Sommen(vijfdeMachten);
            Vijfdemachten v;
            SortedList<int,int> sums;
            List<int> hits = new List<int>();
            Stopwatch sw = new Stopwatch();
            int som = 0;

            sw.Start();
            //sums = s.GenereerSommen(3, 6);
            v = new Vijfdemachten();
            hits = v.Oplossingen();
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            foreach (int el in hits)
            {
                if (el > 9)
                {
                    som += el;
                }
            }

            Console.WriteLine(som);

            Console.ReadKey();
        }
    }

    // Met List: 31767 ms
    // Met Dictionary 34000 ms
    // Met SortedList 6570 ms

    // SortedList opstellen van 20500 elementen en dan checken: 6640 ms
    // Simpelweg alle getallen < 354295 checken: 960 ms
}
