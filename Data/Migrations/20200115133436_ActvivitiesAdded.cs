using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBSTimeReporting.Data.Migrations
{
    public partial class ActvivitiesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActivityType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityName = table.Column<string>(nullable: true),
                    ActivityStatusId = table.Column<int>(nullable: true),
                    ActivityTypeId = table.Column<int>(nullable: true),
                    FromDateTime = table.Column<DateTime>(nullable: false),
                    ToDateTime = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activity_ActivityStatus_ActivityStatusId",
                        column: x => x.ActivityStatusId,
                        principalTable: "ActivityStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Activity_ActivityType_ActivityTypeId",
                        column: x => x.ActivityTypeId,
                        principalTable: "ActivityType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_ActivityStatusId",
                table: "Activity",
                column: "ActivityStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_ActivityTypeId",
                table: "Activity",
                column: "ActivityTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "ActivityStatus");

            migrationBuilder.DropTable(
                name: "ActivityType");
        }
    }
}
