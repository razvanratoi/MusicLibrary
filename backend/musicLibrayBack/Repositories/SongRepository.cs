using Microsoft.EntityFrameworkCore;
using musicLibrayBack.Data;
using musicLibrayBack.Models;

namespace musicLibrayBack.Repositories;

public class SongRepository : Repository<Song>
{
    private readonly MusicDbContext _context;

    public SongRepository(MusicDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Song>> GetSongsByAlbumIdAsync(Guid albumId)
    {
        return await _context.Set<Song>().Where(s => s.AlbumId == albumId).ToListAsync();
    }
}