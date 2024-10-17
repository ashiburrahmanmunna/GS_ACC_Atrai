using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class addedGroupLCSub : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupLC_Sub",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupLCId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupLC_Sub", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupLC_Sub_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupLC_Sub_GroupLC_Main_GroupLCId",
                        column: x => x.GroupLCId,
                        principalTable: "GroupLC_Main",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GroupLC_Sub_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupLC_Sub_ComId",
                table: "GroupLC_Sub",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupLC_Sub_GroupLCId",
                table: "GroupLC_Sub",
                column: "GroupLCId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupLC_Sub_LuserId",
                table: "GroupLC_Sub",
                column: "LuserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupLC_Sub");
        }
    }
}
