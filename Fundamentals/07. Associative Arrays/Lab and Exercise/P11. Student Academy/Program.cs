using System;
using System.Collections.Generic;
using System.Linq;

namespace P11._Student_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> studentGrades = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!studentGrades.ContainsKey(name))
                {
                    studentGrades.Add(name, new List<double>());
                }

                studentGrades[name].Add(grade);
            }

            foreach (var student in studentGrades.Where(student => student.Value.Average() >= 4.50))
            {
                Console.WriteLine($"{student.Key} -> {student.Value.Average():f2}");
            }
        }
    }
}
