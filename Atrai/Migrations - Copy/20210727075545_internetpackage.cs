using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class internetpackage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PackageId",
                table: "InternetMember",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "InternetPackage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Speed = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PackageActiveDay = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PackageAmount = table.Column<float>(type: "real", maxLength: 100, nullable: false),
                    PackageDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternetPackage", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InternetMember_PackageId",
                table: "InternetMember",
                column: "PackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_InternetMember_InternetPackage_PackageId",
                table: "InternetMember",
                column: "PackageId",
                principalTable: "InternetPackage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InternetMember_InternetPackage_PackageId",
                table: "InternetMember");

            migrationBuilder.DropTable(
                name: "InternetPackage");

            migrationBuilder.DropIndex(
                name: "IX_InternetMember_PackageId",
                table: "InternetMember");

            migrationBuilder.AlterColumn<string>(
                name: "PackageId",
                table: "InternetMember",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
