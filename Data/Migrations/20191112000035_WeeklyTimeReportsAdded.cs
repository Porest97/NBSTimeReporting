using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBSTimeReporting.Data.Migrations
{
    public partial class WeeklyTimeReportsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeeklyTimeReport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportStatusId = table.Column<int>(nullable: true),
                    WeekNumber = table.Column<string>(nullable: true),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    PersonId = table.Column<int>(nullable: true),
                    Day1 = table.Column<DateTime>(nullable: false),
                    Day1Started = table.Column<DateTime>(nullable: true),
                    Day1Ended = table.Column<DateTime>(nullable: true),
                    WorkedDay1 = table.Column<decimal>(nullable: false),
                    Day2 = table.Column<DateTime>(nullable: false),
                    Day2Started = table.Column<DateTime>(nullable: true),
                    Day2Ended = table.Column<DateTime>(nullable: true),
                    WorkedDay2 = table.Column<decimal>(nullable: false),
                    Day3 = table.Column<DateTime>(nullable: false),
                    Day3Started = table.Column<DateTime>(nullable: true),
                    Day3Ended = table.Column<DateTime>(nullable: true),
                    WorkedDay3 = table.Column<decimal>(nullable: false),
                    Day4 = table.Column<DateTime>(nullable: false),
                    Day4Started = table.Column<DateTime>(nullable: true),
                    Day4Ended = table.Column<DateTime>(nullable: true),
                    WorkedDay4 = table.Column<decimal>(nullable: false),
                    Day5 = table.Column<DateTime>(nullable: false),
                    Day5Started = table.Column<DateTime>(nullable: true),
                    Day5Ended = table.Column<DateTime>(nullable: true),
                    WorkedDay5 = table.Column<decimal>(nullable: false),
                    Day6 = table.Column<DateTime>(nullable: false),
                    Day6Started = table.Column<DateTime>(nullable: true),
                    Day6Ended = table.Column<DateTime>(nullable: true),
                    WorkedDay6 = table.Column<decimal>(nullable: false),
                    Day7 = table.Column<DateTime>(nullable: false),
                    Day7Started = table.Column<DateTime>(nullable: true),
                    Day7Ended = table.Column<DateTime>(nullable: true),
                    WorkedDay7 = table.Column<decimal>(nullable: false),
                    WorkedHoursTotal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyTimeReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklyTimeReport_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeeklyTimeReport_ReportStatus_ReportStatusId",
                        column: x => x.ReportStatusId,
                        principalTable: "ReportStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyTimeReport_PersonId",
                table: "WeeklyTimeReport",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyTimeReport_ReportStatusId",
                table: "WeeklyTimeReport",
                column: "ReportStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeeklyTimeReport");
        }
    }
}
