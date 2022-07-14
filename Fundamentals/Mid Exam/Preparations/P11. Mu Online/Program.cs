using System;
using System.Linq;

namespace Problem_11_._Mu_Online
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries).ToArray();
            int health = 100;
            int bitcoins = 0;

            for (int i = 0; i < input.Length; i++)
            {
                string[] currentRoom = input[i].Split();

                string command = currentRoom[0];
                int value = int.Parse(currentRoom[1]);

                if (command == "potion")
                {
                    int currHealth = health;
                    int valueHealed = value;
                    health += value;

                    if (health > 100)
                    {
                        health = 100;
                        valueHealed = 100 - currHealth;
                    }

                    Console.WriteLine($"You healed for {valueHealed} hp.");
                    Console.WriteLine($"Current health: {health} hp.");
                }
                else if (command == "chest")
                {
                    bitcoins += value;
                    Console.WriteLine($"You found {value} bitcoins.");
                }
                else
                {
                    health -= value;

                    if (health > 0)
                    {
                        Console.WriteLine($"You slayed {command}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {command}.");
                        Console.WriteLine($"Best room: {i + 1}");
                        break;
                    }
                }
            }

            if (health > 0)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoins}");
                Console.WriteLine($"Health: {health}");
            }
        }
    }
}
