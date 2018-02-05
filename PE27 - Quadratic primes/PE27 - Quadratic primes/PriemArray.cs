using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE27___Quadratic_primes
{
    class PriemArray
    {
        private int[] tempPriemArray;
        private int[] tempPriemArrayNeg;
        private int[] priemArray;
        private int min = 0;
        private int max = 0;

        public int[] PRIEMARRAY
        {
            get { return priemArray; }
        }

        public int MIN
        {
            get { return min; }
        }

        public int MAX
        {
            get { return max; }
        }

        public PriemArray(int min, int max)
        {
            this.min = min;
            this.max = max;
            tempPriemArray = new int[max - min];
            tempPriemArrayNeg = new int[max - min];
            vullen();
        }

        private void vullen()
        {
            bool priem = true;
            int positie = 0;
            int count = 0;
            int countNeg = 0;
            
            for (int i = min <= 0 ? 1 : min; i <= max; i++)
            {
                priem = true;
                for (int j = 2; j <= Math.Sqrt(i) && priem; j++)
                {
                    if (i % j == 0)
                    {
                        priem = false;
                    }
                }
                if (priem)
                {
                    tempPriemArray[positie] = i;
                    positie++;
                    count++;
                    if (-i >= min)
                    {
                        tempPriemArrayNeg[countNeg] = -i;
                        countNeg++;
                    }                    
                }
            }
            priemArray = new int[count + countNeg];
            for (int i = 0, j = countNeg - 1; j >= 0; i++, j--)
            {
                priemArray[i] = tempPriemArrayNeg[j];
            }
            for (int i = countNeg, j = 0; i < priemArray.Length; i++, j++)
            {
                priemArray[i] = tempPriemArray[j];
            }
        }

        public string Schrijf()
        {
            string result = "";

            for (int i = 0; i < priemArray.Length; i++)
            {
                if (i == priemArray.Length - 1)
                {
                    result += priemArray[i];
                }
                else
                {
                    result += priemArray[i] + ",";
                }
            }

            return result;
        }

        public bool PriemCheck(int check)
        {
            bool priem = true;
            int checkPos = check < 0 ? -check : check;

            if (check == 0 || check == 1)
            {
                return false;
            }

            for (int j = 2; j <= Math.Sqrt(checkPos) && priem; j++)
            {
                if (checkPos % j == 0)
                {
                    priem = false;
                }
            }

            return priem;
        }
    }
}
