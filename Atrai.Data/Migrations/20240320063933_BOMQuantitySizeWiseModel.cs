using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class BOMQuantitySizeWiseModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "UniqueId",
                table: "BOMDetails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "BOMQuantitySizeWise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BOMDetailsId = table.Column<int>(type: "int", nullable: false),
                    UniqueId = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOMQuantitySizeWise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BOMQuantitySizeWise_BOMDetails_BOMDetailsId",
                        column: x => x.BOMDetailsId,
                        principalTable: "BOMDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BOMQuantitySizeWise_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BOMQuantitySizeWise_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BOMQuantitySizeWise_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BOMQuantitySizeWise_BOMDetailsId",
                table: "BOMQuantitySizeWise",
                column: "BOMDetailsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BOMQuantitySizeWise_ComId",
                table: "BOMQuantitySizeWise",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_BOMQuantitySizeWise_LuserId",
                table: "BOMQuantitySizeWise",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_BOMQuantitySizeWise_SizeId",
                table: "BOMQuantitySizeWise",
                column: "SizeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BOMQuantitySizeWise");

            migrationBuilder.DropColumn(
                name: "UniqueId",
                table: "BOMDetails");
        }
    }
}
