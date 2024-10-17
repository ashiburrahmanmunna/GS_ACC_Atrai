using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class removeColorModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Color_ColorId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductColor_Color_ColorId",
                table: "ProductColor");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Colors_ColorId",
                table: "Product",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColor_Colors_ColorId",
                table: "ProductColor",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Colors_ColorId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductColor_Colors_ColorId",
                table: "ProductColor");

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<int>(type: "int", nullable: true),
                    ColorCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ColorName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ColorShortName = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isInactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Color_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Color_ComId",
                table: "Color",
                column: "ComId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Color_ColorId",
                table: "Product",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColor_Color_ColorId",
                table: "ProductColor",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
