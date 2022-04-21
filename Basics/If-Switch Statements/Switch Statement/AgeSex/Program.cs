using System;

namespace AgeSex
{
    class Program
    {
        static void Main(string[] args)
        {
            double age = double.Parse(Console.ReadLine());
            string sex = Console.ReadLine();

            if (sex == "f")
            {
                if (age < 16)
                {
                    Console.WriteLine("Miss");
                }
                else Console.WriteLine("Ms.");
            }

            else

                if (age < 16)
            {
                Console.WriteLine("Master");
            }
            else Console.WriteLine("Mr.");
        }

    }
}
