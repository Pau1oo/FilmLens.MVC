using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmLens.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class GenreUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_MovieId_GenreId",
                table: "MovieGenres",
                columns: new[] { "MovieId", "GenreId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MovieGenres_MovieId_GenreId",
                table: "MovieGenres");
        }
    }
}
