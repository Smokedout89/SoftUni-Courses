namespace Artillery.Data.Models;

using System.ComponentModel.DataAnnotations;

using Common;

public class Shell
{
    [Key]
    public int Id { get; set; }

    public double ShellWeight { get; set; }

    [Required]
    [MaxLength(ValidationConstants.ShellCaliberMaxLength)]
    public string Caliber { get; set; } = null!;

    public virtual ICollection<Gun> Guns { get; set; } = new HashSet<Gun>();
}