using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.API.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genres",
                columns: ["Name", "Description"],
                values: new object[,]
                {
                    { "Rock", "Genre that developed from rock and roll in the 1950s and 1960s." },
                    { "Pop", "Popular music genre that originated in the mid-1950s in the United States and United Kingdom." },
                    { "MPB", "Brazilian Popular Music, a genre that emerged in Brazil in the mid-1960s." }
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: ["Name", "Bio", "ProfilePicture"],
                values: new object[,]
                {
                    { "Foo Fighters", "American rock band formed by Dave Grohl in 1994.", "Foto_001.png" },
                    { "Queen", "British rock band formed in London in 1970.", "Foto_002.png" },
                    { "Led Zeppelin", "British rock band formed in London in 1968.", "Foto_003.png" },
                    { "Taylor Swift", "American singer-songwriter.", "Foto_004.png" },
                    { "Michael Jackson", "American singer, songwriter, and dancer.", "Foto_005.png" },
                    { "Madonna", "American singer, songwriter, actress, and businesswoman.", "Foto_006.png" },
                    { "Djavan", "Brazilian singer, songwriter, and guitarist.", "Foto_007.png" },
                    { "Gilberto Gil", "Brazilian singer, songwriter, multi-instrumentalist, and politician.", "Foto_008.png" },
                    { "Caetano Veloso", "Brazilian singer, songwriter, guitarist, writer, and music producer.", "Foto_009.png" }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: ["Name", "ReleaseYear"],
                values: new object[,]
                {
                    { "Everlong", 1997 },
                    { "The Pretender", 2007 },
                    { "Learn to Fly", 1999 },
                    { "Bohemian Rhapsody", 1975 },
                    { "Don't Stop Me Now", 1978 },
                    { "We Will Rock You", 1977 },
                    { "Stairway to Heaven", 1971 },
                    { "Whole Lotta Love", 1969 },
                    { "Black Dog", 1971 },
                    { "Blank Space", 2014 },
                    { "Shake It Off", 2014 },
                    { "Love Story", 2008 },
                    { "Billie Jean", 1982 },
                    { "Thriller", 1982 },
                    { "Beat It", 1982 },
                    { "Like a Virgin", 1984 },
                    { "Material Girl", 1984 },
                    { "Vogue", 1990 },
                    { "Oceano", 1989 },
                    { "Flor de Lis", 1976 },
                    { "Samurai", 1982 },
                    { "Andar com Fé", 1982 },
                    { "Drão", 1982 },
                    { "Expresso 2222", 1972 },
                    { "O Leãozinho", 1977 },
                    { "Sampa", 1978 },
                    { "Cajuína", 1979 }
                });

            // Rock
            migrationBuilder.Sql(@"
                UPDATE Songs S
                INNER JOIN Artists A ON A.Name = 'Foo Fighters'
                JOIN Genres G ON G.Name = 'Rock'
                SET S.ArtistId = A.Id, S.GenreId = G.Id
                WHERE S.Name IN ('Everlong', 'The Pretender', 'Learn to Fly');

                UPDATE Songs S
                INNER JOIN Artists A ON A.Name = 'Queen'
                JOIN Genres G ON G.Name = 'Rock'
                SET S.ArtistId = A.Id, S.GenreId = G.Id
                WHERE S.Name IN ('Bohemian Rhapsody', 'Don''t Stop Me Now', 'We Will Rock You');

                UPDATE Songs S
                INNER JOIN Artists A ON A.Name = 'Led Zeppelin'
                JOIN Genres G ON G.Name = 'Rock'
                SET S.ArtistId = A.Id, S.GenreId = G.Id
                WHERE S.Name IN ('Stairway to Heaven', 'Whole Lotta Love', 'Black Dog');
            ");

            // Pop
            migrationBuilder.Sql(@"
                UPDATE Songs S
                INNER JOIN Artists A ON A.Name = 'Taylor Swift'
                JOIN Genres G ON G.Name = 'Pop'
                SET S.ArtistId = A.Id, S.GenreId = G.Id
                WHERE S.Name IN ('Blank Space', 'Shake It Off', 'Love Story');

                UPDATE Songs S
                INNER JOIN Artists A ON A.Name = 'Michael Jackson'
                JOIN Genres G ON G.Name = 'Pop'
                SET S.ArtistId = A.Id, S.GenreId = G.Id
                WHERE S.Name IN ('Billie Jean', 'Thriller', 'Beat It');

                UPDATE Songs S
                INNER JOIN Artists A ON A.Name = 'Madonna'
                JOIN Genres G ON G.Name = 'Pop'
                SET S.ArtistId = A.Id, S.GenreId = G.Id
                WHERE S.Name IN ('Like a Virgin', 'Material Girl', 'Vogue');
            ");

            // MPB
            migrationBuilder.Sql(@"
                UPDATE Songs S
                INNER JOIN Artists A ON A.Name = 'Djavan'
                JOIN Genres G ON G.Name = 'MPB'
                SET S.ArtistId = A.Id, S.GenreId = G.Id
                WHERE S.Name IN ('Oceano', 'Flor de Lis', 'Samurai');

                UPDATE Songs S
                INNER JOIN Artists A ON A.Name = 'Gilberto Gil'
                JOIN Genres G ON G.Name = 'MPB'
                SET S.ArtistId = A.Id, S.GenreId = G.Id
                WHERE S.Name IN ('Andar com Fé', 'Drão', 'Expresso 2222');

                UPDATE Songs S
                INNER JOIN Artists A ON A.Name = 'Caetano Veloso'
                JOIN Genres G ON G.Name = 'MPB'
                SET S.ArtistId = A.Id, S.GenreId = G.Id
                WHERE S.Name IN ('O Leãozinho', 'Sampa', 'Cajuína');
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Songs");
            migrationBuilder.Sql("DELETE FROM Artists");
            migrationBuilder.Sql("DELETE FROM Genres");
        }
    }
}
