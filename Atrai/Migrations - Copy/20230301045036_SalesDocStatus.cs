using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class SalesDocStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocStatusId",
                table: "Sales",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DocStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SLNo = table.Column<int>(type: "int", nullable: false),
                    DocStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DocStatusShort = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DocTypeId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocStatus_DocType_DocTypeId",
                        column: x => x.DocTypeId,
                        principalTable: "DocType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_DocStatusId",
                table: "Sales",
                column: "DocStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DocStatus_DocTypeId",
                table: "DocStatus",
                column: "DocTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_DocStatus_DocStatusId",
                table: "Sales",
                column: "DocStatusId",
                principalTable: "DocStatus",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_DocStatus_DocStatusId",
                table: "Sales");

            migrationBuilder.DropTable(
                name: "DocStatus");

            migrationBuilder.DropIndex(
                name: "IX_Sales_DocStatusId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "DocStatusId",
                table: "Sales");
        }
    }
}
