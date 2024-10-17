using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class addedPortOfDischarge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PortOfDischargeId",
                table: "MasterLC",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PortOfDischarge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortOfDischargeName = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    PortCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    CountrysId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortOfDischarge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortOfDischarge_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PortOfDischarge_Country_CountrysId",
                        column: x => x.CountrysId,
                        principalTable: "Country",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PortOfDischarge_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MasterLC_PortOfDischargeId",
                table: "MasterLC",
                column: "PortOfDischargeId");

            migrationBuilder.CreateIndex(
                name: "IX_PortOfDischarge_ComId",
                table: "PortOfDischarge",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_PortOfDischarge_CountrysId",
                table: "PortOfDischarge",
                column: "CountrysId");

            migrationBuilder.CreateIndex(
                name: "IX_PortOfDischarge_LuserId",
                table: "PortOfDischarge",
                column: "LuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_PortOfDischarge_PortOfDischargeId",
                table: "MasterLC",
                column: "PortOfDischargeId",
                principalTable: "PortOfDischarge",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_PortOfDischarge_PortOfDischargeId",
                table: "MasterLC");

            migrationBuilder.DropTable(
                name: "PortOfDischarge");

            migrationBuilder.DropIndex(
                name: "IX_MasterLC_PortOfDischargeId",
                table: "MasterLC");

            migrationBuilder.DropColumn(
                name: "PortOfDischargeId",
                table: "MasterLC");
        }
    }
}
