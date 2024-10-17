using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class smssettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SmsSetting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    smsAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    smsUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    smsPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    smsSender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    smsCollection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    smsAbsent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    smsPresent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    smsLate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isInactive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SmsSetting_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SmsSetting_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SmsSetting_ComId",
                table: "SmsSetting",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_SmsSetting_LuserId",
                table: "SmsSetting",
                column: "LuserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SmsSetting");
        }
    }
}
