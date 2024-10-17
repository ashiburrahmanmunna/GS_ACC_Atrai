using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class MigrationName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountsReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tab = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Group = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ReportName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ControllerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsInActive = table.Column<bool>(type: "bit", nullable: false),
                    IsFavorite = table.Column<bool>(type: "bit", nullable: false),
                    SerialNo = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountsReport", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountsReport");
        }
    }
}
