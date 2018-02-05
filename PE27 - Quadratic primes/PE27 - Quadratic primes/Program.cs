using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE27___Quadratic_primes
{
    class Program
    {
        static int[] a = new int[grens * 2];
        static int[][] b;
        const int grens = 1000000;
        
        static void Main(string[] args)
        {
            int[] a1;
            int[] a1Tussen;
            int[] a2;
            bool stop = false;
            int count = 0;
            int aantal = grens * 2;
            PriemArray x = new PriemArray(1,200);
            
            aVullen();
            bVullen();
            a1 = a;
            a2 = new int[a1.Length];
            a1Tussen = new int[a1.Length];

            for (int i = 0; i < b.Length; i++)
            {
                for (int n = 1; stop == false; n++)
                {
                    for (int j = 0, pos = 0; j < aantal; j++)
                    {
                        if (x.PriemCheck(vgl(a1[j], b[i][0], n)))
                        {
                            a1Tussen[pos] = a1[j];
                            pos++;
                            count++;
                        }
                    }
                    aantal = count;                                       
                    if (count < 11 && count > 0)
                    {
                        for (int k = 0; k < count; k++)
                        {
                            a2[k] = a1Tussen[k];
                        }
                    }
                    else if (count == 0)
                    {
                        b[i][1] = a2[0];
                        b[i][2] = n - 1;
                        stop = true;
                    }
                    a1 = a1Tussen;
                    count = 0;
                }
                stop = false;                
                aantal = grens * 2;
                a1 = a;
            }

            hoogsteSchrijven(hoogste());
        }

        static int vgl(int a, int b, int n)
        {
            return (n * n) + (a * n) + b;
        }

        static void aVullen()
        {
            int pos = 0;
            
            for (int i = -grens; i < 0; i++, pos++)
            {
                a[pos] = i;                
            }

            for (int i = 1; i < grens + 1; i++, pos++)
            {
                a[pos] = i;
            }
        }

        static void bVullen()
        {
            PriemArray p = new PriemArray(-grens, grens);
            b = new int[p.PRIEMARRAY.Length][];

            for (int i = 0; i < p.PRIEMARRAY.Length; i++)
            {
                b[i] = new int[3] { p.PRIEMARRAY[i], 0, 0 };
            }
        }

        static void bSchrijven()
        {
            for (int i = 0, k = 0; i < b.Length; i++, k++)
            {
                Console.Write(b[i][0] + " " + b[i][1] + " " + b[i][2] + ",");
                if (k % 3 == 0)
                { 
                    Console.WriteLine(); 
                }
            }
        }

        static int[] hoogste()
        {
            int[] hoogste = new int[3] {0,0,0};

            for (int i = 0; i < b.Length; i++)
            {
                if (b[i][2] > hoogste[2])
                {
                    hoogste = b[i];
                }
            }

            return hoogste;
        }

        static void hoogsteSchrijven(int[] hoogste)
        {
            for (int i = 0; i < hoogste.Length; i++)
            {
                Console.Write(hoogste[i] + " ");
            }
        }
    }
}
