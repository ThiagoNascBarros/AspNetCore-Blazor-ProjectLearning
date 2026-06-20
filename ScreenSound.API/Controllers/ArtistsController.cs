using Microsoft.AspNetCore.Mvc;
using ScreenSound.Data;
using ScreenSound.Domain;
using ScreenSound.Domain;
using ScreenSound.Shared.Models.Requests;
using ScreenSound.Shared.Models.Responses;

namespace ScreenSound.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ArtistsController : ControllerBase
{
    private readonly DAL<Artist> _dal;
    private readonly IHostEnvironment _env;

    public ArtistsController(DAL<Artist> dal, IHostEnvironment env)
    {
        _dal = dal;
        _env = env;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var artists = _dal.GetAll();
        return Ok(artists.Select(ToResponse));
    }

    [HttpGet("{name}")]
    public IActionResult GetByName(string name)
    {
        var artist = _dal.GetBy(a => a.Name.ToUpper().Equals(name.ToUpper()));
        if (artist is null) return NotFound();
        return Ok(ToResponse(artist));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ArtistRequest request)
    {
        var name = request.Name.Trim();
        var profilePicture = "Artista.jpeg";

        if (request.ProfilePicture is not null)
        {
            var fileName = DateTime.Now.ToString("ddMMyyyyhhss") + "." + name + ".jpeg";
            profilePicture = fileName;
            var path = Path.Combine(_env.ContentRootPath, "wwwroot", "FotosPerfil", fileName);
            using var ms = new MemoryStream(Convert.FromBase64String(request.ProfilePicture));
            using var fs = new FileStream(path, FileMode.Create);
            await ms.CopyToAsync(fs);
        }

        var artist = new Artist(request.Name, request.Bio) { ProfilePicture = profilePicture };
        _dal.Add(artist);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var artist = _dal.GetBy(a => a.Id == id);
        if (artist is null) return NotFound();
        _dal.Delete(artist);
        return NoContent();
    }

    [HttpPut]
    public IActionResult Update([FromBody] ArtistUpdateRequest request)
    {
        var artist = _dal.GetBy(a => a.Id == request.Id);
        if (artist is null) return NotFound();
        artist.Name = request.Name;
        artist.Bio = request.Bio;
        _dal.Update(artist);
        return Ok();
    }

    private static ArtistResponse ToResponse(Artist artist) =>
        new(artist.Id, artist.Name, artist.Bio, artist.ProfilePicture);
}
