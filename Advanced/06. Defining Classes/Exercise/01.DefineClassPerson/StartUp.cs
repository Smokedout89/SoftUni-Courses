using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var person = new Person();
            person.Name = "Gergi";
            person.Age = 13;

            var person1 = new Person("Goshko", 14);
        }
    }
}
