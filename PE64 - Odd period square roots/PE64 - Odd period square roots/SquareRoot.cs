using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE64___Odd_period_square_roots
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
