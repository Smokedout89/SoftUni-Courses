namespace Theatre.DataProcessor.ImportDto
{
    using System.Xml.Serialization;
    using System.ComponentModel.DataAnnotations;

    using Common;

    [XmlType("Play")]
    public class PlayDto
    {
        [Required]
        [XmlElement("Title")]
        [MinLength(ValidationConstants.PlayTitleMinLength)]
        [MaxLength(ValidationConstants.PlayTitleMaxLength)]
        public string Title { get; set; }

        [XmlElement("Duration")]
        [Required(AllowEmptyStrings = false)]
        public string Duration { get; set; }

        [Required]
        [Range(0.00, 10.00)]
        [XmlElement("Rating")]
        public float Rating { get; set; }

        [XmlElement("Genre")]
        [Required(AllowEmptyStrings = false)]
        public string Genre { get; set; }

        [XmlElement("Description")]
        [Required(AllowEmptyStrings = false)]
        [MaxLength(ValidationConstants.PlayDescriptionMaxValue)]
        public string Description { get; set; }

        [Required]
        [XmlElement("Screenwriter")]
        [MinLength(ValidationConstants.PlayScreenwriterMinValue)]
        [MaxLength(ValidationConstants.PlayScreenwriterMaxValue)]
        public string Screenwriter { get; set; }
    }
}