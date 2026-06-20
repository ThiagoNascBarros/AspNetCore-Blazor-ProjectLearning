using System.ComponentModel.DataAnnotations;

namespace ScreenSound.Shared.Models.Requests;

public record ArtistRequest([Required] string Name, [Required] string Bio, string? ProfilePicture);
