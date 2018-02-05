using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE39___Integer_right_triangles
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double[]> kwadraatCombos = new List<double[]>();
            List<double> perimeters = new List<double>();
            int maxCount = 1;
            int count = 1;

            kwadraatCombos = GetKwadraatCombos(500);
            foreach (double[] arr in kwadraatCombos)
            {
                if (arr[2] <= 1000)
                {
                    perimeters.Add(arr[2]);
                }
            }
            perimeters.Sort();
            for (int i = 1; i < perimeters.Count; i++)
            {
                if (perimeters[i] == perimeters[i - 1])
                {
                    count++;
                }
                else
                {
                    if (count > maxCount)
                    {
                        maxCount = count;
                        Console.WriteLine("De omtrek {0} heeft {1} gehele oplossingen", perimeters[i - 1], count);
                    }
                    count = 1;
                }
            }
        }

        static List<double[]> GetKwadraatCombos(int tot)
        {
            List<double[]> result = new List<double[]>();            

            for (double a = 1d; a <= tot; a++)
            {
                for (double b = a; b <= tot; b++)
                {
                    if (Math.Sqrt(a * a + b * b) % 1 == 0)
                    {
                        result.Add(new double[3] {a, b, a + b + Math.Sqrt(a * a + b * b)});                        
                    }
                }
            }

            return result;
        }
    }
}
