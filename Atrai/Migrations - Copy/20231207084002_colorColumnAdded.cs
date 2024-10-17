using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class colorColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Custom Form Style_Company_ComId",
                table: "Custom Form Style");

            migrationBuilder.DropForeignKey(
                name: "FK_Custom Form Style_CustomFormStyleVariable_ColorsId",
                table: "Custom Form Style");

            migrationBuilder.DropForeignKey(
                name: "FK_Custom Form Style_CustomFormStyleVariable_FontFamiliesId",
                table: "Custom Form Style");

            migrationBuilder.DropForeignKey(
                name: "FK_Custom Form Style_CustomFormStyleVariable_FontSizesId",
                table: "Custom Form Style");

            migrationBuilder.DropForeignKey(
                name: "FK_Custom Form Style_CustomFormStyleVariable_LogoPlacementsId",
                table: "Custom Form Style");

            migrationBuilder.DropForeignKey(
                name: "FK_Custom Form Style_CustomFormStyleVariable_LogoSizesId",
                table: "Custom Form Style");

            migrationBuilder.DropForeignKey(
                name: "FK_Custom Form Style_CustomFormStyleVariable_PageMarginBottomsId",
                table: "Custom Form Style");

            migrationBuilder.DropForeignKey(
                name: "FK_Custom Form Style_CustomFormStyleVariable_PageMarginLeftsId",
                table: "Custom Form Style");

            migrationBuilder.DropForeignKey(
                name: "FK_Custom Form Style_CustomFormStyleVariable_PageMarginRightsId",
                table: "Custom Form Style");

            migrationBuilder.DropForeignKey(
                name: "FK_Custom Form Style_CustomFormStyleVariable_PageMarginTopsId",
                table: "Custom Form Style");

            migrationBuilder.DropForeignKey(
                name: "FK_Custom Form Style_CustomFormStyleVariable_TemplatesId",
                table: "Custom Form Style");

            migrationBuilder.DropForeignKey(
                name: "FK_Custom Form Style_UserAccount_LuserId",
                table: "Custom Form Style");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Custom Form Style",
                table: "Custom Form Style");

            migrationBuilder.DropIndex(
                name: "IX_Custom Form Style_ColorsId",
                table: "Custom Form Style");

            migrationBuilder.DropIndex(
                name: "IX_Custom Form Style_FontFamiliesId",
                table: "Custom Form Style");

            migrationBuilder.DropIndex(
                name: "IX_Custom Form Style_FontSizesId",
                table: "Custom Form Style");

            migrationBuilder.DropIndex(
                name: "IX_Custom Form Style_LogoPlacementsId",
                table: "Custom Form Style");

            migrationBuilder.DropIndex(
                name: "IX_Custom Form Style_LogoSizesId",
                table: "Custom Form Style");

            migrationBuilder.DropIndex(
                name: "IX_Custom Form Style_PageMarginBottomsId",
                table: "Custom Form Style");

            migrationBuilder.DropIndex(
                name: "IX_Custom Form Style_PageMarginLeftsId",
                table: "Custom Form Style");

            migrationBuilder.DropIndex(
                name: "IX_Custom Form Style_PageMarginRightsId",
                table: "Custom Form Style");

            migrationBuilder.DropIndex(
                name: "IX_Custom Form Style_PageMarginTopsId",
                table: "Custom Form Style");

            migrationBuilder.DropIndex(
                name: "IX_Custom Form Style_TemplatesId",
                table: "Custom Form Style");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Custom Form Style");

            migrationBuilder.DropColumn(
                name: "ColorsId",
                table: "Custom Form Style");

            migrationBuilder.DropColumn(
                name: "FontFamiliesId",
                table: "Custom Form Style");

            migrationBuilder.DropColumn(
                name: "FontSizesId",
                table: "Custom Form Style");

            migrationBuilder.DropColumn(
                name: "LogoPlacementsId",
                table: "Custom Form Style");

            migrationBuilder.DropColumn(
                name: "LogoSizesId",
                table: "Custom Form Style");

            migrationBuilder.DropColumn(
                name: "PageMarginBottomsId",
                table: "Custom Form Style");

            migrationBuilder.DropColumn(
                name: "PageMarginLeftsId",
                table: "Custom Form Style");

            migrationBuilder.DropColumn(
                name: "PageMarginRightsId",
                table: "Custom Form Style");

            migrationBuilder.DropColumn(
                name: "PageMarginTopsId",
                table: "Custom Form Style");

            migrationBuilder.DropColumn(
                name: "TemplatesId",
                table: "Custom Form Style");

            migrationBuilder.RenameTable(
                name: "Custom Form Style",
                newName: "CustomFormStyle");

            migrationBuilder.RenameIndex(
                name: "IX_Custom Form Style_LuserId",
                table: "CustomFormStyle",
                newName: "IX_CustomFormStyle_LuserId");

            migrationBuilder.RenameIndex(
                name: "IX_Custom Form Style_ComId",
                table: "CustomFormStyle",
                newName: "IX_CustomFormStyle_ComId");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "CustomFormStyle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomFormStyle",
                table: "CustomFormStyle",
                column: "Id");

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
                name: "FK_CustomFormStyle_Company_ComId",
                table: "CustomFormStyle",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFormStyle_UserAccount_LuserId",
                table: "CustomFormStyle",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFormStyle_Company_ComId",
                table: "CustomFormStyle");

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

            migrationBuilder.DropForeignKey(
                name: "FK_CustomFormStyle_UserAccount_LuserId",
                table: "CustomFormStyle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomFormStyle",
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
                name: "Color",
                table: "CustomFormStyle");

            migrationBuilder.RenameTable(
                name: "CustomFormStyle",
                newName: "Custom Form Style");

            migrationBuilder.RenameIndex(
                name: "IX_CustomFormStyle_LuserId",
                table: "Custom Form Style",
                newName: "IX_Custom Form Style_LuserId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomFormStyle_ComId",
                table: "Custom Form Style",
                newName: "IX_Custom Form Style_ComId");

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Custom Form Style",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorsId",
                table: "Custom Form Style",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FontFamiliesId",
                table: "Custom Form Style",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FontSizesId",
                table: "Custom Form Style",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LogoPlacementsId",
                table: "Custom Form Style",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LogoSizesId",
                table: "Custom Form Style",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PageMarginBottomsId",
                table: "Custom Form Style",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PageMarginLeftsId",
                table: "Custom Form Style",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PageMarginRightsId",
                table: "Custom Form Style",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PageMarginTopsId",
                table: "Custom Form Style",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TemplatesId",
                table: "Custom Form Style",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Custom Form Style",
                table: "Custom Form Style",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Custom Form Style_ColorsId",
                table: "Custom Form Style",
                column: "ColorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Custom Form Style_FontFamiliesId",
                table: "Custom Form Style",
                column: "FontFamiliesId");

            migrationBuilder.CreateIndex(
                name: "IX_Custom Form Style_FontSizesId",
                table: "Custom Form Style",
                column: "FontSizesId");

            migrationBuilder.CreateIndex(
                name: "IX_Custom Form Style_LogoPlacementsId",
                table: "Custom Form Style",
                column: "LogoPlacementsId");

            migrationBuilder.CreateIndex(
                name: "IX_Custom Form Style_LogoSizesId",
                table: "Custom Form Style",
                column: "LogoSizesId");

            migrationBuilder.CreateIndex(
                name: "IX_Custom Form Style_PageMarginBottomsId",
                table: "Custom Form Style",
                column: "PageMarginBottomsId");

            migrationBuilder.CreateIndex(
                name: "IX_Custom Form Style_PageMarginLeftsId",
                table: "Custom Form Style",
                column: "PageMarginLeftsId");

            migrationBuilder.CreateIndex(
                name: "IX_Custom Form Style_PageMarginRightsId",
                table: "Custom Form Style",
                column: "PageMarginRightsId");

            migrationBuilder.CreateIndex(
                name: "IX_Custom Form Style_PageMarginTopsId",
                table: "Custom Form Style",
                column: "PageMarginTopsId");

            migrationBuilder.CreateIndex(
                name: "IX_Custom Form Style_TemplatesId",
                table: "Custom Form Style",
                column: "TemplatesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Custom Form Style_Company_ComId",
                table: "Custom Form Style",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Custom Form Style_CustomFormStyleVariable_ColorsId",
                table: "Custom Form Style",
                column: "ColorsId",
                principalTable: "CustomFormStyleVariable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Custom Form Style_CustomFormStyleVariable_FontFamiliesId",
                table: "Custom Form Style",
                column: "FontFamiliesId",
                principalTable: "CustomFormStyleVariable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Custom Form Style_CustomFormStyleVariable_FontSizesId",
                table: "Custom Form Style",
                column: "FontSizesId",
                principalTable: "CustomFormStyleVariable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Custom Form Style_CustomFormStyleVariable_LogoPlacementsId",
                table: "Custom Form Style",
                column: "LogoPlacementsId",
                principalTable: "CustomFormStyleVariable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Custom Form Style_CustomFormStyleVariable_LogoSizesId",
                table: "Custom Form Style",
                column: "LogoSizesId",
                principalTable: "CustomFormStyleVariable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Custom Form Style_CustomFormStyleVariable_PageMarginBottomsId",
                table: "Custom Form Style",
                column: "PageMarginBottomsId",
                principalTable: "CustomFormStyleVariable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Custom Form Style_CustomFormStyleVariable_PageMarginLeftsId",
                table: "Custom Form Style",
                column: "PageMarginLeftsId",
                principalTable: "CustomFormStyleVariable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Custom Form Style_CustomFormStyleVariable_PageMarginRightsId",
                table: "Custom Form Style",
                column: "PageMarginRightsId",
                principalTable: "CustomFormStyleVariable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Custom Form Style_CustomFormStyleVariable_PageMarginTopsId",
                table: "Custom Form Style",
                column: "PageMarginTopsId",
                principalTable: "CustomFormStyleVariable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Custom Form Style_CustomFormStyleVariable_TemplatesId",
                table: "Custom Form Style",
                column: "TemplatesId",
                principalTable: "CustomFormStyleVariable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Custom Form Style_UserAccount_LuserId",
                table: "Custom Form Style",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
