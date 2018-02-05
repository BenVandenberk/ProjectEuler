using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContinuedFractions
{
    public struct Expressie
    {
        public SquareRoot Wortel;
        public int Term;
        public int Factor;

        public double Value
        {
            get
            {
                if (Wortel.Value == 0 && Term == 0)
                    return Factor;
                else
                    return (double)((Wortel.Value + Term) * Factor);
            }
        }

        public override string ToString()
        {
            string result = "";
            bool hasFactor = Factor != 1;
            bool hasWortel = Wortel.BaseOfRoot != 0;
            bool hasTerm = Term != 0;

            if (hasFactor)
                result += Factor;

            if (hasFactor && (hasWortel || hasTerm))
                result += " * ";

            if (hasFactor && (hasWortel && hasTerm))
                result += "[ ";

            if (hasWortel)
                result += "sqrt(" + Wortel.BaseOfRoot + ")";

            if (hasWortel && hasTerm)
                result += " + ";

            if (hasTerm)
                result += "(" + Term + ")";

            if (hasFactor && (hasWortel && hasTerm))
                result += " ]";

            return result;
        }

    }
}
