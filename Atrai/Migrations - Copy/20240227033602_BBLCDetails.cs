using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class BBLCDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BBLC_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BBLCMainId = table.Column<int>(type: "int", nullable: true),
                    PIId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BBLC_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BBLC_Details_BBLCMaster_BBLCMainId",
                        column: x => x.BBLCMainId,
                        principalTable: "BBLCMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BBLC_Details_COM_ProformaInvoices_PIId",
                        column: x => x.PIId,
                        principalTable: "COM_ProformaInvoices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BBLC_Details_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BBLC_Details_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BBLC_Details_BBLCMainId",
                table: "BBLC_Details",
                column: "BBLCMainId");

            migrationBuilder.CreateIndex(
                name: "IX_BBLC_Details_ComId",
                table: "BBLC_Details",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_BBLC_Details_LuserId",
                table: "BBLC_Details",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_BBLC_Details_PIId",
                table: "BBLC_Details",
                column: "PIId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BBLC_Details");
        }
    }
}
