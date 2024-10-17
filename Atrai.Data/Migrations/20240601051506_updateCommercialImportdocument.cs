using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateCommercialImportdocument : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BLNo",
                table: "ImportCI_Master",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CNFId",
                table: "ImportCI_Master",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TradeTermId",
                table: "ImportCI_Master",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImportCI_Master_CNFId",
                table: "ImportCI_Master",
                column: "CNFId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportCI_Master_TradeTermId",
                table: "ImportCI_Master",
                column: "TradeTermId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImportCI_Master_Supplier_CNFId",
                table: "ImportCI_Master",
                column: "CNFId",
                principalTable: "Supplier",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImportCI_Master_TradeTerms_TradeTermId",
                table: "ImportCI_Master",
                column: "TradeTermId",
                principalTable: "TradeTerms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImportCI_Master_Supplier_CNFId",
                table: "ImportCI_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_ImportCI_Master_TradeTerms_TradeTermId",
                table: "ImportCI_Master");

            migrationBuilder.DropIndex(
                name: "IX_ImportCI_Master_CNFId",
                table: "ImportCI_Master");

            migrationBuilder.DropIndex(
                name: "IX_ImportCI_Master_TradeTermId",
                table: "ImportCI_Master");

            migrationBuilder.DropColumn(
                name: "BLNo",
                table: "ImportCI_Master");

            migrationBuilder.DropColumn(
                name: "CNFId",
                table: "ImportCI_Master");

            migrationBuilder.DropColumn(
                name: "TradeTermId",
                table: "ImportCI_Master");
        }
    }
}
