using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class removeSizeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Size_SizeId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSize_Size_SizeId",
                table: "ProductSize");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Sizes_SizeId",
                table: "Product",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSize_Sizes_SizeId",
                table: "ProductSize",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Sizes_SizeId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSize_Sizes_SizeId",
                table: "ProductSize");

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    SLNo = table.Column<int>(type: "int", nullable: false),
                    SizeName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SizeShortName = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isInactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Size_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Size_ComId",
                table: "Size",
                column: "ComId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Size_SizeId",
                table: "Product",
                column: "SizeId",
                principalTable: "Size",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSize_Size_SizeId",
                table: "ProductSize",
                column: "SizeId",
                principalTable: "Size",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
