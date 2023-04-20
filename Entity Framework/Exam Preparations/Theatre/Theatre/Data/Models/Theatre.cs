namespace Theatre.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common;

    public class Theatre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.TheatreNameMaxLength)]
        public string Name { get; set; }

        [Range(typeof(sbyte), ValidationConstants.TheatreMinNumberOfHalls, ValidationConstants.TheatreMaxNumberOfHalls)]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [MaxLength(ValidationConstants.TheatreDirectorMaxLength)]
        public string Director { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }
}