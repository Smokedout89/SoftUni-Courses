using System;

namespace _05._Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();    
            double sum = 0;
            while (text != "NoMoreMoney" )
            {
                double currentNum = double.Parse(text);
                if (currentNum < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }          
                sum += currentNum;
                Console.WriteLine($"Increase: {currentNum:f2}");
                text = Console.ReadLine();
            }
            Console.WriteLine($"Total: {sum:f2}");
        }
    }
}
