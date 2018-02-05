using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE62___Cubic_permutations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> derdeMachten = new List<int>();
            List<List<long>> derdeMachtenPerGrootteOrde = new List<List<long>>();

            string antwoord = "";

            do
            {

                double longFractie;
                bool succes;

                do
                {
                    Console.Write("Hoe hoog mogen de derdemachten worden? (in fractie van long.MaxValue): ");
                    succes = double.TryParse(Console.ReadLine(), out longFractie);
                } while (!succes || longFractie >= 1);

                int qPermutaties;
                succes = false;

                do
                {
                    Console.WriteLine("Hoeveel onderlinge permutaties van derdemachten moet het programma vinden?: ");
                    succes = int.TryParse(Console.ReadLine(), out qPermutaties);
                } while (!succes || qPermutaties < 2 || qPermutaties > 50);

                bool stop = false;
                long temp;
                derdeMachtenPerGrootteOrde.Add(new List<long>());
                for (long i = 1, grootteOrde = 0, grens = 10; !stop; i++)
                {
                    temp = i * i * i;
                    stop = temp > longFractie * long.MaxValue;

                    if (temp >= grens)
                    {
                        grens *= 10;
                        grootteOrde++;
                        derdeMachtenPerGrootteOrde.Add(new List<long>());
                    }

                    derdeMachtenPerGrootteOrde[(int)grootteOrde].Add(temp);
                }

                CustomDictionary<int, List<long>> derdeMachtenPerGOEnPerSomASCII = new CustomDictionary<int, List<long>>();
                int tempASCII;

                for (int i = 0; i < derdeMachtenPerGrootteOrde.Count; i++)
                {
                    for (int j = 0; j < derdeMachtenPerGrootteOrde[i].Count; j++)
                    {
                        tempASCII = getASCIIValue(derdeMachtenPerGrootteOrde[i][j]);
                        if (derdeMachtenPerGOEnPerSomASCII.ContainsKey(tempASCII))
                        {
                            derdeMachtenPerGOEnPerSomASCII[tempASCII].Add(derdeMachtenPerGrootteOrde[i][j]);
                        }
                        else
                        {
                            derdeMachtenPerGOEnPerSomASCII.Add(tempASCII, new List<long>() { derdeMachtenPerGrootteOrde[i][j] });
                        }
                    }
                }

                for (int i = derdeMachtenPerGOEnPerSomASCII.CustomKeys.Count - 1; i >= 0; i--)
                {
                    if (derdeMachtenPerGOEnPerSomASCII[derdeMachtenPerGOEnPerSomASCII.CustomKeys[i]].Count < qPermutaties)
                    {
                        derdeMachtenPerGOEnPerSomASCII.Remove(derdeMachtenPerGOEnPerSomASCII.CustomKeys[i]);
                        derdeMachtenPerGOEnPerSomASCII.CustomKeys.Remove(derdeMachtenPerGOEnPerSomASCII.CustomKeys[i]);
                    }
                }

                List<CustomDictionary<int, List<long>>> derdeMachtenPerGOASCIISom = new List<CustomDictionary<int, List<long>>>();
                int tempSom;

                for (int i = 0; i < derdeMachtenPerGOEnPerSomASCII.CustomKeys.Count; i++)
                {
                    derdeMachtenPerGOASCIISom.Add(new CustomDictionary<int, List<long>>());
                    for (int j = 0; j < derdeMachtenPerGOEnPerSomASCII[derdeMachtenPerGOEnPerSomASCII.CustomKeys[i]].Count; j++)
                    {
                        tempSom = derdeMachtenPerGOEnPerSomASCII[derdeMachtenPerGOEnPerSomASCII.CustomKeys[i]][j].ToString().ToCharArray().Sum(x => (int)x);
                        if (derdeMachtenPerGOASCIISom[i].ContainsKey(tempSom))
                        {
                            derdeMachtenPerGOASCIISom[i][tempSom].Add(derdeMachtenPerGOEnPerSomASCII[derdeMachtenPerGOEnPerSomASCII.CustomKeys[i]][j]);
                        }
                        else
                        {
                            derdeMachtenPerGOASCIISom[i].Add(tempSom, new List<long>() { derdeMachtenPerGOEnPerSomASCII[derdeMachtenPerGOEnPerSomASCII.CustomKeys[i]][j] });
                        }
                    }
                }

                List<List<string>> gesorteerdeStrings = new List<List<string>>();

                for (int i = 0, key = derdeMachtenPerGOASCIISom[i].CustomKeys[i]; i < derdeMachtenPerGOASCIISom.Count; i++)
                {
                    gesorteerdeStrings.Add(new List<string>());
                    for (int j = 0; j < derdeMachtenPerGOASCIISom[i][key].Count; j++)
                    {
                        gesorteerdeStrings[i].Add(toSortedString(derdeMachtenPerGOASCIISom[i][key][j]));
                    }
                    if (i < derdeMachtenPerGOASCIISom.Count - 1)
                        key = derdeMachtenPerGOASCIISom[i + 1].CustomKeys[0];
                }

                foreach (List<string> l in gesorteerdeStrings)
                {
                    l.Sort();
                }

                CustomDictionary<int, List<string>> IndicesPermutaties = new CustomDictionary<int, List<string>>();

                int counter = 1;
                string previous;
                for (int i = 0; i < gesorteerdeStrings.Count; i++)
                {
                    previous = gesorteerdeStrings[i][0];
                    for (int j = 1; j < gesorteerdeStrings[i].Count; j++)
                    {
                        if (gesorteerdeStrings[i][j] == previous)
                        {
                            counter++;
                            if (counter == qPermutaties)
                            {
                                if (IndicesPermutaties.ContainsKey(i))
                                {
                                    IndicesPermutaties[i].Add(previous);
                                }
                                else
                                {
                                    IndicesPermutaties.Add(i, new List<string>() { previous });
                                }
                            }
                        }
                        else
                        {
                            previous = gesorteerdeStrings[i][j];
                            counter = 1;
                        }
                    }
                }

                int writeCounter = 0;

                for (int i = 0; i < IndicesPermutaties.CustomKeys.Count; i++)
                {
                    for (int j = 0; j < IndicesPermutaties[IndicesPermutaties.CustomKeys[i]].Count; j++)
                    {
                        foreach (long l in derdeMachtenPerGOEnPerSomASCII[derdeMachtenPerGOEnPerSomASCII.CustomKeys[IndicesPermutaties.CustomKeys[i]]])
                        {
                            if (toSortedString(l) == IndicesPermutaties[IndicesPermutaties.CustomKeys[i]][j])
                            {
                                writeCounter++;

                                if (writeCounter == 1)
                                    Console.Write("{");

                                if (writeCounter == qPermutaties)
                                {
                                    Console.Write(l + "}");
                                    break;
                                }
                                else
                                    Console.Write(l + ", ");
                            }
                        }
                        writeCounter = 0;
                        Console.WriteLine("\n");
                    }
                }

                Console.WriteLine("Opnieuw? (J/N): ");
                antwoord = Console.ReadLine();
            } while (antwoord != "n" && antwoord != "N");
        }

        static int getASCIIValue(long x)
        {
            return x.ToString().ToCharArray().Sum(y => (int)y);
        }

        static string toSortedString(long x)
        {
            string result = "";

            char[] xchar = x.ToString().ToCharArray();
            xchar = xchar.OrderBy(y => y).ToArray();

            foreach (char c in xchar)
            {
                result += c;
            }

            return result;
        }

    }
}


//int listIndex = 0; ;
//        string numbers = "";

//        int counter = 1;
//        string previous;
//        for (int i = 0; i < gesorteerdeStrings.Count; i++)
//        {
//            previous = gesorteerdeStrings[i][0];
//            for (int j = 1; j < gesorteerdeStrings[i].Count; j++)
//            {
//                if (gesorteerdeStrings[i][j] == previous)
//                {
//                    counter++;
//                    if (counter == qPermutaties)
//                    {
//                        numbers = previous;
//                        listIndex = i;                            
//                    }
//                }
//                else
//                {
//                    previous = gesorteerdeStrings[i][j];
//                    counter = 1;
//                }
//            }
//        }

//        foreach (long l in derdeMachtenPerGOEnPerSomASCII[derdeMachtenPerGOEnPerSomASCII.CustomKeys[listIndex]])
//        {
//            if (toSortedString(l) == numbers)
//            {
//                Console.WriteLine(l);
//            }
//        }
