using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class styleModelChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColorChild_Colors_ColorsId",
                table: "ColorChild");

            migrationBuilder.DropForeignKey(
                name: "FK_SizeChild_Sizes_SizesId",
                table: "SizeChild");

            migrationBuilder.DropForeignKey(
                name: "FK_Style_Customer_BuyersId",
                table: "Style");

            migrationBuilder.DropIndex(
                name: "IX_Style_BuyersId",
                table: "Style");

            migrationBuilder.DropIndex(
                name: "IX_SizeChild_SizesId",
                table: "SizeChild");

            migrationBuilder.DropIndex(
                name: "IX_ColorChild_ColorsId",
                table: "ColorChild");

            migrationBuilder.DropColumn(
                name: "BuyersId",
                table: "Style");

            migrationBuilder.DropColumn(
                name: "SizesId",
                table: "SizeChild");

            migrationBuilder.DropColumn(
                name: "ColorsId",
                table: "ColorChild");

            migrationBuilder.CreateIndex(
                name: "IX_Style_BuyerId",
                table: "Style",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_SizeChild_SizeId",
                table: "SizeChild",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_ColorChild_ColorId",
                table: "ColorChild",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ColorChild_Colors_ColorId",
                table: "ColorChild",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_SizeChild_Sizes_SizeId",
                table: "SizeChild",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Style_Customer_BuyerId",
                table: "Style",
                column: "BuyerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColorChild_Colors_ColorId",
                table: "ColorChild");

            migrationBuilder.DropForeignKey(
                name: "FK_SizeChild_Sizes_SizeId",
                table: "SizeChild");

            migrationBuilder.DropForeignKey(
                name: "FK_Style_Customer_BuyerId",
                table: "Style");

            migrationBuilder.DropIndex(
                name: "IX_Style_BuyerId",
                table: "Style");

            migrationBuilder.DropIndex(
                name: "IX_SizeChild_SizeId",
                table: "SizeChild");

            migrationBuilder.DropIndex(
                name: "IX_ColorChild_ColorId",
                table: "ColorChild");

            migrationBuilder.AddColumn<int>(
                name: "BuyersId",
                table: "Style",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SizesId",
                table: "SizeChild",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorsId",
                table: "ColorChild",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Style_BuyersId",
                table: "Style",
                column: "BuyersId");

            migrationBuilder.CreateIndex(
                name: "IX_SizeChild_SizesId",
                table: "SizeChild",
                column: "SizesId");

            migrationBuilder.CreateIndex(
                name: "IX_ColorChild_ColorsId",
                table: "ColorChild",
                column: "ColorsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ColorChild_Colors_ColorsId",
                table: "ColorChild",
                column: "ColorsId",
                principalTable: "Colors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SizeChild_Sizes_SizesId",
                table: "SizeChild",
                column: "SizesId",
                principalTable: "Sizes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Style_Customer_BuyersId",
                table: "Style",
                column: "BuyersId",
                principalTable: "Customer",
                principalColumn: "Id");
        }
    }
}
