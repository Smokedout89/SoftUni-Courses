namespace Artillery
{
    using AutoMapper;

    using Data.Models;
    using DataProcessor.ImportDto;

    public class ArtilleryProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public ArtilleryProfile()
        {
            CreateMap<ImportManufacturersDto, Manufacturer>();
            CreateMap<ImportShellDto, Shell>();
            CreateMap<ImportCountryDto, Country>();
        }
    }
}