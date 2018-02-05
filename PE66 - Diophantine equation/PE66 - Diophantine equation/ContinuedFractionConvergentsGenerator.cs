using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using StringArithmeticLibrary;

namespace PE66___Diophantine_equation
{
    public struct StringBreuk
    {
        public string Teller;
        public string Noemer;

        public void TakeReciprocal()
        {
            string temp = Teller;
            Teller = Noemer;
            Noemer = temp;
        }

        public void AddInteger(int term)
        {
            string tellerAdd = StringArithmetic.Multiply(term.ToString(), Noemer);
            Teller = StringArithmetic.Add(Teller, tellerAdd);
        }

        public override string ToString()
        {
            return Teller + "/" + Noemer;
        }
    }
    
    public class ContinuedFractionConvergentsGenerator
    {
        private int[] coefficients;
        private int currentConvergent;
        private int period;

        public int CurrentConvergent
        {
            get { return this.currentConvergent; }
            private set { this.currentConvergent = value; }
        }
        
        public int[] Coefficients
        {
            get { return this.coefficients; }
            private set { this.coefficients = value; }
        }

        public ContinuedFractionConvergentsGenerator(int[] coefficients)
        {
            this.Coefficients = new int[coefficients.Length];
            coefficients.CopyTo(this.Coefficients, 0);

            CurrentConvergent = 0;
            this.period = this.Coefficients.Length - 1;
        }

        public StringBreuk Next()
        {
            CurrentConvergent++;

            return generate();
        }

        public void Reseed(int[] coefficients)
        {
            Reset();

            this.Coefficients = new int[coefficients.Length];
            coefficients.CopyTo(this.Coefficients, 0);

            this.period = this.Coefficients.Length - 1;
        }

        public void Reset()
        {
            CurrentConvergent = 0;
        }

        private StringBreuk generate()
        {
            StringBreuk result;
            int currentNoemerIndex = CurrentConvergent % period == 0 ? Coefficients.Length - 1 : CurrentConvergent % period;

            result.Teller = "1";

            if (CurrentConvergent == 1)
            {                
                result.Noemer = Coefficients[1].ToString();
                result.AddInteger(Coefficients[0]);
            }
            else
            {
                result.Noemer = Coefficients[currentNoemerIndex].ToString();
                for (int nrOfConvergentsLeft = CurrentConvergent; nrOfConvergentsLeft > 1; nrOfConvergentsLeft--)
                {
                    if (currentNoemerIndex > 1)
                    {
                        currentNoemerIndex--;
                    }
                    else
                    {
                        currentNoemerIndex = coefficients.Length - 1;
                    }

                    result.AddInteger(Coefficients[currentNoemerIndex]);
                    result.TakeReciprocal();
                }

                result.AddInteger(Coefficients[0]);
            }

            return result;
        }
    }
}
