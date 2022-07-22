using System;
using System.Collections.Generic;

namespace _13._Need_for_Speed_III
{
    class Car
    {
        public Car(int mileage, int fuel)
        {
            this.Mileage = mileage;
            this.Fuel = fuel;
        }

        public int Mileage { get; set; }

        public int Fuel { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            for (int i = 0; i < n; i++)
            {
                string[] details = Console.ReadLine().Split('|');
                string carModel = details[0];
                int mileage = int.Parse(details[1]);
                int fuel = int.Parse(details[2]);

                cars.Add(carModel, new Car(mileage, fuel));
            }

            string input = Console.ReadLine();

            while (input != "Stop")
            {
                string[] cmdArgs = input.Split(" : ");
                string command = cmdArgs[0];
                string car = cmdArgs[1];

                if (command == "Drive")
                {
                    int distance = int.Parse(cmdArgs[2]);
                    int fuel = int.Parse(cmdArgs[3]);
                    int carMaxMileage = 100000;

                    if (cars[car].Fuel >= fuel)
                    {
                        cars[car].Fuel -= fuel;
                        cars[car].Mileage += distance;
                        Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    }
                    else
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }

                    if (cars[car].Mileage > carMaxMileage)
                    {
                        Console.WriteLine($"Time to sell the {car}!");
                        cars.Remove(car);
                    }

                }
                else if (command == "Refuel")
                {
                    int fuel = int.Parse(cmdArgs[2]);
                    int carMaxFuel = 75;
                    cars[car].Fuel += fuel;

                    if (cars[car].Fuel > carMaxFuel)
                    {
                        fuel = Math.Abs(cars[car].Fuel - carMaxFuel - fuel);
                        cars[car].Fuel = carMaxFuel;
                    }

                    Console.WriteLine($"{car} refueled with {fuel} liters");
                }
                else if (command == "Revert")
                {
                    int kmToDecrease = int.Parse(cmdArgs[2]);
                    int minMileage = 10000;

                    cars[car].Mileage -= kmToDecrease;

                    if (cars[car].Mileage <= minMileage)
                    {
                        cars[car].Mileage = minMileage;
                        break;
                    }

                    Console.WriteLine($"{car} mileage decreased by {kmToDecrease} kilometers");
                }

                input = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value.Mileage} kms, Fuel in the tank: {car.Value.Fuel} lt.");
            }
        }
    }
}
