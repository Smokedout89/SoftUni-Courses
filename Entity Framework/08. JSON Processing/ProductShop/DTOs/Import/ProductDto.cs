namespace ProductShop.DTOs.Import;

using System.ComponentModel.DataAnnotations;

public class ProductDto
{
    [Required]
    [MinLength(3)]
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int SellerId { get; set; }
    public int? BuyerId { get; set; }
}