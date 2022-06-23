using System;
using System.Collections.Generic;

namespace P12._Company_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companyUsers = new Dictionary<string, List<string>>();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(" -> ");
                string company = cmdArgs[0];
                string userID = cmdArgs[1];

                if (!companyUsers.ContainsKey(company))
                {
                    companyUsers.Add(company, new List<string>());
                }

                if (companyUsers[company].Contains(userID))
                {
                    continue;
                }

                companyUsers[company].Add(userID);
            }

            foreach (var kvp in companyUsers)
            {
                Console.WriteLine(kvp.Key);
                foreach (var user in kvp.Value)
                {
                    Console.WriteLine($"-- {user}");
                }
            }
        }
    }
}
