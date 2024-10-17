using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class Doctypemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isQuotation",
                table: "Sales");

            migrationBuilder.AddColumn<int>(
                name: "DocTypeId",
                table: "Sales",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DocType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SLNo = table.Column<int>(type: "int", nullable: false),
                    DocFor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_DocTypeId",
                table: "Sales",
                column: "DocTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_InternetUser_DocTypeId",
                table: "Sales",
                column: "DocTypeId",
                principalTable: "InternetUser",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_InternetUser_DocTypeId",
                table: "Sales");

            migrationBuilder.DropTable(
                name: "DocType");

            migrationBuilder.DropIndex(
                name: "IX_Sales_DocTypeId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "DocTypeId",
                table: "Sales");

            migrationBuilder.AddColumn<int>(
                name: "isQuotation",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
