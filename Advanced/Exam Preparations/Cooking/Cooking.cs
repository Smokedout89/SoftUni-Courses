using System;
using System.Linq;
using System.Collections.Generic;

namespace Cooking
{
    internal class Cooking
    {
        static void Main(string[] args)
        {
            const int bread = 25;
            const int cake = 50;
            const int pastry = 75;
            const int fruitPie = 100;

            int breadCount = 0;
            int cakeCount = 0;
            int pastryCount = 0;
            int fruitPieCount = 0;

            int[] liquidsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] ingredientsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> liquidsQ = new Queue<int>(liquidsInput);
            Stack<int> ingredientS = new Stack<int>(ingredientsInput);

            while (ingredientS.Count != 0 && liquidsQ.Count != 0)
            {
                int liquid = liquidsQ.Peek();
                int ingredient = ingredientS.Peek();

                if (liquid + ingredient == bread)
                {
                    liquidsQ.Dequeue();
                    ingredientS.Pop();
                    breadCount++;
                }
                else if (liquid + ingredient == cake)
                {
                    liquidsQ.Dequeue();
                    ingredientS.Pop();
                    cakeCount++;
                }
                else if (liquid + ingredient == pastry)
                {
                    liquidsQ.Dequeue();
                    ingredientS.Pop();
                    pastryCount++;
                }
                else if (liquid + ingredient == fruitPie)
                {
                    liquidsQ.Dequeue();
                    ingredientS.Pop();
                    fruitPieCount++;
                }
                else
                {
                    liquidsQ.Dequeue();
                    ingredientS.Pop();
                    ingredient += 3;
                    ingredientS.Push(ingredient);
                }
            }

            if (breadCount >= 1 && cakeCount >= 1 && fruitPieCount >= 1 && pastryCount >= 1)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquidsQ.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquidsQ)}");
            }

            if (ingredientS.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredientS)}");
            }

            Console.WriteLine($"Bread: {breadCount}");
            Console.WriteLine($"Cake: {cakeCount}");
            Console.WriteLine($"Fruit Pie: {fruitPieCount}");
            Console.WriteLine($"Pastry: {pastryCount}");
        }
    }
}
