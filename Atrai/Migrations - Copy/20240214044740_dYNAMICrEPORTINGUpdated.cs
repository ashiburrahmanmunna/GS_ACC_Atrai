using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class dYNAMICrEPORTINGUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DynamicReport_Customer_BuyerInformationsId",
                table: "DynamicReport");

            migrationBuilder.DropIndex(
                name: "IX_DynamicReport_BuyerInformationsId",
                table: "DynamicReport");

            migrationBuilder.DropColumn(
                name: "BuyerInformationsId",
                table: "DynamicReport");

            migrationBuilder.AddColumn<int>(
                name: "DynamicReportId",
                table: "NotifyParty",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotifyParty_DynamicReportId",
                table: "NotifyParty",
                column: "DynamicReportId");

            migrationBuilder.CreateIndex(
                name: "IX_DynamicReport_BuyerId",
                table: "DynamicReport",
                column: "BuyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_DynamicReport_Customer_BuyerId",
                table: "DynamicReport",
                column: "BuyerId",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NotifyParty_DynamicReport_DynamicReportId",
                table: "NotifyParty",
                column: "DynamicReportId",
                principalTable: "DynamicReport",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DynamicReport_Customer_BuyerId",
                table: "DynamicReport");

            migrationBuilder.DropForeignKey(
                name: "FK_NotifyParty_DynamicReport_DynamicReportId",
                table: "NotifyParty");

            migrationBuilder.DropIndex(
                name: "IX_NotifyParty_DynamicReportId",
                table: "NotifyParty");

            migrationBuilder.DropIndex(
                name: "IX_DynamicReport_BuyerId",
                table: "DynamicReport");

            migrationBuilder.DropColumn(
                name: "DynamicReportId",
                table: "NotifyParty");

            migrationBuilder.AddColumn<int>(
                name: "BuyerInformationsId",
                table: "DynamicReport",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DynamicReport_BuyerInformationsId",
                table: "DynamicReport",
                column: "BuyerInformationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_DynamicReport_Customer_BuyerInformationsId",
                table: "DynamicReport",
                column: "BuyerInformationsId",
                principalTable: "Customer",
                principalColumn: "Id");
        }
    }
}
