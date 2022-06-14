using System;
using System.Collections.Generic;
using System.Linq;

namespace P06._Vehicle_Catalogue
{
    class Car
    {
        public Car(string model, string color, double horsePower)
        {
            this.Model = model;
            this.Color = color;
            this.HorsePower = horsePower;

            this.Cars = new List<Car>();
        }

        public List<Car> Cars { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public double HorsePower { get; set; }
    }

    class Truck
    {
        public Truck(string model, string color, double horsePower)
        {
            this.Model = model;
            this.Color = color;
            this.HorsePower = horsePower;

            this.Trucks = new List<Truck>();
        }

        public List<Truck> Trucks { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public double HorsePower { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] cmdArgs = command.Split();

                string type = cmdArgs[0];
                string model = cmdArgs[1];
                string color = cmdArgs[2];
                double horsePower = double.Parse(cmdArgs[3]);

                if (type == "car")
                {
                    cars.Add(new Car(model, color, horsePower));
                }

                if (type == "truck")
                {
                    trucks.Add(new Truck(model, color, horsePower));
                }

                command = Console.ReadLine();
            }

            string vehicleToPrint = Console.ReadLine();

            while (vehicleToPrint != "Close the Catalogue")
            {
                string modelNeeded = vehicleToPrint;

                if (CarOrTruck(cars, modelNeeded))
                {
                    foreach (Car car in cars)
                    {
                        if (car.Model == modelNeeded)
                        {
                            Console.WriteLine($"Type: Car");
                            Console.WriteLine($"Model: {car.Model}");
                            Console.WriteLine($"Color: {car.Color}");
                            Console.WriteLine($"Horsepower: {car.HorsePower}");
                            continue;
                        }
                    }

                }
                else
                {
                    foreach (Truck truck in trucks)
                    {
                        if (truck.Model == modelNeeded)
                        {
                            Console.WriteLine($"Type: Truck");
                            Console.WriteLine($"Model: {truck.Model}");
                            Console.WriteLine($"Color: {truck.Color}");
                            Console.WriteLine($"Horsepower: {truck.HorsePower}");
                            continue;
                        }
                    }
                }

                vehicleToPrint = Console.ReadLine();
            }

            CarAverage(cars);
            TruckAverage(trucks);
        }

        static bool CarOrTruck(List<Car> cars, string modelNeeded)
        {
            if (cars.Any(m => m.Model == modelNeeded))
            {
                return true;
            }

            return false;
        }

        static void CarAverage(List<Car> cars)
        {
            double totalCarHorsePower = 0;
            foreach (Car car in cars)
            {
                totalCarHorsePower += car.HorsePower;
            }

            double carsAverage = totalCarHorsePower / cars.Count;

            if (cars.Count > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {carsAverage:f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }
        }

        static void TruckAverage(List<Truck> trucks)
        {
            double totalTruckHorsePower = 0;

            foreach (Truck truck in trucks)
            {
                totalTruckHorsePower += truck.HorsePower;
            }

            double truckAverage = totalTruckHorsePower / trucks.Count;

            if (trucks.Count > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {truckAverage:f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }
        }
    }
}
