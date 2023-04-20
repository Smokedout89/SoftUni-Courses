namespace Theatre.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    using Common;

    public class ProjectionDto
    {
        [Required]
        [MinLength(ValidationConstants.TheatreNameMinLength)]
        [MaxLength(ValidationConstants.TheatreNameMaxLength)]
        public string Name { get; set; }

        [Range(typeof(sbyte), ValidationConstants.TheatreMinNumberOfHalls, ValidationConstants.TheatreMaxNumberOfHalls)]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [MinLength(ValidationConstants.TheatreDirectorMinLength)]
        [MaxLength(ValidationConstants.TheatreDirectorMaxLength)]
        public string Director { get; set; }

        public TicketDto[] Tickets { get; set; }
    }
}