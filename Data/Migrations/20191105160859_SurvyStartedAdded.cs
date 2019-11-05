using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBSTimeReporting.Data.Migrations
{
    public partial class SurvyStartedAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SurveyStarde",
                table: "Survey");

            migrationBuilder.AddColumn<DateTime>(
                name: "SurveyStarted",
                table: "Survey",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SurveyStarted",
                table: "Survey");

            migrationBuilder.AddColumn<DateTime>(
                name: "SurveyStarde",
                table: "Survey",
                type: "datetime2",
                nullable: true);
        }
    }
}
