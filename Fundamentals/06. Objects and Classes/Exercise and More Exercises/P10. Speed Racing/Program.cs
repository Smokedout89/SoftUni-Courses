using System;
using System.Collections.Generic;

namespace P10._Speed_Racing
{
    class Car
    {
        public Car(string model, double fuelAmount, double fuelPerKm)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelPerKM = fuelPerKm;

            this.Cars = new List<Car>();
        }
        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelPerKM { get; set; }

        public double DistanceTravelled { get; set; }

        public List<Car> Cars { get; set; }

        public void Drive(int distanceToTravel)
        {
            double fuelNeeded = distanceToTravel * this.FuelPerKM;

            if (this.FuelAmount >= fuelNeeded)
            {
                this.FuelAmount -= fuelNeeded;
                this.DistanceTravelled += distanceToTravel;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();
                string model = cmdArgs[0];
                double fuelAmount = double.Parse(cmdArgs[1]);
                double fuelPerKM = double.Parse(cmdArgs[2]);

                cars.Add(new Car(model, fuelAmount, fuelPerKM));
            }

            string command;
            int kmToTravel = 0;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split();
                string model = cmdArgs[1];
                kmToTravel = int.Parse(cmdArgs[2]);

                cars.Find(m => m.Model == model).Drive(kmToTravel);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.DistanceTravelled}");
            }
        }
    }
}
