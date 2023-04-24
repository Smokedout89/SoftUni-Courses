namespace Trucks.DataProcessor.ImportDto;

using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;

using Common;
using Data.Models;

[XmlType(nameof(Despatcher))]
public class DispatcherTrucksDto
{
    [XmlElement(nameof(Name))]
    [Required]
    [MinLength(ValidationConstants.DispatcherNameMinLength)]
    [MaxLength(ValidationConstants.DispatcherNameMaxLength)]
    public string Name { get; set; } = null!;

    [XmlElement(nameof(Position))]
    [Required]
    public string Position { get; set; } = null!;

    [XmlArray(nameof(Trucks))] 
    public TruckDto[] Trucks { get; set; } = null!;
}