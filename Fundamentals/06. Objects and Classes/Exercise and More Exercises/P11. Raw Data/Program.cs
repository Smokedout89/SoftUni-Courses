using System;
using System.Collections.Generic;
using System.Linq;

namespace P11._Raw_Data
{
    class Car
    {
        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType) 
        {
            this.Model = model;
            this.CarsEngine = new Engine(engineSpeed, enginePower);
            this.CarsCargo = new Cargo(cargoWeight, cargoType);
        }
        public Engine CarsEngine { get; set; }

        public Cargo CarsCargo { get; set; }

        public string Model { get; set; }
    }

    class Engine
    {
        public Engine(int speed, int power)
        {
            this.EngineSpeed = speed;
            this.EnginePower = power;
        }
        public int EngineSpeed { get; set; }

        public int EnginePower { get; set; }

    }

    class Cargo
    {
        public Cargo(int weight, string type)
        {
            this.CargoWeight = weight;
            this.CargoType = type;
        }
        public int CargoWeight { get; set; }

        public string CargoType { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];

                cars.Add(new Car(model, engineSpeed, enginePower, cargoWeight,cargoType));
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (Car car in cars.Where(c => c.CarsCargo.CargoType == "fragile" && c.CarsCargo.CargoWeight < 1000))
                {
                    Console.WriteLine(car.Model);
                }
            }

            if (command == "flamable")
            {
                foreach (Car car in cars.Where(c => c.CarsCargo.CargoType == "flamable" && c.CarsEngine.EnginePower > 250))
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
