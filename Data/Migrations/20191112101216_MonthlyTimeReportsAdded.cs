using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBSTimeReporting.Data.Migrations
{
    public partial class MonthlyTimeReportsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonthlyTimeReport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportStatusId = table.Column<int>(nullable: true),
                    Month = table.Column<string>(nullable: true),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    WeeklyTimeReportId = table.Column<int>(nullable: true),
                    WeeklyTimeReportId1 = table.Column<int>(nullable: true),
                    WeeklyTimeReportId2 = table.Column<int>(nullable: true),
                    WeeklyTimeReportId3 = table.Column<int>(nullable: true),
                    WeeklyTimeReportId4 = table.Column<int>(nullable: true),
                    TotalTimeWorked = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyTimeReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonthlyTimeReport_ReportStatus_ReportStatusId",
                        column: x => x.ReportStatusId,
                        principalTable: "ReportStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MonthlyTimeReport_WeeklyTimeReport_WeeklyTimeReportId",
                        column: x => x.WeeklyTimeReportId,
                        principalTable: "WeeklyTimeReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MonthlyTimeReport_WeeklyTimeReport_WeeklyTimeReportId1",
                        column: x => x.WeeklyTimeReportId1,
                        principalTable: "WeeklyTimeReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MonthlyTimeReport_WeeklyTimeReport_WeeklyTimeReportId2",
                        column: x => x.WeeklyTimeReportId2,
                        principalTable: "WeeklyTimeReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MonthlyTimeReport_WeeklyTimeReport_WeeklyTimeReportId3",
                        column: x => x.WeeklyTimeReportId3,
                        principalTable: "WeeklyTimeReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MonthlyTimeReport_WeeklyTimeReport_WeeklyTimeReportId4",
                        column: x => x.WeeklyTimeReportId4,
                        principalTable: "WeeklyTimeReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyTimeReport_ReportStatusId",
                table: "MonthlyTimeReport",
                column: "ReportStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyTimeReport_WeeklyTimeReportId",
                table: "MonthlyTimeReport",
                column: "WeeklyTimeReportId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyTimeReport_WeeklyTimeReportId1",
                table: "MonthlyTimeReport",
                column: "WeeklyTimeReportId1");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyTimeReport_WeeklyTimeReportId2",
                table: "MonthlyTimeReport",
                column: "WeeklyTimeReportId2");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyTimeReport_WeeklyTimeReportId3",
                table: "MonthlyTimeReport",
                column: "WeeklyTimeReportId3");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyTimeReport_WeeklyTimeReportId4",
                table: "MonthlyTimeReport",
                column: "WeeklyTimeReportId4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonthlyTimeReport");
        }
    }
}
