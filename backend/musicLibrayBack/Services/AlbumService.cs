namespace musicLibrayBack.Services;
using System;
using musicLibrayBack.Models;
using musicLibrayBack.Repositories;

public class AlbumService
{
    private readonly AlbumRepository _albumRepository;
    public AlbumService(AlbumRepository albumRepository)
    {
        _albumRepository = albumRepository;
    }
    public async Task<IEnumerable<Album>> GetAlbumsByArtistIdAsync(Guid artistId)
    {
        return await _albumRepository.GetAlbumsByArtistIdAsync(artistId);
    }

    public async Task<IEnumerable<Album>> GetAlbumsAsync()
    {
        return await _albumRepository.GetAllAsync();
    }

    public async Task<Album> GetAlbumByIdAsync(Guid albumId)
    {
        return await _albumRepository.GetByIdAsync(albumId);
    }

    public async Task AddAlbumAsync(Album album)
    {
        album.Id = Guid.NewGuid();
        await _albumRepository.AddAsync(album);
    }

    public async Task UpdateAlbumAsync(Album album)
    {
        await _albumRepository.UpdateAsync(album);
    }

    public async Task DeleteAlbumAsync(Guid albumId)
    {
        await _albumRepository.DeleteAsync(albumId);
    }
}
