namespace ScreenSound.Shared.Models.Requests;

public record ArtistUpdateRequest(int Id, string Name, string Bio, string? ProfilePicture)
    : ArtistRequest(Name, Bio, ProfilePicture);
