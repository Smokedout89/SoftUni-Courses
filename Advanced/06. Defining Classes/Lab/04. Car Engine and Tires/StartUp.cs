using System;
using CarManufacturer;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var tires = new Tire[4]
            {
                new Tire(1, 2.2),
                new Tire(1, 2.3),
                new Tire(2, 2.3),
                new Tire(2, 2.2)
            };

            var engine = new Engine(170, 2700);

            var car = new Car("Mercedes", "C-Class", 2001, 200, 10, engine, tires);

            Console.WriteLine($"{car.Engine.HorsePower} , {car.Engine.CubicCapacity}");

            foreach (var tire in tires)
            {
                Console.WriteLine($"{tire.Pressure}");
            }
        }
    }
}
