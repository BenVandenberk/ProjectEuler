using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE20
{
    class Program
    {
        static void Main(string[] args)
        {
            string faculteit = "";
            int som = 0;
            int invoer = 0;

            Console.WriteLine("Het programma berekent de faculteit van het gegeven getal en de som van de cijfers van het resultaat");
            Console.Write("Geef een getal op: ");
            invoer = int.Parse(Console.ReadLine());
            
            Vermenigvuldig v = new Vermenigvuldig(invoer, invoer - 1);
            faculteit = v.PRODUCT;

            for (int i = invoer - 2; i > 0; i--)
            { 
                Vermenigvuldig w = new Vermenigvuldig(i.ToString(), faculteit);
                faculteit = w.PRODUCT;
            }

            for (int j = 0; j < faculteit.Length; j++)
            {
                som += int.Parse(faculteit.Substring(j, 1));
            }

            Console.WriteLine("De faculteit van het getal is: {0}", faculteit);
            Console.WriteLine();
            Console.WriteLine("De som van de cijfers van de faculteit is: {0}", som);

        }
    }   
}

/*  Testmateriaal
    *  long factor1 = 0;
           long factor2 = 0;
           long product = 0;
           string antwoord = "";

           do
           {
               Console.Write("Geef factor 1: ");
               factor1 = long.Parse(Console.ReadLine());
               Console.Write("Geef factor 2: ");
               factor2 = long.Parse(Console.ReadLine());

               Vermenigvuldig v = new Vermenigvuldig(factor1, factor2);
               Console.WriteLine(v.PRODUCT);
               product = factor1 * factor2;
               Console.WriteLine(product);

               Console.Write("Nogmaals (j/n)?: ");
               antwoord = Console.ReadLine();
           } while (antwoord != "n");
    * */
