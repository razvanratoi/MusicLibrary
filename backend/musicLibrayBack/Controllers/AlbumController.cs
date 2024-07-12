using Microsoft.AspNetCore.Mvc;
using musicLibrayBack.Models;
using musicLibrayBack.Services;

namespace musicLibrayBack.Controllers;

[Controller]
[Route("api/[controller]/[action]")]
public class AlbumController : ControllerBase
{
    private readonly AlbumService _albumService;
    public AlbumController(AlbumService albumService)
    {
        _albumService = albumService;
    }

    // cruds on albums

    [HttpGet]
    public async Task<IActionResult> GetAlbums()
    {
        var albums = await _albumService.GetAlbumsAsync();
        return Ok(albums);
    }

    [HttpGet("{artistId}")]
    public async Task<IActionResult> GetAlbumsByArtistId([FromRoute] Guid artistId)
    {
        var albums = await _albumService.GetAlbumsByArtistIdAsync(artistId);
        return Ok(albums);
    }

    [HttpGet("{albumId}")]
    public async Task<IActionResult> GetAlbumById([FromRoute] Guid albumId)
    {
        var album = await _albumService.GetAlbumByIdAsync(albumId);
        return Ok(album);
    }

    [HttpPost]
    public async Task<IActionResult> AddAlbum([FromBody] Album album)
    {
        await _albumService.AddAlbumAsync(album);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAlbum([FromBody] Album album)
    {
        await _albumService.UpdateAlbumAsync(album);
        return Ok();
    }

    [HttpDelete("{albumId}")]
    public async Task<IActionResult> DeleteAlbum([FromRoute] Guid albumId)
    {
        await _albumService.DeleteAlbumAsync(albumId);
        return Ok();
    }
}