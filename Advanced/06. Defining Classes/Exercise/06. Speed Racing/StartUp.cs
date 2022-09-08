using System;
using System.Linq;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumption = double.Parse(input[2]);

                cars.Add(new Car(model, fuelAmount, fuelConsumption));
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] input = command.Split();
                string model = input[1];
                double kmTravelled = double.Parse(input[2]);

                var carToDrive = cars.First(car => car.Model == model);
                carToDrive.Drive(kmTravelled);

                command = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
