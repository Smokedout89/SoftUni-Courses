namespace ProductShop.DTOs.Import;

using System.ComponentModel.DataAnnotations;

public class CategoryDto
{
    [Required]
    [MinLength(3)]
    public string Name { get; set; }
}