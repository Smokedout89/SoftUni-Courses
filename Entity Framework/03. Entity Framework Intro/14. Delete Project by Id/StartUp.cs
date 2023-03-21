namespace SoftUni
{
    using Data;
    using Models;

    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();

            string result = DeleteProjectById(dbContext);

            Console.WriteLine(result);
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            Project projectToDelete = context
                .Projects
                .Find(2);

            List<EmployeeProject> empProject = context
                .EmployeesProjects
                .Where(ep => ep.ProjectId == projectToDelete.ProjectId)
                .ToList();

            context.EmployeesProjects.RemoveRange(empProject);
            context.Projects.Remove(projectToDelete);
            context.SaveChanges();

            List<string> tenProjects = context
                .Projects
                .Take(10)
                .Select(p => p.Name)
                .ToList();

            foreach (var project in tenProjects)
            {
                sb
                    .AppendLine(project);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
