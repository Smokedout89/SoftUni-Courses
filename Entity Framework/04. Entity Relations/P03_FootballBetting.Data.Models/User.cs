namespace P02_FootballBetting.Data.Models
{
    using Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.Bets = new HashSet<Bet>();
        }

        [Key]   
        public int UserId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.UserUsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        [MaxLength(GlobalConstants.UserPasswordMaxLength)]
        public string Password { get; set; }

        [Required]
        [MaxLength(GlobalConstants.UserEmailMaxLength)]
        public string Email { get; set; }

        [Required]
        [MaxLength(GlobalConstants.UserNameMaxLength)]
        public string Name { get; set; }

        public decimal Balance { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
    }
}