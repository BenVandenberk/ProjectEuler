using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PE20;
using System.Diagnostics;

namespace PE29___Distinct_powers
{
    class Program
    {
        static void Main(string[] args)
        {
            const int tot = 100;
            string[] machten = new string[(tot - 1) * (tot - 1)];
            int pos = 0;
            Stopwatch s = new Stopwatch();

            s.Start();
            for (int a = 2; a <= tot; a++)
            {
               for (int b = 2; b <= tot; b++)
               {
                  machten[pos] = xTotDeY(a, b);
                  pos++;
               }
            }           

            Console.WriteLine(aantalTeSchrappen(machten));
            s.Stop();
            Console.WriteLine(s.ElapsedMilliseconds);
            Console.ReadKey();

        }

        static string xTotDeY(int x, int y)
        {
            string stringX = x.ToString();            
            Vermenigvuldig v = null;
            
            for (int i = y; i > 1; i--)
            {
                v = new Vermenigvuldig(stringX, x.ToString());
                stringX = v.PRODUCT;                
            }

            return stringX;
        }

        static int aantalTeSchrappen(string[] invoer)
        {
            bool stop = false;
            int count = 0;
            
            for (int i = 0; i < invoer.Length; i++)
            {
                for (int j = i + 1; j < invoer.Length && stop == false; j++)
                {
                    if (invoer[i] == invoer[j])
                    {
                        count++;
                        stop = true;
                    }
                }
                stop = false;
            }

            return count;
        }
    }
}
