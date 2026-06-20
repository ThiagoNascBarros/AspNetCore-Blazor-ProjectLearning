namespace ScreenSound.Domain;

public class Song
{
    public Song() { }

    public Song(string name)
    {
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public int? ReleaseYear { get; set; }
    public int? ArtistId { get; set; }
    public int? GenreId { get; set; }
    public virtual Artist? Artist { get; set; }
    public virtual Genre? Genre { get; set; }
}
