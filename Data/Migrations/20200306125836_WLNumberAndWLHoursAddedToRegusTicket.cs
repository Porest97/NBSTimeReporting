using Microsoft.EntityFrameworkCore.Migrations;

namespace NBSTimeReporting.Data.Migrations
{
    public partial class WLNumberAndWLHoursAddedToRegusTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "WLHours",
                table: "RegusTicket",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "WLNumber",
                table: "RegusTicket",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WLHours",
                table: "RegusTicket");

            migrationBuilder.DropColumn(
                name: "WLNumber",
                table: "RegusTicket");
        }
    }
}
