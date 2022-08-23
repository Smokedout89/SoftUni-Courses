using System;
using System.Linq;
using System.Collections.Generic;

namespace _08._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string examsInfo;
            Dictionary<string, string> examPass = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> studentExams = new Dictionary<string, Dictionary<string, int>>();

            while ((examsInfo = Console.ReadLine()) != "end of contests")
            {
                string[] examDetails = examsInfo.Split(':');
                examPass.Add(examDetails[0], examDetails[1]);
            }

            string examResults;

            while ((examResults = Console.ReadLine()) != "end of submissions")
            {
                string[] cmdArgs = examResults.Split("=>");
                string examName = cmdArgs[0];
                string examPassword = cmdArgs[1];
                string student = cmdArgs[2];
                int points = int.Parse(cmdArgs[3]);

                if (examPass.ContainsKey(examName) && examPass[examName] == examPassword)
                {
                    if (!studentExams.ContainsKey(student))
                    {
                        studentExams.Add(student, new Dictionary<string, int>());
                    }

                    if (studentExams[student].ContainsKey(examName))
                    {
                        if (studentExams[student][examName] < points)
                        {
                            studentExams[student][examName] = points;
                            continue;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    studentExams[student].Add(examName, points);
                }
            }

            string bestStudent = string.Empty;
            int maxScore = 0;

            foreach (var student in studentExams)
            {
                if (student.Value.Values.Sum() > maxScore)
                {
                    maxScore = student.Value.Values.Sum();
                    bestStudent = student.Key;
                }
            }

            Console.WriteLine($"Best candidate is {bestStudent} with total {maxScore} points.");
            Console.WriteLine("Ranking:");

            foreach (var student in studentExams.OrderBy(x => x.Key))
            {
                Console.WriteLine(student.Key);

                foreach (var exam in student.Value.OrderByDescending(p => p.Value))
                {
                    Console.WriteLine($"#  {exam.Key} -> {exam.Value}");
                }
            }
        }
    }
}
