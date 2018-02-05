using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE4
{
    class Program
    {
        static int vrlpiggrootste = 0;

        static void Main(string[] args)
        {
            alleGetallen3CijfersVermenigvuldigen();
            Console.WriteLine(vrlpiggrootste);
        }

        static void alleGetallen3CijfersVermenigvuldigen()
        {
            for (int i = 100; i < 1000; i++)
            {
                for (int j = 100; j < 1000; j++)
                {
                    if (test (i * j))
                        grootsteCheck (i*j);
                }
            }
        }

        static void grootsteCheck(int input)
        {
            if (input > vrlpiggrootste)
                vrlpiggrootste = input;
        }

        static bool test(int input)
        {
            return input.ToString() == stringOmdraaien(input.ToString());
        }

        static string stringOmdraaien(string input)
        {
            int a = input.Length - 1;
            int b = 0;
            string d = "";
            char[] c = input.ToCharArray(0, input.Length);
                        
            while (a >= 0)
            {
                d = d + c.ElementAt(a);
                b++;
                a--;
            }

            return d;          
        }
    }
}
