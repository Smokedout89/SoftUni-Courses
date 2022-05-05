using System;

namespace P01._Data_Type_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            while (input != "END")
            {
                if (int.TryParse(input, out int intType))
                {
                    Console.WriteLine($"{input} is integer type");
                }
                else if (float.TryParse(input, out float floatType))
                {
                    Console.WriteLine($"{input} is floating point type");
                }
                else if (char.TryParse(input, out char charType))
                {
                    Console.WriteLine($"{input} is character type");
                }
                else if (bool.TryParse(input, out bool boolType))
                {
                    Console.WriteLine($"{input} is boolean type");
                }
                else
                {
                    Console.WriteLine($"{input} is string type");
                }

                input = Console.ReadLine();

            }
        }
    }
}
