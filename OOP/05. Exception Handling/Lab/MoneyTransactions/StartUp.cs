using System;
using System.Collections.Generic;

namespace MoneyTransactions
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { ',', '-' });

            Dictionary<int, double> accounts = new Dictionary<int, double>();

            for (int i = 0; i < input.Length - 1; i += 2)
            {
                int accountNum = int.Parse(input[i]);
                double accountSum = double.Parse(input[i + 1]);

                accounts.Add(accountNum, accountSum);
            }

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split();
                string action = cmdArgs[0];
                int accountNum = int.Parse(cmdArgs[1]);
                double currentSum = double.Parse(cmdArgs[2]);

                try
                {
                    if (!accounts.ContainsKey(accountNum))
                    {
                        throw new ArgumentException("Invalid account!");
                    }

                    if (action == "Deposit")
                    {
                        accounts[accountNum] += currentSum;
                        Console.WriteLine($"Account {accountNum} has new balance: {accounts[accountNum]:f2}");
                    }
                    else if (action == "Withdraw")
                    {
                        if (accounts[accountNum] < currentSum)
                        {
                            throw new ArgumentException("Insufficient balance!");
                        }

                        accounts[accountNum] -= currentSum;
                        Console.WriteLine($"Account {accountNum} has new balance: {accounts[accountNum]:f2}");
                    }
                    else
                    {
                        throw new ArgumentException("Invalid command!");
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }
        }
    }
}
