namespace Theatre.DataProcessor.ImportDto
{
    using System.Xml.Serialization;
    using System.ComponentModel.DataAnnotations;

    using Common;

    [XmlType("Cast")]
    public class CastDto
    {
        [Required]
        [MinLength(ValidationConstants.CastFullNameMinLength)]
        [MaxLength(ValidationConstants.CastFullNameMaxLength)]
        public string FullName { get; set; }

        public bool IsMainCharacter { get; set; }

        [Required]
        [RegularExpression(ValidationConstants.CastPhoneNumberRegex)]
        public string PhoneNumber { get; set; }

        public int PlayId { get; set; }
    }
}