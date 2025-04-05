using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nostalgia.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddScanId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScanId",
                table: "Cosas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScanId",
                table: "Cosas");
        }
    }
}
