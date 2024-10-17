using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class CustomReportsmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReportLink = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: true),
                    InActive = table.Column<bool>(type: "bit", nullable: false),
                    IsNew = table.Column<bool>(type: "bit", nullable: false),
                    IsManagement = table.Column<bool>(type: "bit", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    CustomValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    ComId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomReports_ReportGroup_GroupId",
                        column: x => x.GroupId,
                        principalTable: "ReportGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomReports_GroupId",
                table: "CustomReports",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomReports");
        }
    }
}
