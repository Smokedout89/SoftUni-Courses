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
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];

                Tire[] tires = new Tire[4];
                int tireIndex = 0;

                for (int j = 5; j < input.Length; j += 2)
                {
                    double currTirePressure = double.Parse(input[j]);
                    int currTireAge = int.Parse(input[j + 1]);

                    Tire tire = new Tire(currTireAge, currTirePressure);
                    tires[tireIndex] = tire;
                    tireIndex++;
                }

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                cars.Add(new Car(model, engine, cargo, tires));
            }

            string command = Console.ReadLine();

            List<Car> carsToPrint = new List<Car>();

            if (command == "fragile")
            {
                carsToPrint = cars.Where(c => c.Cargo.CargoType == "fragile" 
                                              && c.Tires.Any(p => p.TirePressure < 1)).ToList();
            }
            else
            {
                carsToPrint = cars.Where(c => c.Cargo.CargoType == "flammable" && c.Engine.EnginePower > 250).ToList();
            }

            foreach (var car in carsToPrint)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
