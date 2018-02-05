using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EP2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef een getal in waaronder het programma de som van al de even Fibonacci getallen neemt: ");
            Console.WriteLine(somEvenFibOnder(int.Parse(Console.ReadLine())));
        }
        static bool even(int test)
        {
            return (test % 2 == 0);
        }
        static int somEvenFibOnder(int bovenGrens)
        {
            int fibA = 1;
            int fibB = 2;
            int som = 0;
            while (fibB < bovenGrens)
            {
                if (even (fibB))
                    som = som + fibB;
                fibB = fibB + fibA;
                fibA = fibB - fibA;
            }
            return som;
        }
    }
}
