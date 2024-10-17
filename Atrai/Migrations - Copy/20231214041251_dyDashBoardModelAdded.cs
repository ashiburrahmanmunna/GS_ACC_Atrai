using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class dyDashBoardModelAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "CustomFormStyle",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FontColor",
                table: "CustomFormStyle",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DyDashBoard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ChartType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ChartTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GroupBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GroupFilterValue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AdditionalFilter = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AdditionalFilterValue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DyDashBoard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DyDashBoard_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DyDashBoard_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DyDashBoard_ComId",
                table: "DyDashBoard",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_DyDashBoard_LuserId",
                table: "DyDashBoard",
                column: "LuserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DyDashBoard");

            migrationBuilder.DropColumn(
                name: "FontColor",
                table: "CustomFormStyle");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "CustomFormStyle",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);
        }
    }
}
