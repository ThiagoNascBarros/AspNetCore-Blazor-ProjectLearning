using System.ComponentModel.DataAnnotations;

namespace ScreenSound.Shared.Models.Requests;

public record SongRequest([Required] string Name, [Required] int ArtistId, int ReleaseYear, int GenreId);
