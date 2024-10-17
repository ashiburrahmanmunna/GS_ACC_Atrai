using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class addedPortOfLoading : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PortOfLoadingId",
                table: "MasterLC",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PortOfLoading",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortOfLoadingName = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
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
                    table.PrimaryKey("PK_PortOfLoading", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortOfLoading_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PortOfLoading_Country_CountrysId",
                        column: x => x.CountrysId,
                        principalTable: "Country",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PortOfLoading_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MasterLC_PortOfLoadingId",
                table: "MasterLC",
                column: "PortOfLoadingId");

            migrationBuilder.CreateIndex(
                name: "IX_PortOfLoading_ComId",
                table: "PortOfLoading",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_PortOfLoading_CountrysId",
                table: "PortOfLoading",
                column: "CountrysId");

            migrationBuilder.CreateIndex(
                name: "IX_PortOfLoading_LuserId",
                table: "PortOfLoading",
                column: "LuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_PortOfLoading_PortOfLoadingId",
                table: "MasterLC",
                column: "PortOfLoadingId",
                principalTable: "PortOfLoading",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_PortOfLoading_PortOfLoadingId",
                table: "MasterLC");

            migrationBuilder.DropTable(
                name: "PortOfLoading");

            migrationBuilder.DropIndex(
                name: "IX_MasterLC_PortOfLoadingId",
                table: "MasterLC");

            migrationBuilder.DropColumn(
                name: "PortOfLoadingId",
                table: "MasterLC");
        }
    }
}
