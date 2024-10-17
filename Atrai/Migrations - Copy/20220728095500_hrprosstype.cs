using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Invoice.Migrations
{
    public partial class hrprosstype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HR_ProssType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProssDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DaySts = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DayStsB = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsLock = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtTran = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_ProssType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HR_ProssType_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HR_ProssType_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HR_ProssType_ComId",
                table: "HR_ProssType",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_ProssType_LuserId",
                table: "HR_ProssType",
                column: "LuserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HR_ProssType");
        }
    }
}
