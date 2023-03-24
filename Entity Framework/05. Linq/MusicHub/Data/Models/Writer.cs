namespace MusicHub.Data.Models;

using Common;
using System.ComponentModel.DataAnnotations;

public class Writer
{
    public Writer()
    {
        this.Songs = new HashSet<Song>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(GlobalConstants.WriterNameMaxLength)]
    public string Name { get; set; }

    public string? Pseudonym { get; set; }

    public virtual ICollection<Song> Songs { get; set; }
}