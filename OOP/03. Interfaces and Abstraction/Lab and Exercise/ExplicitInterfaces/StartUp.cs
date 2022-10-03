using System;
using ExplicitInterfaces.Contracts;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split();
                string name = cmdArgs[0];
                string country = cmdArgs[1];
                int age = int.Parse(cmdArgs[2]);

                IPerson person = new Citizen(name, age, country);
                IResident resident = new Citizen(name, age, country);

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
