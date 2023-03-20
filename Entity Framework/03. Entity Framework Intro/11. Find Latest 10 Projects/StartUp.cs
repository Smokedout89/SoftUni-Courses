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

            string result = GetLatestProjects(dbContext);

            Console.WriteLine(result);
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var latest10 = context
                .Projects
                .OrderByDescending(p => p.StartDate)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt")
                })
                .Take(10)
                .OrderBy(p => p.Name)
                .ToList();

            foreach (var proj in latest10)
            {
                sb
                    .AppendLine(proj.Name)
                    .AppendLine(proj.Description)
                    .AppendLine(proj.StartDate);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
