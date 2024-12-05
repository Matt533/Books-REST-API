using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookEStore.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedAuthorModelwithImageforProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileImage",
                table: "authors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImage",
                table: "authors");
        }
    }
}
