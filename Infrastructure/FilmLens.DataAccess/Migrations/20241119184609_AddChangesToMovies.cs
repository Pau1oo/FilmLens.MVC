using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmLens.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddChangesToMovies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrailerUrl",
                table: "movies");

            migrationBuilder.RenameColumn(
                name: "PosterPath",
                table: "movies",
                newName: "PosterUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PosterUrl",
                table: "movies",
                newName: "PosterPath");

            migrationBuilder.AddColumn<string>(
                name: "TrailerUrl",
                table: "movies",
                type: "text",
                nullable: true);
        }
    }
}
