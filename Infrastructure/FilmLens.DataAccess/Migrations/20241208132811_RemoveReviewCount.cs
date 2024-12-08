using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmLens.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemoveReviewCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReviewCount",
                table: "users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReviewCount",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
