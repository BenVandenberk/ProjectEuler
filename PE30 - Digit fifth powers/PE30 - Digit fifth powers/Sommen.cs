using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE30___Digit_fifth_powers
{
    class Sommen
    {
        private int[] termen;
        private int[] tempSommen;
        private int niveau;
        private int som;
        private int key;
        private SortedList<int,int> alleSommen;
        
        public int[] Termen
        {
            get { return termen; }
            set { termen = value; }
        }

        public int[] TempSommen
        {
            get { return tempSommen; }
            set { tempSommen = value; }
        }

        public int Niveau
        {
            get { return niveau; }
            set { niveau = value; }
        }

        public int Som
        {
            get { return som; }
            set { som = value; }
        }

        public int Key
        {
            get { return key; }
            set { key = value; }
        }

        public SortedList<int,int> AlleSommen
        {
            get { return alleSommen; }
            set { alleSommen = value; }
        }
        
        public Sommen(int[] termen)
        {
            Termen = termen;
            Niveau = 0;
            Som = 0;
            Key = 0;
            AlleSommen = new SortedList<int,int>();
        }

        public SortedList<int, int> GenereerSommen(int minAC, int maxAC)
        {
            reset();

            for (int i = minAC; i <= maxAC; i++)
            {
                TempSommen = new int[i];
                recursieveSommen(i);
                reset();
            }

            return AlleSommen;
        }

        private void recursieveSommen(int aantalCijfers)
        {
            Niveau++;

            for (int i = 0; i < Termen.Length; i++)
            {
                Som += Termen[i];

                if (Niveau == aantalCijfers)
                {
                    if (!AlleSommen.ContainsValue(som))
                    {
                        AlleSommen.Add(Key++, som);
                        Som -= Termen[i];
                    }
                }
                else
                {
                    TempSommen[Niveau] = Som;
                    recursieveSommen(aantalCijfers);
                }
            }
           
            Niveau--;
            Som = Niveau == 0 ? TempSommen[0] : TempSommen[Niveau - 1];
        }

        private void reset()
        {
            Som = 0;
            Niveau = 0;
            TempSommen = null;            
        }
    }
}
