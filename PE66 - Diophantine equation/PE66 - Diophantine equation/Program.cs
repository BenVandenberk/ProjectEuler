using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using StringArithmeticLibrary;
using ContinuedFractions;

namespace PE66___Diophantine_equation
{
    // Na lang zoeken en nog steeds geen goed algoritme gevonden te hebben, heb ik de vergelijking gegoogeld. Zo ben ik er op uit gekomen dat dit Pell's equation is.
    // Pell's equation is een soort van Diophantine equation die op te lossen is met behulp van continued fractions. Meerbepaald:
    // 
    //              Pell's equation: x^2 - Dy^2 = 1
    //
    // Als D square is zijn er geen oplossingen (stond al in opgave)
    // Voor alle andere waarden van D is de oplossing, minimaal in x, te vinden door de opeenvolgende convergenten a/b van de continued fraction van sqrt(D) te berekenen
    // en a = x en b = y te proberen in Pell's equation.
    //
    // Voorbeeld
    //
    // Opeenvolgende convergenten van sqrt(2) zijn 3/2, 7/5, 17/12, ... x = 3 en y = 2 is een oplossing voor Pell's equation (D=2), minimaal in x!

    class Program
    {
        static void Main(string[] args)
        {
            int keuze;
            string antwoord = "";

            do
            {
                Console.Clear();
                do
                {
                    Console.WriteLine("/////////////////////////////////////////////////////////");
                    Console.WriteLine("PE 66 - Diophantine equation [Pell's equation]");
                    Console.WriteLine("/////////////////////////////////////////////////////////\n\n");

                    Console.WriteLine("PELL'S EQUATION\t x^2 - Dy^2 = 1\n\n");

                    Console.WriteLine("Kies een optie");
                    Console.WriteLine("1. Geef het antwoord op Opgave 66 van projecteuler.net");
                    Console.WriteLine("2. Geef een D waarde in waarvoor de computer opgeloste Pell's equation, minimaal in x, geeft");
                    Console.WriteLine("3. Geef een interval van D waarden op waarvoor de computer alle oplossingen, minimaal in x, geeft");
                    Console.WriteLine("4. Geef een D waarde waaronder de computer de maximale minimale x-oplossing zoekt\n");

                } while (!int.TryParse(Console.ReadLine(), out keuze));

                switch (keuze)
                {
                    case 1:
                        Stopwatch s = new Stopwatch();
                        s.Start();

                        RootToContinuedFraction rootToCF = new RootToContinuedFraction();
                        ContinuedFractionConvergentsGenerator CFConvergentsGenerator = new ContinuedFractionConvergentsGenerator(new int[] { 0 });
                        string maxMinimalX = "";
                        int resultD = 0;

                        for (int D = 1; D <= 1000; D++)
                        {
                            if (Math.Sqrt(D) % 1.0 == 0)
                            {
                                continue;
                            }

                            rootToCF.Generate(D);
                            CFConvergentsGenerator.Reseed(rootToCF.Coefficients);
                            bool pellOK = false;

                            do
                            {
                                StringBreuk temp = CFConvergentsGenerator.Next();
                                pellOK = pellCheck(temp.Teller, temp.Noemer, D.ToString());
                                if (pellOK)
                                {
                                    if (temp.Teller.Length < maxMinimalX.Length)
                                    {
                                        continue;
                                    }
                                    else if (temp.Teller.Length > maxMinimalX.Length)
                                    {
                                        maxMinimalX = temp.Teller;
                                        resultD = D;
                                        continue;
                                    }
                                    else
                                    {
                                        if (String.CompareOrdinal(temp.Teller, maxMinimalX) > 0)
                                        {
                                            maxMinimalX = temp.Teller;
                                            resultD = D;
                                            continue;
                                        }
                                        else
                                        {
                                            continue;
                                        }
                                    }
                                }
                            } while (!pellOK);
                        }

                        s.Stop();

                        Console.WriteLine("Van alle mogelijke instanties van Pell's equation (1 <= D <= 1000), is de minimale oplossing in x het grootst voor D = " + resultD);
                        Console.WriteLine("De bekomen waarde voor x is: " + maxMinimalX);
                        Console.WriteLine("Computatietijd: " + s.ElapsedMilliseconds / 1000.0 + " s");
                        break;
                    case 2:
                        int KeuzeD = 0;

                        do
                        {
                            Console.Clear();
                            if (KeuzeD != 0)
                            {
                                Console.WriteLine("De waarde voor D mag geen kwadraat zijn");
                            }
                            do
                            {
                                Console.Write("Geef een waarde in voor D: ");
                            } while (!int.TryParse(Console.ReadLine(), out KeuzeD));
                        } while (Math.Sqrt(KeuzeD) % 1.0 == 0);

                        s = new Stopwatch();
                        s.Start();

                        rootToCF = new RootToContinuedFraction();
                        CFConvergentsGenerator = new ContinuedFractionConvergentsGenerator(new int[] { 0 });
                        maxMinimalX = "";
                        string maxY = "";
                        resultD = 0;

                        rootToCF.Generate(KeuzeD);
                        CFConvergentsGenerator.Reseed(rootToCF.Coefficients);
                        bool pellOK2 = false;

                        do
                        {
                            StringBreuk temp = CFConvergentsGenerator.Next();
                            pellOK2 = pellCheck(temp.Teller, temp.Noemer, KeuzeD.ToString());
                            if (pellOK2)
                            {
                                if (temp.Teller.Length < maxMinimalX.Length)
                                {
                                    continue;
                                }
                                else if (temp.Teller.Length > maxMinimalX.Length)
                                {
                                    maxMinimalX = temp.Teller;
                                    maxY = temp.Noemer;
                                    resultD = KeuzeD;
                                    continue;
                                }
                                else
                                {
                                    if (String.CompareOrdinal(temp.Teller, maxMinimalX) > 0)
                                    {
                                        maxMinimalX = temp.Teller;
                                        maxY = temp.Noemer;
                                        resultD = KeuzeD;
                                        continue;
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                            }
                        } while (!pellOK2);

                        s.Stop();

                        Console.WriteLine("\nVoor D = " + KeuzeD + " is de minimale oplossing in x van Pell's equation:");
                        Console.WriteLine(getPellEquation(maxMinimalX, maxY, KeuzeD.ToString()));
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    default:
                        break;
                }

                Console.Write("\nOpnieuw? (J/N): ");
                antwoord = Console.ReadLine();
            } while (antwoord == "J" || antwoord == "j");



        }

        private static bool pellCheck(string x, string y, string d)
        {
            string xSquared = StringArithmetic.Multiply(x, x);

            string dTimesYSquaredPlusOne = StringArithmetic.Multiply(y, y);
            dTimesYSquaredPlusOne = StringArithmetic.Multiply(dTimesYSquaredPlusOne, d);
            dTimesYSquaredPlusOne = StringArithmetic.Add(dTimesYSquaredPlusOne, "1");

            return xSquared == dTimesYSquaredPlusOne;
        }

        private static string getPellEquation(string x, string y, string d)
        {          
            return x + "^2 - " + d + " * " + y + "^2 = 1";
        }


    }
}
