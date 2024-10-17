using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class NotifyPartModelUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotifyParty_Country_CountrysId",
                table: "NotifyParty");

            migrationBuilder.DropForeignKey(
                name: "FK_NotifyParty_Customer_BuyerInformationsId",
                table: "NotifyParty");

            migrationBuilder.DropIndex(
                name: "IX_NotifyParty_BuyerInformationsId",
                table: "NotifyParty");

            migrationBuilder.DropIndex(
                name: "IX_NotifyParty_CountrysId",
                table: "NotifyParty");

            migrationBuilder.DropColumn(
                name: "BuyerInformationsId",
                table: "NotifyParty");

            migrationBuilder.DropColumn(
                name: "CountrysId",
                table: "NotifyParty");

            migrationBuilder.CreateIndex(
                name: "IX_NotifyParty_BuyerId",
                table: "NotifyParty",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_NotifyParty_CountryId",
                table: "NotifyParty",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotifyParty_Country_CountryId",
                table: "NotifyParty",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NotifyParty_Customer_BuyerId",
                table: "NotifyParty",
                column: "BuyerId",
                principalTable: "Customer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotifyParty_Country_CountryId",
                table: "NotifyParty");

            migrationBuilder.DropForeignKey(
                name: "FK_NotifyParty_Customer_BuyerId",
                table: "NotifyParty");

            migrationBuilder.DropIndex(
                name: "IX_NotifyParty_BuyerId",
                table: "NotifyParty");

            migrationBuilder.DropIndex(
                name: "IX_NotifyParty_CountryId",
                table: "NotifyParty");

            migrationBuilder.AddColumn<int>(
                name: "BuyerInformationsId",
                table: "NotifyParty",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountrysId",
                table: "NotifyParty",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotifyParty_BuyerInformationsId",
                table: "NotifyParty",
                column: "BuyerInformationsId");

            migrationBuilder.CreateIndex(
                name: "IX_NotifyParty_CountrysId",
                table: "NotifyParty",
                column: "CountrysId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotifyParty_Country_CountrysId",
                table: "NotifyParty",
                column: "CountrysId",
                principalTable: "Country",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NotifyParty_Customer_BuyerInformationsId",
                table: "NotifyParty",
                column: "BuyerInformationsId",
                principalTable: "Customer",
                principalColumn: "Id");
        }
    }
}
