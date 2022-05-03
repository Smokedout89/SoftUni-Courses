using System;

namespace P03._Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            if (capacity >= people)
            {
                Console.WriteLine(1);
            }
            else
            {
                if (people % capacity == 0)
                {
                    Console.WriteLine(people / capacity);
                }
                else
                {
                    Console.WriteLine((people / capacity) + 1);
                }
            }
        }
    }
}
