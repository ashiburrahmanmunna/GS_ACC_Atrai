using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class CustomFormStyleAndVariableTablecreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportStyleMainModel");

            migrationBuilder.DropTable(
                name: "ReportStyleVariableModel");

            migrationBuilder.CreateTable(
                name: "CustomFormStyleVariable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VariableName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    VariableValue = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    VariableFor = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomFormStyleVariable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Custom Form Style",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsInActive = table.Column<bool>(type: "bit", nullable: false),
                    ReportFor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TemplateId = table.Column<int>(type: "int", nullable: true),
                    TemplatesId = table.Column<int>(type: "int", nullable: true),
                    BusinessName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    ColorsId = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LogoSizeId = table.Column<int>(type: "int", nullable: true),
                    LogoSizesId = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FontSizeId = table.Column<int>(type: "int", nullable: true),
                    FontSizesId = table.Column<int>(type: "int", nullable: true),
                    CompanyRegNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LogoPlacementId = table.Column<int>(type: "int", nullable: true),
                    LogoPlacementsId = table.Column<int>(type: "int", nullable: true),
                    BusinessAllAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FontFamilyId = table.Column<int>(type: "int", nullable: true),
                    FontFamiliesId = table.Column<int>(type: "int", nullable: true),
                    PageMarginLeftId = table.Column<int>(type: "int", nullable: true),
                    PageMarginLeftsId = table.Column<int>(type: "int", nullable: true),
                    PageMarginRightId = table.Column<int>(type: "int", nullable: true),
                    PageMarginRightsId = table.Column<int>(type: "int", nullable: true),
                    PageMarginTopId = table.Column<int>(type: "int", nullable: true),
                    PageMarginTopsId = table.Column<int>(type: "int", nullable: true),
                    PageMarginBottomId = table.Column<int>(type: "int", nullable: true),
                    PageMarginBottomsId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Custom Form Style", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Custom Form Style_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Custom Form Style_CustomFormStyleVariable_ColorsId",
                        column: x => x.ColorsId,
                        principalTable: "CustomFormStyleVariable",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Custom Form Style_CustomFormStyleVariable_FontFamiliesId",
                        column: x => x.FontFamiliesId,
                        principalTable: "CustomFormStyleVariable",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Custom Form Style_CustomFormStyleVariable_FontSizesId",
                        column: x => x.FontSizesId,
                        principalTable: "CustomFormStyleVariable",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Custom Form Style_CustomFormStyleVariable_LogoPlacementsId",
                        column: x => x.LogoPlacementsId,
                        principalTable: "CustomFormStyleVariable",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Custom Form Style_CustomFormStyleVariable_LogoSizesId",
                        column: x => x.LogoSizesId,
                        principalTable: "CustomFormStyleVariable",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Custom Form Style_CustomFormStyleVariable_PageMarginBottomsId",
                        column: x => x.PageMarginBottomsId,
                        principalTable: "CustomFormStyleVariable",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Custom Form Style_CustomFormStyleVariable_PageMarginLeftsId",
                        column: x => x.PageMarginLeftsId,
                        principalTable: "CustomFormStyleVariable",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Custom Form Style_CustomFormStyleVariable_PageMarginRightsId",
                        column: x => x.PageMarginRightsId,
                        principalTable: "CustomFormStyleVariable",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Custom Form Style_CustomFormStyleVariable_PageMarginTopsId",
                        column: x => x.PageMarginTopsId,
                        principalTable: "CustomFormStyleVariable",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Custom Form Style_CustomFormStyleVariable_TemplatesId",
                        column: x => x.TemplatesId,
                        principalTable: "CustomFormStyleVariable",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Custom Form Style_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Custom Form Style_ColorsId",
                table: "Custom Form Style",
                column: "ColorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Custom Form Style_ComId",
                table: "Custom Form Style",
                column: "ComId");

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
                name: "IX_Custom Form Style_LuserId",
                table: "Custom Form Style",
                column: "LuserId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Custom Form Style");

            migrationBuilder.DropTable(
                name: "CustomFormStyleVariable");

            migrationBuilder.CreateTable(
                name: "ReportStyleVariableModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VariableFor = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    VariableName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    VariableValue = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportStyleVariableModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportStyleMainModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    FontFamilyVariableId = table.Column<int>(type: "int", nullable: true),
                    FontSizeId = table.Column<int>(type: "int", nullable: true),
                    LogoPlacementId = table.Column<int>(type: "int", nullable: true),
                    LogoSizeId = table.Column<int>(type: "int", nullable: true),
                    TemplateId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FontFamilyId = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsInActive = table.Column<bool>(type: "bit", nullable: false),
                    ReportFor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportStyleMainModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportStyleMainModel_ReportStyleVariableModel_ColorId",
                        column: x => x.ColorId,
                        principalTable: "ReportStyleVariableModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReportStyleMainModel_ReportStyleVariableModel_FontFamilyVariableId",
                        column: x => x.FontFamilyVariableId,
                        principalTable: "ReportStyleVariableModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReportStyleMainModel_ReportStyleVariableModel_FontSizeId",
                        column: x => x.FontSizeId,
                        principalTable: "ReportStyleVariableModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReportStyleMainModel_ReportStyleVariableModel_LogoPlacementId",
                        column: x => x.LogoPlacementId,
                        principalTable: "ReportStyleVariableModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReportStyleMainModel_ReportStyleVariableModel_LogoSizeId",
                        column: x => x.LogoSizeId,
                        principalTable: "ReportStyleVariableModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReportStyleMainModel_ReportStyleVariableModel_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "ReportStyleVariableModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportStyleMainModel_ColorId",
                table: "ReportStyleMainModel",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportStyleMainModel_FontFamilyVariableId",
                table: "ReportStyleMainModel",
                column: "FontFamilyVariableId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportStyleMainModel_FontSizeId",
                table: "ReportStyleMainModel",
                column: "FontSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportStyleMainModel_LogoPlacementId",
                table: "ReportStyleMainModel",
                column: "LogoPlacementId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportStyleMainModel_LogoSizeId",
                table: "ReportStyleMainModel",
                column: "LogoSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportStyleMainModel_TemplateId",
                table: "ReportStyleMainModel",
                column: "TemplateId");
        }
    }
}
