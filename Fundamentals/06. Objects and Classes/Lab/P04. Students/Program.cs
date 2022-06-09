using System;
using System.Collections.Generic;

namespace P4._Students
{
    class Student
    {
        public Student(string firstName, string lastName, string age,string town)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Town = town;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Town { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            
            List<Student> students = new List<Student>();

            while (command != "end")
            {
                string[] cmdArgs = command.Split(' ');

                string firstName = cmdArgs[0];
                string lastName = cmdArgs[1];
                string age = cmdArgs[2];
                string town = cmdArgs[3];

                Student student = new Student(firstName, lastName, age, town);

                students.Add(student);

                command = Console.ReadLine();
            }

            string townNeeded = Console.ReadLine();

            List<Student> sortedStudents = students.FindAll(student => student.Town == townNeeded);

            foreach (var student in sortedStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }
    }
}
