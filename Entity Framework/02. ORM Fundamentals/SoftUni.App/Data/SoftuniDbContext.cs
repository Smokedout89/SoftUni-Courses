namespace SoftUni.App.Data
{
    using MiniORM;
    using SoftUni.App.Data.Entities;

    public class SoftuniDbContext : DbContext
    {
        public SoftuniDbContext(string connectionString) 
            : base(connectionString)
        {
        }

        public DbSet<Employee> Employees { get; }
        public DbSet<Department> Departments { get; }
        public DbSet<Project> Projects { get; }
        public DbSet<EmployeeProject> EmployeesProjects { get; }
    }
}
