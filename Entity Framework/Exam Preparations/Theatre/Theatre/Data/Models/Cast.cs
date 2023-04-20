namespace Theatre.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common;

    public class Cast
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.CastFullNameMaxLength)]
        public string FullName { get; set; }

        public bool IsMainCharacter  { get; set; }

        [Required]
        [RegularExpression(ValidationConstants.CastPhoneNumberRegex)]
        public string PhoneNumber { get; set; }

        [ForeignKey(nameof(Play))]
        public int PlayId { get; set; }
        public virtual Play Play { get; set; }
    }
}