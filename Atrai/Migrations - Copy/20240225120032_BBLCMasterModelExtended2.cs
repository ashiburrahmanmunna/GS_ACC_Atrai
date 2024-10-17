using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class BBLCMasterModelExtended2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "BBLCMaster",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DayListId",
                table: "BBLCMaster",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DayListTermId",
                table: "BBLCMaster",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DestinationID",
                table: "BBLCMaster",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Insurance",
                table: "BBLCMaster",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LienBankId",
                table: "BBLCMaster",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OpeningBankId",
                table: "BBLCMaster",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentTermsId",
                table: "BBLCMaster",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PortOfDischargeId",
                table: "BBLCMaster",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PortOfLoadingId",
                table: "BBLCMaster",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "BBLCMaster",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TradeTermId",
                table: "BBLCMaster",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BBLCMaster_CurrencyId",
                table: "BBLCMaster",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_BBLCMaster_DayListId",
                table: "BBLCMaster",
                column: "DayListId");

            migrationBuilder.CreateIndex(
                name: "IX_BBLCMaster_DayListTermId",
                table: "BBLCMaster",
                column: "DayListTermId");

            migrationBuilder.CreateIndex(
                name: "IX_BBLCMaster_DestinationID",
                table: "BBLCMaster",
                column: "DestinationID");

            migrationBuilder.CreateIndex(
                name: "IX_BBLCMaster_LienBankId",
                table: "BBLCMaster",
                column: "LienBankId");

            migrationBuilder.CreateIndex(
                name: "IX_BBLCMaster_OpeningBankId",
                table: "BBLCMaster",
                column: "OpeningBankId");

            migrationBuilder.CreateIndex(
                name: "IX_BBLCMaster_PaymentTermsId",
                table: "BBLCMaster",
                column: "PaymentTermsId");

            migrationBuilder.CreateIndex(
                name: "IX_BBLCMaster_PortOfDischargeId",
                table: "BBLCMaster",
                column: "PortOfDischargeId");

            migrationBuilder.CreateIndex(
                name: "IX_BBLCMaster_PortOfLoadingId",
                table: "BBLCMaster",
                column: "PortOfLoadingId");

            migrationBuilder.CreateIndex(
                name: "IX_BBLCMaster_SupplierId",
                table: "BBLCMaster",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_BBLCMaster_TradeTermId",
                table: "BBLCMaster",
                column: "TradeTermId");

            migrationBuilder.AddForeignKey(
                name: "FK_BBLCMaster_Country_CurrencyId",
                table: "BBLCMaster",
                column: "CurrencyId",
                principalTable: "Country",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BBLCMaster_DayListTerm_DayListTermId",
                table: "BBLCMaster",
                column: "DayListTermId",
                principalTable: "DayListTerm",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BBLCMaster_DayList_DayListId",
                table: "BBLCMaster",
                column: "DayListId",
                principalTable: "DayList",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BBLCMaster_Destination_DestinationID",
                table: "BBLCMaster",
                column: "DestinationID",
                principalTable: "Destination",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BBLCMaster_LienBank_LienBankId",
                table: "BBLCMaster",
                column: "LienBankId",
                principalTable: "LienBank",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BBLCMaster_OpeningBank_OpeningBankId",
                table: "BBLCMaster",
                column: "OpeningBankId",
                principalTable: "OpeningBank",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BBLCMaster_PaymentTermss_PaymentTermsId",
                table: "BBLCMaster",
                column: "PaymentTermsId",
                principalTable: "PaymentTermss",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BBLCMaster_PortOfDischarge_PortOfDischargeId",
                table: "BBLCMaster",
                column: "PortOfDischargeId",
                principalTable: "PortOfDischarge",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BBLCMaster_PortOfLoading_PortOfLoadingId",
                table: "BBLCMaster",
                column: "PortOfLoadingId",
                principalTable: "PortOfLoading",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BBLCMaster_Supplier_SupplierId",
                table: "BBLCMaster",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BBLCMaster_TradeTerm_TradeTermId",
                table: "BBLCMaster",
                column: "TradeTermId",
                principalTable: "TradeTerm",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BBLCMaster_Country_CurrencyId",
                table: "BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_BBLCMaster_DayListTerm_DayListTermId",
                table: "BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_BBLCMaster_DayList_DayListId",
                table: "BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_BBLCMaster_Destination_DestinationID",
                table: "BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_BBLCMaster_LienBank_LienBankId",
                table: "BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_BBLCMaster_OpeningBank_OpeningBankId",
                table: "BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_BBLCMaster_PaymentTermss_PaymentTermsId",
                table: "BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_BBLCMaster_PortOfDischarge_PortOfDischargeId",
                table: "BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_BBLCMaster_PortOfLoading_PortOfLoadingId",
                table: "BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_BBLCMaster_Supplier_SupplierId",
                table: "BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_BBLCMaster_TradeTerm_TradeTermId",
                table: "BBLCMaster");

            migrationBuilder.DropIndex(
                name: "IX_BBLCMaster_CurrencyId",
                table: "BBLCMaster");

            migrationBuilder.DropIndex(
                name: "IX_BBLCMaster_DayListId",
                table: "BBLCMaster");

            migrationBuilder.DropIndex(
                name: "IX_BBLCMaster_DayListTermId",
                table: "BBLCMaster");

            migrationBuilder.DropIndex(
                name: "IX_BBLCMaster_DestinationID",
                table: "BBLCMaster");

            migrationBuilder.DropIndex(
                name: "IX_BBLCMaster_LienBankId",
                table: "BBLCMaster");

            migrationBuilder.DropIndex(
                name: "IX_BBLCMaster_OpeningBankId",
                table: "BBLCMaster");

            migrationBuilder.DropIndex(
                name: "IX_BBLCMaster_PaymentTermsId",
                table: "BBLCMaster");

            migrationBuilder.DropIndex(
                name: "IX_BBLCMaster_PortOfDischargeId",
                table: "BBLCMaster");

            migrationBuilder.DropIndex(
                name: "IX_BBLCMaster_PortOfLoadingId",
                table: "BBLCMaster");

            migrationBuilder.DropIndex(
                name: "IX_BBLCMaster_SupplierId",
                table: "BBLCMaster");

            migrationBuilder.DropIndex(
                name: "IX_BBLCMaster_TradeTermId",
                table: "BBLCMaster");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "BBLCMaster");

            migrationBuilder.DropColumn(
                name: "DayListId",
                table: "BBLCMaster");

            migrationBuilder.DropColumn(
                name: "DayListTermId",
                table: "BBLCMaster");

            migrationBuilder.DropColumn(
                name: "DestinationID",
                table: "BBLCMaster");

            migrationBuilder.DropColumn(
                name: "Insurance",
                table: "BBLCMaster");

            migrationBuilder.DropColumn(
                name: "LienBankId",
                table: "BBLCMaster");

            migrationBuilder.DropColumn(
                name: "OpeningBankId",
                table: "BBLCMaster");

            migrationBuilder.DropColumn(
                name: "PaymentTermsId",
                table: "BBLCMaster");

            migrationBuilder.DropColumn(
                name: "PortOfDischargeId",
                table: "BBLCMaster");

            migrationBuilder.DropColumn(
                name: "PortOfLoadingId",
                table: "BBLCMaster");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "BBLCMaster");

            migrationBuilder.DropColumn(
                name: "TradeTermId",
                table: "BBLCMaster");
        }
    }
}
