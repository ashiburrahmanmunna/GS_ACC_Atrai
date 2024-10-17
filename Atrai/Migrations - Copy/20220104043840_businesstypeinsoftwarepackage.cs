using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class businesstypeinsoftwarepackage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BusinessTypeId",
                table: "SoftwarePackage",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SoftwarePackage_BusinessTypeId",
                table: "SoftwarePackage",
                column: "BusinessTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SoftwarePackage_BusinessType_BusinessTypeId",
                table: "SoftwarePackage",
                column: "BusinessTypeId",
                principalTable: "BusinessType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoftwarePackage_BusinessType_BusinessTypeId",
                table: "SoftwarePackage");

            migrationBuilder.DropIndex(
                name: "IX_SoftwarePackage_BusinessTypeId",
                table: "SoftwarePackage");

            migrationBuilder.DropColumn(
                name: "BusinessTypeId",
                table: "SoftwarePackage");
        }
    }
}
