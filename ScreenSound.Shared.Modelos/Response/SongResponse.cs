namespace ScreenSound.Shared.Models.Responses;

public record SongResponse(int Id, string Name, int ArtistId, string ArtistName, int? ReleaseYear, string? ProfilePicture);
