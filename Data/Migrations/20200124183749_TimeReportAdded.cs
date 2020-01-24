using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBSTimeReporting.Data.Migrations
{
    public partial class TimeReportAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimeReport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteId = table.Column<int>(nullable: true),
                    IncidentNumber = table.Column<string>(nullable: true),
                    ShiftStarted = table.Column<DateTime>(nullable: false),
                    ShiftEnded = table.Column<DateTime>(nullable: false),
                    WorkedHours = table.Column<double>(nullable: false),
                    FeeHour = table.Column<double>(nullable: false),
                    TotalFee = table.Column<double>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeReport_Site_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeReport_SiteId",
                table: "TimeReport",
                column: "SiteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeReport");
        }
    }
}
