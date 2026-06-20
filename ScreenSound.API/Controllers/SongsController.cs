using Microsoft.AspNetCore.Mvc;
using ScreenSound.Data;
using ScreenSound.Domain;
using ScreenSound.Shared.Models.Requests;
using ScreenSound.Shared.Models.Responses;

namespace ScreenSound.API.Controllers;

[ApiController]
[Route("[controller]")]
public class SongsController : ControllerBase
{
    private readonly DAL<Song> _dal;

    public SongsController(DAL<Song> dal)
    {
        _dal = dal;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var songs = _dal.GetAll("Artist");
        return Ok(songs.Select(ToResponse));
    }

    [HttpGet("{name}")]
    public IActionResult GetByName(string name)
    {
        var song = _dal.GetBy(s => s.Name.ToUpper().Equals(name.ToUpper()));
        if (song is null) return NotFound();
        return Ok(ToResponse(song));
    }

    [HttpPost]
    public IActionResult Create([FromBody] SongRequest request)
    {
        var song = new Song(request.Name)
        {
            ArtistId = request.ArtistId,
            ReleaseYear = request.ReleaseYear,
            GenreId = request.GenreId
        };
        _dal.Add(song);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var song = _dal.GetBy(s => s.Id == id);
        if (song is null) return NotFound();
        _dal.Delete(song);
        return NoContent();
    }

    [HttpPut]
    public IActionResult Update([FromBody] SongUpdateRequest request)
    {
        var song = _dal.GetBy(s => s.Id == request.Id);
        if (song is null) return NotFound();
        song.Name = request.Name;
        song.ReleaseYear = request.ReleaseYear;
        _dal.Update(song);
        return Ok();
    }

    private static SongResponse ToResponse(Song song) =>
        new(song.Id, song.Name!, song.Artist!.Id, song.Artist?.Name!, song.ReleaseYear, song.Artist?.ProfilePicture);
}
