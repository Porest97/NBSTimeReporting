using Microsoft.EntityFrameworkCore.Migrations;

namespace NBSTimeReporting.Data.Migrations
{
    public partial class AssetsMACAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MACAddress",
                table: "Asset",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MACAddress",
                table: "Asset");
        }
    }
}
