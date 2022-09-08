using System;
using System.Linq;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int inputEngines = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            for (int i = 0; i < inputEngines; i++)
            {
                string[] info = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string engineModel = info[0];
                int enginePower = int.Parse(info[1]);

                Engine engine = new Engine
                {
                    Model = engineModel,
                    Power = enginePower
                };

                if (info.Length == 4)
                {
                    int displacement = int.Parse(info[2]);
                    string efficiency = info[3];

                    engine.Displacement = displacement;
                    engine.Efficiency = efficiency;
                }

                if (info.Length == 3)
                {
                    bool isDisplacement = int.TryParse(info[2], out var disp);

                    if (isDisplacement)
                    {
                        engine.Displacement = disp;
                    }
                    else
                    {
                        engine.Efficiency = info[2];
                    }
                }

                engines.Add(engine);
            }

            int inputCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputCars; i++)
            {
                string[] info = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string carModel = info[0];
                string carEngine = info[1];

                Engine engineSearched = engines.FirstOrDefault(e => e.Model == carEngine);

                Car car = new Car
                {
                    Model = carModel,
                    Engine = engineSearched
                };

                if (info.Length == 4)
                {
                    int weight = int.Parse(info[2]);
                    string color = info[3];

                    car.Weight = weight;
                    car.Color = color;
                }

                if (info.Length == 3)
                {
                    bool isWeight = int.TryParse(info[2], out var weight);

                    if (isWeight)
                    {
                        car.Weight = weight;
                    }
                    else
                    {
                        car.Color = info[2];
                    }
                }

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");

                string displacementInfo = car.Engine.Displacement.HasValue
                    ? $"    Displacement: {car.Engine.Displacement}"
                    : $"    Displacement: n/a";

                Console.WriteLine(displacementInfo);

                string efficiencyInfo = car.Engine.Efficiency != null
                    ? $"    Efficiency: {car.Engine.Efficiency}"
                    : $"    Efficiency: n/a";

                Console.WriteLine(efficiencyInfo);

                string weightInfo = car.Weight.HasValue ? $"  Weight: {car.Weight}" : $"  Weight: n/a";

                Console.WriteLine(weightInfo);

                string colorInfo = car.Color != null ? $"  Color: {car.Color}" : $"  Color: n/a";

                Console.WriteLine(colorInfo);
            }
        }
    }
}
