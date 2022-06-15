using System;
using System.Collections.Generic;
using System.Linq;

namespace P08._Company_Roster____More_Exercise
{
    class Employee
    {
        public Employee(string name, double salary, string department)
        {
            this.Name = name;
            this.Salary = salary;
            this.Department = department;
        }

        public string Department { get; set; }

        public string Name { get; set; }

        public double Salary { get; set; }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Employee> employees = new List<Employee>();
            List<string> departments = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();

                string name = cmdArgs[0];
                double salary = double.Parse(cmdArgs[1]);
                string department = cmdArgs[2];

                employees.Add(new Employee(name, salary, department));
                departments.Add(new string(department));

            }

            departments = departments.Distinct().ToList();

            string departHighestAvg = string.Empty;
            double highestAvgSalary = double.MinValue;

            foreach (string department in departments)
            {
                double avgSalary = employees.Where(s => s.Department == department).Select(s => s.Salary).Average();

                if (avgSalary > highestAvgSalary)
                {
                    highestAvgSalary = avgSalary;
                    departHighestAvg = department;
                }
            }

            Console.WriteLine($"Highest Average Salary: {departHighestAvg}");

            foreach (Employee employee in employees.Where(e => e.Department == departHighestAvg).OrderByDescending(e => e.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2}");
            }
        }
    }
}
