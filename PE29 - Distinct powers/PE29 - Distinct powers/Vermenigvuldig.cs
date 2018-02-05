using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace PE20
{
    class Vermenigvuldig
    {
        private string factor1 = "";    // factor met het meeste aantal cijfers
        private string factor2 = "";    // factor met het minste aantal cijfers
        private string product = "";
        private ArrayList[] tussenTermen = null;
        private Optellen o = null;

        public string PRODUCT
        {
            get { return product; }
        }
        
        #region Constructors

        public Vermenigvuldig(string factor1, string factor2)
        {
            this.factor1 = factor1.Length >= factor2.Length ? factor1 : factor2;
            this.factor2 = factor1.Length < factor2.Length ? factor1 : factor2;
            tussenTermen = new ArrayList[this.factor2.Length];
            cijferen();
            som();
        }

        public Vermenigvuldig(int factor1, int factor2)
        {
            this.factor1 = factor1 >= factor2 ? factor1.ToString() : factor2.ToString();
            this.factor2 = factor1 < factor2 ? factor1.ToString() : factor2.ToString();
            tussenTermen = new ArrayList[this.factor2.Length];
            cijferen();
            som();
        }

        public Vermenigvuldig(long factor1, long factor2)
        {
            this.factor1 = factor1 >= factor2 ? factor1.ToString() : factor2.ToString();
            this.factor2 = factor1 < factor2 ? factor1.ToString() : factor2.ToString();
            tussenTermen = new ArrayList[this.factor2.Length];
            cijferen();
            som();
        }

        #endregion

        private void cijferen()
        {
            int overloop = 0;
                        
            for (int i = factor2.Length - 1, nullen = 0; i >= 0; i--, nullen++)
            {
                tussenTermen[i] = new ArrayList();
                for (int k = nullen ;k > 0; k--)
                {
                    tussenTermen[i].Insert(0, 0);
                }
                for (int j = factor1.Length - 1; j >= 0; j--)
                {
                    tussenTermen[i].Insert(0, ((int.Parse(factor1.Substring(j, 1)) * int.Parse(factor2.Substring(i, 1))) + overloop) % 10);
                    overloop = ((int.Parse(factor1.Substring(j, 1)) * int.Parse(factor2.Substring(i, 1))) + overloop) / 10;
                }
                if (overloop != 0)
                {
                    tussenTermen[i].Insert(0, overloop);
                }
                overloop = 0;
            }
        }

        private string arrayListToString(ArrayList invoer)
        {
            string resultaat = "";

            foreach (int cijfer in invoer)
            {
                resultaat += cijfer;
            }

            return resultaat;
        }

        private void som()
        {
            string huidig = arrayListToString(tussenTermen[0]);
            
            for (int i = 1; i < tussenTermen.Length; i++)
            {
                o = new Optellen(huidig, arrayListToString(tussenTermen[i]));
                huidig = o.SOM;
            }

            this.product = huidig;
        }

    }
}
