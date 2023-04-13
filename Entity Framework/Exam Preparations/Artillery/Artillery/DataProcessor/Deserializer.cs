namespace Artillery.DataProcessor
{
    using System.Text;
    using System.ComponentModel.DataAnnotations;

    using Data;
    using Common;
    using ImportDto;
    using Data.Models;
    using System.Linq;
    using AutoMapper;
    using Data.Models.Enums;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        private readonly XmlHelper xmlHelper;

        public Deserializer()
        {
            this.xmlHelper = new XmlHelper();
        }

        private static Mapper Mapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ArtilleryProfile>();
            });

            return new Mapper(config);
        }

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();
            ImportCountryDto[] dtos = xmlHelper.Deserialize<ImportCountryDto[]>(xmlString, "Countries");

            StringBuilder sb = new StringBuilder();
            ICollection<Country> validCountries = new HashSet<Country>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Country country = Mapper().Map<Country>(dto);
                validCountries.Add(country);

                sb.AppendLine(string.Format(SuccessfulImportCountry, country.CountryName, country.ArmySize));
            }

            context.Countries.AddRange(validCountries);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();
            ImportManufacturersDto[] dtos = xmlHelper.Deserialize<ImportManufacturersDto[]>(xmlString, "Manufacturers");

            StringBuilder sb = new StringBuilder();
            ICollection<Manufacturer> validManufacturers = new HashSet<Manufacturer>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Manufacturer manufacturer = Mapper().Map<Manufacturer>(dto);

                if (validManufacturers.Any(m => m.ManufacturerName == manufacturer.ManufacturerName))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                validManufacturers.Add(manufacturer);

                string[] foundedInfo = manufacturer.Founded.Split(", ");
                string country = foundedInfo[foundedInfo.Length - 1];
                string city = foundedInfo[foundedInfo.Length - 2];
                string townCountry = string.Concat(city, ", ", country);

                sb.AppendLine(string.Format(SuccessfulImportManufacturer, manufacturer.ManufacturerName, townCountry));
            }

            context.Manufacturers.AddRange(validManufacturers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();
            ImportShellDto[] dtos = xmlHelper.Deserialize<ImportShellDto[]>(xmlString, "Shells");

            StringBuilder sb = new StringBuilder();
            ICollection<Shell> validShells = new HashSet<Shell>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Shell shell = Mapper().Map<Shell>(dto);
                validShells.Add(shell);

                sb.AppendLine(string.Format(SuccessfulImportShell, shell.Caliber, shell.ShellWeight));
            }

            context.Shells.AddRange(validShells);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportGunDto[] dtos = JsonConvert.DeserializeObject<ImportGunDto[]>(jsonString)!;

            ICollection<Gun> validGuns = new HashSet<Gun>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isGunTypeValid = Enum.TryParse(typeof(GunType) ,dto.GunType, out var gunType);

                if (!isGunTypeValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Gun gun = new Gun
                {
                    ManufacturerId = dto.ManufacturerId,
                    GunWeight = dto.GunWeight,
                    BarrelLength = dto.BarrelLength,
                    NumberBuild = dto.NumberBuild,
                    Range = dto.Range,
                    GunType = (GunType)Enum.Parse(typeof(GunType), dto.GunType),
                    ShellId = dto.ShellId,
                };

                foreach (var dtoCountry in dto.Countries)
                {
                    gun.CountriesGuns.Add(new CountryGun
                    {
                        CountryId = dtoCountry.Id,
                        Gun = gun
                    });
                }

                validGuns.Add(gun);

                sb.AppendLine(string.Format(SuccessfulImportGun, gun.GunType, gun.GunWeight,
                    gun.BarrelLength));
            }

            context.Guns.AddRange(validGuns);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}