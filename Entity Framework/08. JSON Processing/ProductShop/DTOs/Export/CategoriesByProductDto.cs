namespace ProductShop.DTOs.Export;

using Newtonsoft.Json;

public class CategoriesByProductDto
{
    [JsonProperty("category")]
    public string Category { get; set; }

    [JsonProperty("productsCount")]
    public int ProductsCount { get; set; }

    [JsonProperty("averagePrice")]
    public double AveragePrice { get; set; }

    [JsonProperty("totalRevenue")]
    public double TotalRevenue { get; set; }
}