using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Atrai.Migrations
{
    public partial class reportstylemainmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReportStyleVariableModel",
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
                    table.PrimaryKey("PK_ReportStyleVariableModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportStyleMainModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsInActive = table.Column<bool>(type: "bit", nullable: false),
                    ReportFor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TemplateId = table.Column<int>(type: "int", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    LogoSizeId = table.Column<int>(type: "int", nullable: true),
                    FontSizeId = table.Column<int>(type: "int", nullable: true),
                    LogoPlacementId = table.Column<int>(type: "int", nullable: true),
                    FontFamilyId = table.Column<int>(type: "int", nullable: true),
                    FontFamilyVariableId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportStyleMainModel");

            migrationBuilder.DropTable(
                name: "ReportStyleVariableModel");
        }
    }
}
