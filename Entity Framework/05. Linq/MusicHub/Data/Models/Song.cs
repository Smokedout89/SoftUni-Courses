namespace MusicHub.Data.Models;

using Enums;
using Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Song
{
    public Song()
    {
        this.SongPerformers = new HashSet<SongPerformer>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(GlobalConstants.SongNameMaxLength)]
    public string Name { get; set; }

    public TimeSpan Duration { get; set; }
    public DateTime CreatedOn { get; set; }
    public Genre Genre { get; set; }

    [ForeignKey(nameof(Album))]
    public int? AlbumId { get; set; }
    public virtual Album? Album { get; set; }

    [ForeignKey(nameof(Writer))]
    public int WriterId { get; set; }
    public virtual Writer Writer { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<SongPerformer> SongPerformers { get; set; }  
}