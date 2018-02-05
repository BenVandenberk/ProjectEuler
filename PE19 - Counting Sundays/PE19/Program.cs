using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE19
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;

            Console.WriteLine("Het programma berekent het aantal zondagen op de eerste dag van de maand\n");
            Console.Write("Geef de begindatum (volgorde d,m,j): ");
            Datum begin = new Datum(Console.ReadLine());
            Console.Write("Geef de einddatum (volgorde d,m,j): ");
            Datum eind = new Datum(Console.ReadLine());

            for (int i = begin.SERIEEL; i < eind.SERIEEL + 1; i++)
            {
                Datum test = new Datum(i);
                counter += (test.DAGNR == 1 && test.DAG == "zondag") ? 1 : 0;
            }

            Console.WriteLine("\nIn de opgegeven periode vallen {0} zondagen op de eerste dag van de maand", counter);
        }
    }
}

/*   TESTMATERIAAL
 *   int serieel = 0;
            string antwoord;

            do
            {
                Console.Write("Geef het serieel getal waarvan u de datum wil kennen: ");
                serieel = int.Parse(Console.ReadLine());
                Datum d = new Datum(serieel);

                Console.WriteLine("Datum: {0} {1} {2}", d.DAGNR, d.MAAND, d.JAAR);
                Console.WriteLine("Het is dag {0} van het jaar", d.DAGVANHETJAAR);
                Console.WriteLine("Lange datumnotatie: {0} {1} {2} {3}", d.DAG, d.DAGNR, d.MAAND, d.JAAR);

                Console.Write("Nogmaals (j/n)?: ");
                antwoord = Console.ReadLine();
            } while (antwoord != "n");

            /*string datum, antwoord;

            do
            {
                Console.Write("Geef de datum (dag-maand-jaar): ");
                datum = Console.ReadLine();
                Datum e = new Datum(datum);
                Console.WriteLine("De datum is: {0}/{1}/{2}", e.DAGNR, e.MAANDNR, e.JAAR);

                Console.Write("Nogmaals (j/n)?: ");
                antwoord = Console.ReadLine();                
            } while (antwoord != "n");

            int dag, maand, jaar;
            string antwoord2;

            do
            {
                Console.Write("Geef de dag: ");
                dag = int.Parse(Console.ReadLine());
                Console.Write("Geef de maand: ");
                maand = int.Parse(Console.ReadLine());
                Console.Write("Geef het jaar: ");
                jaar = int.Parse(Console.ReadLine());

                Datum f = new Datum(dag, maand, jaar);
                Console.WriteLine("De datum is: {0}/{1}/{2}", f.DAGNR, f.MAANDNR, f.JAAR);
                Console.WriteLine("Andere gegevens: {0} {1} {2}", f.SCHRIKKELJAAR, f.SERIEEL, f.MAAND);
                Console.WriteLine("Het is dag {0} van het jaar", f.DAGVANHETJAAR);
                Console.WriteLine("Lange datumnotatie: {0} {1} {2} {3}", f.DAG, f.DAGNR, f.MAAND, f.JAAR);

                Console.Write("Nogmaals (j/n)?: ");
                antwoord2 = Console.ReadLine();                
            } while (antwoord2 != "n");*/
