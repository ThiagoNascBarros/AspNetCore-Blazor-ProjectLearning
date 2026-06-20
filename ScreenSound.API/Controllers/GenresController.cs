using Microsoft.AspNetCore.Mvc;
using ScreenSound.Data;
using ScreenSound.Domain;
using ScreenSound.Shared.Models.Requests;
using ScreenSound.Shared.Models.Responses;

namespace ScreenSound.API.Controllers;

[ApiController]
[Route("[controller]")]
public class GenresController : ControllerBase
{
    private readonly DAL<Genre> _dal;

    public GenresController(DAL<Genre> dal)
    {
        _dal = dal;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_dal.GetAll().Select(ToResponse));
    }

    [HttpGet("{name}")]
    public IActionResult GetByName(string name)
    {
        var genre = _dal.GetBy(g => g.Name!.ToUpper().Equals(name.ToUpper()));
        if (genre is null) return NotFound();
        return Ok(ToResponse(genre));
    }

    [HttpPost]
    public IActionResult Create([FromBody] GenreRequest request)
    {
        _dal.Add(new Genre { Name = request.Name, Description = request.Description });
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var genre = _dal.GetBy(g => g.Id == id);
        if (genre is null) return NotFound();
        _dal.Delete(genre);
        return NoContent();
    }

    private static GenreResponse ToResponse(Genre genre) =>
        new(genre.Id, genre.Name!, genre.Description!);
}
