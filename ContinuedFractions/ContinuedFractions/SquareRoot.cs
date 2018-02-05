using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContinuedFractions
{
    public struct SquareRoot
    {
        public int BaseOfRoot;
        public int Factor;

        public double Value
        {
            get { return (double)(Math.Sqrt(BaseOfRoot) * Factor); }
        }
    }
}
