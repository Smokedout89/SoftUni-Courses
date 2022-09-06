using System;
using _02._Car_Extension;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car myCar = new Car();

            myCar.Make = "Mercedes";
            myCar.Model = "C-Class";
            myCar.Year = 2001;
            myCar.FuelQuantity = 150;
            myCar.FuelConsumption = 8;

            myCar.Drive(15);

           // Console.WriteLine($"I drive a {myCar.Year} {myCar.Make} {myCar.Model}");
            Console.WriteLine(myCar.WhoAmI());
        }
    }
}
