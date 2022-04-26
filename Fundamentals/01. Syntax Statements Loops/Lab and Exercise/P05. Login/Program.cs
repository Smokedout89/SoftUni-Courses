using System;

namespace P05._Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = string.Empty;

            for (int i = username.Length - 1; i >= 0; i--)
            {
                password += username[i];
            }

            for (int count = 1; count <= 4; count++)
            {
                string userInput = Console.ReadLine();

                if (userInput == password)
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }

                if (count == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    break;
                }
                else if (userInput != password)
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }
            }
        }
    }
}
