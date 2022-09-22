using System;
using System.Linq;
using System.Collections.Generic;

namespace Meal_Plan
{
    internal class MealPlan
    {
        static void Main(string[] args)
        {
            List<string> meals = Console.ReadLine().Split().ToList();
            Stack<int> caloriesPerDay = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            const int salad = 350;
            const int soup = 490;
            const int pasta = 680;
            const int steak = 790;
            int mealsEaten = 0;

            while (meals.Count > 0 && caloriesPerDay.Count > 0)
            {
                int currDayCalories = caloriesPerDay.Pop();
                int currentMeal = 0;

                switch (meals[0])
                {
                    case "salad": currentMeal = salad; break;
                    case "soup": currentMeal = soup; break;
                    case "pasta": currentMeal = pasta; break;
                    case "steak": currentMeal = steak; break;
                }

                if (currDayCalories - currentMeal >= 0)
                {
                    currDayCalories -= currentMeal;
                    caloriesPerDay.Push(currDayCalories);
                    meals.RemoveAt(0);
                    mealsEaten++;
                }
                else
                {
                    int caloriesLeft = currentMeal - currDayCalories;

                    if (caloriesPerDay.Count > 0)
                    {
                        currDayCalories = caloriesPerDay.Pop() - caloriesLeft;
                        caloriesPerDay.Push(currDayCalories);
                        meals.RemoveAt(0);
                        mealsEaten++;
                    }
                    else
                    {
                        mealsEaten++;
                        meals.RemoveAt(0);
                    }
                }
            }

            if (meals.Count == 0)
            {
                Console.WriteLine($"John had {mealsEaten} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", caloriesPerDay)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {mealsEaten} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
        }
    }
}
