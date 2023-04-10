namespace CarDealer.DTOs.Import;

using System.ComponentModel.DataAnnotations;

public class SupplierDto
{
    [Required]
    public string Name { get; set; }

    public bool IsImporter { get; set; }
}