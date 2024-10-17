using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class softwarepackageincompnay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SoftwarePackageId",
                table: "StoreSetting",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoreSetting_SoftwarePackageId",
                table: "StoreSetting",
                column: "SoftwarePackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreSetting_SoftwarePackage_SoftwarePackageId",
                table: "StoreSetting",
                column: "SoftwarePackageId",
                principalTable: "SoftwarePackage",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreSetting_SoftwarePackage_SoftwarePackageId",
                table: "StoreSetting");

            migrationBuilder.DropIndex(
                name: "IX_StoreSetting_SoftwarePackageId",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "SoftwarePackageId",
                table: "StoreSetting");
        }
    }
}
