namespace Trucks.DataProcessor.ImportDto;

using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;

using Common;
using Data.Models;

[XmlType(nameof(Truck))]
public class TruckDto
{
    [XmlElement(nameof(RegistrationNumber))]
    [MinLength(ValidationConstants.TruckRegNumberLength)]
    [MaxLength(ValidationConstants.TruckRegNumberLength)]
    [RegularExpression(ValidationConstants.TruckRegNumberRegex)]
    public string? RegistrationNumber { get; set; }

    [XmlElement(nameof(VinNumber))]
    [Required]
    [MinLength(ValidationConstants.TruckVinNumberLength)]
    [MaxLength(ValidationConstants.TruckVinNumberLength)]
    public string VinNumber { get; set; } = null!;

    [XmlElement(nameof(TankCapacity))]
    [Range(ValidationConstants.TruckTankMinCapacity, ValidationConstants.TruckTankMaxCapacity)]
    public int TankCapacity { get; set; }

    [XmlElement(nameof(CargoCapacity))]
    [Range(ValidationConstants.TruckCargoMinCapacity, ValidationConstants.TruckCargoMaxCapacity)]
    public int CargoCapacity { get; set; }

    [XmlElement(nameof(CategoryType))]
    [Range(ValidationConstants.TruckCategoryTypeMin, ValidationConstants.TruckCategoryTypeMax)]
    public int CategoryType { get; set; }

    [XmlElement(nameof(MakeType))]
    [Range(ValidationConstants.TruckMakeTypeMin, ValidationConstants.TruckMakeTypeMax)]
    public int MakeType { get; set; }
}