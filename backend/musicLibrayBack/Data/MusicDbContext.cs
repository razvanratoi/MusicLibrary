using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using musicLibrayBack.Models;

namespace musicLibrayBack.Data;

public class MusicDbContext : DbContext
{
    public MusicDbContext(DbContextOptions context) : base(context) { }
    public DbSet<Artist> Artist { get; set; }
    public DbSet<Album> Album { get; set; }
    public DbSet<Song> Song { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artist>()
            .HasMany(a => a.Albums)
            .WithOne(a => a.Artist)
            .HasForeignKey(a => a.ArtistId);

        modelBuilder.Entity<Album>()
            .HasMany(a => a.Songs)
            .WithOne(s => s.Album)
            .HasForeignKey(s => s.AlbumId);

        modelBuilder.Entity<Song>();

        base.OnModelCreating(modelBuilder);
    }
}