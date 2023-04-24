namespace Trucks.DataProcessor
{
    using System.Text;
    using System.ComponentModel.DataAnnotations;

    using Newtonsoft.Json;

    using Data;
    using Common;
    using ImportDto;
    using Data.Models;
    using Data.Models.Enums;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";
        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        private readonly XmlHelper xmlHelper;

        public Deserializer()
        {
            this.xmlHelper = new XmlHelper();
        }

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();
            DispatcherTrucksDto[] dtos = xmlHelper.Deserialize<DispatcherTrucksDto[]>(xmlString, "Despatchers");

            StringBuilder sb = new StringBuilder();
            ICollection<Despatcher> validDespatchers = new HashSet<Despatcher>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Despatcher despatcher = new Despatcher
                {
                    Name = dto.Name,
                    Position = dto.Position
                };

                foreach (var dtoTruck in dto.Trucks)
                {
                    if (!IsValid(dtoTruck))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Truck truck = new Truck
                    {
                        RegistrationNumber = dtoTruck.RegistrationNumber,
                        VinNumber = dtoTruck.VinNumber,
                        TankCapacity = dtoTruck.TankCapacity,
                        CargoCapacity = dtoTruck.CargoCapacity,
                        CategoryType = (CategoryType)dtoTruck.CategoryType,
                        MakeType = (MakeType)dtoTruck.MakeType
                    };

                    despatcher.Trucks.Add(truck);
                }

                validDespatchers.Add(despatcher);
                sb.AppendLine(string.Format(SuccessfullyImportedDespatcher, despatcher.Name, despatcher.Trucks.Count));
            }

            context.Despatchers.AddRange(validDespatchers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ClientDto[] dtos = JsonConvert.DeserializeObject<ClientDto[]>(jsonString)!;

            ICollection<Client> validClients = new HashSet<Client>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto) || dto.Type == "usual")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Client client = new Client
                {
                    Name = dto.Name,
                    Nationality = dto.Nationality,
                    Type = dto.Type
                };

                foreach (var dtoTruck in dto.Trucks.Distinct())
                {
                    if (!context.Trucks.Any(t => t.Id == dtoTruck))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Truck truck = context.Trucks.Find(dtoTruck)!;

                    ClientTruck clientTruck = new ClientTruck
                    {
                        Client = client,
                        TruckId = truck.Id
                    };

                    client.ClientsTrucks.Add(clientTruck);
                }

                validClients.Add(client);
                sb.AppendLine(string.Format(SuccessfullyImportedClient, client.Name, client.ClientsTrucks.Count));
            }

            context.Clients.AddRange(validClients);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}