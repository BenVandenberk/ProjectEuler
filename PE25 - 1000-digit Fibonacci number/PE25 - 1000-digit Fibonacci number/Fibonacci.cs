using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PE20;

namespace PE25___1000_digit_Fibonacci_number
{
    static class Fibonacci
    {
        static public string Fibx (int x)
        {
            string fib1 = "1";
            string fib2 = "1";
            string result = "";
            Optellen o = null;

            if (x == 1 || x == 2)
            {
                result = fib1;
            }
            else if (x < 1)
            {
                result = "Foute waarde";
            }
            else
            {
                for (int i = 3; i <= x; i++)
                {
                    o = new Optellen(fib1, fib2);
                    fib1 = fib2;
                    fib2 = o.SOM;
                }
                result = fib2;
            }
            return result;
        }

        /*static public int EersteFibMetXGetallen(int x)
        {
            bool fibCheck = Fibx(1).Length >= x ? true : false;
            int result = 1;

            for (int i = 2; fibCheck == false; i++)
            {
                if (Fibx(i).Length >= x)
                {
                    fibCheck = true;
                }
                result++;
            }

            return result;
        }*/

        static public int EersteFibMetXGetallen(int x)
        {
            int result = 2;
            string fib1 = "1";
            string fib2 = "1";
            Optellen o = null;
            bool fibCheck = false;

            if (x > 1)
            {
                while (fibCheck == false)
                {
                    o = new Optellen(fib1, fib2);
                    fib1 = fib2;
                    fib2 = o.SOM;
                    if (fib2.Length >= x)
                    {
                        fibCheck = true;
                    }
                    result++;
                }
            }
            else
            {
                result = 1;
            }

            return result;
        }
    }
}
