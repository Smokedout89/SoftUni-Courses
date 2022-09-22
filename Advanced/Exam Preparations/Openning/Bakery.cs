using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace BakeryOpenning
{
    public class Bakery
    {
        private Dictionary<string, Employee> employees;

        public Bakery(string name, int capacity)
        {
            employees = new Dictionary<string, Employee>();
            Name = name;
            Capacity = capacity;
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => employees.Count;

        public void Add(Employee employee)
        {
            if (employees.Count < Capacity)
            {
                employees.Add(employee.Name, employee);
            }
        }

        public bool Remove(string name)
        {
            if (employees.ContainsKey(name))
            {
                employees.Remove(name);
                return true;
            }

            return false;
        }

        public Employee GetOldestEmployee()
        {
            //int maxAge = int.MinValue;
            //Employee oldest = null;

            //foreach (var employee in employees)
            //{
            //    if (maxAge < employee.Value.Age)
            //    {
            //        oldest = employee.Value;
            //        maxAge = employee.Value.Age;
            //    }
            //}

            //return oldest;

            Employee oldest = employees.Values.OrderByDescending(a => a.Age).FirstOrDefault();

            return oldest;
        }

        public Employee GetEmployee(string name)
        {
            return employees.FirstOrDefault(n => n.Value.Name == name).Value;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Employees working at Bakery {Name}:");
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.Value.Name}");
            }

            return sb.ToString();
        }
    }
}
