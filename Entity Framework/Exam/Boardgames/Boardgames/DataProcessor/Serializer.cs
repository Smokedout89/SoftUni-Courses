namespace Boardgames.DataProcessor
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

        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            var creators = context.Creators
                .Where(c => c.Boardgames.Count >= 1)
                .ToArray()
                .Select(c => new ExportCreatorDto
                {
                    BoardgamesCount = c.Boardgames.Count,
                    CreatorName = string.Concat(c.FirstName, ' ', c.LastName),
                    Boardgames = c.Boardgames
                        .Select(b => new ExportBoardgameDto
                        {
                            BoardgameName = b.Name,
                            BoardgameYearPublished = b.YearPublished
                        })
                        .OrderBy(n => n.BoardgameName)
                        .ToArray()
                })
                .OrderByDescending(bc => bc.BoardgamesCount)
                .ThenBy(n => n.CreatorName)
                .ToArray();

            XmlHelper xmlHelper = new XmlHelper();

            return xmlHelper.Serialize(creators, "Creators");
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var sellers = context.Sellers
                .Where(b => b.BoardgamesSellers.Any
                    (bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating))
                .Select(s => new
                {
                    Name = s.Name,
                    Website = s.Website,
                    Boardgames = s.BoardgamesSellers
                        .Where(b => b.Boardgame.YearPublished >= year && 
                                        b.Boardgame.Rating <= rating)
                        .Select(b => new
                        {
                            Name = b.Boardgame.Name,
                            Rating = b.Boardgame.Rating,
                            Mechanics = b.Boardgame.Mechanics,
                            Category = b.Boardgame.CategoryType.ToString()
                        })
                        .OrderByDescending(r => r.Rating)
                        .ThenBy(n => n.Name)
                        .ToArray()
                })
                .OrderByDescending(b => b.Boardgames.Length)
                .ThenBy(n => n.Name)
                .Take(5)
                .ToArray();

            string json = JsonConvert.SerializeObject(sellers, Formatting.Indented);
            return json;
        }
    }
}