using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PE52___Permuted_multiples
{
    class Program
    {
        static void Main(string[] args)
        {
            bool stop = false;
            bool multiplePerm = true;
            int result = 0;
            Stopwatch sw = new Stopwatch();

            sw.Start();
            
            for (int i = 1; !stop; i++)
            {
                for (int j = 2; multiplePerm && j < 7; j++)
                {
                    multiplePerm = hasSameDigits(i, i * j);
                }
                if (multiplePerm)
                {
                    stop = true;
                    result = i;
                }
                multiplePerm = true;
            }

            sw.Stop();

            Console.WriteLine(result);
            Console.WriteLine("Computatietijd: {0} ms", sw.ElapsedMilliseconds);
        }

        static bool hasSameDigits(int x, int y)
        {
            if (x.ToString().Length != y.ToString().Length)
            {
                return false;
            }
            
            char[] arrX = x.ToString().ToCharArray();
            char[] arrY = y.ToString().ToCharArray();
            bool changed = false;
            bool stop = false;

            for (int i = 0; !stop && i < arrX.Length; i++)
            {
                for (int j = 0; !changed && j < arrY.Length; j++)
                {
                    if (arrX[i] == arrY[j])
                    {
                        arrY[j] = 'a';
                        changed = true;
                    }
                }
                if (!changed)
                {
                    stop = true;
                }
                changed = false;
            }

            return stop ? false : true;
        }
    }
}
