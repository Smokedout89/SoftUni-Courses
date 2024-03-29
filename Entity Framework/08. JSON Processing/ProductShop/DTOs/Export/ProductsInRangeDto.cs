﻿namespace ProductShop.DTOs.Export;

using Newtonsoft.Json;

public class ProductsInRangeDto
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("price")]
    public decimal Price { get; set; }

    [JsonProperty("seller")]
    public string Seller { get; set; }
}