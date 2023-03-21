namespace SoftUni
{
    using Data;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();

            string result = IncreaseSalaries(dbContext);

            Console.WriteLine(result);
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var empToIncreaseSalary = context
                .Employees
                .Where(d => d.Department.Name == "Engineering"
                            || d.Department.Name == "Tool Design"
                            || d.Department.Name == "Marketing"
                            || d.Department.Name == "Information Services")
                .ToList();

            foreach (var employee in empToIncreaseSalary)
            {
                employee.Salary *= 1.12m;
            }

            context.SaveChanges();

            var empWithIncreasedSalary = context
                .Employees
                .Where(d => d.Department.Name == "Engineering" 
                            || d.Department.Name == "Tool Design"
                            || d.Department.Name == "Marketing"
                            || d.Department.Name == "Information Services")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            foreach (var emp in empWithIncreasedSalary)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} (${emp.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
