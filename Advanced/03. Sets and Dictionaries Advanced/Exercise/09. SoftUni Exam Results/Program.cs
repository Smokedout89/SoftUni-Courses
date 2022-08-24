using System;
using System.Linq;
using System.Collections.Generic;

namespace _09.__SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command;
            Dictionary<string, int> submissions = new Dictionary<string, int>();
            Dictionary<string, int> students = new Dictionary<string, int>();

            while ((command = Console.ReadLine()) != "exam finished")
            {
                string[] cmdArgs = command.Split('-');
                string name = cmdArgs[0];
                string language = cmdArgs[1];

                if (language == "banned")
                {
                    students.Remove(name);
                    continue;
                }

                int points = int.Parse(cmdArgs[2]);

                if (!submissions.ContainsKey(language))
                {
                    submissions.Add(language, 0);
                }

                submissions[language]++;

                if (!students.ContainsKey(name))
                {
                    students.Add(name, points);
                }

                if (students[name] < points)
                {
                    students[name] = points;
                }
            }

            Dictionary<string, int> orderedStudents = students
                .OrderByDescending(p => p.Value)
                .ThenBy(n => n.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Results:");
            foreach (var student in orderedStudents)
            {
                Console.WriteLine($"{student.Key} | {student.Value}");
            }

            Dictionary<string, int> sortedBySubmissions = submissions
                .OrderByDescending(c => c.Value)
                .ThenBy(s => s.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Submissions:");
            foreach (var submission in sortedBySubmissions)
            {
                Console.WriteLine($"{submission.Key} - {submission.Value}");
            }
        }
    }
}
