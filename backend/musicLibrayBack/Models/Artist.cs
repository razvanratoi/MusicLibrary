using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace musicLibrayBack.Models
{
    public class Artist
    {
        [Key]
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Image { get; set; }
        public ICollection<Album> Albums { get; set; } = new List<Album>();
    }
}