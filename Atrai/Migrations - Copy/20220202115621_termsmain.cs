using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Invoice.Migrations
{
    public partial class termsmain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TermsMain",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TermsName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TermsRemarks = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermsMain", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TermsMain_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TermsMain_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TermsSub",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Terms = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TermsDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    TermsSerialNo = table.Column<int>(type: "int", nullable: false),
                    TermsId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermsSub", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TermsSub_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TermsSub_TermsMain_TermsId",
                        column: x => x.TermsId,
                        principalTable: "TermsMain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TermsSub_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TermsMain_ComId",
                table: "TermsMain",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_TermsMain_LuserId",
                table: "TermsMain",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_TermsSub_ComId",
                table: "TermsSub",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_TermsSub_LuserId",
                table: "TermsSub",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_TermsSub_TermsId",
                table: "TermsSub",
                column: "TermsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TermsSub");

            migrationBuilder.DropTable(
                name: "TermsMain");
        }
    }
}
