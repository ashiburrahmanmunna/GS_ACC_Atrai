using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class DestrinationModelAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Destination",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DestinationNameSearch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DestinationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DestinationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    CountrysId = table.Column<int>(type: "int", nullable: true),
                    ExportOrdersId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destination", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Destination_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Destination_Country_CountrysId",
                        column: x => x.CountrysId,
                        principalTable: "Country",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Destination_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExportOrder_DestinationID",
                table: "ExportOrder",
                column: "DestinationID");

            migrationBuilder.CreateIndex(
                name: "IX_Destination_ComId",
                table: "Destination",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Destination_CountrysId",
                table: "Destination",
                column: "CountrysId");

            migrationBuilder.CreateIndex(
                name: "IX_Destination_LuserId",
                table: "Destination",
                column: "LuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportOrder_Destination_DestinationID",
                table: "ExportOrder",
                column: "DestinationID",
                principalTable: "Destination",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExportOrder_Destination_DestinationID",
                table: "ExportOrder");

            migrationBuilder.DropTable(
                name: "Destination");

            migrationBuilder.DropIndex(
                name: "IX_ExportOrder_DestinationID",
                table: "ExportOrder");
        }
    }
}
