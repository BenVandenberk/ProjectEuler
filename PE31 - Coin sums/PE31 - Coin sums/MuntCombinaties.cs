using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE31___Coin_sums
{
    class MuntCombinaties
    {
        public List<int> Munten { get; set; }
        public List<List<int>> MuntCombos;
        public int Index { get; set; }
        public List<int> Huidig { get; set; }

        public MuntCombinaties(List<int> munten)
        {
            Munten = munten;
            MuntCombos = new List<List<int>>();
            Index = -1;
            Huidig = new List<int>();
        }

        private void mcRec(List<int> coins, int qMunten)
        {
            List<int> temp = new List<int>();

            if (qMunten == 1)
            {
                foreach (int munt in coins)
                {
                    Index++;
                    MuntCombos.Add(new List<int>());
                    if (Huidig.Count != 0)
                    {
                        foreach (int h in Huidig)
                        {
                            MuntCombos[Index].Add(h);
                        }
                    }
                    MuntCombos[Index].Add(munt);
                }                
            }
            else
            {
                for (int i = 0; i < coins.Count; i++)
                {
                    Huidig.Add(coins[i]);
                    temp = new List<int>(); // temp resetten
                    for (int j = 0; j < coins.Count; j++)  // Juiste lijst doorgeven: alles wat in Huidig zit mag niet in temp komen en ook alle i's die we hebben gehad niet
                    {
                        if (!Huidig.Contains(coins[j]) && j > i)
                        {
                            temp.Add(coins[j]);
                        }
                    }
                    mcRec(temp, qMunten - 1);
                    Huidig.RemoveAt(Huidig.Count - 1);
                }
            }
        }   

        public List<List<int>> GeefCombinaties()
        {
            for (int i = 1; i <= Munten.Count; i++)
            {
                mcRec(Munten, i);
            }

            return MuntCombos;
        }
    }
}
