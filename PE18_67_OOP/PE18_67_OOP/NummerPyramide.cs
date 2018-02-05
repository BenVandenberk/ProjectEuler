using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE18_67_OOP
{
    class NummerPyramide
    {
        /*
         * FUNCTIONALITEITEN
         * Vullen met .txt file OK
         * Transformeren OK
         * Bepaald elementje schrijven
         * 
         * EIGENSCHAPPEN
         * Hoogte (alleen opvraagbaar, niet setbaar) OK
         * Waarde van bepaald elementje lezen OK
         */

        private int hoogte;
        private int[][] pyramide;
        private string[] pyramideNiveaus;
        
        #region Properties
        public int HOOGTE
        {
            get
            {
                if (this.pyramide == null)
                {
                    return hoogte = 0;
                }
                else 
                {
                    return hoogte = pyramide.GetLength(0);
                }
            }
        }
        #endregion

        #region Constructors
        public NummerPyramide()
        {
            hoogte = 0;
        }

        public NummerPyramide(string path)
        {
            vullen(path);
        }
        #endregion

        #region Functions
        private void vullen(string path)
        {
            pyramideNiveaus = System.IO.File.ReadAllLines(@path);
            pyramide = new int[pyramideNiveaus.GetLength(0)][];

            for (int i = 0; i < pyramideNiveaus.GetLength(0); i++)
            {
                pyramide[i] = new int[i + 1];
                for (int j = 0, k = 0; j < pyramideNiveaus[i].Length; j += 3, k++)
                {
                    pyramide[i][k] = int.Parse(pyramideNiveaus[i].Substring(j, 2));
                }
            }
        }

        public void Schrijven()
        {
            for (int i = 0; i < pyramide.GetLength(0); i++)
            {
                for (int j = 0; j < pyramide[i].Length; j++)
                {
                    Console.Write(pyramide[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void Transformeren()
        {
            int[][] tussenPyr = new int[pyramide.GetLength(0)][];

            // Laatste rij kopiëren
            tussenPyr[pyramide.GetLength(0) - 1] = new int[pyramide[pyramide.GetLength(0) - 1].Length];
            for (int i = 0; i < pyramide[pyramide.GetLength(0) - 1].Length; i++)
            {
                tussenPyr[pyramide.GetLength(0) - 1][i] = pyramide[pyramide.GetLength(0) - 1][i];
            }

            // Transformaties op al de andere rijen
            for (int i = pyramide.GetLength(0) - 2; i >= 0; i--)
            {
                tussenPyr[i] = new int[pyramide[i].Length];
                for (int j = 0; j < pyramide[i].Length; j++)
                {
                    tussenPyr[i][j] = pyramide[i + 1][j] >= pyramide[i + 1][j + 1] ? pyramide[i][j] + pyramide[i + 1][j] : pyramide[i][j] + pyramide[i + 1][j + 1];
                    pyramide[i][j] = tussenPyr[i][j];
                }
            }
        }

        public int WaardeVan(int rij, int kolom)
        {
            try
            {
                return pyramide[rij - 1][kolom - 1];
            }
            catch (NullReferenceException nREx)
            {
                Console.WriteLine(nREx.Message);
                return 0;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Dit elementje bestaat niet!\nControleer de coördinaten.");
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        #endregion
    }
}
