using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Filter_by_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int> people = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine().Split(", ");
                string currentName = personInfo[0];
                int currentAge = int.Parse(personInfo[1]);

                people.Add(currentName, currentAge);
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Func<int, bool> checker = AgeChecker(condition, age);

            string format = Console.ReadLine();

            Action<KeyValuePair<string, int>> print = PrintResult(format);

            InvokePrint(people, checker, print);
        }

        private static void InvokePrint(Dictionary<string, int> people, Func<int, bool> checker,
            Action<KeyValuePair<string, int>> print)
        {
            foreach (var person in people)
            {
                if (checker(person.Value))
                {
                    print(person);
                }
            }
        }

        public static Func<int, bool> AgeChecker(string condition, int age)
        {
            switch (condition)
            {
                case "younger": return a => a < age;
                case "older": return a => a >= age;
                default: return null;
            }
        }

        public static Action<KeyValuePair<string, int>> PrintResult(string format)
        {
            switch (format)
            {
                case "name": return name => Console.WriteLine($"{name.Key}");
                case "age": return age => Console.WriteLine($"{age.Value}");
                case "name age": return kvp => Console.WriteLine($"{kvp.Key} - {kvp.Value}");
                default: return null;
            }
        }

    }
}
