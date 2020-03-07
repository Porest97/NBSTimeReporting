using Microsoft.EntityFrameworkCore.Migrations;

namespace NBSTimeReporting.Data.Migrations
{
    public partial class CCAddedInCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Company",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Company_PersonId",
                table: "Company",
                column: "PersonId",
                unique: true,
                filter: "[PersonId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Person_PersonId",
                table: "Company",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Person_PersonId",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_PersonId",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Company");
        }
    }
}
