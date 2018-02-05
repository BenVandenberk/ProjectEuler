using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringArithmeticLibrary;

namespace PE65___Convergents_of_e
{
    public struct Breuk
    {
        public string Teller;
        public string Noemer;

        public void AddTo(int input)
        {
            string tellerAdd = StringArithmetic.Multiply(input.ToString(), this.Noemer);
            this.Teller = StringArithmetic.Add(this.Teller, tellerAdd);
            //simplify();
        }

        private long gcd(long a, long b)
        {
            while (a != b)
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }

            return a;
        }

        //private void simplify()
        //{
        //    long ggd = gcd(Teller, Noemer);
        //    Teller /= ggd;
        //    Noemer /= ggd;
        //}
        public void TakeReciprocal()
        {
            string temp = Teller;
            Teller = Noemer;
            Noemer = temp;
        }

    }
}
