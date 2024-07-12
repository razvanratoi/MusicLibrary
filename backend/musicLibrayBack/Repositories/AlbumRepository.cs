using Microsoft.EntityFrameworkCore;
using musicLibrayBack.Data;
using musicLibrayBack.Models;

namespace musicLibrayBack.Repositories;

public class AlbumRepository : Repository<Album>
{
    private readonly MusicDbContext _context;

    public AlbumRepository(MusicDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Album>> GetAlbumsByArtistIdAsync(Guid artistId)
    {
        return await _context.Set<Album>().Where(a => a.ArtistId == artistId).ToListAsync();
    }
}