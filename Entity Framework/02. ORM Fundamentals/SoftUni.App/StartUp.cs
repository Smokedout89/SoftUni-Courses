namespace SoftUni.App
{
    using System.Linq;
    using Data;
    using Data.Entities;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=SMOKEDOUT\SQLEXPRESS;Database=MiniORM;Integrated Security=True";

            SoftuniDbContext context = new SoftuniDbContext(connectionString);

            context.Employees.Add(new Employee
            {
                FirstName = "Peshkata",
                LastName = "Dimitrichev",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true
            });

            Employee employee = context.Employees.Last();
            employee.LastName = "Balabanov";

            context.SaveChanges();
        }
    }
}
