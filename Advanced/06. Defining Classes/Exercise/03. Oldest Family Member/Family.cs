using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            People = new List<Person>();
        }

        public List<Person> People { get; set; }

        public void AddMember(Person member)
        {
            People.Add(member);
        }

        public Person GetOldestMember()
        {
            Person oldest = People.OrderByDescending(a => a.Age).FirstOrDefault();

            return oldest;
        }
    }
}
