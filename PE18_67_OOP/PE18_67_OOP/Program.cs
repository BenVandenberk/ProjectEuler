using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE18_67_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            NummerPyramide n = new NummerPyramide(@"C:\Users\Ben\Documents\Ben\Programmeren\C#\ProjectEuler\PE18\GegevenPyramide.txt");
            NummerPyramide y = new NummerPyramide();

            //n.Transformeren();
            Console.WriteLine(n.WaardeVan(1,15));
        }
    }
}
