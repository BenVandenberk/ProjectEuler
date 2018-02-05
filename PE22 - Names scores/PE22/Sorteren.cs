using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE22
{
    class Sorteren
    {
        private string[] teSorteren;
        private int somScores;

        public int SOMSCORES
        {
            get { return somScores; }
        }
        
        public Sorteren(string path)
        {
            vullen(path);
            mergeSort();
            somScores = somVanNaamScores();            
        }
        
        private void vullen(string path)
        {
            string gegeven = System.IO.File.ReadAllText(@path);
            string[] tussen = new string[gegeven.Length];
            int counter = 0;

            for (int i = 0, plaats = 0; plaats < gegeven.LastIndexOf('"'); i++)
            {
                while (char.Parse(gegeven.Substring(plaats, 1)) < 65 || (char.Parse(gegeven.Substring(plaats, 1)) > 90 && char.Parse(gegeven.Substring(plaats, 1)) < 97) || char.Parse(gegeven.Substring(plaats, 1)) > 122)
                {
                    plaats++;
                }
                while ((char.Parse(gegeven.Substring(plaats, 1)) >= 65 && char.Parse(gegeven.Substring(plaats, 1)) <= 90) || (char.Parse(gegeven.Substring(plaats, 1)) >= 97 && char.Parse(gegeven.Substring(plaats, 1)) <= 122))
                {
                    tussen[i] += char.Parse(gegeven.Substring(plaats, 1));
                    plaats++;
                }
            }

            while (tussen[counter] != null)
            {
                counter++;
            }

            teSorteren = new string[counter];

            for (int i = 0; i < counter; i++)
            {
                teSorteren[i] = tussen[i];
            }
        }

        public void Schrijven()
        {
            for (int i = 0; i < teSorteren.Length; i++)
            {
                Console.WriteLine(teSorteren[i]);
            }
        }

        public bool stringsVergelijken(string string1, string string2)     // geeft true als string 2 alfabetisch vóór string 1 komt
        {
            int lengteKortste = string1.Length < string2.Length ? string1.Length : string2.Length;
            bool resultaat = false;
            int aanUit = 1;

            for (int plaats = 0; plaats < lengteKortste && aanUit == 1; plaats++)
            {
                if (char.Parse(string1.Substring(plaats, 1)) < char.Parse(string2.Substring(plaats, 1)))
                {
                    resultaat = false;
                    aanUit = 0;
                }
                else if (char.Parse(string1.Substring(plaats, 1)) > char.Parse(string2.Substring(plaats, 1)))
                {
                    resultaat = true;
                    aanUit = 0;
                }
            }

            if (aanUit == 1)
            {
                resultaat = string1.Length < string2.Length ? false : true;
            }           

            return resultaat;
        }

        private void bubbleSortPlus()
        {
            string tussen = "";
            bool gesorteerd;
            int tot = teSorteren.Length - 1;

            do
            {
                gesorteerd = true;
                for (int i = 0; i < tot; i++)
                {
                    if (stringsVergelijken(teSorteren[i], teSorteren[i + 1]))
                    {
                        tussen = teSorteren[i];
                        teSorteren[i] = teSorteren[i + 1];
                        teSorteren[i + 1] = tussen;
                        gesorteerd = false;
                    }
                }
                tot--;
            } while (gesorteerd == false);
        }

        private int alfabetischeWaarde(string invoer)
        {
            int som = 0;
            
            for (int i = 0; i < invoer.Length; i++)
            {
                if (char.Parse(invoer.Substring(i, 1)) < 91)
                {
                    som += (char.Parse(invoer.Substring(i, 1)) - 64);
                }
                else
                {
                    som += (char.Parse(invoer.Substring(i, 1)) - 96);
                }
            }

            return som;
        }

        private int somVanNaamScores()
        {
            int som = 0;

            for (int i = 0; i < teSorteren.Length; i++)
            {
                som += (i + 1) * alfabetischeWaarde(teSorteren[i]);
            }

            return som;
        }

        private void mergeSort()
        {
            string[][][] merger;
            int counter = 1;

            for (double i = teSorteren.Length; i > 1; i /= 2)
            {
                counter++;
            }

            merger = new string[counter][][];  
          
            for (double lengte = teSorteren.Length, i = 0; counter > 0; lengte = Math.Ceiling(lengte / 2), i++, counter--)
            {
                merger[(int)i] = new string[(int)lengte][];
            }
            
            for (int i = 0; i < teSorteren.Length; i++)
            {
                merger[0][i] = new string[1];
                merger[0][i][0] = teSorteren[i];
            }

            for (int i = 0; i < merger.GetLength(0) - 1; i++)
            {
                if (merger[i].Length % 2 == 0)
                {
                    for (int j = 0, k = 0; j < merger[i].Length; j += 2, k++)
                    {
                        merger[i + 1][k] = merge(merger[i][j], merger[i][j + 1]);
                    }
                }
                else
                {
                    for (int j = 0, k = 0; j < merger[i].Length - 2; j += 2, k++)
                    {
                        merger[i + 1][k] = merge(merger[i][j], merger[i][j + 1]);
                    }
                    merger[i + 1][merger[i + 1].Length - 1] = merger[i][merger[i].Length - 1];
                }
            }           
            
            for (int i = 0; i < teSorteren.Length; i++)
            {
                teSorteren[i] = merger[merger.Length - 1][0][i];
            }
        }

        public string[] merge(string[] string1, string[] string2)
        {
            string[] resultaat = new string[string1.Length + string2.Length];
            int plaats1 = 0, plaats2 = 0;

            for (int i = 0; i < resultaat.Length; i++)
            {
                if (plaats1 == string1.Length || plaats2 == string2.Length)
                {
                    resultaat[i] = plaats1 == string1.Length ? string2[plaats2++] : string1[plaats1++];
                }
                else if (stringsVergelijken(string1[plaats1], string2[plaats2]))
                {
                    resultaat[i] = string2[plaats2];
                    plaats2++;
                }
                else
                {
                    resultaat[i] = string1[plaats1];
                    plaats1++;
                }                
            }

            return resultaat;
        }
    }
}



