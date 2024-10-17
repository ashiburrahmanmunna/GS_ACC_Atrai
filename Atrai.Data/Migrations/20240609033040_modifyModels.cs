using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class modifyModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LayNo",
                table: "DeptWise_DailyProduction_Details",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Utilization",
                table: "DeptWise_DailyProduction_Details",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Width",
                table: "DeptWise_DailyProduction_Details",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CostCategoryId",
                table: "BOMDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCost",
                table: "BOMDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CategoryTypeId",
                table: "BOMAllocationCategory",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoryType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryType_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryType_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BOMDetails_CostCategoryId",
                table: "BOMDetails",
                column: "CostCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BOMAllocationCategory_CategoryTypeId",
                table: "BOMAllocationCategory",
                column: "CategoryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryType_ComId",
                table: "CategoryType",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryType_LuserId",
                table: "CategoryType",
                column: "LuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BOMAllocationCategory_CategoryType_CategoryTypeId",
                table: "BOMAllocationCategory",
                column: "CategoryTypeId",
                principalTable: "CategoryType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BOMDetails_BOMAllocationCategory_CostCategoryId",
                table: "BOMDetails",
                column: "CostCategoryId",
                principalTable: "BOMAllocationCategory",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BOMAllocationCategory_CategoryType_CategoryTypeId",
                table: "BOMAllocationCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_BOMDetails_BOMAllocationCategory_CostCategoryId",
                table: "BOMDetails");

            migrationBuilder.DropTable(
                name: "CategoryType");

            migrationBuilder.DropIndex(
                name: "IX_BOMDetails_CostCategoryId",
                table: "BOMDetails");

            migrationBuilder.DropIndex(
                name: "IX_BOMAllocationCategory_CategoryTypeId",
                table: "BOMAllocationCategory");

            migrationBuilder.DropColumn(
                name: "LayNo",
                table: "DeptWise_DailyProduction_Details");

            migrationBuilder.DropColumn(
                name: "Utilization",
                table: "DeptWise_DailyProduction_Details");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "DeptWise_DailyProduction_Details");

            migrationBuilder.DropColumn(
                name: "CostCategoryId",
                table: "BOMDetails");

            migrationBuilder.DropColumn(
                name: "IsCost",
                table: "BOMDetails");

            migrationBuilder.DropColumn(
                name: "CategoryTypeId",
                table: "BOMAllocationCategory");
        }
    }
}
