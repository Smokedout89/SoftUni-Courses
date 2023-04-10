namespace CarDealer.DTOs.Import;

using Newtonsoft.Json;

public class CarDto
{
    public string Make { get; set; } = null!;
    public string Model { get; set; } = null!;

    [JsonProperty("traveledDistance")]
    public long TravelledDistance { get; set; }
    public int[] PartsId { get; set; } = null!;
}