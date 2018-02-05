using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE10
{
    class Program
    {
        static long primeSum = 2;

        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            primeSummer(a);
            Console.WriteLine(primeSum);
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
                
        static void primeSummer(int bovenGrens)
        {
            for (int i = 3; i < bovenGrens; i += 2)
            {
                if (checkPrime(i))
                    primeSum += i;
            }
        }
    }
}
