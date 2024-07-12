using musicLibrayBack.Data;
using musicLibrayBack.Models;

namespace musicLibrayBack.Repositories;

public class ArtistRepository : Repository<Artist>
{
    private readonly MusicDbContext _context;

    public ArtistRepository(MusicDbContext context) : base(context)
    {
        _context = context;
    }
}