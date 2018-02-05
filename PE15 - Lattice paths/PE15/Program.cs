using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE15
{
    class Program
    {
        static long[,] tabel = new long[21, 21];
        
        static void Main(string[] args)
        {
            zijkantenIs1();
            restOpvullen();
            Console.WriteLine(tabel[0,0]);
        }

        static void zijkantenIs1()
        {
            for (int i = 0; i < tabel.GetLength(0); i++)
            {
                tabel[i, tabel.GetLength(0) - 1] = 1;
                tabel[tabel.GetLength(0) - 1, i] = 1;
            }
        }

        static void restOpvullen()
        {
            for (int i = tabel.GetLength(0) - 2; i >= 0; i--)
            {
                for (int j = tabel.GetLength(0) - 2; j >= 0; j--)
                {
                    tabel[i, j] = tabel[i + 1, j] + tabel[i, j + 1];
                }
            }
        }

        static void schrijfTabel()
        {
            for (int i = 0; i < tabel.GetLength(0); i++)
            {
                for (int j = 0; j < tabel.GetLength(0); j++)
                {
                    Console.Write(tabel[i,j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
