using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBSTimeReporting.Migrations
{
    public partial class NetelloABInvoicesAddd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvoiceStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NetelloInvoice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegusTicketId = table.Column<int>(nullable: true),
                    DWWorkLogId = table.Column<int>(nullable: true),
                    WLHours = table.Column<decimal>(nullable: false),
                    MaterialKost = table.Column<decimal>(nullable: false),
                    HourPrice = table.Column<decimal>(nullable: false),
                    TotalKost = table.Column<decimal>(nullable: false),
                    InvoiceStatusId = table.Column<int>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: true),
                    PayedDate = table.Column<DateTime>(nullable: true),
                    FoerNoxNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetelloInvoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NetelloInvoice_DWWorkLog_DWWorkLogId",
                        column: x => x.DWWorkLogId,
                        principalTable: "DWWorkLog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NetelloInvoice_InvoiceStatus_InvoiceStatusId",
                        column: x => x.InvoiceStatusId,
                        principalTable: "InvoiceStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NetelloInvoice_RegusTicket_RegusTicketId",
                        column: x => x.RegusTicketId,
                        principalTable: "RegusTicket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NetelloInvoice_DWWorkLogId",
                table: "NetelloInvoice",
                column: "DWWorkLogId");

            migrationBuilder.CreateIndex(
                name: "IX_NetelloInvoice_InvoiceStatusId",
                table: "NetelloInvoice",
                column: "InvoiceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_NetelloInvoice_RegusTicketId",
                table: "NetelloInvoice",
                column: "RegusTicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NetelloInvoice");

            migrationBuilder.DropTable(
                name: "InvoiceStatus");
        }
    }
}
