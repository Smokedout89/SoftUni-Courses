using System;
using System.Linq;
using System.Collections.Generic;

namespace Masterchef
{
    internal class Masterchef
    {
        static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> freshness = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            const int dippingSauce = 150;
            const int greenSalad = 250;
            const int chocolateCake = 300;
            const int lobster = 400;

            Dictionary<string, int> dishesCooked = new Dictionary<string, int>()
                {
                    {"Dipping sauce", 0},
                    {"Green salad", 0},
                    {"Chocolate cake", 0},
                    {"Lobster", 0}
                };

            while (ingredients.Count > 0 && freshness.Count > 0)
            {
                if (ingredients.Peek() == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }

                int currIngredient = ingredients.Dequeue();
                int currFreshness = freshness.Pop();
                int sum = currFreshness * currIngredient;

                if (sum == dippingSauce)
                {
                    dishesCooked["Dipping sauce"]++;
                }
                else if (sum == greenSalad)
                {
                    dishesCooked["Green salad"]++;
                }
                else if (sum == chocolateCake)
                {
                    dishesCooked["Chocolate cake"]++;
                }
                else if (sum == lobster)
                {
                    dishesCooked["Lobster"]++;
                }
                else
                {
                    currIngredient += 5;
                    ingredients.Enqueue(currIngredient);
                }
            }

            bool isTrue = dishesCooked.Values.All(x => x > 0);

            if (isTrue)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var dish in dishesCooked.Where(v => v.Value > 0).OrderBy(k => k.Key))
            {
                Console.WriteLine($" # {dish.Key} --> {dish.Value}");
            }
        }
    }
}
