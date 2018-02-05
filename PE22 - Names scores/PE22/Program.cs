using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PE22
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch d = new Stopwatch();
            
            d.Start();            
            Sorteren s = new Sorteren(@"C:\Users\Ben\Documents\Ben\Programmeren\C#\ProjectEuler\PE22\names.txt");
            d.Stop();
            Console.WriteLine(s.SOMSCORES);
            Console.WriteLine(d.ElapsedMilliseconds);            
        }
    }
}
