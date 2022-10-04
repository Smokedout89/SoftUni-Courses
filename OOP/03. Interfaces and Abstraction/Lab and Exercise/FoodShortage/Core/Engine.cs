using System;
using System.Collections.Generic;
using System.Linq;
using BorderControl.Models;
using FoodShortage.Contracts;

namespace FoodShortage.Core
{
    public class Engine
    {
        private IList<IBuyer> buyers = new List<IBuyer>();

        public Engine()
        {
            buyers = new List<IBuyer>();
        }

        public void Run()
        {
            ReadData();
            BuyFood();
            Console.WriteLine(TotalFood());
        }

        private int TotalFood()
        {
            int totalFood = buyers.Sum(f => f.Food);
            return totalFood;
        }

        private void BuyFood()
        {
            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                var current = buyers.FirstOrDefault(n => n.Name == command);

                if (current != null)
                {
                    current.BuyFood();
                }
            }
        }

        private void ReadData()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputInfo = Console.ReadLine().Split();
                string name = inputInfo[0];
                int age = int.Parse(inputInfo[1]);

                IBuyer buyer = null;

                if (inputInfo.Length == 3)
                {
                    string group = inputInfo[2];

                    buyer = new Rebel(name, age, group);
                }
                else if (inputInfo.Length == 4)
                {
                    string id = inputInfo[2];
                    string birthdate = inputInfo[3];

                    buyer = new Citizen(name, age, id, birthdate);
                }

                buyers.Add(buyer);
            }
        }
    }
}