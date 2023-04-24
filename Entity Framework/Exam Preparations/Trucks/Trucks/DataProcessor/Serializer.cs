namespace Trucks.DataProcessor
{
    using Newtonsoft.Json;

    using Data;
    using Common;
    using ExportDto;

    public class Serializer
    {
        private readonly XmlHelper xmlHelper;

        public Serializer()
        {
            this.xmlHelper = new XmlHelper();
        }

        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            var dispatchers = context
                .Despatchers
                .Where(d => d.Trucks.Any())
                .ToArray()
                .Select(d => new ExportDispatcherDto
                {
                    TrucksCount = d.Trucks.Count,
                    DespatcherName = d.Name,
                    Trucks = d.Trucks
                        .Select(t => new ExportTruckDto
                        {
                            RegistrationNumber = t.RegistrationNumber!,
                            Make = t.MakeType.ToString()
                        })
                        .OrderBy(r => r.RegistrationNumber)
                        .ToArray()
                })
                .OrderByDescending(t => t.Trucks.Length)
                .ThenBy(n => n.DespatcherName)
                .ToArray();

            XmlHelper xmlHelper = new XmlHelper();
            
            return xmlHelper.Serialize(dispatchers, "Despatchers");
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var clients = context
                .Clients
                .Where(ct => ct.ClientsTrucks.Any(t => t.Truck.TankCapacity >= capacity))
                .ToArray()
                .Select(c => new
                {
                    Name = c.Name,
                    Trucks = c.ClientsTrucks
                        .Where(ct => ct.Truck.TankCapacity >= capacity)
                        .Select(t => new
                        {
                            TruckRegistrationNumber = t.Truck.RegistrationNumber,
                            VinNumber = t.Truck.VinNumber,
                            TankCapacity = t.Truck.TankCapacity,
                            CargoCapacity = t.Truck.CargoCapacity,
                            CategoryType = t.Truck.CategoryType.ToString(),
                            MakeType = t.Truck.MakeType.ToString()
                        })
                        .OrderBy(m => m.MakeType)
                        .ThenByDescending(cc => cc.CargoCapacity)
                        .ToArray()
                })
                .OrderByDescending(ct => ct.Trucks.Count())
                .ThenBy(n => n.Name)
                .Take(10)
                .ToArray();

            string json = JsonConvert.SerializeObject(clients, Formatting.Indented);
            return json;
        }
    }
}
