using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE7
{
    class Program
    {
        static int primeCounter = 0;
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hoeveelste priemgetal: ");
            int zoveelste = int.Parse(Console.ReadLine());

            Console.WriteLine(primeZoeker(zoveelste));
        }

        static bool checkPrime(int input)
        {
            for (int i = 2; i <= Math.Sqrt(input); i++)
            {
                if ((input % i) == 0)
                    return false;
            }
            return true;
        }

        static int primeZoeker(int zoveelstePrime)
        {
            int test = 2;

            while (primeCounter < zoveelstePrime)
            {
                if (checkPrime(test))
                    primeCounter++;
                test++;
            }

            return --test;
        }
    }
}
