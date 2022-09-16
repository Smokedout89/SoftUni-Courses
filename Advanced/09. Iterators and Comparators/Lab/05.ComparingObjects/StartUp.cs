using System;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Person> persons = new List<Person>();

            while (input != "END")
            {
                string[] info = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];
                int age = int.Parse(info[1]);
                string town = info[2];

                Person currPerson = new Person(name, age, town);
                persons.Add(currPerson);

                input = Console.ReadLine();
            }

            int indexToCompare = int.Parse(Console.ReadLine());

            Person person = persons[indexToCompare - 1];

            int equals = 0;
            int different = 0;

            foreach (var currPerson in persons)
            {
                if (person.CompareTo(currPerson) == 0)
                {
                    equals++;
                }
                else
                {
                    different++;
                }
            }

            if (equals == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equals} {different} {persons.Count}");
            }
        }
    }
}
