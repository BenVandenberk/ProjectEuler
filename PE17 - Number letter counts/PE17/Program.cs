using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE17
{
    class Program
    {
        static string[,] getallenBehalve11Tot19 = new string[9, 2] { {"ten", "one"}, {"twenty", "two"}, {"thirty", "three"}, {"forty", "four"}, {"fifty", "five"}, {"sixty", "six"}, {"seventy", "seven"}, {"eighty", "eight"}, {"ninety", "nine"} };
        static string[] getallen11Tot19 = new string[9] {"eleven", "twelve","thirteen","fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"};
        static string h = "hundred";
        static string t = "thousand";
        static string m = "million";
        static string a = "and";
        
        static void Main(string[] args)
        {
            string invoer;

            do
            {
                Console.Write("Geef een getal (programma stoppen = q): ");
                invoer = Console.ReadLine();
                if (invoer != "q")
                {
                    Console.WriteLine(getalNaarTekst(int.Parse(invoer)));
                }
            }
            while (invoer != "q");                  
            
        }

        static string getalNaarTekst(int getal)
        {
            string getalString = getal.ToString();
            string result = "";

            switch (getalString.Length)
            {
                case 1:
                    result = getal1NaarTekst(getal);
                    break;
                case 2:
                    result = getal2NaarTekst(getal);
                    break;
                case 3:
                    result = getal3NaarTekst(getal);
                    break;
                case 4:
                case 5:
                case 6:
                    result = getal456NaarTekst(getal);
                    break;
                case 7:
                case 8:
                case 9:
                    result = getal789NaarTekst(getal);
                    break;
            }
            return result;
        }

        static string getal789NaarTekst(int getal)
        {
            string getalString = getal.ToString();
            string result = "";

            switch (getalString.Length)
            {
                case 7:
                    result = getal1NaarTekst(int.Parse(getalString.Substring(0, 1))) + " " + m + " " + getal456NaarTekst(int.Parse(getalString.Substring(1, 6)));
                    break;
                case 8:
                    result = getal2NaarTekst(int.Parse(getalString.Substring(0, 2))) + " " + m + " " + getal456NaarTekst(int.Parse(getalString.Substring(2, 6)));
                    break;
                case 9:
                    result = getal3NaarTekst(int.Parse(getalString.Substring(0, 3))) + " " + m + " " + getal456NaarTekst(int.Parse(getalString.Substring(3, 6)));
                    break;
            }
            return result;
        }

        static string getal456NaarTekst(int getal)
        {
            string getalString = getal.ToString();
            string result = "";

            switch (getalString.Length)
            {
                case 4:
                    result = getal1NaarTekst(int.Parse(getalString.Substring(0, 1))) + " " + t + " " + getal3NaarTekst(int.Parse(getalString.Substring(1, 3)));
                    break;
                case 5:
                    result = getal2NaarTekst(int.Parse(getalString.Substring(0, 2))) + " " + t + " " + getal3NaarTekst(int.Parse(getalString.Substring(2, 3)));
                    break;
                case 6:
                    result = getal3NaarTekst(int.Parse(getalString.Substring(0, 3))) + " " + t + " " + getal3NaarTekst(int.Parse(getalString.Substring(3, 3)));
                    break;
            }
            return result;
        }
        
        static string getal3NaarTekst(int getal)
        {
            string getalString = getal.ToString();
            string result = "";
            
            result += getallenBehalve11Tot19[int.Parse(getalString.Substring(0, 1)) - 1, 1] + " " + h;
            if (getalString.Substring(1, 1) == "0")
            {
                result += " " + a + " " + getal1NaarTekst(getal % 100);
            }                
            else
            {
                result += " " + a + " " + getal2NaarTekst(int.Parse(getalString.Substring(1, 2)));
            }
            return result;
        }

        static string getal2NaarTekst(int getal)
        {
            string getalString = getal.ToString();
            string result = "";

            if (getalString.Substring(0, 1) == "1" && getalString.Substring(1, 1) != "0")
            {
                result = getallen11Tot19[(getal % 10) - 1];
            }
            else if (getalString.Substring(1, 1) == "0")
            {
                result = getallenBehalve11Tot19[int.Parse(getalString.Substring(0, 1)) - 1, 0];
            }
            else
            {
                result += getallenBehalve11Tot19[int.Parse(getalString.Substring(0, 1)) - 1, 0] + "-";
                result += getallenBehalve11Tot19[(getal % 10) - 1, 1];
            }

            return result;
        }

        static string getal1NaarTekst(int getal)
        {
            return getallenBehalve11Tot19[getal - 1, 1];         
        }

        static string verwijderSpatiesEnStreepjes(string s)
        {
            string result = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s.Substring(i, 1) != " " && s.Substring(i, 1) != "-")
                {
                    result += s.Substring(i, 1);
                }
            }
            return result;
        }

        static int telAantalLetters(int totGetal)
        {
            string result = "";
            int lengte;
            for (int i = 1; i <= totGetal; i++)
            {
                result += verwijderSpatiesEnStreepjes(getalNaarTekst(i));
            }
            return lengte = result.Length;
        }


    }
}
