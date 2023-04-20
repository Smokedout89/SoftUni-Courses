namespace Theatre.DataProcessor
{
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using Data;
    using ExportDto;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theaters = context
                .Theatres
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20)
                .ToList()
                .Select(t => new
                {
                    t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets
                        .Where(ticket => ticket.RowNumber <= 5)
                        .Sum(p => p.Price),
                    Tickets = t.Tickets
                        .Where(ticket => ticket.RowNumber <= 5)
                        .Select(tt => new
                        {
                            tt.Price,
                            tt.RowNumber
                        })
                        .OrderByDescending(p => p.Price)
                        .ToList()
                })
                .OrderByDescending(h => h.Halls)
                .ThenBy(n => n.Name)
                .ToList();

            string json = JsonConvert.SerializeObject(theaters, Formatting.Indented);
            return json;
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var plays = context
                .Plays
                .Where(p => p.Rating <= rating)
                .OrderBy(p => p.Title)
                .ThenByDescending(g => g.Genre)
                .Select(p => new PlayExportDto
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c"),
                    Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts
                        .Where(a => a.IsMainCharacter)
                        .Select(a => new ActorExportDto
                        {
                            FullName = a.FullName,
                            MainCharacter = $"Plays main character in '{a.Play.Title}'."
                        })
                        .OrderByDescending(n => n.FullName)
                        .ToArray()
                })
                .ToArray();
                
           StringBuilder sb = new StringBuilder();
           using StringWriter writer = new StringWriter(sb);

           XmlRootAttribute xmlRoot = new XmlRootAttribute("Plays");
           XmlSerializer xmlSerializer = new XmlSerializer(typeof(PlayExportDto[]), xmlRoot);

           XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
           namespaces.Add(string.Empty, string.Empty);

           xmlSerializer.Serialize(writer, plays, namespaces);

           return sb.ToString().TrimEnd();
        }
    }
}
