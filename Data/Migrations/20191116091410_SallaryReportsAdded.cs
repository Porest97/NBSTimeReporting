using Microsoft.EntityFrameworkCore.Migrations;

namespace NBSTimeReporting.Data.Migrations
{
    public partial class SallaryReportsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SallaryReport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportStatusId = table.Column<int>(nullable: true),
                    Month = table.Column<string>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    TimeWorked = table.Column<decimal>(nullable: false),
                    PaymentPerHour = table.Column<decimal>(nullable: false),
                    TotalPayment = table.Column<decimal>(nullable: false),
                    Payed = table.Column<bool>(nullable: false),
                    AmountPayed = table.Column<decimal>(nullable: false),
                    DueToPay = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SallaryReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SallaryReport_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SallaryReport_ReportStatus_ReportStatusId",
                        column: x => x.ReportStatusId,
                        principalTable: "ReportStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SallaryReport_PersonId",
                table: "SallaryReport",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_SallaryReport_ReportStatusId",
                table: "SallaryReport",
                column: "ReportStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SallaryReport");
        }
    }
}
