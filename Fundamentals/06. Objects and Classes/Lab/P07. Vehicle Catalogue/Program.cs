using System;
using System.Collections.Generic;
using System.Linq;

namespace P7._Vehicle_Catalogue
{
    class Car
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public string HorsePower { get; set; }
    }

    class Truck
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public string Weight { get; set; }
    }

    class Catalog
    {
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();

            while (command != "end")
            {
                string[] cmdArgs = command.Split('/');

                string type = cmdArgs[0];
                string brand = cmdArgs[1];
                string model = cmdArgs[2];
                string weightOrPower = cmdArgs[3];

                if (type == "Car")
                {
                    Car car = new Car()
                    {
                        Brand = brand,
                        Model = model,
                        HorsePower = weightOrPower
                    };
                    cars.Add(car);
                }
                else
                {
                    Truck truck = new Truck()
                    {
                        Brand = brand,
                        Model = model,
                        Weight = weightOrPower
                    };
                    trucks.Add(truck);
                }

                command = Console.ReadLine();
            }

            List<Car> sortedCars = cars.OrderBy(brand => brand.Brand).ToList();
            List<Truck> sortedTrucks = trucks.OrderBy(brand => brand.Brand).ToList();

            if (cars.Count > 0)
            {
                Console.WriteLine("Cars:");
                foreach (Car car in sortedCars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                foreach (Truck truck in sortedTrucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }
}
