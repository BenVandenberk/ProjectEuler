using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace PE13
{
    class Program
    {
        static int[,] gegeven = new int[100,50];
        static int[] opgeteldeKolommen = new int[100];

        static void Main(string[] args)
        {
            inlezen();
            alleKolommenOptellen();
            opgeteldeKolommenUpdaten();
            schrijvenZonderNullen(opgeteldeKolommen);            
        }

        static void inlezen()
        {
            string[] getallen = System.IO.File.ReadAllLines(@"C:\Users\Ben\Documents\Ben\Programmeren\C#\ProjectEuler\PE13\100GetallenVan50Cijfers.txt");
            for (int i = 0; i < getallen.Length; i++)
            {
                for (int j = 0; j < getallen[i].Length; j++)
                {
                    gegeven[i, j] = int.Parse(getallen[i].Substring(j, 1));
                }
            }
        }

        static void schrijven()
        {
            for (int i = 0; i < gegeven.GetLength(0); i++)
            {
                for (int j = 0; j < gegeven.GetLength(1); j++)
                {
                    Console.Write(gegeven[i,j]);
                }
                Console.WriteLine();
            }
        }

        static void schrijven2()
        {
            for (int i = 0; i < opgeteldeKolommen.Length; i++)
            {
                Console.Write(opgeteldeKolommen[i] + ",");
            }
        }

        static void schrijvenZonderNullen(int[] input)
        {
            int huidig = 0;
            while (input[huidig] == 0)
            {
                huidig++;
            }
            for (int i = huidig; i < input.Length; i++)
            {
                Console.Write(input[i]);
            }
            Console.WriteLine();
        }


        // Kolom 1 zijn de eenheden, kolom 50 het meest linkse cijfer
        static int kolomOptellen(int kolom)
        {
            int som = 0;
            for (int i = 0; i < gegeven.GetLength(0); i++)
            {
                som += gegeven[i, 50 - kolom];
            }
            return som;
        }

        static void alleKolommenOptellen()
        {
            for (int i = 99; i >= 50; i--)
            {
                opgeteldeKolommen[i] = kolomOptellen(100 - i);
            }
        }
 
        static void opgeteldeKolommenUpdaten()
        {
            for (int i = opgeteldeKolommen.Length - 1; i > 0; i--)
            {
                opgeteldeKolommen[i - 1] += (opgeteldeKolommen[i] - (opgeteldeKolommen[i] % 10)) / 10;
                opgeteldeKolommen[i] %= 10;                
            }
        }
     
    }
}
