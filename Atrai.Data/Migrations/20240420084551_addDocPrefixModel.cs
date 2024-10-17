using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class addDocPrefixModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocPrefix",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocTypeId = table.Column<int>(type: "int", nullable: false),
                    DocPrefix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastDocNo = table.Column<int>(type: "int", nullable: false),
                    FirstDocNo = table.Column<int>(type: "int", nullable: false),
                    YearSuffix = table.Column<bool>(type: "bit", nullable: false),
                    MonthSuffix = table.Column<bool>(type: "bit", nullable: false),
                    LastGeneratedCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocPrefix", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocPrefix_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocPrefix_DocType_DocTypeId",
                        column: x => x.DocTypeId,
                        principalTable: "DocType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DocPrefix_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocPrefix_ComId",
                table: "DocPrefix",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_DocPrefix_DocTypeId",
                table: "DocPrefix",
                column: "DocTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DocPrefix_LuserId",
                table: "DocPrefix",
                column: "LuserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocPrefix");
        }
    }
}
