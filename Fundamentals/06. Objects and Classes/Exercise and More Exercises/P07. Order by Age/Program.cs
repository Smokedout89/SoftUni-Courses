using System;
using System.Collections.Generic;
using System.Linq;

namespace P07._Order_by_Age
{
    class Person
    {
        public Person(string name, string id, int age)
        {
            this.Name = name;
            this.Id = id;
            this.Age = age;

            this.Persons = new List<Person>();
        }
        public List<Person> Persons { get; set; }

        public string Name { get; set; }

        public string Id { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} with ID: {Id} is {Age} years old.";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Person> persons = new List<Person>();

            while (command != "End")
            {
                string[] cmdArgs = command.Split();

                string name = cmdArgs[0];
                string id = cmdArgs[1];
                int age = int.Parse(cmdArgs[2]);

                foreach (Person person in persons)
                {
                    if (persons.Any(x => x.Id == id))
                    {
                        person.Name = name;
                        person.Age = age;
                        continue;
                    }
                }

                persons.Add(new Person(name, id, age));

                command = Console.ReadLine();
            }

            persons = persons.OrderBy(a => a.Age).ToList();

            foreach (Person person in persons)
            {
                Console.WriteLine(person);
            }
        }
    }
}
