using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace PE16
{
    class Program
    {
        static ArrayList resultaat = new ArrayList();

        static void Main(string[] args)
        {
            resultaat.Add(2);
            Console.Write("2 tot de hoeveelste macht?  ");
            xKerenMaalTwee(int.Parse(Console.ReadLine()));
            Console.WriteLine();
            schrijf(resultaat);
            Console.WriteLine();
            sommeer(resultaat);
        }

        static void sommeer(ArrayList input)
        {
            int som = 0;
            foreach (int getal in input)
            {
                som += getal;
            }
            Console.WriteLine(som);
        }
        
        static void schrijf(ArrayList input)
        {
            foreach (int getal in input)
            {
                Console.Write(getal);
            }
            Console.WriteLine();
        }

        static void xKerenMaalTwee (int x)
        {
            for (int i = 1; i < x; i++)
            {
                maalTwee();
            }
        }

        static void maalTwee()
        {
            int huidig;
            for (int i = 0; i < resultaat.Count; i++)
            {
                huidig = 2 * (int)resultaat[i];
                if (huidig > 9)
                {
                    if (updateArrayMO(i, huidig) == 1)
                    {
                        i++;
                    }
                }
                else
                {
                    updateArrayZO(i, huidig);
                }
            }
         }

        static int updateArrayMO(int index, int huidigOverflow)
        {
            int geupdate = update(huidigOverflow);
            int overslaan = 0;
            
            if (index == 0)
            {
                resultaat.Insert(0, 1);
                resultaat.RemoveAt(1);
                resultaat.Insert(1, geupdate);
                overslaan = 1;
            }
            else
            {
                int temp = (int)resultaat[index - 1];
                resultaat.RemoveAt(index - 1);
                resultaat.Insert(index - 1, temp + 1);
                resultaat.RemoveAt(index);
                resultaat.Insert(index, geupdate);
            }
            return overslaan;
        }

        static void updateArrayZO(int index, int huidig)
        {
            resultaat.RemoveAt(index);
            resultaat.Insert(index, huidig);
        }

        static int update(int input)
        {
            if (input < 10)
            {
                return input;
            }
            else if (input > 10)
            {
                return input - 10;
            }
            else 
            {
                return 0;
            }
        }
    }
}
