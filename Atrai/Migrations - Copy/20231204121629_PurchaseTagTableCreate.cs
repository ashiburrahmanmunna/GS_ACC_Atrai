using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class PurchaseTagTableCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "purchaseTag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseId = table.Column<int>(type: "int", nullable: false),
                    VoucherId = table.Column<int>(type: "int", nullable: true),
                    tag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchaseTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_purchaseTag_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_purchaseTag_Purchase_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "Purchase",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_purchaseTag_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_purchaseTag_ComId",
                table: "purchaseTag",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseTag_LuserId",
                table: "purchaseTag",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseTag_VoucherId",
                table: "purchaseTag",
                column: "VoucherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "purchaseTag");
        }
    }
}
