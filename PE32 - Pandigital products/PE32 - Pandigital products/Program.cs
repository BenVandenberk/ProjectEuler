using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PE32___Pandigital_products
{
    class Program
    {
        static void Main(string[] args)
        {
            bool pandigitaal = false;
            List<int> delers = new List<int>();            
            List<int> pandigitaleProducten = new List<int>();
            int som = 0;
            Stopwatch s = new Stopwatch();

            s.Start();

            for (int i = 1000; i < 10000; i++)
            {
                if (!Helper.CheckDeeltal(i))
                {
                    continue;
                }

                delers = Helper.GeefCombinaties(Helper.Overblijvers(i), 2);        
                for (int j = 1; j < 10; j++)
                {
                    if (!i.ToString().Contains(j.ToString()))
                    {
                        delers.Add(j);
                    }
                }               

                for (int j = 0; j < delers.Count && !pandigitaal; j++)
                {
                    if (i % delers[j] == 0)
                    {
                        pandigitaal = Helper.CheckPandigital(Helper.ConcatenateInts(i, delers[j], i / delers[j]));
                    }
                }
                if (pandigitaal)
                {
                    pandigitaleProducten.Add(i);
                }

                pandigitaal = false;
            }

            foreach (int panprod in pandigitaleProducten)
            {
                som += panprod;
            }

            s.Stop();

            Console.WriteLine(som);
            Console.WriteLine(s.ElapsedMilliseconds);
        }   
    }
}
