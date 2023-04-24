namespace Trucks.Data.Models;

using System.ComponentModel.DataAnnotations;

using Common;

public class Despatcher
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ValidationConstants.DispatcherNameMaxLength)]
    public string Name { get; set; } = null!;

    public string? Position { get; set; }

    public virtual ICollection<Truck> Trucks { get; set; } = new HashSet<Truck>();
}