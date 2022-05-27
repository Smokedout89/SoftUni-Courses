using System;

namespace P01._Data_Types
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (input == "int")
            {
                int num = int.Parse(Console.ReadLine());
                DataType(num);
            }
            else if (input == "real")
            {
                double num = double.Parse(Console.ReadLine());
                DataType(num);
            }
            else
            {
                string word = Console.ReadLine();
                DataType(word);
            }
        }

        static void DataType(int num)
        {
            Console.WriteLine(num * 2);
        }

        static void DataType(double num)
        {
            double result = num * 1.5;
            Console.WriteLine($"{result:f2}");
        }

        static void DataType(string word)
        {
            Console.WriteLine($"${word}$");
        }
    }
    
}
