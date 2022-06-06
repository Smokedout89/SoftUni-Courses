using System;
using System.Collections.Generic;
using System.Linq;

namespace P06._Cards_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayerCards = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondPlayerCards = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                int indexToCompare = 0;

                if (firstPlayerCards.Count == 0 || secondPlayerCards.Count == 0)
                {
                    break;
                }
                else
                {
                    if (firstPlayerCards[indexToCompare] == secondPlayerCards[indexToCompare])
                    {
                        firstPlayerCards.RemoveAt(indexToCompare);
                        secondPlayerCards.RemoveAt(indexToCompare);
                        continue;
                    }

                    if (firstPlayerCards[indexToCompare] > secondPlayerCards[indexToCompare])
                    {
                        int winningHand = firstPlayerCards[indexToCompare];
                        int loosingHand = secondPlayerCards[indexToCompare];
                        firstPlayerCards.RemoveAt(indexToCompare);
                        secondPlayerCards.RemoveAt(indexToCompare);
                        firstPlayerCards.Add(loosingHand);
                        firstPlayerCards.Add(winningHand);
                    }
                    else
                    {
                        int winningHand = secondPlayerCards[indexToCompare];
                        int loosingHand = firstPlayerCards[indexToCompare];
                        firstPlayerCards.RemoveAt(indexToCompare);
                        secondPlayerCards.RemoveAt(indexToCompare);
                        secondPlayerCards.Add(loosingHand);
                        secondPlayerCards.Add(winningHand);
                    }
                }
            }

            if (firstPlayerCards.Count == 0)
            {
                Console.WriteLine($"Second player wins! Sum: {secondPlayerCards.Sum()}");
            }
            else
            {
                Console.WriteLine($"First player wins! Sum: {firstPlayerCards.Sum()}");
            }
        }
    }
}
