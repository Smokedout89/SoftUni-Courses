namespace Theatre.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common;

    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Range(typeof(decimal), "1.00" ,"100.00")]
        public decimal Price { get; set; }

        [Range(typeof(sbyte), ValidationConstants.TheatreMinNumberOfHalls, ValidationConstants.TheatreMaxNumberOfHalls)]
        public sbyte RowNumber { get; set; }

        [ForeignKey(nameof(Play))]
        public int PlayId { get; set; }
        public virtual Play Play { get; set; }

        [ForeignKey(nameof(Theatre))]
        public int TheatreId { get; set; }
        public virtual Theatre Theatre { get; set; }
    }
}