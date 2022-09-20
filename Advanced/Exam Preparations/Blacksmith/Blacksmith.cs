using System;
using System.Linq;
using System.Collections.Generic;

namespace Blacksmith
{
    internal class Blacksmith
    {
        static void Main(string[] args)
        {
            List<int> steel = Console.ReadLine().Split().Select(int.Parse).ToList();
            Stack<int> carbon = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            const int Gladius = 70;
            const int Shamshir = 80;
            const int Katana = 90;
            const int Sabre = 110;
            const int Broadsword = 150;
            int swordsCount = 0;

            Dictionary<string, int> craftedSwords = new Dictionary<string, int>()
            {
                    {"Gladius", 0},
                    {"Shamshir", 0},
                    {"Katana", 0},
                    {"Sabre", 0},
                    {"Broadsword", 0}
            };

            while (steel.Count > 0 && carbon.Count > 0)
            {
                int currCarbon = carbon.Pop();
                int currentMatch = steel[0] + currCarbon;

                if (currentMatch == Gladius)
                {
                    craftedSwords["Gladius"]++;
                    swordsCount++;
                    steel.RemoveAt(0);
                }
                else if (currentMatch == Shamshir)
                {
                    craftedSwords["Shamshir"]++;
                    swordsCount++;
                    steel.RemoveAt(0);
                }
                else if (currentMatch == Katana)
                {
                    craftedSwords["Katana"]++;
                    swordsCount++;
                    steel.RemoveAt(0);
                }
                else if (currentMatch == Sabre)
                {
                    craftedSwords["Sabre"]++;
                    swordsCount++;
                    steel.RemoveAt(0);
                }
                else if (currentMatch == Broadsword)
                {
                    craftedSwords["Broadsword"]++;
                    swordsCount++;
                    steel.RemoveAt(0);
                }
                else
                {
                    steel.RemoveAt(0);
                    currCarbon += 5;
                    carbon.Push(currCarbon);
                }
            }

            if (swordsCount > 0)
            {
                Console.WriteLine($"You have forged {swordsCount} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            if (steel.Count > 0)
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }

            if (carbon.Count > 0)
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }

            foreach (var craftedSword in craftedSwords.Where(v => v.Value > 0).OrderBy(k => k.Key))
            {
                Console.WriteLine($"{craftedSword.Key}: {craftedSword.Value}");
            }
        }
    }
}
