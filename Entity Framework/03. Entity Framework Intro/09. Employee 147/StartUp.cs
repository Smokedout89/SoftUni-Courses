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

            string result = GetEmployee147(dbContext);

            Console.WriteLine(result);
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employee147 = context
                .Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    AllProjects = e.EmployeesProjects
                        .Select(ep => ep.Project.Name)
                        .OrderBy(p => p)
                        .ToList()
                })
                .First();

            sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

            foreach (var proj in employee147.AllProjects)
            {
                sb.AppendLine(proj);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
