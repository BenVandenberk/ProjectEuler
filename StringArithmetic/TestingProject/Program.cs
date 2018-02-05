using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringArithmeticLibrary;
using System.Diagnostics;

namespace TestingProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch s = new Stopwatch();
            long[] times = new long[200];
            string vang;

            for (int j = 0; j < times.Length; j++)
            {

                s.Start();

                for (int i = 0; i < 1000; i++)
                {
                    vang = StringArithmetic.Multiply("56786573", "75435386");
                }

                s.Stop();

                times[j] = s.ElapsedMilliseconds;

                s.Reset();

            }

            long sum = times.Sum();
            Console.WriteLine((double)sum / (double)times.Length);

            //Console.WriteLine(StringArithmetic.Multiply("56786573", "75435386"));

           
            
        }
    }
}
