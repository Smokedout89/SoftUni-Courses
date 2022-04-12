using System;

namespace numbersSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < number; i++)
            {
                int numberS = int.Parse(Console.ReadLine());
                sum += numberS;
            }
            Console.WriteLine(sum);
        }
    }
}
