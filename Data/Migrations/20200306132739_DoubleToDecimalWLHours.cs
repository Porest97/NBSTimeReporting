using Microsoft.EntityFrameworkCore.Migrations;

namespace NBSTimeReporting.Data.Migrations
{
    public partial class DoubleToDecimalWLHours : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "WLHours",
                table: "RegusTicket",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "WLHours",
                table: "RegusTicket",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
