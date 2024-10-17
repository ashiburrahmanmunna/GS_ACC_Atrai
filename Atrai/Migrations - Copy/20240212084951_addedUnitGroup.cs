using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class addedUnitGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnitGroupId",
                table: "UnitMaster",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UnitGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitGroup_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnitGroup_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UnitMaster_UnitGroupId",
                table: "UnitMaster",
                column: "UnitGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitGroup_ComId",
                table: "UnitGroup",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitGroup_LuserId",
                table: "UnitGroup",
                column: "LuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UnitMaster_UnitGroup_UnitGroupId",
                table: "UnitMaster",
                column: "UnitGroupId",
                principalTable: "UnitGroup",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnitMaster_UnitGroup_UnitGroupId",
                table: "UnitMaster");

            migrationBuilder.DropTable(
                name: "UnitGroup");

            migrationBuilder.DropIndex(
                name: "IX_UnitMaster_UnitGroupId",
                table: "UnitMaster");

            migrationBuilder.DropColumn(
                name: "UnitGroupId",
                table: "UnitMaster");
        }
    }
}
