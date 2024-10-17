using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class addedItemDesc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemDescription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemDescCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescHSCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ItemDescShortName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ItemGroupId = table.Column<int>(type: "int", nullable: true),
                    ItemGroupsId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDescription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemDescription_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemDescription_ItemGroup_ItemGroupsId",
                        column: x => x.ItemGroupsId,
                        principalTable: "ItemGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItemDescription_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemDescription_ComId",
                table: "ItemDescription",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDescription_ItemGroupsId",
                table: "ItemDescription",
                column: "ItemGroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDescription_LuserId",
                table: "ItemDescription",
                column: "LuserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemDescription");
        }
    }
}
