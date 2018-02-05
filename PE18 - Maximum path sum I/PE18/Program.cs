using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE18
{
    class Program
    {
        static string[] gegeven = System.IO.File.ReadAllLines(@"C:\Users\Ben\Documents\Ben\Programmeren\C#\ProjectEuler\PE18\GegevenPyramide.txt");
        static int[][] pyramide = new int[gegeven.GetLength(0)][];
        static int[][] pyramideVanGemiddelden = new int[gegeven.GetLength(0)][];
        static int[][] pyramideVanSommen = new int[gegeven.GetLength(0)][];
        static int[][] getransformeerdePyramide = new int [gegeven.GetLength(0)][];
                
        static void Main(string[] args)
        {
            pyramideVullen();
            transformeren();
            schrijven();
        }

        static void pyramideVullen()
        {                                   
            for (int i = 0; i < gegeven.GetLength(0); i++)
            {
                pyramide[i] = new int[i + 1];
                for (int j = 0, k = 0; j < gegeven[i].Length; j += 3, k++)
                {
                    pyramide[i][k] = int.Parse(gegeven[i].Substring(j, 2));
                }
            }
        }

        static void schrijven()
        {
            for (int i = 0; i < pyramide.GetLength(0); i++)
            {
                for (int j = 0; j < pyramide[i].Length; j++)
                {
                    Console.Write(getransformeerdePyramide[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void gemiddeldeTransformatie()
        {
            // Eerste rij kopiëren
            pyramideVanGemiddelden[0] = new int[1];
            pyramideVanGemiddelden[0][0] = pyramide[0][0];  

            // Laatste rij kopiëren
            pyramideVanGemiddelden[pyramide.GetLength(0) - 1] = new int[pyramide[pyramide.GetLength(0) - 1].Length];
            for (int i = 0; i < pyramide[pyramide.GetLength(0) - 1].Length; i++)
            {
                pyramideVanGemiddelden[pyramide.GetLength(0) - 1][i] = pyramide[pyramide.GetLength(0) - 1][i];
            }

            // Transformatie uitvoeren op tussenliggende rijen
            for (int i = pyramide.GetLength(0) - 2; i > 0; i--)
            {
                pyramideVanGemiddelden[i] = new int[pyramide[i].Length];
                for (int j = 0; j < pyramide[i].Length; j++)
                {
                    pyramideVanGemiddelden[i][j] = pyramide[i][j] + ((pyramide[i + 1][j] + pyramide[i + 1][j + 1]) / 2);
                    pyramide[i][j] = pyramideVanGemiddelden[i][j];
                }
            }
        }

        static void somTransformatie()
        {
            // Eerste rij kopiëren
            pyramideVanSommen[0] = new int[1];
            pyramideVanSommen[0][0] = pyramide[0][0];

            // Laatste rij kopiëren
            pyramideVanSommen[pyramide.GetLength(0) - 1] = new int[pyramide[pyramide.GetLength(0) - 1].Length];
            for (int i = 0; i < pyramide[pyramide.GetLength(0) - 1].Length; i++)
            {
                pyramideVanSommen[pyramide.GetLength(0) - 1][i] = pyramide[pyramide.GetLength(0) - 1][i];
            }

            // Transformatie uitvoeren op tussenliggende rijen
            for (int i = pyramide.GetLength(0) - 2; i > 0; i--)
            {
                pyramideVanSommen[i] = new int[pyramide[i].Length];
                for (int j = 0; j < pyramide[i].Length; j++)
                {
                    pyramideVanSommen[i][j] = pyramide[i][j] + pyramide[i + 1][j] + pyramide[i + 1][j + 1];
                    pyramide[i][j] = pyramideVanSommen[i][j];
                }
            }
        }

        static int somGemiddelde()
        {
            int som = 0;
            int x = 0;
            int y = 0;

            som += pyramide[x][y];
            while (x < pyramide.GetLength(0) - 1)
            {
                som += pyramideVanGemiddelden[x + 1][y] >= pyramideVanGemiddelden[x + 1][y + 1] ? pyramide[x++ + 1][y] : pyramide[x++ + 1][y++ + 1];
            }
            return som;
        }

        static int somSommen()
        {
            int som = 0;
            int x = 0;
            int y = 0;

            som += pyramide[x][y];
            while (x < pyramide.GetLength(0) - 1)
            {
                som += pyramideVanSommen[x + 1][y] >= pyramideVanSommen[x + 1][y + 1] ? pyramide[x++ + 1][y] : pyramide[x++ + 1][y++ + 1];
            }
            return som;
        }

        static void transformeren()
        {
            // Laatste rij kopiëren
            getransformeerdePyramide[pyramide.GetLength(0) - 1] = new int[pyramide[pyramide.GetLength(0) - 1].Length];
            for (int i = 0; i < pyramide[pyramide.GetLength(0) - 1].Length; i++)
            {
                getransformeerdePyramide[pyramide.GetLength(0) - 1][i] = pyramide[pyramide.GetLength(0) - 1][i];
            }

            // Transformaties al de andere rijen
            for (int i = pyramide.GetLength(0) - 2; i >= 0; i--)
            {
                getransformeerdePyramide[i] = new int[pyramide[i].Length];
                for (int j = 0; j < pyramide[i].Length; j++)
                {
                    getransformeerdePyramide[i][j] = pyramide[i + 1][j] >= pyramide[i + 1][j + 1] ? pyramide[i][j] + pyramide[i + 1][j] : pyramide[i][j] + pyramide[i + 1][j + 1];
                    pyramide[i][j] = getransformeerdePyramide[i][j];
                }
            }
        }


    }
}
