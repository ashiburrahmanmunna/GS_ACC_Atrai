using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class customFormStyleModelUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFormStyle_CustomFormStyleVariable_FontFamilyId",
                table: "CustomFormStyle");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomFormStyle_CustomFormStyleVariable_FontSizeId",
                table: "CustomFormStyle");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomFormStyle_CustomFormStyleVariable_LogoPlacementId",
                table: "CustomFormStyle");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomFormStyle_CustomFormStyleVariable_LogoSizeId",
                table: "CustomFormStyle");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomFormStyle_CustomFormStyleVariable_PageMarginBottomId",
                table: "CustomFormStyle");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomFormStyle_CustomFormStyleVariable_PageMarginLeftId",
                table: "CustomFormStyle");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomFormStyle_CustomFormStyleVariable_PageMarginRightId",
                table: "CustomFormStyle");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomFormStyle_CustomFormStyleVariable_PageMarginTopId",
                table: "CustomFormStyle");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomFormStyle_CustomFormStyleVariable_TemplateId",
                table: "CustomFormStyle");

            migrationBuilder.DropIndex(
                name: "IX_CustomFormStyle_FontFamilyId",
                table: "CustomFormStyle");

            migrationBuilder.DropIndex(
                name: "IX_CustomFormStyle_FontSizeId",
                table: "CustomFormStyle");

            migrationBuilder.DropIndex(
                name: "IX_CustomFormStyle_LogoPlacementId",
                table: "CustomFormStyle");

            migrationBuilder.DropIndex(
                name: "IX_CustomFormStyle_LogoSizeId",
                table: "CustomFormStyle");

            migrationBuilder.DropIndex(
                name: "IX_CustomFormStyle_PageMarginBottomId",
                table: "CustomFormStyle");

            migrationBuilder.DropIndex(
                name: "IX_CustomFormStyle_PageMarginLeftId",
                table: "CustomFormStyle");

            migrationBuilder.DropIndex(
                name: "IX_CustomFormStyle_PageMarginRightId",
                table: "CustomFormStyle");

            migrationBuilder.DropIndex(
                name: "IX_CustomFormStyle_PageMarginTopId",
                table: "CustomFormStyle");

            migrationBuilder.DropIndex(
                name: "IX_CustomFormStyle_TemplateId",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "FontFamilyId",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "FontSizeId",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "LogoPlacementId",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "LogoSizeId",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "PageMarginBottomId",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "PageMarginLeftId",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "PageMarginRightId",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "PageMarginTopId",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "TemplateId",
                table: "CustomFormStyle");

            migrationBuilder.AddColumn<string>(
                name: "FontFamily",
                table: "CustomFormStyle",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FontSize",
                table: "CustomFormStyle",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogoPlacement",
                table: "CustomFormStyle",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogoSize",
                table: "CustomFormStyle",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PageMarginBottom",
                table: "CustomFormStyle",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PageMarginLeft",
                table: "CustomFormStyle",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PageMarginRight",
                table: "CustomFormStyle",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PageMarginTop",
                table: "CustomFormStyle",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Template",
                table: "CustomFormStyle",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FontFamily",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "FontSize",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "LogoPlacement",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "LogoSize",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "PageMarginBottom",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "PageMarginLeft",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "PageMarginRight",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "PageMarginTop",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "Template",
                table: "CustomFormStyle");

            migrationBuilder.AddColumn<int>(
                name: "FontFamilyId",
                table: "CustomFormStyle",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FontSizeId",
                table: "CustomFormStyle",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LogoPlacementId",
                table: "CustomFormStyle",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LogoSizeId",
                table: "CustomFormStyle",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PageMarginBottomId",
                table: "CustomFormStyle",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PageMarginLeftId",
                table: "CustomFormStyle",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PageMarginRightId",
                table: "CustomFormStyle",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PageMarginTopId",
                table: "CustomFormStyle",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TemplateId",
                table: "CustomFormStyle",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomFormStyle_FontFamilyId",
                table: "CustomFormStyle",
                column: "FontFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFormStyle_FontSizeId",
                table: "CustomFormStyle",
                column: "FontSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFormStyle_LogoPlacementId",
                table: "CustomFormStyle",
                column: "LogoPlacementId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFormStyle_LogoSizeId",
                table: "CustomFormStyle",
                column: "LogoSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFormStyle_PageMarginBottomId",
                table: "CustomFormStyle",
                column: "PageMarginBottomId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFormStyle_PageMarginLeftId",
                table: "CustomFormStyle",
                column: "PageMarginLeftId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFormStyle_PageMarginRightId",
                table: "CustomFormStyle",
                column: "PageMarginRightId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFormStyle_PageMarginTopId",
                table: "CustomFormStyle",
                column: "PageMarginTopId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFormStyle_TemplateId",
                table: "CustomFormStyle",
                column: "TemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFormStyle_CustomFormStyleVariable_FontFamilyId",
                table: "CustomFormStyle",
                column: "FontFamilyId",
                principalTable: "CustomFormStyleVariable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFormStyle_CustomFormStyleVariable_FontSizeId",
                table: "CustomFormStyle",
                column: "FontSizeId",
                principalTable: "CustomFormStyleVariable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFormStyle_CustomFormStyleVariable_LogoPlacementId",
                table: "CustomFormStyle",
                column: "LogoPlacementId",
                principalTable: "CustomFormStyleVariable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFormStyle_CustomFormStyleVariable_LogoSizeId",
                table: "CustomFormStyle",
                column: "LogoSizeId",
                principalTable: "CustomFormStyleVariable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFormStyle_CustomFormStyleVariable_PageMarginBottomId",
                table: "CustomFormStyle",
                column: "PageMarginBottomId",
                principalTable: "CustomFormStyleVariable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFormStyle_CustomFormStyleVariable_PageMarginLeftId",
                table: "CustomFormStyle",
                column: "PageMarginLeftId",
                principalTable: "CustomFormStyleVariable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFormStyle_CustomFormStyleVariable_PageMarginRightId",
                table: "CustomFormStyle",
                column: "PageMarginRightId",
                principalTable: "CustomFormStyleVariable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFormStyle_CustomFormStyleVariable_PageMarginTopId",
                table: "CustomFormStyle",
                column: "PageMarginTopId",
                principalTable: "CustomFormStyleVariable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFormStyle_CustomFormStyleVariable_TemplateId",
                table: "CustomFormStyle",
                column: "TemplateId",
                principalTable: "CustomFormStyleVariable",
                principalColumn: "Id");
        }
    }
}
