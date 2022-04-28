using System;

namespace P03._Gaming_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());
            double initialBalance = balance;
            double moneySpent = 0;

            const double outfall = 39.99;
            const double cs = 15.99;
            const double zplinter = 19.99;
            const double honored = 59.99;
            const double roveratch = 29.99;
            const double origins = 39.99;

            string input = Console.ReadLine();

            while (input != "Game Time")
            {
                switch (input)
                {
                    case "OutFall 4":
                        if (balance >= outfall)
                        {
                            balance -= outfall;
                            moneySpent += outfall;
                            Console.WriteLine("Bought OutFall 4");
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "CS: OG":
                        if (balance >= cs)
                        {
                            balance -= cs;
                            moneySpent += cs;
                            Console.WriteLine("Bought CS: OG");
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "Zplinter Zell":
                        if (balance >= zplinter)
                        {
                            balance -= zplinter;
                            moneySpent += zplinter;
                            Console.WriteLine("Bought Zplinter Zell");
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "Honored 2":
                        if (balance >= honored)
                        {
                            balance -= honored;
                            moneySpent += honored;
                            Console.WriteLine("Bought Honored 2");
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "RoverWatch":
                        if (balance >= roveratch)
                        {
                            balance -= roveratch;
                            moneySpent += roveratch;
                            Console.WriteLine("Bought RoverWatch");
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "RoverWatch Origins Edition":
                        if (balance >= origins)
                        {
                            balance -= origins;
                            moneySpent += origins;
                            Console.WriteLine("Bought RoverWatch Origins Edition");
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;

                    default:
                        Console.WriteLine("Not Found");
                        break;
                }

                if (balance <= 0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }
                input = Console.ReadLine();
            }

            if (balance > 0)
            {
                Console.WriteLine($"Total spent: ${moneySpent:f2}. Remaining: ${initialBalance - moneySpent:f2}");
            }
        }
    }
}
