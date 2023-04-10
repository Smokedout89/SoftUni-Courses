namespace CarDealer.DTOs.Export;

using Newtonsoft.Json;

public class ExCarDto
{
    public string Make { get; set; } = null!;
    public string Model { get; set; } = null!;

    [JsonProperty("TraveledDistance")]
    public long TraveledDistance { get; set; }
}