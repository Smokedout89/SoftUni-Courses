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

            string result = GetAddressesByTown(dbContext);

            Console.WriteLine(result);
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var addresses = context
                .Addresses
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    EmloyeeCount = a.Employees.Count
                })
                .OrderByDescending(a => a.EmloyeeCount)
                .ThenBy(t => t.TownName)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToList();

            foreach (var address in addresses)
            {
                sb
                    .AppendLine($"{address.AddressText}, {address.TownName} - {address.EmloyeeCount} employees");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
