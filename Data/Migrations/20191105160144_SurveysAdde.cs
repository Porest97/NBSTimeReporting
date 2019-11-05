using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBSTimeReporting.Data.Migrations
{
    public partial class SurveysAdde : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SurveyStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SurveyType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Survey",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyStatusId = table.Column<int>(nullable: true),
                    SurveyTypeId = table.Column<int>(nullable: true),
                    TicketId = table.Column<int>(nullable: true),
                    Version = table.Column<string>(nullable: true),
                    SurveyStarde = table.Column<DateTime>(nullable: true),
                    SurveyEnded = table.Column<DateTime>(nullable: true),
                    NumberOfAPs = table.Column<string>(nullable: true),
                    APBrandModel = table.Column<string>(nullable: true),
                    APFloorMap = table.Column<string>(nullable: true),
                    NetSpotReport = table.Column<string>(nullable: true),
                    SpeedTestIMG = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Survey_SurveyStatus_SurveyStatusId",
                        column: x => x.SurveyStatusId,
                        principalTable: "SurveyStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Survey_SurveyType_SurveyTypeId",
                        column: x => x.SurveyTypeId,
                        principalTable: "SurveyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Survey_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Survey_SurveyStatusId",
                table: "Survey",
                column: "SurveyStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_SurveyTypeId",
                table: "Survey",
                column: "SurveyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_TicketId",
                table: "Survey",
                column: "TicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Survey");

            migrationBuilder.DropTable(
                name: "SurveyStatus");

            migrationBuilder.DropTable(
                name: "SurveyType");
        }
    }
}
