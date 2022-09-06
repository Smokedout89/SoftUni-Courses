using System;
using _01._Car;

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

            Console.WriteLine($"I drive a {myCar.Year} {myCar.Make} {myCar.Model}");
        }
    }
}
