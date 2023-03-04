using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace skitBackend.Migrations
{
    /// <inheritdoc />
    public partial class CompanyIsPublishedadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Companies",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Companies");
        }
    }
}
