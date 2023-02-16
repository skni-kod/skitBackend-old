using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace skitBackend.Migrations
{
    /// <inheritdoc />
    public partial class ColumnCompanyCreatedByUserAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Companies",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CreatedByUserId",
                table: "Companies",
                column: "CreatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Users_CreatedByUserId",
                table: "Companies",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Users_CreatedByUserId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_CreatedByUserId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Companies");
        }
    }
}
