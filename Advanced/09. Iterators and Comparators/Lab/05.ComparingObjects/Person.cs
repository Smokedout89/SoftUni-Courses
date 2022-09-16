using System;

namespace IteratorsAndComparators
{
    public class Person : IComparable<Person>
    {

        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Town { get; set; }

        public int CompareTo(Person other)
        {
            int names = this.Name.CompareTo(other.Name);

            if (names != 0)
            {
                return names;
            }

            int ages = this.Age.CompareTo(other.Age);

            if (ages != 0)
            {
                return ages;
            }

            int towns = this.Town.CompareTo(other.Town);

            if (towns != 0)
            {
                return towns;
            }

            return 0;
        }
    }
}
