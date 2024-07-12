using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace musicLibrayBack.Models
{
    public class Album
    {
        [Key]
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public Guid ArtistId { get; set; }
        public Artist Artist { get; set; } = null!;
        public ICollection<Song> Songs { get; set; } = new List<Song>();

    }
}