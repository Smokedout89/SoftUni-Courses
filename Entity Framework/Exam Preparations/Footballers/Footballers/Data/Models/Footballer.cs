namespace Footballers.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Enums;
using Common;

public class Footballer
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ValidationConstants.FootballerNameMaxLength)]
    public string Name { get; set; } = null!;

    public DateTime ContractStartDate { get; set; }

    public DateTime ContractEndDate { get; set; }

    public PositionType PositionType { get; set; }

    public BestSkillType BestSkillType { get; set; }

    [ForeignKey(nameof(Coach))]
    public int CoachId { get; set; }

    public Coach Coach { get; set; } = null!;

    public virtual ICollection<TeamFootballer> TeamsFootballers { get; set; } = new List<TeamFootballer>();
}