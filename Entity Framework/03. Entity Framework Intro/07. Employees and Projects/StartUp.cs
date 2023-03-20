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

            string result = GetEmployeesInPeriod(dbContext);

            Console.WriteLine(result);
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var empWithProj = context
                .Employees
                .Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001
                                                          && ep.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    AllProjects = e.EmployeesProjects
                        .Select(ep => new
                        {
                            ProjectName = ep.Project.Name,
                            StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt"),
                            EndDate = ep.Project.EndDate.HasValue
                            ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt")
                            : "not finished"
                        })
                        .ToList()
                })
                .ToList();

            foreach (var emp in empWithProj)
            {
                sb.AppendLine(
                    $"{emp.FirstName} {emp.LastName} " +
                    $"- Manager: {emp.ManagerFirstName} {emp.ManagerLastName}");

                foreach (var proj in emp.AllProjects)
                {
                    sb.AppendLine($"--{proj.ProjectName} - {proj.StartDate} - {proj.EndDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}