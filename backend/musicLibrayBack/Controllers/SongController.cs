using Microsoft.AspNetCore.Mvc;
using musicLibrayBack.Models;
using musicLibrayBack.Services;

namespace musicLibrayBack.Controllers;

[Controller]
[Route("api/[controller]/[action]")]
public class SongController : ControllerBase 
{
    private readonly SongService _songService;
    public SongController(SongService songService)
    {
        _songService = songService;
    }

    [HttpGet]
    public async Task<IActionResult> GetSongs()
    {
        var songs = await _songService.GetSongsAsync();
        System.Console.WriteLine(songs);
        return Ok(songs);
    }

    [HttpGet("{albumId}")]
    public async Task<IActionResult> GetSongsByAlbumId([FromRoute] Guid albumId)
    {
        var songs = await _songService.GetSongsByAlbumIdAsync(albumId);
        return Ok(songs);
    }

    [HttpGet("{songId}")]
    public async Task<IActionResult> GetSongById([FromRoute] Guid songId)
    {
        var song = await _songService.GetSongByIdAsync(songId);
        return Ok(song);
    }

    [HttpPost]
    public async Task<IActionResult> AddSong([FromBody] Song song)
    {
        await _songService.AddSongAsync(song);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSong([FromBody] Song song)
    {
        await _songService.UpdateSongAsync(song);
        return Ok();
    }

    [HttpDelete("{songId}")]
    public async Task<IActionResult> DeleteSong([FromRoute] Guid songId)
    {
        await _songService.DeleteSongAsync(songId);
        return Ok();
    }
}