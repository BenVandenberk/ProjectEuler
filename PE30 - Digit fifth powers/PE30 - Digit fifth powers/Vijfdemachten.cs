using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE30___Digit_fifth_powers
{
    class Vijfdemachten
    {
        private int[] machtenVanVijf = new int[10] { 0, 1, 32, 243, 1024, 3125, 7776, 16807, 32768, 59049 };
        private SortedList<int, int> gegeven;
        private List<int> hits;

        public SortedList<int, int> Gegeven
        {
            get { return gegeven; }
            set { gegeven = value; }
        }

        public List<int> Hits
        {
            get { return hits; }
            set { hits = value; }
        }

        public Vijfdemachten(SortedList<int, int> gegeven)
        {
            Gegeven = gegeven;
            Hits = new List<int>();
        }

        public Vijfdemachten()
        {
            Hits = new List<int>();
        }

        public List<int> Oplossingen()
        {
            opl2();
            return Hits;
        }

        private void opl()
        {
            int som;
            
            for (int i = 0; i < Gegeven.Count; i++)
            {
                som = 0;

                for (int j = 0; j < Gegeven[i].ToString().Length && som <= Gegeven[i]; j++)
                {
                    som += machtenVanVijf[int.Parse(Gegeven[i].ToString().Substring(j, 1))];
                }

                if (som == Gegeven[i])
                {
                    Hits.Add(som);
                }
            }
        }

        private void opl2()
        {
            int som;

            for (int i = 0; i < 354295; i++)
            {
                som = 0;

                for (int j = 0; j < i.ToString().Length && som <= i; j++)
                {
                    som += machtenVanVijf[int.Parse(i.ToString().Substring(j, 1))];
                }

                if (som == i)
                {
                    Hits.Add(som);
                }
            }
        }
        
    }
}
