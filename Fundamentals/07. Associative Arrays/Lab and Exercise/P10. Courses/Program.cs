using System;
using System.Collections.Generic;

namespace P10._Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command.Split(" : ");
                string currCours = cmdArgs[0];
                string currStudent = cmdArgs[1];

                if (!courses.ContainsKey(currCours))
                {
                    courses.Add(currCours, new List<string>());
                }

                courses[currCours].Add(currStudent);
            }

            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                
                foreach (var studentName in course.Value)
                {
                    Console.WriteLine($"-- {studentName}");
                }
            }
        }
    }
}
