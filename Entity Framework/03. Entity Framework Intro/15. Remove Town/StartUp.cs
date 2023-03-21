namespace SoftUni
{
    using Data;
    using Models;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();

            string result = RemoveTown(dbContext);

            Console.WriteLine(result);
        }

        public static string RemoveTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            Town townToDelete = context
                .Towns
                .FirstOrDefault(t => t.Name == "Seattle");

            IQueryable<Address> addressesToDelete = context
                .Addresses
                .Where(a => a.TownId == townToDelete.TownId);

            IQueryable<Employee> empToReplaceAddress = context
                .Employees
                .Where(e => addressesToDelete
                    .Any(a => a.AddressId == e.AddressId));

            foreach (var employee in empToReplaceAddress)
            {
                employee.AddressId = null;
            }

            int deletedCount = addressesToDelete.Count();

            context.Addresses.RemoveRange(addressesToDelete);
            context.Towns.Remove(townToDelete);

            context.SaveChanges();

            sb.AppendLine($"{deletedCount} addresses in Seattle were deleted");

            return sb.ToString().TrimEnd();
        }
    }
}