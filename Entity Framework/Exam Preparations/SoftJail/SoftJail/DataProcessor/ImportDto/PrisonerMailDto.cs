namespace SoftJail.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using Common;
    using Newtonsoft.Json;

    public class PrisonerMailDto
    {
        [Required]
        [JsonProperty(nameof(Description))]
        public string Description { get; set; }

        [Required]
        [JsonProperty(nameof(Sender))]
        public string Sender { get; set; }

        [Required]
        [JsonProperty(nameof(Address))]
        [RegularExpression(ValidationConstants.MailAddressRegex)]
        public string Address { get; set; }
    }
}