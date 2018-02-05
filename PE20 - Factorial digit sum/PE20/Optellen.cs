using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace PE20
{
    public class Optellen
    {
        private string getal1String = "";
        private string getal2String = "";
        private string som = "";
        private ArrayList resultaat = new ArrayList();

        public string SOM
        {
            get 
            {
                cijferen();
                som = arrayListToString(resultaat);
                return som;
            }
        }
        
        #region Constructors
        
        public Optellen(string getal1, string getal2)
        {
            getal1String = getal1;
            getal2String = getal2;
        }

        public Optellen(int getal1, int getal2)
        {
            getal1String = getal1.ToString();
            getal2String = getal2.ToString();
        }

        public Optellen(long getal1, long getal2)
        {
            getal1String = getal1.ToString();
            getal2String = getal2.ToString();
        }

        public Optellen(ArrayList getal1, ArrayList getal2)
        {
            getal1String = arrayListToString(getal1);
            getal2String = arrayListToString(getal2);
        }

        #endregion

        private void cijferen()
        {
            int overloop = 0;
            int positie1 = getal1String.Length - 1;
            int positie2 = getal2String.Length - 1;

            while (positie1 >= 0 && positie2 >= 0)
            {
                resultaat.Insert(0, (int.Parse(getal1String.Substring(positie1, 1)) + int.Parse(getal2String.Substring(positie2, 1)) + overloop) % 10);
                overloop = (int.Parse(getal1String.Substring(positie1, 1)) + int.Parse(getal2String.Substring(positie2, 1)) + overloop) / 10;
                positie1--;
                positie2--;
            }
            while (positie1 > positie2)
            {
                resultaat.Insert(0, (int.Parse(getal1String.Substring(positie1, 1)) + overloop) % 10);
                overloop = (int.Parse(getal1String.Substring(positie1, 1)) + overloop) / 10;
                positie1--;
            }
            while (positie2 > positie1)
            {
                resultaat.Insert(0, (int.Parse(getal2String.Substring(positie2, 1)) + overloop) % 10);
                overloop = (int.Parse(getal2String.Substring(positie2, 1)) + overloop) / 10;
                positie2--;
            }
            if (overloop > 0)
            {
                resultaat.Insert(0, overloop);
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
    }
}
