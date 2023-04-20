namespace Theatre.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Enums;
    using Common;

    public class Play
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.PlayTitleMaxLength)]
        public string Title { get; set; }

        [Column(TypeName = "time")]
        public TimeSpan Duration { get; set; }

        [Range(typeof(float), "0.00", "10.00")]
        public float Rating { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [MaxLength(ValidationConstants.PlayDescriptionMaxValue)]
        public string Description { get; set; }

        [Required]
        [MaxLength(ValidationConstants.PlayScreenwriterMaxValue)]
        public string Screenwriter { get; set; }

        public virtual ICollection<Cast> Casts { get; set; } = new HashSet<Cast>();

        public virtual ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }
}