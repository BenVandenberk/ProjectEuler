using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace PE59___XOR_decryption
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            
            // Inladen file als bytes                    
            
            string allText = File.ReadAllText(@"C:\Users\Ben\Documents\Ben\Programmeren\C#\ProjectEuler\PE59 - XOR decryption\cipher1.txt");            
            bool[][] bytes = allText.Split(new char[] { ',' }).Select(x => toByte(Int32.Parse(x))).ToArray();

            // XORREN met alle combinaties van [a-z][a-z][a-z] en tekst schrijven als (#spaties) > (#tekens / 6)
            // Gemiddelde Engelse woordlengte is 5,1. Voor elk woord staat een spatie, dus 6,1

                // Huidige resultaat opslaan

            int[] huidigeTekens = new int[bytes.Length];

                // Countertje spaties

            int qSpaties = 0;
            
            for (int i = 97; i < 123; i++)
            {
                for (int j = 97; j < 123; j++)
                {
                    for (int k = 97; k < 123; k++)
                    {
                        for (int index = 0; index < bytes.Length; index++)
                        {
                            switch (index % 3)
                            {
                                case 0:
                                    huidigeTekens[index] = toInt(XOR(bytes[index], toByte(i)));
                                    break;
                                case 1:
                                    huidigeTekens[index] = toInt(XOR(bytes[index], toByte(j)));
                                    break;
                                case 2:
                                    huidigeTekens[index] = toInt(XOR(bytes[index], toByte(k)));
                                    break;
                            }
                            qSpaties += huidigeTekens[index] == 32 ? 1 : 0;
                        }

                        if (qSpaties > bytes.Length / 6)
                        {
                            foreach (int g in huidigeTekens)
                            {
                                writeIntAsChar(g);
                            }
                            Console.WriteLine("\n");                            
                            Console.WriteLine("De som van de juiste ASCII waarden is: " + huidigeTekens.Sum());
                            Console.WriteLine("De juiste key was: " + Convert.ToChar(i) + Convert.ToChar(j) + Convert.ToChar(k));
                            Console.WriteLine("Verstreken tijd: " + s.ElapsedMilliseconds / 1000.0 + " s.");
                            Console.WriteLine();
                        }

                        qSpaties = 0;
                    }
                }
            }

            Console.WriteLine("Tijd nodig om alle keys te proberen: " + s.ElapsedMilliseconds / 1000.0 + " s.");
        }

        static bool[] toByte(int input)
        {
            if (input > 255 || input < 0)
                Console.WriteLine("Invalid input!");

            bool[] result = new bool[8];

            for (int i = 7; input > 0; i--, input /=2)
            {
                if (input % 2 == 1)
                {
                    result[i] = true;
                }
            }

            return result;
        }

        static int toInt(bool[] input)
        {
            int result = 0;

            for (int i = input.Length - 1, toAdd = 1; i >= 0; i--, toAdd *=2)
            {
                if (input[i])
                {
                    result += toAdd;
                }
            }

            return result;           
        }

        static bool[] XOR(bool[] in1, bool[] in2)
        {
            bool[] result = new bool[8];

            for (int i = 0; i < 8; i++)
            {
                if (in1[i] != in2[i])
                {
                    result[i] = true;
                }
            }

            return result;
        }

        static void writeByte(bool[] input)
        {
            foreach (bool b in input)
            {
                if (b)
                    Console.Write(1);
                else
                    Console.Write(0);
            }
        }

        static void writeIntAsChar(int input)
        {
            Console.Write(Convert.ToChar(input));
        }
    }
}
