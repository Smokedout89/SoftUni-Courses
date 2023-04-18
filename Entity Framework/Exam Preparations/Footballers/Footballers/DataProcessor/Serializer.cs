namespace Footballers.DataProcessor
{
    using System.Text;
    using System.Globalization;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using Data;
    using ExportDto;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            var coaches = context
                .Coaches
                .Where(c => c.Footballers.Any())
                .Select(c => new ExportCoachDto
                {
                    FootballersCount = c.Footballers.Count.ToString(),
                    CoachName = c.Name,
                    Footballers = c.Footballers
                        .Select(f => new ExportFootballersDto
                        {
                            Name = f.Name,
                            Position = f.PositionType.ToString()
                        })
                        .OrderBy(n => n.Name)
                        .ToArray()
                })
                .OrderByDescending(c => c.Footballers.Length)
                .ThenBy(n => n.CoachName)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Coaches");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCoachDto[]), xmlRoot);
            
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            
            xmlSerializer.Serialize(writer, coaches, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teamsWithMostFootballers = context
                .Teams
                .Where(t => t.TeamsFootballers.Any(c => c.Footballer.ContractStartDate >= date))
                .Select(t => new
                {
                    t.Name,
                    Footballers = t.TeamsFootballers
                        .Where(f => f.Footballer.ContractStartDate >= date)
                        .OrderByDescending(f => f.Footballer.ContractEndDate)
                        .ThenBy(f => f.Footballer.Name)
                        .Select(f => new
                        {
                            FootballerName = f.Footballer.Name,
                            ContractStartDate = f.Footballer.ContractStartDate.ToString(
                                "d", CultureInfo.InvariantCulture),
                            ContractEndDate = f.Footballer.ContractEndDate.ToString(
                                "d", CultureInfo.InvariantCulture),
                            BestSkillType = f.Footballer.BestSkillType.ToString(),
                            PositionType = f.Footballer.PositionType.ToString()
                        })
                        .ToArray()
                })
                .OrderByDescending(fc => fc.Footballers.Length)
                .ThenBy(fc => fc.Name)
                .Take(5)
                .ToArray();

            string json = JsonConvert.SerializeObject(teamsWithMostFootballers, Formatting.Indented);
            return json;
        }
    }
}
