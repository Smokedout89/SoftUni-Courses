namespace SoftJail
{
    using System.Linq;

    using AutoMapper;

    using Data.Models;
    using DataProcessor.ExportDto;
    using DataProcessor.ImportDto;

    public class SoftJailProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public SoftJailProfile()
        {
            CreateMap<DepartmentCellDto, Cell>();

            CreateMap<PrisonerMailDto, Mail>();

            CreateMap<Mail, PrisonerMailsDto>()
                .ForMember(d => d.Description, 
                    mo => mo.MapFrom(s => string.Join("", s.Description.Reverse())));

            CreateMap<Prisoner, PrisonerDto>()
                .ForMember(d => d.IncarcerationDate,
                    mo => mo.MapFrom(s => s.IncarcerationDate.ToString("yyyy-MM-dd")))
                .ForMember(d => d.Mails,
                    mo => mo.MapFrom(s => s.Mails));
        }
    }
}