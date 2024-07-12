using System.ComponentModel.DataAnnotations;

namespace musicLibrayBack.Models
{
    public class Song
    {
        [Key]
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Length { get; set; }
        public Guid AlbumId { get; set; }
        public Album Album { get; set; } = null!;
    }
}