namespace Artillery.DataProcessor
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

        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shells = context
                .Shells
                .Where(s => s.ShellWeight > shellWeight)
                .Select(s => new
                {
                    ShellWeight = s.ShellWeight,
                    Caliber = s.Caliber,
                    Guns = s.Guns
                        .Where(g => ((int)g.GunType) == 3)
                        .Select(g => new
                        {
                            GunType = g.GunType.ToString(),
                            GunWeight = g.GunWeight,
                            BarrelLength = g.BarrelLength,
                            Range = g.Range > 3000 ? "Long-range" : "Regular range"
                        })
                        .OrderByDescending(gw => gw.GunWeight)
                        .ToArray()
                })
                .OrderBy(sw => sw.ShellWeight)
                .ToArray();

            string json = JsonConvert.SerializeObject(shells, Formatting.Indented);
            return json;
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            var guns = context.Guns
                .Where(g => g.Manufacturer.ManufacturerName == manufacturer)
                .Select(g => new ExportGunDto
                {
                    Manufacturer = g.Manufacturer.ManufacturerName,
                    GunType = g.GunType.ToString(),
                    GunWeight = g.GunWeight,
                    BarrelLength = g.BarrelLength,
                    Range = g.Range,
                    Countries = g.CountriesGuns.
                        Where(cg => cg.Country.ArmySize > 4500000)
                        .Select(c => new ExportCountryDto
                        {
                            Country = c.Country.CountryName,
                            ArmySize = c.Country.ArmySize
                        })
                        .OrderBy(a => a.ArmySize)
                        .ToArray()
                })
                .OrderBy(b => b.BarrelLength)
                .ToArray();
            
            XmlHelper xmlHelper = new XmlHelper();

            return xmlHelper.Serialize(guns, "Guns");
        }
    }
}
