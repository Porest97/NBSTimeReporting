using Microsoft.EntityFrameworkCore.Migrations;

namespace NBSTimeReporting.Migrations
{
    public partial class NBSAssetsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NBSAsset",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NBSAssetNumber = table.Column<string>(nullable: true),
                    NBSAssetName = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: true),
                    SiteId = table.Column<int>(nullable: true),
                    AssetStatusId = table.Column<int>(nullable: true),
                    AssetTypeId = table.Column<int>(nullable: true),
                    AssetBrandId = table.Column<int>(nullable: true),
                    MACAddress = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: true),
                    Connectivity = table.Column<string>(nullable: true),
                    LocalIP = table.Column<string>(nullable: true),
                    Ethernet1LLDP = table.Column<string>(nullable: true),
                    Ethernet1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NBSAsset", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NBSAsset_AssetBrand_AssetBrandId",
                        column: x => x.AssetBrandId,
                        principalTable: "AssetBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NBSAsset_AssetStatus_AssetStatusId",
                        column: x => x.AssetStatusId,
                        principalTable: "AssetStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NBSAsset_AssetType_AssetTypeId",
                        column: x => x.AssetTypeId,
                        principalTable: "AssetType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NBSAsset_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NBSAsset_Site_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NBSAsset_AssetBrandId",
                table: "NBSAsset",
                column: "AssetBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_NBSAsset_AssetStatusId",
                table: "NBSAsset",
                column: "AssetStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_NBSAsset_AssetTypeId",
                table: "NBSAsset",
                column: "AssetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NBSAsset_CompanyId",
                table: "NBSAsset",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_NBSAsset_SiteId",
                table: "NBSAsset",
                column: "SiteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NBSAsset");

            migrationBuilder.DropTable(
                name: "AssetStatus");
        }
    }
}
