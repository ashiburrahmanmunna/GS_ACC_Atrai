using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class ReportStyles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReportStyleId",
                table: "StoreSetting",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ReportStyle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportStyleName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ReportStyleRemarks = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsInActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportStyle", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoreSetting_ReportStyleId",
                table: "StoreSetting",
                column: "ReportStyleId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreSetting_ReportStyle_ReportStyleId",
                table: "StoreSetting",
                column: "ReportStyleId",
                principalTable: "ReportStyle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreSetting_ReportStyle_ReportStyleId",
                table: "StoreSetting");

            migrationBuilder.DropTable(
                name: "ReportStyle");

            migrationBuilder.DropIndex(
                name: "IX_StoreSetting_ReportStyleId",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "ReportStyleId",
                table: "StoreSetting");
        }
    }
}
