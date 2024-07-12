using System;
using musicLibrayBack.Models;
using musicLibrayBack.Repositories;

namespace musicLibrayBack.Services;

public class ArtistService
{
    private readonly ArtistRepository _artistRepository;
    public ArtistService(ArtistRepository artistRepository)
    {
        _artistRepository = artistRepository;
    }

    public async Task<IEnumerable<Artist>> GetArtistsAsync()
    {
        return await _artistRepository.GetAllAsync();
    }

    public async Task<Artist> GetArtistByIdAsync(Guid artistId)
    {
        return await _artistRepository.GetByIdAsync(artistId);
    }

    public async Task AddArtistAsync(Artist artist)
    {
        artist.Id = Guid.NewGuid();
        await _artistRepository.AddAsync(artist);
    }

    public async Task UpdateArtistAsync(Artist artist)
    {
        await _artistRepository.UpdateAsync(artist);
    }

    public async Task DeleteArtistAsync(Guid artistId)
    {
        await _artistRepository.DeleteAsync(artistId);
    }

    
}