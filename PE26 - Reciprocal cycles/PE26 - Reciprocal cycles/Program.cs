using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE26___Reciprocal_cycles
{
    class Program
    {
        static void Main(string[] args)
        {
            int huidigeMax = 0;
            int a = 0;
            Deling d = null;
            Repititie r = null;

            for (int i = 1; i < 1001; i++)
            {
                d = new Deling(1, i, 10000);
                r = new Repititie(d.QUOTIENT, 10000);

                if (r.REPLENGTE > huidigeMax)
                {
                    huidigeMax = r.REPLENGTE;
                    a = i;
                }
            }

            Console.WriteLine(huidigeMax + "\t" + a);
        }
    }
}
