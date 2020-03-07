using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBSTimeReporting.Data.Migrations
{
    public partial class RegusTicketsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegusTicket",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketPriorityId = table.Column<int>(nullable: true),
                    TicketStatusId = table.Column<int>(nullable: true),
                    TicketTypeId = table.Column<int>(nullable: true),
                    RegusTicketNumber = table.Column<string>(nullable: true),
                    IncidentNumber = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    SiteId = table.Column<int>(nullable: true),
                    Received = table.Column<DateTime>(nullable: true),
                    PersonId1 = table.Column<int>(nullable: true),
                    FEScheduled = table.Column<DateTime>(nullable: true),
                    PersonId2 = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FEEntersSite = table.Column<DateTime>(nullable: true),
                    FEEExitsSite = table.Column<DateTime>(nullable: true),
                    Logg = table.Column<string>(nullable: true),
                    IssueResolved = table.Column<DateTime>(nullable: true),
                    Resolution = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegusTicket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegusTicket_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegusTicket_Person_PersonId1",
                        column: x => x.PersonId1,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegusTicket_Person_PersonId2",
                        column: x => x.PersonId2,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegusTicket_Site_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegusTicket_TicketPriority_TicketPriorityId",
                        column: x => x.TicketPriorityId,
                        principalTable: "TicketPriority",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegusTicket_TicketStatus_TicketStatusId",
                        column: x => x.TicketStatusId,
                        principalTable: "TicketStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegusTicket_TicketType_TicketTypeId",
                        column: x => x.TicketTypeId,
                        principalTable: "TicketType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegusTicket_PersonId",
                table: "RegusTicket",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_RegusTicket_PersonId1",
                table: "RegusTicket",
                column: "PersonId1");

            migrationBuilder.CreateIndex(
                name: "IX_RegusTicket_PersonId2",
                table: "RegusTicket",
                column: "PersonId2");

            migrationBuilder.CreateIndex(
                name: "IX_RegusTicket_SiteId",
                table: "RegusTicket",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_RegusTicket_TicketPriorityId",
                table: "RegusTicket",
                column: "TicketPriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_RegusTicket_TicketStatusId",
                table: "RegusTicket",
                column: "TicketStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_RegusTicket_TicketTypeId",
                table: "RegusTicket",
                column: "TicketTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegusTicket");
        }
    }
}
