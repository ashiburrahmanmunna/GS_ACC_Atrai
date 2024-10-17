using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class vouchertags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acc_VoucherTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherId = table.Column<int>(type: "int", nullable: false),
                    tag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Acc_VoucherSubModelId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_VoucherTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherTags_Acc_VoucherMain_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "Acc_VoucherMain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherTags_Acc_VoucherSub_Acc_VoucherSubModelId",
                        column: x => x.Acc_VoucherSubModelId,
                        principalTable: "Acc_VoucherSub",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Acc_VoucherTags_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherTags_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherTags_Acc_VoucherSubModelId",
                table: "Acc_VoucherTags",
                column: "Acc_VoucherSubModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherTags_ComId",
                table: "Acc_VoucherTags",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherTags_LuserId",
                table: "Acc_VoucherTags",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherTags_VoucherId",
                table: "Acc_VoucherTags",
                column: "VoucherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acc_VoucherTags");
        }
    }
}
