using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] nameAge = Console.ReadLine().Split();
                string name = nameAge[0];
                int age = int.Parse(nameAge[1]);

                Person person = new Person(name, age);
                people.Add(person);
            }

            var sortedPeople = people.Where(a => a.Age > 30).OrderBy(n => n.Name);

            foreach (var person in sortedPeople)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
