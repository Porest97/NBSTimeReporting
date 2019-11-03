using Microsoft.EntityFrameworkCore.Migrations;

namespace NBSTimeReporting.Data.Migrations
{
    public partial class ChangingInCopnies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_ComapnyRole_CompanyRoleId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_ComapnyStatus_CompanyStatusId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_ComapnyType_CompanyTypeId",
                table: "Company");

            migrationBuilder.DropTable(
                name: "ComapnyRole");

            migrationBuilder.DropTable(
                name: "ComapnyStatus");

            migrationBuilder.DropTable(
                name: "ComapnyType");

            migrationBuilder.CreateTable(
                name: "CompanyRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyRoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyType", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Company_CompanyRole_CompanyRoleId",
                table: "Company",
                column: "CompanyRoleId",
                principalTable: "CompanyRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_CompanyStatus_CompanyStatusId",
                table: "Company",
                column: "CompanyStatusId",
                principalTable: "CompanyStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_CompanyType_CompanyTypeId",
                table: "Company",
                column: "CompanyTypeId",
                principalTable: "CompanyType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_CompanyRole_CompanyRoleId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_CompanyStatus_CompanyStatusId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_CompanyType_CompanyTypeId",
                table: "Company");

            migrationBuilder.DropTable(
                name: "CompanyRole");

            migrationBuilder.DropTable(
                name: "CompanyStatus");

            migrationBuilder.DropTable(
                name: "CompanyType");

            migrationBuilder.CreateTable(
                name: "ComapnyRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyRoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComapnyRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComapnyStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyStatusName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComapnyStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComapnyType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComapnyType", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Company_ComapnyRole_CompanyRoleId",
                table: "Company",
                column: "CompanyRoleId",
                principalTable: "ComapnyRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_ComapnyStatus_CompanyStatusId",
                table: "Company",
                column: "CompanyStatusId",
                principalTable: "ComapnyStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_ComapnyType_CompanyTypeId",
                table: "Company",
                column: "CompanyTypeId",
                principalTable: "ComapnyType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
