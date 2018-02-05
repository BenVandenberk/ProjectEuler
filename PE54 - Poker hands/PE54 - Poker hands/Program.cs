using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace PE54___Poker_hands
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            PokerHand HandPlayer1, HandPlayer2;
            Card[] current1 = new Card[5];
            Card[] current2 = new Card[5];
            int Player1Won = 0;
            int Player2Won = 0;
            PokerCombination highest = PokerCombination.High_Card;

            sw.Start();
            
            string[] pokerHands = File.ReadAllLines(@"C:\Users\Ben\Documents\Ben\Programmeren\C#\ProjectEuler\PE54 - Poker hands\PE54 - Poker hands\poker.txt");

            foreach (string Hands in pokerHands)
            {
                string[] cards = Hands.Split(new char[] {' '});
                for (int i = 0; i < cards.Length; i++)
                {
                    if (i < 5)
                    {
                        current1[i] = Poker.StringToCard(cards[i]);
                    }
                    else
                    {
                        current2[i - 5] = Poker.StringToCard(cards[i]);
                    }
                }

                HandPlayer1 = new PokerHand(current1);
                HandPlayer2 = new PokerHand(current2);

                //Console.Write("Player 1: " + HandPlayer1.PokerCombination + "\t||   Player 2: " + HandPlayer2.PokerCombination);

                if (HandPlayer1.PokerCombination > highest)
                {
                    highest = HandPlayer1.PokerCombination;
                }
                if (HandPlayer2.PokerCombination > highest)
                {
                    highest = HandPlayer2.PokerCombination;
                }

                if (HandPlayer1.ValueCode.CompareTo(HandPlayer2.ValueCode) > 0)
                {
                    //Console.WriteLine("   |---> Player 1 wins!");
                    Player1Won++;
                }
                else
                {
                    //Console.WriteLine("   |---> Player 2 wins!");
                    Player2Won++;
                }
            }

            sw.Stop();
            
            Console.WriteLine("Player 1 wins " + Player1Won + " times!");
            Console.WriteLine("The best combination was: " + highest);
            Console.WriteLine("Elapsed time: " + sw.ElapsedMilliseconds + " ms.");
            
        }
    }
}
