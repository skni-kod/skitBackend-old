using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreApp.Migrations
{
    public partial class RelationsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Projects_SectionId",
                table: "Projects");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_SectionId",
                table: "Projects",
                column: "SectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Projects_SectionId",
                table: "Projects");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_SectionId",
                table: "Projects",
                column: "SectionId",
                unique: true);
        }
    }
}
