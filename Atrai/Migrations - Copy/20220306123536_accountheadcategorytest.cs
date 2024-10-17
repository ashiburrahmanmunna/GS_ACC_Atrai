using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class accountheadcategorytest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccIdConsumption",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccIdInventory",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccIdSales",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountCategoryId",
                table: "AccountHead",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AccountCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountCategory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_AccIdConsumption",
                table: "Product",
                column: "AccIdConsumption");

            migrationBuilder.CreateIndex(
                name: "IX_Product_AccIdInventory",
                table: "Product",
                column: "AccIdInventory");

            migrationBuilder.CreateIndex(
                name: "IX_Product_AccIdSales",
                table: "Product",
                column: "AccIdSales");

            migrationBuilder.CreateIndex(
                name: "IX_AccountHead_AccountCategoryId",
                table: "AccountHead",
                column: "AccountCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountHead_AccountCategory_AccountCategoryId",
                table: "AccountHead",
                column: "AccountCategoryId",
                principalTable: "AccountCategory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_AccountHead_AccIdConsumption",
                table: "Product",
                column: "AccIdConsumption",
                principalTable: "AccountHead",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_AccountHead_AccIdInventory",
                table: "Product",
                column: "AccIdInventory",
                principalTable: "AccountHead",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_AccountHead_AccIdSales",
                table: "Product",
                column: "AccIdSales",
                principalTable: "AccountHead",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountHead_AccountCategory_AccountCategoryId",
                table: "AccountHead");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_AccountHead_AccIdConsumption",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_AccountHead_AccIdInventory",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_AccountHead_AccIdSales",
                table: "Product");

            migrationBuilder.DropTable(
                name: "AccountCategory");

            migrationBuilder.DropIndex(
                name: "IX_Product_AccIdConsumption",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_AccIdInventory",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_AccIdSales",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_AccountHead_AccountCategoryId",
                table: "AccountHead");

            migrationBuilder.DropColumn(
                name: "AccIdConsumption",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "AccIdInventory",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "AccIdSales",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "AccountCategoryId",
                table: "AccountHead");
        }
    }
}
