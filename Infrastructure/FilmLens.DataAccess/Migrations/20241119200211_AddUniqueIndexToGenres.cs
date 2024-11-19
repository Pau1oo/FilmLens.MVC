using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmLens.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueIndexToGenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.CreateIndex(
			name: "IX_Genres_Name",
			table: "genres",
			column: "Name",
			unique: true);
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.DropIndex(
			name: "IX_Genres_Name",
			table: "genres");
		}
    }
}
