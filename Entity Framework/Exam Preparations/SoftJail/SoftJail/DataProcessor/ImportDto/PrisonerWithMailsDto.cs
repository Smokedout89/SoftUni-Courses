namespace SoftJail.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    using Newtonsoft.Json;

    using Common;

    public class PrisonerWithMailsDto
    {
        [Required]
        [JsonProperty(nameof(FullName))]
        [MinLength(ValidationConstants.PrisonerFullNameMinLength)]
        [MaxLength(ValidationConstants.PrisonerFullNameMaxLength)]
        public string FullName { get; set; }

        [Required]
        [JsonProperty(nameof(Nickname))]
        [RegularExpression(ValidationConstants.PrisonerNicknameRegex)]
        public string Nickname { get; set; }

        [JsonProperty(nameof(Age))]
        [Range(ValidationConstants.PrisonerAgeMinValue, ValidationConstants.PrisonerAgeMaxValue)]
        public int Age { get; set; }

        [Required]
        [JsonProperty(nameof(IncarcerationDate))]
        public string IncarcerationDate { get; set; }

        [JsonProperty(nameof(ReleaseDate))]
        public string ReleaseDate { get; set; }

        [JsonProperty(nameof(Bail))]
        [Range(typeof(decimal), ValidationConstants.NonNegativeDecimalMinValue, ValidationConstants.NonNegativeDecimalMaxValue)]
        public decimal? Bail { get; set; }

        [JsonProperty(nameof(CellId))]
        public int? CellId { get; set; }

        [JsonProperty(nameof(Mails))]
        public PrisonerMailDto[] Mails { get; set; }
    }
}