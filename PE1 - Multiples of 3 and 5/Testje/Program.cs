using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Testje
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef een getal waaronder het programma de veelvouden van 3 en 5 optelt: ");
            string s = Console.ReadLine();
            Console.WriteLine(somVeelvouden3En5(int.Parse(s)));                     
        }
        static int somVeelvouden3En5(int bovenGrens)
        {
            int som = 0;
            for (int i = 0; i < bovenGrens; i++)
            {
                if (deelbaarDoor3(i))
                    som = som + i;
                else if (deelbaarDoor5(i))
                    som = som + i;                
            }
            return som;
        }
        static bool deelbaarDoor3(int test)
        {
            while (test > 0)
            {
                test = test - 3;
            }
            return test == 0;
        }
        static bool deelbaarDoor5(int test)
        {
            while (test > 0)
            {
                test = test - 5;
            }
            return test == 0;
        }
   }
}
