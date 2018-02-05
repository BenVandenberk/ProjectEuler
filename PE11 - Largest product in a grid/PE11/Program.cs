using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE11
{
    class Program
    {
        static int[,] gegevenTabel = new int[20, 20];
        static int product = 0;

        static void Main(string[] args)
        {
            inlezen();
            horizontaleProducten();
            verticaleProducten();          
            linksDiagonaal();
            rechtsDiagonaal();
            Console.WriteLine(product);
        }

        static void inlezen()
        {
            string[] rijen = System.IO.File.ReadAllLines(@"C:\Users\Ben\Documents\Ben\Programmeren\C#\ProjectEuler\PE11\20maal20grid.txt");
            for (int i = 0; i < rijen.Length; i++)
            {
                int element = 0;
                for (int j = 0; j < rijen[i].Length; j += 3)
                {
                    gegevenTabel[i,element] = int.Parse(rijen[i].Substring(j,2));
                    element++;
                }
            }
        }

        static void schrijven()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Console.Write(gegevenTabel[i,j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void horizontaleProducten()
        {
            int tempProduct = 0;
            for (int i = 0; i < gegevenTabel.GetLength(0); i++)
            {
                for (int j = 0; j < gegevenTabel.GetLength(1) - 3; j++)
                {
                    tempProduct = gegevenTabel[i, j] * gegevenTabel[i, j + 1] * gegevenTabel[i, j + 2] * gegevenTabel[i, j + 3];
                    updateProduct(tempProduct);
                }
            }
        }

        static void verticaleProducten()
        {
            int tempProduct = 0;
            for (int j = 0; j < gegevenTabel.GetLength(1); j++)
            {
                for (int i = 0; i < gegevenTabel.GetLength(0) - 3; i++)
                {
                    tempProduct = gegevenTabel[i, j] * gegevenTabel[i + 1, j] * gegevenTabel[i + 2,j] * gegevenTabel[i + 3, j];
                    updateProduct(tempProduct);
                }
            }
        }

        static void rechtsDiagonaal()
        {
            int tempProduct = 0;
            for (int i = 0; i < gegevenTabel.GetLength(1) - 3; i++)
            {
                for (int j = 0; j < gegevenTabel.GetLength(0) - 3; j++)
                {
                    tempProduct = gegevenTabel[i, j] * gegevenTabel[i + 1, j + 1] * gegevenTabel[i + 2, j + 2] * gegevenTabel[i + 3, j + 3];
                    updateProduct(tempProduct);
                }

            }
        }

        static void linksDiagonaal()
        {
            int tempProduct = 0;
            for (int i = 0; i < gegevenTabel.GetLength(1) - 3; i++)
            {
                for (int j = 3; j < gegevenTabel.GetLength(0); j++)
                {
                    tempProduct = gegevenTabel[i, j] * gegevenTabel[i + 1, j - 1] * gegevenTabel[i + 2, j - 2] * gegevenTabel[i + 3, j - 3];
                    updateProduct(tempProduct);
                }

            }
        }

        static void updateProduct(int input)
        {
            if (input > product)
            {
                product = input;
            }
        }       
    }
}
