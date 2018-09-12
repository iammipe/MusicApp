using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mnRelations.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    PlaylistID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlaylistName = table.Column<string>(nullable: true),
                    PlaylistImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.PlaylistID);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    SongID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameOfSong = table.Column<string>(nullable: true),
                    NameOfArtist = table.Column<string>(nullable: true),
                    SongURL = table.Column<string>(nullable: true),
                    PictureURL = table.Column<string>(nullable: true),
                    Duration = table.Column<string>(nullable: true),
                    FunFact = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.SongID);
                });

            migrationBuilder.CreateTable(
                name: "SongPlaylist",
                columns: table => new
                {
                    SongID = table.Column<int>(nullable: false),
                    PlaylistID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongPlaylist", x => new { x.SongID, x.PlaylistID });
                    table.ForeignKey(
                        name: "FK_SongPlaylist_Playlists_PlaylistID",
                        column: x => x.PlaylistID,
                        principalTable: "Playlists",
                        principalColumn: "PlaylistID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SongPlaylist_Songs_SongID",
                        column: x => x.SongID,
                        principalTable: "Songs",
                        principalColumn: "SongID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SongPlaylist_PlaylistID",
                table: "SongPlaylist",
                column: "PlaylistID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SongPlaylist");

            migrationBuilder.DropTable(
                name: "Playlists");

            migrationBuilder.DropTable(
                name: "Songs");
        }
    }
}
