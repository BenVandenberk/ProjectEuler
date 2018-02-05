using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Diagnostics;

namespace PE33___Digit_canceling_fractions
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList breuken = new ArrayList();
            int tellerProduct = 1;
            int noemerProduct = 1;
            int ggd;
            Stopwatch s = new Stopwatch();

            s.Start();

            for (int noemer = 11; noemer < 100; noemer++)
            {
                for (int teller = 10; teller < noemer; teller++)
                {
                    if (!((noemer % 10 == 0) && (teller % 10 == 0)))
                    {
                        Breuk breuk = new Breuk(teller, noemer);
                        if (breuk.CancelingFraction())
                        {
                            breuken.Add(breuk);
                        }
                    }
                }
            }

            foreach (Breuk breuk in breuken)
            {
                tellerProduct *= breuk.Teller;
                noemerProduct *= breuk.Noemer;
            }

            ggd = Helper.GGD(tellerProduct, noemerProduct);
            Console.WriteLine(noemerProduct / ggd);

            s.Stop();

            Console.WriteLine(s.ElapsedMilliseconds);
        }
    }
}
