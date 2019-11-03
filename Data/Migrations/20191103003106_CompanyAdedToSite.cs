using Microsoft.EntityFrameworkCore.Migrations;

namespace NBSTimeReporting.Data.Migrations
{
    public partial class CompanyAdedToSite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Site",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Site_CompanyId",
                table: "Site",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Site_Company_CompanyId",
                table: "Site",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Site_Company_CompanyId",
                table: "Site");

            migrationBuilder.DropIndex(
                name: "IX_Site_CompanyId",
                table: "Site");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Site");
        }
    }
}
