namespace ScreenSound.Domain;

public class Artist
{
    public virtual ICollection<Song> Songs { get; set; } = new List<Song>();

    public Artist() { }

    public Artist(string name, string bio)
    {
        Name = name;
        Bio = bio;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string ProfilePicture { get; set; }
    public string Bio { get; set; }
}
