using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace skitBackend.Migrations
{
    /// <inheritdoc />
    public partial class CompanyJsonFieldAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("Links", "Companies");
            migrationBuilder.AddColumn<List<string>>(
                name: "Links",
                table: "Companies",
                type: "jsonb",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("Links", "Companies");
            migrationBuilder.AddColumn<List<string>>(
                name: "Links",
                table: "Companies",
                type: "text",
                nullable: true);
        }
    }
}
