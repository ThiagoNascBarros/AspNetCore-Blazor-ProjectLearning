namespace ScreenSound.Shared.Models.Requests;

public record SongUpdateRequest(int Id, string Name, int ArtistId, int ReleaseYear, int GenreId)
    : SongRequest(Name, ArtistId, ReleaseYear, GenreId);
