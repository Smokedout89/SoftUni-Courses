using System;
using System.Linq;
using System.Collections.Generic;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command;

            List<Tire[]> tires = new List<Tire[]>();

            while ((command = Console.ReadLine()) != "No more tires")
            {
                string[] elements = command.Split();

                Tire[] tireData = new Tire[4]
                {
                    new Tire(int.Parse(elements[0]), double.Parse(elements[1])),
                    new Tire(int.Parse(elements[2]), double.Parse(elements[3])),
                    new Tire(int.Parse(elements[4]), double.Parse(elements[5])),
                    new Tire(int.Parse(elements[6]), double.Parse(elements[7])),
                };

                tires.Add(tireData);
            }

            List<Engine> engines = new List<Engine>();

            while ((command = Console.ReadLine()) != "Engines done")
            {
                string[] elements = command.Split();
                int horsePower = int.Parse(elements[0]);
                double cubicCapacity = double.Parse(elements[1]);

                engines.Add(new Engine(horsePower, cubicCapacity));
            }

            List<Car> cars = new List<Car>();

            while ((command = Console.ReadLine()) != "Show special")
            {
                string[] elements = command.Split();
                string make = elements[0];
                string model = elements[1];
                int year = int.Parse(elements[2]);
                double fuelQuantity = double.Parse(elements[3]);
                double fuelConsumption = double.Parse(elements[4]);
                Engine engine = engines[int.Parse(elements[5])];
                Tire[] tire = tires[int.Parse(elements[6])];

                cars.Add(new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tire));
            }

            var specialCars = cars.Where(x => x.Year >= 2017).Where(x => x.Engine.HorsePower > 330)
                .Where(x => x.Tires.Sum(y => y.Pressure) >= 9).Where(x => x.Tires.Sum(y => y.Pressure) <= 10);

            foreach (var specialCar in specialCars)
            {
                specialCar.Drive(20);
                Console.WriteLine(specialCar.WhoAmI());
            }
        }
    }
}
