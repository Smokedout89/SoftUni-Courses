namespace CarDealer;

using System.Globalization;

using Models;
using DTOs.Import;

using AutoMapper;
using DTOs.Export;

public class CarDealerProfile : Profile
{
    public CarDealerProfile()
    {
        // Import
        CreateMap<SupplierDto, Supplier>();
        CreateMap<PartDto, Part>();
        CreateMap<CarDto, Car>();
        CreateMap<CustomerDto, Customer>();

        // Export
        CreateMap<Customer, OrderedCustomersDto>()
            .ForMember(d => d.BirthDate,
                mo => mo.MapFrom(s => 
                    s.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)));

        CreateMap<Car, ToyotaCarsDto>();

        CreateMap<Supplier, LocalSupplierDto>()
            .ForMember(d => d.PartsCount, 
                mo => mo.MapFrom(s => s.Parts.Count));

        CreateMap<Car, ExCarDto>();
        CreateMap<Part, ExPartDto>();
    }
}