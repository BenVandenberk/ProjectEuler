using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace SnelheidTestPrimeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            List<int> primes = new List<int>();
            int tot = 0;
            bool gelukt = false;
            bool stop = false;
            string antwoord;

            Console.WriteLine("Dit programma test hoe snel alle priemgetallen tot een bepaalde grens \ngegenereerd worden door de PrimeGenerator enerzijds en door te \nloopen over alle getallen en de isPrime method anderzijds.\n");

            do
            {
                do
                {
                    Console.Write("Geef de grenswaarde in: ");
                    gelukt = int.TryParse(Console.ReadLine(), out tot);
                } while (!gelukt);

                sw.Start();
                PrimeGenerator pg = new PrimeGenerator(tot);
                primes = pg.Primes;
                sw.Stop();
                Console.WriteLine("\nDe PrimeGenerator doet er {0} ms over.", sw.ElapsedMilliseconds);

                sw.Reset();
                sw.Start();
                primes.Clear();
                for (int i = 1; i <= tot; i++)
                {
                    if (isPrime(i))
                    {
                        primes.Add(i);
                    }
                }
                sw.Stop();
                Console.WriteLine("De loop + isPrime methode doer er {0} ms over.", sw.ElapsedMilliseconds);
                Console.Write("\nNogmaals? (j/n): ");
                antwoord = Console.ReadLine();
                stop = antwoord == "j" || antwoord == "J" ? false : true;
            } while (!stop);
        }

        static bool isPrime(int x)
        {
            bool isPrime = true;

            if (x == 1)
            {
                return false;
            }
            else if (x == 2)
            {
                return true;
            }
            else
            {
                for (int i = 2; isPrime && i <= Math.Sqrt(x); i++)
                {
                    if (x % i == 0)
                    {
                        isPrime = false;
                    }
                }
            }

            return isPrime;
        }
    }
}
