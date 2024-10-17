using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class addTaxCriteria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaxCriteriaId",
                table: "SalesTax",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TaxCriteria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Criteria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxCriteria", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesTax_TaxCriteriaId",
                table: "SalesTax",
                column: "TaxCriteriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesTax_TaxCriteria_TaxCriteriaId",
                table: "SalesTax",
                column: "TaxCriteriaId",
                principalTable: "TaxCriteria",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesTax_TaxCriteria_TaxCriteriaId",
                table: "SalesTax");

            migrationBuilder.DropTable(
                name: "TaxCriteria");

            migrationBuilder.DropIndex(
                name: "IX_SalesTax_TaxCriteriaId",
                table: "SalesTax");

            migrationBuilder.DropColumn(
                name: "TaxCriteriaId",
                table: "SalesTax");
        }
    }
}
