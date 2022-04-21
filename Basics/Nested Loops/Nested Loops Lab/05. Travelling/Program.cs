using System;

namespace _05._Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();           

            while (destination != "End")
            {
                double moneyNeeded = double.Parse(Console.ReadLine());
                double moneySum = 0;

                while (moneySum < moneyNeeded)  
                {
                    moneySum += double.Parse(Console.ReadLine());
                }
                Console.WriteLine($"Going to {destination}!");

                destination = Console.ReadLine();
            }
        }
    }
}
