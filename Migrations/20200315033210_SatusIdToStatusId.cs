using Microsoft.EntityFrameworkCore.Migrations;

namespace NBSTimeReporting.Migrations
{
    public partial class SatusIdToStatusId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DWWLSatusId",
                table: "DWWorkLog");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DWWLSatusId",
                table: "DWWorkLog",
                type: "int",
                nullable: true);
        }
    }
}
