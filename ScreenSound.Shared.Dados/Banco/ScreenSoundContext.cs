using Microsoft.EntityFrameworkCore;
using ScreenSound.Domain;

namespace ScreenSound.Data;

public class ScreenSoundContext : DbContext
{
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<Genre> Genres { get; set; }

    private string _connectionString = "Server=localhost;Database=ScreenSoundV0;User=root;Password=root;";

    public ScreenSoundContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;

        optionsBuilder
            .UseMySql(_connectionString, new MySqlServerVersion(new Version(8, 0, 0)))
            .UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Song>()
            .HasOne(s => s.Artist)
            .WithMany(a => a.Songs)
            .HasForeignKey(s => s.ArtistId);

        modelBuilder.Entity<Song>()
            .HasOne(s => s.Genre)
            .WithMany(g => g.Songs)
            .HasForeignKey(s => s.GenreId);
    }
}
