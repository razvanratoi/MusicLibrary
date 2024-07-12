using Microsoft.AspNetCore.Mvc;
using musicLibrayBack.Models;
using musicLibrayBack.Services;

namespace musicLibrayBack.Controllers;

[Controller]
[Route("api/[controller]/[action]")]
public class ArtistController : ControllerBase
{
    private readonly ArtistService _artistService;
    public ArtistController(ArtistService artistService)
    {
        _artistService = artistService;
    }

    [HttpGet]
    public async Task<IActionResult> GetArtists()
    {
        var artists = await _artistService.GetArtistsAsync();
        return Ok(artists);
    }

    [HttpGet("{artistId}")]
    public async Task<IActionResult> GetArtistById([FromRoute] Guid artistId)
    {
        var artist = await _artistService.GetArtistByIdAsync(artistId);
        return Ok(artist);
    }

    [HttpPost]
    public async Task<IActionResult> AddArtist([FromBody] Artist artist)
    {
        await _artistService.AddArtistAsync(artist);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateArtist([FromBody] Artist artist)
    {
        await _artistService.UpdateArtistAsync(artist);
        return Ok();
    }

    [HttpDelete("{artistId}")]
    public async Task<IActionResult> DeleteArtist([FromRoute] Guid artistId)
    {
        await _artistService.DeleteArtistAsync(artistId);
        return Ok();
    }
}