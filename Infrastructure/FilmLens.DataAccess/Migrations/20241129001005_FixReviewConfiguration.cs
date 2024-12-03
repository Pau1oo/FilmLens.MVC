using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmLens.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixReviewConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reviews_movies_MovieId",
                table: "reviews");

            migrationBuilder.DropIndex(
                name: "IX_reviews_MovieId",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "reviews");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "reviews",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_reviews_MovieId",
                table: "reviews",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_movies_MovieId",
                table: "reviews",
                column: "MovieId",
                principalTable: "movies",
                principalColumn: "Id");
        }
    }
}
