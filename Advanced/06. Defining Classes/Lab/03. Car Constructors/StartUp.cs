using System;
using System.Collections.Generic;
using _03._Car_Constructors;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());

            Car firstCar = new Car();
            Car secondCar = new Car("Mercedes", "C-Class" , 2001);
            Car thirdCar = new Car("Mercedes", "C-Class" , 2001, 150, 10);

            List<Car> cars = new List<Car>();
            cars.Add(firstCar);
            cars.Add(secondCar);
            cars.Add(thirdCar);

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.WhoAmI()}");
            }
        }
    }
}
