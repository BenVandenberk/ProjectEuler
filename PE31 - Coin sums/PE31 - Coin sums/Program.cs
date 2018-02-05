using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PE31___Coin_sums
{
    class Program
    {               
        static void Main(string[] args)
        {
            List<int> munten = new List<int>();            
            Stopwatch s = new Stopwatch();
            munten.Add(1);
            munten.Add(2);
            munten.Add(5);
            munten.Add(10);
            munten.Add(20);
            munten.Add(50);
            munten.Add(100);
            munten.Add(200);
            munten.Add(500);
            munten.Add(1000);
            //munten.Add(2000);
            //munten.Add(5000);
            //munten.Add(10000);
            //munten.Add(20000);
            //munten.Add(50000);
            s.Start();
            MuntCombinaties mc = new MuntCombinaties(munten);
            Coinsums cs = new Coinsums(munten, 1000);
            Console.WriteLine(cs.AantalMogelijkheden());           
            s.Stop();
            Console.WriteLine(s.ElapsedMilliseconds);
            
        }
    }
}
