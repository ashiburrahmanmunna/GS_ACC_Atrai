using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class docStatusAndStatusModelAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocStatus_DocType_DocTypeId",
                table: "DocStatus");

            migrationBuilder.DropColumn(
                name: "DocStatus",
                table: "DocStatus");

            migrationBuilder.DropColumn(
                name: "DocStatusShort",
                table: "DocStatus");

            migrationBuilder.AlterColumn<int>(
                name: "DocTypeId",
                table: "DocStatus",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "DocStatus",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SLNo = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StatusShort = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocStatus_StatusId",
                table: "DocStatus",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocStatus_DocType_DocTypeId",
                table: "DocStatus",
                column: "DocTypeId",
                principalTable: "DocType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocStatus_Status_StatusId",
                table: "DocStatus",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocStatus_DocType_DocTypeId",
                table: "DocStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_DocStatus_Status_StatusId",
                table: "DocStatus");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_DocStatus_StatusId",
                table: "DocStatus");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "DocStatus");

            migrationBuilder.AlterColumn<int>(
                name: "DocTypeId",
                table: "DocStatus",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocStatus",
                table: "DocStatus",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocStatusShort",
                table: "DocStatus",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DocStatus_DocType_DocTypeId",
                table: "DocStatus",
                column: "DocTypeId",
                principalTable: "DocType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
