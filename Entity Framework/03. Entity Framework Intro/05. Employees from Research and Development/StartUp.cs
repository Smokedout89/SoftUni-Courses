namespace SoftUni
{
    using Data;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();

            string result = GetEmployeesFromResearchAndDevelopment(dbContext);

            Console.WriteLine(result);
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var rndEmployees = context
                .Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName);

            foreach (var rndEmployee in rndEmployees)
            {
                sb
                    .AppendLine($"{rndEmployee.FirstName} {rndEmployee.LastName} " +
                                $"from {rndEmployee.DepartmentName} - ${rndEmployee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}