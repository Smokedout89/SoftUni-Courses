using System;
using System.Collections.Generic;
using System.Linq;

namespace P09._Oldest_Family_Member
{
    class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; set; }

        public int Age { get; set; }
    }

    class Family
    {
        public List<Person> FamilyMembers { get; set; } = new List<Person>();

        public void AddMember(string name, int age)
        {
            this.FamilyMembers.Add(new Person(name, age));
        }

        public Person GetOldestMember()
        {
            return FamilyMembers.OrderByDescending(a => a.Age).First();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ');
                string name = cmdArgs[0];
                int age = int.Parse(cmdArgs[1]);
                family.AddMember(name, age);
            }

            Person oldest = family.GetOldestMember();

            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }

    }
}
