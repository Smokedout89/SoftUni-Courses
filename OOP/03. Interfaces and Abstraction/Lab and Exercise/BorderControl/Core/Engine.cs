using System;
using System.Collections.Generic;
using BorderControl.Contracts;
using BorderControl.Models;

namespace BorderControl.Core
{
    public class Engine
    {

        private IList<IBirthdateable> birthdatebles = new List<IBirthdateable>();

        public Engine()
        {
            this.birthdatebles = new List<IBirthdateable>();
        }

        public void Run()
        {
            ReadData();
            ShowBirthdays();
        }

        private void ShowBirthdays()
        {
            string year = Console.ReadLine();

            foreach (var birthdateable in birthdatebles)
            {
                if (birthdateable.Birthdate.EndsWith(year))
                {
                    Console.WriteLine(birthdateable.Birthdate);
                }
            }
        }

        private void ReadData()
        {
            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split();
                string type = cmdArgs[0];
                string name = cmdArgs[1];

                IBirthdateable birthdateable = null;

                if (type == "Citizen")
                {
                    int age = int.Parse(cmdArgs[2]);
                    string id = cmdArgs[3];
                    string birthdate = cmdArgs[4];

                    birthdateable = new Citizen(name, age, id, birthdate);
                }
                else if (type == "Pet")
                {
                    string birthdate = cmdArgs[2];

                    birthdateable = new Pet(name, birthdate);
                }
                else
                {
                    continue;
                }

                birthdatebles.Add(birthdateable);
            }
        }
    }
}