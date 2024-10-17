using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class addTermMainId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TermsMainId",
                table: "Purchase",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_TermsMainId",
                table: "Purchase",
                column: "TermsMainId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_TermsMain_TermsMainId",
                table: "Purchase",
                column: "TermsMainId",
                principalTable: "TermsMain",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_TermsMain_TermsMainId",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_TermsMainId",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "TermsMainId",
                table: "Purchase");
        }
    }
}
