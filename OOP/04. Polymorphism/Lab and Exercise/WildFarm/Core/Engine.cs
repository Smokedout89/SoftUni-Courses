using System;
using System.Collections.Generic;
using WildFarm.Contracts;
using WildFarm.Food;
using WildFarm.Models;

namespace WildFarm.Core
{
    public class Engine
    {
        public void Run()
        {
            List<IAnimal> animals = ReadData();
            PrintAnimals(animals);
        }

        private void PrintAnimals(List<IAnimal> animals)
        {
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }

        private List<IAnimal> ReadData()
        {
            string input;
            List<IAnimal> animals = new List<IAnimal>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] animalInfo = input.Split();
                string[] foodInfo = Console.ReadLine().Split();
             
                IAnimal animal = null;
                animal = CreateAnimal(animal, animalInfo);
                Console.WriteLine(animal.ProduceSound());
                animals.Add(animal);

                IFood food = null;
                food = GetFood(food, foodInfo);

                try
                {
                    animal.Eat(food);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            return animals;
        }

        private IFood GetFood(IFood food, string[] foodInfo)
        {
            string inputFood = foodInfo[0];
            int quantity = int.Parse(foodInfo[1]);

            if (inputFood == "Vegetable")
            {
                food = new Vegetable(quantity);
            }
            else if (inputFood == "Fruit")
            {
                food = new Fruit(quantity);
            }
            else if (inputFood == "Meat")
            {
                food = new Meat(quantity);
            }
            else if (inputFood == "Seeds")
            {
                food = new Seeds(quantity);
            }

            return food;
        }

        private IAnimal CreateAnimal(IAnimal animal, string[] animalInfo)
        {
            string animalType = animalInfo[0];
            string animalName = animalInfo[1];
            double animalWeight = double.Parse(animalInfo[2]);

            if (animalType == "Hen" || animalType == "Owl")
            {
                double wingSize = double.Parse(animalInfo[3]);

                return animalType == "Hen"
                    ? animal = new Hen(animalName, animalWeight, wingSize)
                    : animal = new Owl(animalName, animalWeight, wingSize);

                //if (animalType == "Hen")
                //{
                //    animal = new Hen(animalName, animalWeight, wingSize);
                //}
                //else
                //{
                //    animal = new Owl(animalName, animalWeight, wingSize);
                //}
            }
            else if (animalType == "Mouse" || animalType == "Dog")
            {
                string livingRegion = animalInfo[3];

                return animalType == "Mouse"
                    ? animal = new Mouse(animalName, animalWeight, livingRegion)
                    : animal = new Dog(animalName, animalWeight, livingRegion);

                //if (animalType == "Mouse")
                //{
                //    animal = new Mouse(animalName, animalWeight, livingRegion);
                //}
                //else
                //{
                //    animal = new Dog(animalName, animalWeight, livingRegion);
                //}
            }
            else if (animalType == "Cat" || animalType == "Tiger")
            {
                string livingRegion = animalInfo[3];
                string breed = animalInfo[4];

                return animalType == "Cat"
                    ? animal = new Cat(animalName, animalWeight, livingRegion, breed)
                    : animal = new Tiger(animalName, animalWeight, livingRegion, breed);

                //if (animalType == "Cat")
                //{
                //    animal = new Cat(animalName, animalWeight, livingRegion, breed);
                //}
                //else
                //{
                //    animal = new Tiger(animalName, animalWeight, livingRegion, breed);
                //}
            }

            return animal;
        }
    }
}
