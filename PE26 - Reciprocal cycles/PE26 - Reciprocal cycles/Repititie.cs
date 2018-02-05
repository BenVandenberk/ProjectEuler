using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE26___Reciprocal_cycles
{
    class Repititie
    {
        private string checkValue = "";
        private int lengte = 0;
        private int minLengte = 0;
        private int repLengte = 0;
        private bool repititief = false;

        public Repititie(string check, int minLengte)
        {
            checkValue = check;
            lengte = check.Length;
            this.minLengte = minLengte;
            repititief = checkRepititie();
        }

        public bool REPITTIEF
        {
            get { return repititief; }
        }

        public int REPLENGTE
        {
            get { return repLengte; }
        }

        private bool checkRepititie()
        {
            int repititieLengte = 1;
            bool tussen = false;

            if (lengte < minLengte)
            {
                tussen = false;
            }
            else
            {
                bool repititie;
                for (; tussen == false && repititieLengte < lengte / 2; repititieLengte++)
                {
                    repititie = true;
                    for (int positie = lengte - 1 - repititieLengte, counter = lengte / repititieLengte > 50 ? 50 : lengte / repititieLengte; repititie == true && counter > 3; positie -= repititieLengte, counter--)
                    {
                        if (checkValue.Substring(positie, repititieLengte) != checkValue.Substring(positie - repititieLengte, repititieLengte))
                        {
                            repititie = false;
                        }
                    }
                    tussen = repititie;
                }
                this.repLengte = repititieLengte - 1;
            }
            return tussen;
        }
    }
}
