namespace ProductShop.DTOs.Export;

using Newtonsoft.Json;

public class UsersWithSoldProductsDto
{
    [JsonProperty("firstName")]
    public string FirstName { get; set; }

    [JsonProperty("lastName")]
    public string LastName { get; set; }

    [JsonProperty("soldProducts")]
    public List<UserSoldProductsDto> SoldProducts { get; set; }
}