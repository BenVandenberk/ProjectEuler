using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE64___Odd_period_square_roots
{
    public class RootToContinuedFraction
    {
        private Breuk tussenResultaat;
        private List<double> checkWaarden;
        private List<int> resultaatWaarden;
        private int eersteResultaatWaarde;
        private int wortel;

        public int Period { get; private set; }
        public string ShortNotation { get; private set; }
        public string LongNotation { get; private set; }
        public int[] Coefficients { get; set; }

        public RootToContinuedFraction()
        {
            checkWaarden = new List<double>();
            resultaatWaarden = new List<int>();
        }

        public void Generate(int wortel)
        {
            checkWaarden.Clear();
            resultaatWaarden.Clear();            

            this.wortel = wortel;
            tussenResultaat = initBreukOpWortelVan(wortel);

            eersteResultaatWaarde = shaveOffWholeNumbers(ref tussenResultaat);
            checkWaarden.Add(tussenResultaat.Value);
            tussenResultaat.TakeReciprocal();
            moveRootToTeller(ref tussenResultaat);

            bool stop = false;

            while (!stop)
            {
                stop = update();
            }

            Period = resultaatWaarden.Count;

            Coefficients = new int[resultaatWaarden.Count + 1];
            Coefficients[0] = eersteResultaatWaarde;
            for (int i = 1; i < Coefficients.Length; i++)
            {
                Coefficients[i] = resultaatWaarden[i - 1];
            }

            ShortNotation = "[" + eersteResultaatWaarde + "(";
            for (int i = 0; i < resultaatWaarden.Count - 1; i++)
            {
                ShortNotation += resultaatWaarden[i] + ", ";
            }
            ShortNotation += resultaatWaarden[resultaatWaarden.Count - 1] + ")]";
            LongNotation = "sqrt(" + this.wortel + ") = " + this.ShortNotation + "  => Period = " + this.Period; 
        }

        private bool update()
        {
            resultaatWaarden.Add(shaveOffWholeNumbers(ref tussenResultaat));
            if (checkWaarden.Contains(tussenResultaat.Value))
                return true;

            checkWaarden.Add(tussenResultaat.Value);
            tussenResultaat.TakeReciprocal();
            moveRootToTeller(ref tussenResultaat);
            return false;
        }

        private int shaveOffWholeNumbers(ref Breuk br)
        {
            int rest = (int)br.Value;

            br.Teller.Term = (br.Teller.Term * br.Teller.Factor) - rest * br.Noemer.Factor;
            br.Teller.Wortel.Factor = br.Teller.Factor;
            br.Teller.Factor = 1;

            return rest;
        }

        private void moveRootToTeller(ref Breuk br)
        {
            br.Teller.Wortel = br.Noemer.Wortel;
            br.Teller.Term = br.Noemer.Term * -1;

            br.Noemer.Factor = br.Noemer.Wortel.BaseOfRoot - (br.Noemer.Term * br.Noemer.Term);
            br.Noemer.Wortel.BaseOfRoot = 0;
            br.Noemer.Term = 0;

            br.Simplify();
        }

        private Breuk initBreukOpWortelVan(int wortel)
        {
            Breuk b;

            b.Teller.Wortel.BaseOfRoot = wortel;
            b.Teller.Wortel.Factor = 1;
            b.Teller.Factor = 1;
            b.Teller.Term = 0;

            b.Noemer.Wortel.BaseOfRoot = 0;
            b.Noemer.Wortel.Factor = 1;
            b.Noemer.Term = 0;
            b.Noemer.Factor = 1;

            return b;
        }
    }
}
