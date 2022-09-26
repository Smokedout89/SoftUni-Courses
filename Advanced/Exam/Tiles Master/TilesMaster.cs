using System;
using System.Linq;
using System.Collections.Generic;

namespace Tiles_Master
{
    internal class TilesMaster
    {
        static void Main(string[] args)
        {
            Stack<int> whiteTiles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> greyTiles = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            const int sink = 40;
            const int oven = 50;
            const int countertop = 60;
            const int wall = 70;

            Dictionary<string, int> tiles = new Dictionary<string, int>()
            {
                {"Floor", 0},
                {"Sink", 0},
                {"Oven", 0},
                {"Countertop", 0},
                {"Wall", 0},
            };

            while (whiteTiles.Count > 0 && greyTiles.Count > 0)
            {
                int currentGrey = greyTiles.Peek();
                int currentWhite = whiteTiles.Peek();

                if (currentWhite == currentGrey)
                {
                    int sum = currentGrey + currentWhite;

                    if (sum == sink)
                    {
                        tiles["Sink"]++;
                    }
                    else if (sum == oven)
                    {
                        tiles["Oven"]++;
                    }
                    else if (sum == countertop)
                    {
                        tiles["Countertop"]++;
                    }
                    else if (sum == wall)
                    {
                        tiles["Wall"]++;
                    }
                    else
                    {
                        tiles["Floor"]++;
                    }

                    greyTiles.Dequeue();
                    whiteTiles.Pop();
                }
                else
                {
                    whiteTiles.Pop();
                    currentWhite /= 2;
                    whiteTiles.Push(currentWhite);
                    greyTiles.Dequeue();
                    greyTiles.Enqueue(currentGrey);
                }
            }

            if (whiteTiles.Count > 0)
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTiles)}");
            }
            else
            {
                Console.WriteLine("White tiles left: none");
            }

            if (greyTiles.Count > 0)
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles)}");
            }
            else
            {
                Console.WriteLine("Grey tiles left: none");
            }

            foreach (var tile in tiles.OrderByDescending(v => v.Value).ThenBy(k => k.Key))
            {
                if (tile.Value > 0)
                {
                    Console.WriteLine($"{tile.Key}: {tile.Value}");
                }
            }
        }
    }
}
