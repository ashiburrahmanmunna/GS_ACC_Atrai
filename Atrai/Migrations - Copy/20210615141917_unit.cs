using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Invoice.Migrations
{
    public partial class unit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "vUnitId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UnitNameBangla = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UnitShortName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_vUnitId",
                table: "Product",
                column: "vUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Unit_vUnitId",
                table: "Product",
                column: "vUnitId",
                principalTable: "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Unit_vUnitId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropIndex(
                name: "IX_Product_vUnitId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "vUnitId",
                table: "Product");
        }
    }
}
