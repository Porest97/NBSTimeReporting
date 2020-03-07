using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBSTimeReporting.Data.Migrations
{
    public partial class OfferingAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Offer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTimeOffered = table.Column<DateTime>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    SiteId = table.Column<int>(nullable: true),
                    TicketNumber = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateTimeScheduledStart = table.Column<DateTime>(nullable: true),
                    DateTimeScheduledEnd = table.Column<DateTime>(nullable: true),
                    HoursOnSite = table.Column<double>(nullable: false),
                    PricePerHour = table.Column<double>(nullable: false),
                    KostHours = table.Column<double>(nullable: false),
                    KostMtrl = table.Column<double>(nullable: false),
                    Riskfaktor = table.Column<double>(nullable: false),
                    TotalOfferAmount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offer_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Offer_Site_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offer_PersonId",
                table: "Offer",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_SiteId",
                table: "Offer",
                column: "SiteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offer");
        }
    }
}
