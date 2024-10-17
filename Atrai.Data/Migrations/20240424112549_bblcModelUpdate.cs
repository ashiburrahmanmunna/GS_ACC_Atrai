using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class bblcModelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BBLC_Details_BBLCMaster_BBLCMainId",
                table: "BBLC_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_BBLC_Details_Com_proformaInvoice_PIId",
                table: "BBLC_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_BBLC_Details_Company_ComId",
                table: "BBLC_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_BBLC_Details_UserAccount_LuserId",
                table: "BBLC_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_BBLCMaster_Com_GroupLC_Main_GroupLCId",
                table: "BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_BBLCMaster_CommercialCompanies_CommercialCompanyId",
                table: "BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_BBLCMaster_Company_ComId",
                table: "BBLCMaster");

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
                name: "FK_BBLCMaster_ItemGroup_ItemGroupId",
                table: "BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_BBLCMaster_LienBank_LienBankId",
                table: "BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_BBLCMaster_MasterLC_COM_MasterLCId",
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
                name: "FK_BBLCMaster_ShipMode_ShipModeId",
                table: "BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_BBLCMaster_Supplier_SupplierId",
                table: "BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_BBLCMaster_TradeTerm_TradeTermId",
                table: "BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_BBLCMaster_TruckInfo_TruckInfoId",
                table: "BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_BBLCMaster_UserAccount_LuserId",
                table: "BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_CommercialInvoice_BBLCMaster_BBLCId",
                table: "COM_CommercialInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_DocumentAcceptance_Master_BBLCMaster_BBLCId",
                table: "COM_DocumentAcceptance_Master");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BBLCMaster",
                table: "BBLCMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BBLC_Details",
                table: "BBLC_Details");

            migrationBuilder.RenameTable(
                name: "BBLCMaster",
                newName: "Com_BBLCMaster");

            migrationBuilder.RenameTable(
                name: "BBLC_Details",
                newName: "Com_BBLC_Details");

            migrationBuilder.RenameIndex(
                name: "IX_BBLCMaster_TruckInfoId",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_TruckInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_BBLCMaster_TradeTermId",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_TradeTermId");

            migrationBuilder.RenameIndex(
                name: "IX_BBLCMaster_SupplierId",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_BBLCMaster_ShipModeId",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_ShipModeId");

            migrationBuilder.RenameIndex(
                name: "IX_BBLCMaster_PortOfLoadingId",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_PortOfLoadingId");

            migrationBuilder.RenameIndex(
                name: "IX_BBLCMaster_PortOfDischargeId",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_PortOfDischargeId");

            migrationBuilder.RenameIndex(
                name: "IX_BBLCMaster_PaymentTermsId",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_PaymentTermsId");

            migrationBuilder.RenameIndex(
                name: "IX_BBLCMaster_OpeningBankId",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_OpeningBankId");

            migrationBuilder.RenameIndex(
                name: "IX_BBLCMaster_LuserId",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_LuserId");

            migrationBuilder.RenameIndex(
                name: "IX_BBLCMaster_LienBankId",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_LienBankId");

            migrationBuilder.RenameIndex(
                name: "IX_BBLCMaster_ItemGroupId",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_ItemGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_BBLCMaster_GroupLCId",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_GroupLCId");

            migrationBuilder.RenameIndex(
                name: "IX_BBLCMaster_DestinationID",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_DestinationID");

            migrationBuilder.RenameIndex(
                name: "IX_BBLCMaster_DayListTermId",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_DayListTermId");

            migrationBuilder.RenameIndex(
                name: "IX_BBLCMaster_DayListId",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_DayListId");

            migrationBuilder.RenameIndex(
                name: "IX_BBLCMaster_CurrencyId",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_BBLCMaster_CommercialCompanyId",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_CommercialCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_BBLCMaster_ComId",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_ComId");

            migrationBuilder.RenameIndex(
                name: "IX_BBLCMaster_COM_MasterLCId",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_COM_MasterLCId");

            migrationBuilder.RenameIndex(
                name: "IX_BBLC_Details_PIId",
                table: "Com_BBLC_Details",
                newName: "IX_Com_BBLC_Details_PIId");

            migrationBuilder.RenameIndex(
                name: "IX_BBLC_Details_LuserId",
                table: "Com_BBLC_Details",
                newName: "IX_Com_BBLC_Details_LuserId");

            migrationBuilder.RenameIndex(
                name: "IX_BBLC_Details_ComId",
                table: "Com_BBLC_Details",
                newName: "IX_Com_BBLC_Details_ComId");

            migrationBuilder.RenameIndex(
                name: "IX_BBLC_Details_BBLCMainId",
                table: "Com_BBLC_Details",
                newName: "IX_Com_BBLC_Details_BBLCMainId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Com_BBLCMaster",
                table: "Com_BBLCMaster",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Com_BBLC_Details",
                table: "Com_BBLC_Details",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_BBLC_Details_Com_BBLCMaster_BBLCMainId",
                table: "Com_BBLC_Details",
                column: "BBLCMainId",
                principalTable: "Com_BBLCMaster",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_BBLC_Details_Com_proformaInvoice_PIId",
                table: "Com_BBLC_Details",
                column: "PIId",
                principalTable: "Com_proformaInvoice",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_BBLC_Details_Company_ComId",
                table: "Com_BBLC_Details",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Com_BBLC_Details_UserAccount_LuserId",
                table: "Com_BBLC_Details",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Com_BBLCMaster_Com_GroupLC_Main_GroupLCId",
                table: "Com_BBLCMaster",
                column: "GroupLCId",
                principalTable: "Com_GroupLC_Main",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_BBLCMaster_CommercialCompanies_CommercialCompanyId",
                table: "Com_BBLCMaster",
                column: "CommercialCompanyId",
                principalTable: "CommercialCompanies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_BBLCMaster_Company_ComId",
                table: "Com_BBLCMaster",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Com_BBLCMaster_Country_CurrencyId",
                table: "Com_BBLCMaster",
                column: "CurrencyId",
                principalTable: "Country",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_BBLCMaster_DayListTerm_DayListTermId",
                table: "Com_BBLCMaster",
                column: "DayListTermId",
                principalTable: "DayListTerm",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_BBLCMaster_DayList_DayListId",
                table: "Com_BBLCMaster",
                column: "DayListId",
                principalTable: "DayList",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_BBLCMaster_Destination_DestinationID",
                table: "Com_BBLCMaster",
                column: "DestinationID",
                principalTable: "Destination",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_BBLCMaster_ItemGroup_ItemGroupId",
                table: "Com_BBLCMaster",
                column: "ItemGroupId",
                principalTable: "ItemGroup",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_BBLCMaster_LienBank_LienBankId",
                table: "Com_BBLCMaster",
                column: "LienBankId",
                principalTable: "LienBank",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_BBLCMaster_MasterLC_COM_MasterLCId",
                table: "Com_BBLCMaster",
                column: "COM_MasterLCId",
                principalTable: "MasterLC",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_BBLCMaster_OpeningBank_OpeningBankId",
                table: "Com_BBLCMaster",
                column: "OpeningBankId",
                principalTable: "OpeningBank",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_BBLCMaster_PaymentTermss_PaymentTermsId",
                table: "Com_BBLCMaster",
                column: "PaymentTermsId",
                principalTable: "PaymentTermss",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_BBLCMaster_PortOfDischarge_PortOfDischargeId",
                table: "Com_BBLCMaster",
                column: "PortOfDischargeId",
                principalTable: "PortOfDischarge",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_BBLCMaster_PortOfLoading_PortOfLoadingId",
                table: "Com_BBLCMaster",
                column: "PortOfLoadingId",
                principalTable: "PortOfLoading",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_BBLCMaster_ShipMode_ShipModeId",
                table: "Com_BBLCMaster",
                column: "ShipModeId",
                principalTable: "ShipMode",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_BBLCMaster_Supplier_SupplierId",
                table: "Com_BBLCMaster",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_BBLCMaster_TradeTerm_TradeTermId",
                table: "Com_BBLCMaster",
                column: "TradeTermId",
                principalTable: "TradeTerm",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_BBLCMaster_TruckInfo_TruckInfoId",
                table: "Com_BBLCMaster",
                column: "TruckInfoId",
                principalTable: "TruckInfo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_BBLCMaster_UserAccount_LuserId",
                table: "Com_BBLCMaster",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_CommercialInvoice_Com_BBLCMaster_BBLCId",
                table: "COM_CommercialInvoice",
                column: "BBLCId",
                principalTable: "Com_BBLCMaster",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_DocumentAcceptance_Master_Com_BBLCMaster_BBLCId",
                table: "COM_DocumentAcceptance_Master",
                column: "BBLCId",
                principalTable: "Com_BBLCMaster",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Com_BBLC_Details_Com_BBLCMaster_BBLCMainId",
                table: "Com_BBLC_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_BBLC_Details_Com_proformaInvoice_PIId",
                table: "Com_BBLC_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_BBLC_Details_Company_ComId",
                table: "Com_BBLC_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_BBLC_Details_UserAccount_LuserId",
                table: "Com_BBLC_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_BBLCMaster_Com_GroupLC_Main_GroupLCId",
                table: "Com_BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_BBLCMaster_CommercialCompanies_CommercialCompanyId",
                table: "Com_BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_BBLCMaster_Company_ComId",
                table: "Com_BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_BBLCMaster_Country_CurrencyId",
                table: "Com_BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_BBLCMaster_DayListTerm_DayListTermId",
                table: "Com_BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_BBLCMaster_DayList_DayListId",
                table: "Com_BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_BBLCMaster_Destination_DestinationID",
                table: "Com_BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_BBLCMaster_ItemGroup_ItemGroupId",
                table: "Com_BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_BBLCMaster_LienBank_LienBankId",
                table: "Com_BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_BBLCMaster_MasterLC_COM_MasterLCId",
                table: "Com_BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_BBLCMaster_OpeningBank_OpeningBankId",
                table: "Com_BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_BBLCMaster_PaymentTermss_PaymentTermsId",
                table: "Com_BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_BBLCMaster_PortOfDischarge_PortOfDischargeId",
                table: "Com_BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_BBLCMaster_PortOfLoading_PortOfLoadingId",
                table: "Com_BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_BBLCMaster_ShipMode_ShipModeId",
                table: "Com_BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_BBLCMaster_Supplier_SupplierId",
                table: "Com_BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_BBLCMaster_TradeTerm_TradeTermId",
                table: "Com_BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_BBLCMaster_TruckInfo_TruckInfoId",
                table: "Com_BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_BBLCMaster_UserAccount_LuserId",
                table: "Com_BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_CommercialInvoice_Com_BBLCMaster_BBLCId",
                table: "COM_CommercialInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_DocumentAcceptance_Master_Com_BBLCMaster_BBLCId",
                table: "COM_DocumentAcceptance_Master");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Com_BBLCMaster",
                table: "Com_BBLCMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Com_BBLC_Details",
                table: "Com_BBLC_Details");

            migrationBuilder.RenameTable(
                name: "Com_BBLCMaster",
                newName: "BBLCMaster");

            migrationBuilder.RenameTable(
                name: "Com_BBLC_Details",
                newName: "BBLC_Details");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_TruckInfoId",
                table: "BBLCMaster",
                newName: "IX_BBLCMaster_TruckInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_TradeTermId",
                table: "BBLCMaster",
                newName: "IX_BBLCMaster_TradeTermId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_SupplierId",
                table: "BBLCMaster",
                newName: "IX_BBLCMaster_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_ShipModeId",
                table: "BBLCMaster",
                newName: "IX_BBLCMaster_ShipModeId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_PortOfLoadingId",
                table: "BBLCMaster",
                newName: "IX_BBLCMaster_PortOfLoadingId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_PortOfDischargeId",
                table: "BBLCMaster",
                newName: "IX_BBLCMaster_PortOfDischargeId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_PaymentTermsId",
                table: "BBLCMaster",
                newName: "IX_BBLCMaster_PaymentTermsId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_OpeningBankId",
                table: "BBLCMaster",
                newName: "IX_BBLCMaster_OpeningBankId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_LuserId",
                table: "BBLCMaster",
                newName: "IX_BBLCMaster_LuserId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_LienBankId",
                table: "BBLCMaster",
                newName: "IX_BBLCMaster_LienBankId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_ItemGroupId",
                table: "BBLCMaster",
                newName: "IX_BBLCMaster_ItemGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_GroupLCId",
                table: "BBLCMaster",
                newName: "IX_BBLCMaster_GroupLCId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_DestinationID",
                table: "BBLCMaster",
                newName: "IX_BBLCMaster_DestinationID");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_DayListTermId",
                table: "BBLCMaster",
                newName: "IX_BBLCMaster_DayListTermId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_DayListId",
                table: "BBLCMaster",
                newName: "IX_BBLCMaster_DayListId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_CurrencyId",
                table: "BBLCMaster",
                newName: "IX_BBLCMaster_CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_CommercialCompanyId",
                table: "BBLCMaster",
                newName: "IX_BBLCMaster_CommercialCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_ComId",
                table: "BBLCMaster",
                newName: "IX_BBLCMaster_ComId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_COM_MasterLCId",
                table: "BBLCMaster",
                newName: "IX_BBLCMaster_COM_MasterLCId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLC_Details_PIId",
                table: "BBLC_Details",
                newName: "IX_BBLC_Details_PIId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLC_Details_LuserId",
                table: "BBLC_Details",
                newName: "IX_BBLC_Details_LuserId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLC_Details_ComId",
                table: "BBLC_Details",
                newName: "IX_BBLC_Details_ComId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLC_Details_BBLCMainId",
                table: "BBLC_Details",
                newName: "IX_BBLC_Details_BBLCMainId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BBLCMaster",
                table: "BBLCMaster",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BBLC_Details",
                table: "BBLC_Details",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BBLC_Details_BBLCMaster_BBLCMainId",
                table: "BBLC_Details",
                column: "BBLCMainId",
                principalTable: "BBLCMaster",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BBLC_Details_Com_proformaInvoice_PIId",
                table: "BBLC_Details",
                column: "PIId",
                principalTable: "Com_proformaInvoice",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BBLC_Details_Company_ComId",
                table: "BBLC_Details",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BBLC_Details_UserAccount_LuserId",
                table: "BBLC_Details",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_BBLCMaster_Com_GroupLC_Main_GroupLCId",
                table: "BBLCMaster",
                column: "GroupLCId",
                principalTable: "Com_GroupLC_Main",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BBLCMaster_CommercialCompanies_CommercialCompanyId",
                table: "BBLCMaster",
                column: "CommercialCompanyId",
                principalTable: "CommercialCompanies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BBLCMaster_Company_ComId",
                table: "BBLCMaster",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BBLCMaster_ItemGroup_ItemGroupId",
                table: "BBLCMaster",
                column: "ItemGroupId",
                principalTable: "ItemGroup",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BBLCMaster_LienBank_LienBankId",
                table: "BBLCMaster",
                column: "LienBankId",
                principalTable: "LienBank",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BBLCMaster_MasterLC_COM_MasterLCId",
                table: "BBLCMaster",
                column: "COM_MasterLCId",
                principalTable: "MasterLC",
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
                name: "FK_BBLCMaster_ShipMode_ShipModeId",
                table: "BBLCMaster",
                column: "ShipModeId",
                principalTable: "ShipMode",
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

            migrationBuilder.AddForeignKey(
                name: "FK_BBLCMaster_TruckInfo_TruckInfoId",
                table: "BBLCMaster",
                column: "TruckInfoId",
                principalTable: "TruckInfo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BBLCMaster_UserAccount_LuserId",
                table: "BBLCMaster",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_CommercialInvoice_BBLCMaster_BBLCId",
                table: "COM_CommercialInvoice",
                column: "BBLCId",
                principalTable: "BBLCMaster",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_DocumentAcceptance_Master_BBLCMaster_BBLCId",
                table: "COM_DocumentAcceptance_Master",
                column: "BBLCId",
                principalTable: "BBLCMaster",
                principalColumn: "Id");
        }
    }
}
