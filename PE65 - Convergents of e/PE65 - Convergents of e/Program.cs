using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringArithmeticLibrary;
using System.Diagnostics;

namespace PE65___Convergents_of_e
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            
            int[] coreValues = new int[100];
            coreValues[0] = 2;
            int somCijfers = 0;            

            for (int i = 1, j = 2; i < 100; i++)
            {
                if ((i - 1) % 3 == 1)
                {
                    coreValues[i] = j;
                    j += 2;
                }
                else
                {
                    coreValues[i] = 1;
                }
            }

            Breuk tussenBreuk;
            tussenBreuk.Teller = "1";
            tussenBreuk.Noemer = coreValues[99].ToString();

            for (int i = 98; i >= 0; i--)
            {
                tussenBreuk.AddTo(coreValues[i]);
                if (i != 0)
                    tussenBreuk.TakeReciprocal();
            }          

            for (int i = 0; i < tussenBreuk.Teller.Length; i++)
            {
                somCijfers += int.Parse(tussenBreuk.Teller.Substring(i, 1));
            }

            s.Stop();

            Console.WriteLine("De honderste convergent van de continued fraction van e is:\n");
            Console.WriteLine("Teller: " + tussenBreuk.Teller + "\nNoemer: " + tussenBreuk.Noemer + "\n");
            Console.WriteLine("Som van de cijfers van de teller: " + somCijfers);
            Console.WriteLine("Computatietijd: " + s.ElapsedMilliseconds / 1000.0 + " s\n");
        }
    }
}
