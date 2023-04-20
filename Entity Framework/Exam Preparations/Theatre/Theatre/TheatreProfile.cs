namespace Theatre
{
    using AutoMapper;

    using Data.Models;
    using DataProcessor.ExportDto;
    using DataProcessor.ImportDto;

    class TheatreProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public TheatreProfile()
        {
            CreateMap<CastDto, Cast>();
            CreateMap<TicketDto, Ticket>();

            //CreateMap<Cast, ActorExportDto>()
            //    .ForMember(d => d.MainCharacter,
            //        mo => mo.MapFrom(s => $"Plays main character in '{s.Play.Title}'."));

            //CreateMap<Play, PlayExportDto>()
            //    .ForMember(d => d.Genre, mo => mo.MapFrom(s => s.Genre.ToString()))
            //    .ForMember(d => d.Rating,
            //        mo => mo.MapFrom(s => s.Rating == 0 ? "Premier" : s.Rating.ToString()))
            //    .ForMember(d => d.Duration, mo => mo.MapFrom(s => s.Duration.ToString("c")));
        }
    }
}
