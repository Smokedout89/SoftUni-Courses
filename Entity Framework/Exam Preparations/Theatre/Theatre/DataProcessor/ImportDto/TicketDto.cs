namespace Theatre.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    using Common;

    public class TicketDto
    {
        [Required]
        [Range(typeof(decimal), "1.00", "100.00")]
        public string Price { get; set; }

        [Range(typeof(sbyte), ValidationConstants.TicketRowNumberMinLength, ValidationConstants.TicketRowNumberMaxLength)]
        public sbyte RowNumber { get; set; }

        public int PlayId { get; set; }
    }
}