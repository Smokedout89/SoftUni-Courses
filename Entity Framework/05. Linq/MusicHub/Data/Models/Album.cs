namespace MusicHub.Data.Models;

using Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Album
{
    public Album()
    {
        this.Songs = new HashSet<Song>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(GlobalConstants.AlbumNameMaxLength)]
    public string Name { get; set; }

    public DateTime ReleaseDate { get; set; }

    [NotMapped]
    public decimal Price => 
        this.Songs.Count > 0 ? this.Songs.Sum(p => p.Price) : 0m;

    [ForeignKey(nameof(Producer))]
    public int? ProducerId { get; set; }
    public virtual Producer? Producer { get; set; }

    public virtual ICollection<Song> Songs { get; set; }
}