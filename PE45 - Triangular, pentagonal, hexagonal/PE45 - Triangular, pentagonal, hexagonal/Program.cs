using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE45___Triangular__pentagonal__hexagonal
{
    class Program
    {
        static void Main()
        {
            const long limit = 100000000;
            int pentIndex = 0; ;

            for (int i = 287; i < limit; i += 2)
            {
                if (isPentagonaal(Triangular(i), ref pentIndex))
                {
                    Console.WriteLine("T" + i + " = H" + ((i + 1) / 2) + " = P" + pentIndex + " = " + Triangular(i));
                }
            }
        }

        static long Triangular(int n)
        {
            return n * ((long)n + 1L) / 2L;
        }

        static long Hexagonal(int n)
        {
            return n * (2 * n - 1);
        }

        static long Pentagonal(int n)
        {
            return n * (3L * n - 1) / 2;
        }

        static bool isPentagonaal(long x, ref int pentIndex)
        {
            double disc = 1d + 4d * 2 * x * 3;
            double opl1;
            double opl2;

            if (disc < 0)
            {
                return false;
            }
            opl1 = (1 + Math.Sqrt(disc)) / 6d;
            opl2 = (1 - Math.Sqrt(disc)) / 6d;

            if (opl1 > 0 && opl1 % 1.0 == 0)
            {
                pentIndex = (int)opl1;
                return true;
            }
            if (opl2 > 0 && opl2 % 1.0 == 0)
            {
                pentIndex = (int)opl2;
                return true;
            }

            return false;
        }
    }
}
