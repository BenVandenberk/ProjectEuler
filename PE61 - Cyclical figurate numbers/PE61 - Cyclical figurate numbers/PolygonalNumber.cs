using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE61___Cyclical_figurate_numbers
{
    public enum Polygon { Triangular, Square, Pentogonal, Hexogonal, Heptogonal, Octogonal };

    public struct PolygonalNumber
    {
        public int Value;
        public Polygon Type;
    }
}
