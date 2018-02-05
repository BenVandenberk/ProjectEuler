using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE19
{
    class Datum
    {
        #region Variables
        private string dag = "", maand = "";
        private int dagNr = 0, maandNr = 0, jaar = 0, dagVanHetJaar = 0, serieel = 0;
        private bool schrikkeljaar = false;
        #endregion

        #region Properties
        public string DAG
        {
            get { return dag; }
        }

        public string MAAND
        {
            get { return maand; }
        }

        public int DAGNR
        {
            get { return dagNr; }
        }

        public int MAANDNR
        {
            get { return maandNr; }
        }

        public int JAAR
        {
            get { return jaar; }
        }

        public int DAGVANHETJAAR
        {
            get { return dagVanHetJaar; }
        }

        public int SERIEEL
        {
            get { return serieel; }
        }

        public bool SCHRIKKELJAAR
        {
            get { return schrikkeljaar; }
        }
        #endregion

        #region Constructors
        public Datum(int serieel)
        { 
            jaar = jaarBerekenen(serieel);
            maandNr = maandBerekenen(dagVanHetJaar);
            this.serieel = serieel;
            dagToewijzen();
        }

        public Datum(int dagGeg, int maandGeg, int jaarGeg)
        {
            try
            {
                waardenInitInt(dagGeg, maandGeg, jaarGeg);
                this.schrikkeljaar = schrikkeljaarCheck(this.jaar);
                dagVanHetJaarInit(this.dagNr, this.maandNr, this.schrikkeljaar);
                maandToewijzen(this.maandNr);
                serieel = serieelBerekenen();
                dagToewijzen();
            }
            catch (Exception)
            {
                Console.WriteLine("Gelieve een geldige datum in te geven");
            }
        }

        public Datum(string datumGeg)
        {
            try
            {
                waardenInitString(datumGeg);
                this.schrikkeljaar = schrikkeljaarCheck(this.jaar);
                dagVanHetJaarInit(this.dagNr, this.maandNr, this.schrikkeljaar);
                maandToewijzen(this.maandNr);
                serieel = serieelBerekenen();
                dagToewijzen();
            }
            catch (Exception)
            {
                Console.WriteLine("Gelieve een geldige datum in te geven");
            }
        }
        #endregion

        #region PrivateFunctions
        #region Algemeen
        private void dagToewijzen()
        {
            int rest7 = this.serieel % 7;
            switch (rest7)
            {
                case 0:
                    this.dag = "zondag";
                    break;
                case 1:
                    this.dag = "maandag";
                    break;
                case 2:
                    this.dag = "dinsdag";
                    break;
                case 3:
                    this.dag = "woensdag";
                    break;
                case 4:
                    this.dag = "donderdag";
                    break;
                case 5:
                    this.dag = "vrijdag";
                    break;
                case 6:
                    this.dag = "zaterdag";
                    break;
                default:
                    this.dag = "FOUT";
                    break;
            }
        }

        private void maandToewijzen(int maandNrGeg)
        {
            switch (maandNrGeg)
            {
                case 1:
                    maand = "januari";
                    break;
                case 2:
                    maand = "februari";
                    break;
                case 3:
                    maand = "maart";
                    break;
                case 4:
                    maand = "april";
                    break;
                case 5:
                    maand = "mei";
                    break;
                case 6:
                    maand = "juni";
                    break;
                case 7:
                    maand = "juli";
                    break;
                case 8:
                    maand = "augustus";
                    break;
                case 9:
                    maand = "september";
                    break;
                case 10:
                    maand = "oktober";
                    break;
                case 11:
                    maand = "november";
                    break;
                case 12:
                    maand = "december";
                    break;
                default:
                    maand = "FOUT";
                    break;
            }
        }

        private bool schrikkeljaarCheck(int jaarGeg)
        {
            bool schrikkeljaarTussen;
            if ((jaarGeg % 4) != 0)
            {
                schrikkeljaarTussen = false;
            }
            else if ((jaarGeg % 100 == 0) && (jaarGeg % 400) != 0)
            {
                schrikkeljaarTussen = false;
            }
            else
            {
                schrikkeljaarTussen = true;
            }
            return schrikkeljaarTussen;
        }
        #endregion
        #region Serieel naar datum
        private int jaarBerekenen(int serieel)
        {
            int jaarTussen = 1900;
            int serieelTussen = serieel;
            int aanUit = 1;
            bool schrikkeljaarTussen = false;

            while (aanUit == 1)
            {
                if (schrikkeljaarTussen == false)
                {
                    if (serieelTussen > 365)
                    {
                        jaarTussen++;
                        serieelTussen -= 365;
                        schrikkeljaarTussen = schrikkeljaarCheck(jaarTussen);
                    }
                    else
                    {
                        aanUit = 0;
                        dagVanHetJaar = serieelTussen;
                        schrikkeljaar = schrikkeljaarTussen;
                    }
                }
                else
                {
                    if (serieelTussen > 366)
                    {
                        jaarTussen++;
                        serieelTussen -= 366;
                        schrikkeljaarTussen = schrikkeljaarCheck(jaarTussen);
                    }
                    else
                    {
                        aanUit = 0;
                        dagVanHetJaar = serieelTussen;
                        schrikkeljaar = schrikkeljaarTussen;
                    }
                }
            }

            return jaarTussen;
        }       

        private int maandBerekenen(int serieelGeg)      // Berekent de maand ahv de rest van het serieel getal dat overschiet na het berekenen van het jaar
        {
            int[] dagenPerMaand = schrikkeljaar ? new int[12] { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 } : new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int maandNrTussen = 1;
            int serieelTussen = serieelGeg;

            for (; serieelTussen - dagenPerMaand[maandNrTussen - 1] > 0; maandNrTussen++)
            {
                serieelTussen -= dagenPerMaand[maandNrTussen - 1];
            }

            dagNr = serieelTussen;
            maandToewijzen(maandNrTussen);
            return maandNrTussen;
        }

        
        #endregion
        #region Datum naar serieel
        private void waardenInitString(string datumString)
        {
            int plaats = 0;
            int dagTussen = 0, maandTussen = 0, jaarTussen = 0;
            string dagString = "", maandString = "", jaarString = "";

            for (char d = char.Parse(datumString.Substring(plaats, 1)); d > 47 && d < 58 && plaats < datumString.Length; )
            {
                dagString += d.ToString();
                if (plaats + 1 == datumString.Length)
                {
                    plaats++;
                }
                else
                {
                    d = char.Parse(datumString.Substring(++plaats, 1));
                } 
            }
            for (char d = char.Parse(datumString.Substring(plaats, 1)); (d < 47 || d > 58) && plaats < datumString.Length; )
            {
                d = char.Parse(datumString.Substring(++plaats, 1));
            }

            for (char d = char.Parse(datumString.Substring(plaats, 1)); d > 47 && d < 58 && plaats < datumString.Length; )
            {
                maandString += d.ToString();
                if (plaats + 1 == datumString.Length)
                {
                    plaats++;
                }
                else
                {
                    d = char.Parse(datumString.Substring(++plaats, 1));
                } 
            }
            for (char d = char.Parse(datumString.Substring(plaats, 1)); (d < 47 || d > 58) && plaats < datumString.Length; )
            {
                d = char.Parse(datumString.Substring(++plaats, 1));
            }

            for (char d = char.Parse(datumString.Substring(plaats, 1)); d > 47 && d < 58 && plaats < datumString.Length; )
            {
                jaarString += d.ToString();
                if (plaats + 1 == datumString.Length)
                {
                    plaats++;
                }
                else 
                {
                    d = char.Parse(datumString.Substring(++plaats, 1));
                }                
            }

            if (int.Parse(maandString) < 13 && int.Parse(maandString) > 0)
            {
                maandTussen = int.Parse(maandString);
            }
            if (int.Parse(jaarString) >= 0)
            {
                jaarTussen = int.Parse(jaarString);
            }
            switch (maandTussen)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    if (int.Parse(dagString) > 0 && int.Parse(dagString) < 32)
                    {
                        dagTussen = int.Parse(dagString);
                    }
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    if (int.Parse(dagString) > 0 && int.Parse(dagString) < 31)
                    {
                        dagTussen = int.Parse(dagString);
                    }
                    break;
                case 2:
                    if (schrikkeljaarCheck(jaarTussen))
                    {
                        if (int.Parse(dagString) > 0 && int.Parse(dagString) < 30)
                        {
                            dagTussen = int.Parse(dagString);
                        }
                    }
                    else 
                    {
                        if (int.Parse(dagString) > 0 && int.Parse(dagString) < 29)
                        {
                            dagTussen = int.Parse(dagString);
                        }
                    }
                    break;
                default:
                    dagTussen = 0;
                    break;
            }

            this.dagNr = dagTussen;
            this.maandNr = maandTussen;
            this.jaar = jaarTussen;            
        }

        public void waardenInitInt(int dagGeg, int maandGeg, int jaarGeg)
        {
            if (maandGeg < 13 && maandGeg > 0)
            {
                this.maandNr = maandGeg;
            }
            if (jaarGeg >= 0)
            {
                this.jaar = jaarGeg;
            }
            switch (this.maandNr)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    if (dagGeg > 0 && dagGeg < 32)
                    {
                        this.dagNr = dagGeg;
                    }
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    if (dagGeg > 0 && dagGeg < 31)
                    {
                        this.dagNr = dagGeg;
                    }
                    break;
                case 2:
                    if (schrikkeljaarCheck(this.jaar))
                    {
                        if (dagGeg > 0 && dagGeg < 30)
                        {
                            this.dagNr = dagGeg;
                        }
                    }
                    else
                    {
                        if (dagGeg > 0 && dagGeg < 29)
                        {
                            this.dagNr = dagGeg;
                        }
                    }
                    break;
                default:
                    this.dagNr = 0;
                    break;
            }            
        }

        private void dagVanHetJaarInit(int dagGeg, int maandGeg, bool schrikkelGeg)
        {
            int[] dagenPerMaand = schrikkelGeg ? new int[12] { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 } : new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int dvhjTussen = dagGeg;

            for (int i = maandGeg - 2; i >= 0; i--)
            {
                dvhjTussen += dagenPerMaand[i];
            }

            this.dagVanHetJaar = dvhjTussen;
        }

        private int serieelBerekenen()
        {
            int serieelTussen = 0;
            int[] dagenPerMaand = schrikkeljaarCheck(this.jaar) ? new int[12] { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 } : new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            for (int huidig = 1900; huidig < this.jaar; huidig++)
            {
                serieelTussen += schrikkeljaarCheck(huidig) ? 366 : 365;
            }
            for (int i = 0; i < this.maandNr - 1; i++)
            {
                serieelTussen += dagenPerMaand[i];
            }
            serieelTussen += this.dagNr;

            return serieelTussen;
        }
        #endregion
        #endregion
    }
}
