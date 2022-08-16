using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> grades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] studentInfo = Console.ReadLine().Split();
                string name = studentInfo[0];
                decimal grade = decimal.Parse(studentInfo[1]);

                if (!grades.ContainsKey(name))
                {
                    grades[name] = new List<decimal>();
                }

                grades[name].Add(grade);
            }

            //foreach (var pair in grades)
            //{
            //    Console.WriteLine($"{pair.Key} -> {string.Join(' ', pair.Value)} (avg: {pair.Value.Average():f2})");
            //}

            foreach (var kvp in grades)
            {
                string name = kvp.Key;
                List<decimal> studentGrades = kvp.Value;
                decimal averageGrade = studentGrades.Average();

                Console.Write($"{name} -> ");

                foreach (var grade in studentGrades)
                {
                    Console.Write($"{grade:f2} ");
                }

                Console.WriteLine($"(avg: {averageGrade:f2})");
            }
        }
    }
}
