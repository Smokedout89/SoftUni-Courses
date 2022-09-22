using System;
using System.Linq;
using System.Collections.Generic;

namespace Loot_box
{
    internal class LootBox
    {
        static void Main(string[] args)
        {
            List<int> firstLootBox = new List<int>(Console.ReadLine().Split().Select(int.Parse).ToList());
            Stack<int> secondLootBox = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            int lootSum = 0;

            while (firstLootBox.Count > 0 && secondLootBox.Count > 0)
            {
                int firstItem = firstLootBox[0];
                int secondItem = secondLootBox.Pop();

                if ((firstItem + secondItem) % 2 == 0)
                {
                    lootSum += firstItem + secondItem;
                    firstLootBox.RemoveAt(0);
                }
                else
                {
                    firstLootBox.Add(secondItem);
                }
            }

            if (firstLootBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (lootSum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {lootSum}");  
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {lootSum}");
            }
        }
    }
}
