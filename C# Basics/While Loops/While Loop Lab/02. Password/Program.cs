using System;

namespace _02._Password
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = Console.ReadLine();

            string inputPass = Console.ReadLine();

            while (inputPass != password)   
            {
                inputPass = Console.ReadLine();
            }

            Console.WriteLine($"Welcome {username}!");
        }
    }
}
