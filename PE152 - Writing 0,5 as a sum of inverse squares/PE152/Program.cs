using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE152
{
    class Program
    {
        static void Main(string[] args)
        {
            double test = inverseSquare(2) + inverseSquare(3) + inverseSquare(4) + inverseSquare(6) + inverseSquare(7) + inverseSquare(9) + inverseSquare(10) + inverseSquare(20) + inverseSquare(28) + inverseSquare(35) + inverseSquare(36) + inverseSquare(48);
            Console.WriteLine(test);
        }

        static double inverseSquare(int vanGetal)
        {
            return (1.0 / (vanGetal * vanGetal));
        }

        // We definen een functie die een inversesquare geeft die kleiner is dan een bepaalde waarde


    }
}
