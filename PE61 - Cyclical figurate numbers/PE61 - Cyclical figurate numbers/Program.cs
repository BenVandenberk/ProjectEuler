using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PE61___Cyclical_figurate_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch s = new Stopwatch();
            s.Start();

            List<PolygonalNumber> allPolygonNumbers = new List<PolygonalNumber>();

            bool stop = false;
            PolygonalNumber temp;
            for (int i = 0, basenr = 1, plus = 0, running = 1, baseupdate = 2, plusupdate = 1; !stop; i++)
            {
                if (i % 6 != 0)
                    running += plus;
                temp.Value = running;
                switch (i % 6)
                {
                    case 0:
                        if (running > 9999)
                            stop = true;
                        temp.Type = Polygon.Triangular;
                        if (running > 999 && running < 10000)
                            allPolygonNumbers.Add(temp);
                        break;
                    case 1:
                        temp.Type = Polygon.Square;
                        if (running > 999 && running < 10000)
                            allPolygonNumbers.Add(temp);
                        break;
                    case 2:
                        temp.Type = Polygon.Pentogonal;
                        if (running > 999 && running < 10000)
                            allPolygonNumbers.Add(temp);
                        break;
                    case 3:
                        temp.Type = Polygon.Hexogonal;
                        if (running > 999 && running < 10000)
                            allPolygonNumbers.Add(temp);
                        break;
                    case 4:
                        temp.Type = Polygon.Heptogonal;
                        if (running > 999 && running < 10000)
                            allPolygonNumbers.Add(temp);
                        break;
                    case 5:
                        temp.Type = Polygon.Octogonal;
                        if (running > 999 && running < 10000)
                            allPolygonNumbers.Add(temp);
                        basenr += baseupdate;
                        baseupdate++;
                        plus += plusupdate;
                        plusupdate++;
                        running = basenr;
                        break;
                }
            }

            List<PolygonalNumber[]> setsOf2 = new List<PolygonalNumber[]>();

            PolygonalNumber[] temp2;
            for (int i = 0; i < allPolygonNumbers.Count; i++)
            {
                for (int j = i + 1; j < allPolygonNumbers.Count; j++)
                {
                    if (allPolygonNumbers[i].Type != allPolygonNumbers[j].Type)
                    {
                        temp2 = getCyclicSet(allPolygonNumbers[i], allPolygonNumbers[j]);
                        if (temp2 != null)
                            setsOf2.Add(temp2);
                    }
                    temp2 = null;
                }
            }

            List<PolygonalNumber[]> setsOf4 = new List<PolygonalNumber[]>();

            temp2 = null;
            for (int i = 0; i < setsOf2.Count; i++)
            {
                for (int j = i + 1; j < setsOf2.Count; j++)
                {
                    if (areAllOfDifferentTypes(setsOf2[i], setsOf2[j]))
                    {
                        temp2 = getCyclicSet(setsOf2[i], setsOf2[j]);
                        if (temp2 != null)
                            setsOf4.Add(temp2);
                    }
                    temp2 = null;
                }
            }

            List<PolygonalNumber[]> setsOf6 = new List<PolygonalNumber[]>();

            temp2 = null;
            for (int i = 0; i < setsOf4.Count; i++)
            {
                for (int j = 0; j < setsOf2.Count; j++)
                {
                    if (areAllOfDifferentTypes(setsOf4[i], setsOf2[j]))
                    {
                        temp2 = getLargeCyclicSet(setsOf4[i], setsOf2[j]);
                        if (temp2 != null)
                            setsOf6.Add(temp2);
                    }
                    temp2 = null;
                }
            }

            s.Stop();

            Console.WriteLine(setsOf6[0].Sum(x => x.Value));
            Console.WriteLine("Computing time: " + s.ElapsedMilliseconds / 1000.0 + " s");

        }

        static bool areAllOfDifferentTypes(PolygonalNumber[] x, PolygonalNumber[] y)
        {
            bool result = true;

            for (int i = 0; i < x.Length && result; i++)
            {
                for (int j = 0; j < y.Length && result; j++)
                {
                    result = x[i].Type == y[j].Type ? false : true;
                }
            }

            return result;
        }

        static PolygonalNumber[] getCyclicSet(PolygonalNumber x, PolygonalNumber y)
        {
            if (x.Value.ToString().Substring(0, 2) == y.Value.ToString().Substring(2, 2))
                return new PolygonalNumber[] { y, x };

            if (y.Value.ToString().Substring(0, 2) == x.Value.ToString().Substring(2, 2))
                return new PolygonalNumber[] { x, y };

            return null;
        }

        static PolygonalNumber[] getCyclicSet(PolygonalNumber[] x, PolygonalNumber[] y) // input = sets of 2!
        {
            if (x[1].Value.ToString().Substring(2, 2) == y[0].Value.ToString().Substring(0, 2))
                return new PolygonalNumber[] { x[0], x[1], y[0], y[1] };

            if (y[1].Value.ToString().Substring(2, 2) == x[0].Value.ToString().Substring(0, 2))
                return new PolygonalNumber[] { y[0], y[1], x[0], x[1] };

            return null;
        }

        static PolygonalNumber[] getLargeCyclicSet(PolygonalNumber[] setOf4, PolygonalNumber[] setOf2) // input = set of 4 + set of 2!
        {
            if (setOf2[1].Value.ToString().Substring(2, 2) == setOf4[0].Value.ToString().Substring(0, 2) && setOf2[0].Value.ToString().Substring(0, 2) == setOf4[3].Value.ToString().Substring(2, 2))
                return new PolygonalNumber[] { setOf2[1], setOf4[0], setOf4[1], setOf4[2], setOf4[3], setOf2[0] };

            return null;
        }
    }
}
