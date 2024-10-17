using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class bblcModelUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Com_BBLC_Details_Com_BBLCMaster_BBLCMainId",
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

            migrationBuilder.RenameTable(
                name: "Com_BBLCMaster",
                newName: "COM_BBLC_Master");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_TruckInfoId",
                table: "COM_BBLC_Master",
                newName: "IX_COM_BBLC_Master_TruckInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_TradeTermId",
                table: "COM_BBLC_Master",
                newName: "IX_COM_BBLC_Master_TradeTermId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_SupplierId",
                table: "COM_BBLC_Master",
                newName: "IX_COM_BBLC_Master_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_ShipModeId",
                table: "COM_BBLC_Master",
                newName: "IX_COM_BBLC_Master_ShipModeId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_PortOfLoadingId",
                table: "COM_BBLC_Master",
                newName: "IX_COM_BBLC_Master_PortOfLoadingId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_PortOfDischargeId",
                table: "COM_BBLC_Master",
                newName: "IX_COM_BBLC_Master_PortOfDischargeId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_PaymentTermsId",
                table: "COM_BBLC_Master",
                newName: "IX_COM_BBLC_Master_PaymentTermsId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_OpeningBankId",
                table: "COM_BBLC_Master",
                newName: "IX_COM_BBLC_Master_OpeningBankId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_LuserId",
                table: "COM_BBLC_Master",
                newName: "IX_COM_BBLC_Master_LuserId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_LienBankId",
                table: "COM_BBLC_Master",
                newName: "IX_COM_BBLC_Master_LienBankId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_ItemGroupId",
                table: "COM_BBLC_Master",
                newName: "IX_COM_BBLC_Master_ItemGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_GroupLCId",
                table: "COM_BBLC_Master",
                newName: "IX_COM_BBLC_Master_GroupLCId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_DestinationID",
                table: "COM_BBLC_Master",
                newName: "IX_COM_BBLC_Master_DestinationID");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_DayListTermId",
                table: "COM_BBLC_Master",
                newName: "IX_COM_BBLC_Master_DayListTermId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_DayListId",
                table: "COM_BBLC_Master",
                newName: "IX_COM_BBLC_Master_DayListId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_CurrencyId",
                table: "COM_BBLC_Master",
                newName: "IX_COM_BBLC_Master_CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_CommercialCompanyId",
                table: "COM_BBLC_Master",
                newName: "IX_COM_BBLC_Master_CommercialCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_ComId",
                table: "COM_BBLC_Master",
                newName: "IX_COM_BBLC_Master_ComId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_BBLCMaster_COM_MasterLCId",
                table: "COM_BBLC_Master",
                newName: "IX_COM_BBLC_Master_COM_MasterLCId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_COM_BBLC_Master",
                table: "COM_BBLC_Master",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_BBLC_Details_COM_BBLC_Master_BBLCMainId",
                table: "Com_BBLC_Details",
                column: "BBLCMainId",
                principalTable: "COM_BBLC_Master",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_BBLC_Master_Com_GroupLC_Main_GroupLCId",
                table: "COM_BBLC_Master",
                column: "GroupLCId",
                principalTable: "Com_GroupLC_Main",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_BBLC_Master_CommercialCompanies_CommercialCompanyId",
                table: "COM_BBLC_Master",
                column: "CommercialCompanyId",
                principalTable: "CommercialCompanies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_BBLC_Master_Company_ComId",
                table: "COM_BBLC_Master",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_BBLC_Master_Country_CurrencyId",
                table: "COM_BBLC_Master",
                column: "CurrencyId",
                principalTable: "Country",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_BBLC_Master_DayListTerm_DayListTermId",
                table: "COM_BBLC_Master",
                column: "DayListTermId",
                principalTable: "DayListTerm",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_BBLC_Master_DayList_DayListId",
                table: "COM_BBLC_Master",
                column: "DayListId",
                principalTable: "DayList",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_BBLC_Master_Destination_DestinationID",
                table: "COM_BBLC_Master",
                column: "DestinationID",
                principalTable: "Destination",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_BBLC_Master_ItemGroup_ItemGroupId",
                table: "COM_BBLC_Master",
                column: "ItemGroupId",
                principalTable: "ItemGroup",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_BBLC_Master_LienBank_LienBankId",
                table: "COM_BBLC_Master",
                column: "LienBankId",
                principalTable: "LienBank",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_BBLC_Master_MasterLC_COM_MasterLCId",
                table: "COM_BBLC_Master",
                column: "COM_MasterLCId",
                principalTable: "MasterLC",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_BBLC_Master_OpeningBank_OpeningBankId",
                table: "COM_BBLC_Master",
                column: "OpeningBankId",
                principalTable: "OpeningBank",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_BBLC_Master_PaymentTermss_PaymentTermsId",
                table: "COM_BBLC_Master",
                column: "PaymentTermsId",
                principalTable: "PaymentTermss",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_BBLC_Master_PortOfDischarge_PortOfDischargeId",
                table: "COM_BBLC_Master",
                column: "PortOfDischargeId",
                principalTable: "PortOfDischarge",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_BBLC_Master_PortOfLoading_PortOfLoadingId",
                table: "COM_BBLC_Master",
                column: "PortOfLoadingId",
                principalTable: "PortOfLoading",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_BBLC_Master_ShipMode_ShipModeId",
                table: "COM_BBLC_Master",
                column: "ShipModeId",
                principalTable: "ShipMode",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_BBLC_Master_Supplier_SupplierId",
                table: "COM_BBLC_Master",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_BBLC_Master_TradeTerm_TradeTermId",
                table: "COM_BBLC_Master",
                column: "TradeTermId",
                principalTable: "TradeTerm",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_BBLC_Master_TruckInfo_TruckInfoId",
                table: "COM_BBLC_Master",
                column: "TruckInfoId",
                principalTable: "TruckInfo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_BBLC_Master_UserAccount_LuserId",
                table: "COM_BBLC_Master",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_CommercialInvoice_COM_BBLC_Master_BBLCId",
                table: "COM_CommercialInvoice",
                column: "BBLCId",
                principalTable: "COM_BBLC_Master",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_DocumentAcceptance_Master_COM_BBLC_Master_BBLCId",
                table: "COM_DocumentAcceptance_Master",
                column: "BBLCId",
                principalTable: "COM_BBLC_Master",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Com_BBLC_Details_COM_BBLC_Master_BBLCMainId",
                table: "Com_BBLC_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_BBLC_Master_Com_GroupLC_Main_GroupLCId",
                table: "COM_BBLC_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_BBLC_Master_CommercialCompanies_CommercialCompanyId",
                table: "COM_BBLC_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_BBLC_Master_Company_ComId",
                table: "COM_BBLC_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_BBLC_Master_Country_CurrencyId",
                table: "COM_BBLC_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_BBLC_Master_DayListTerm_DayListTermId",
                table: "COM_BBLC_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_BBLC_Master_DayList_DayListId",
                table: "COM_BBLC_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_BBLC_Master_Destination_DestinationID",
                table: "COM_BBLC_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_BBLC_Master_ItemGroup_ItemGroupId",
                table: "COM_BBLC_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_BBLC_Master_LienBank_LienBankId",
                table: "COM_BBLC_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_BBLC_Master_MasterLC_COM_MasterLCId",
                table: "COM_BBLC_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_BBLC_Master_OpeningBank_OpeningBankId",
                table: "COM_BBLC_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_BBLC_Master_PaymentTermss_PaymentTermsId",
                table: "COM_BBLC_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_BBLC_Master_PortOfDischarge_PortOfDischargeId",
                table: "COM_BBLC_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_BBLC_Master_PortOfLoading_PortOfLoadingId",
                table: "COM_BBLC_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_BBLC_Master_ShipMode_ShipModeId",
                table: "COM_BBLC_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_BBLC_Master_Supplier_SupplierId",
                table: "COM_BBLC_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_BBLC_Master_TradeTerm_TradeTermId",
                table: "COM_BBLC_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_BBLC_Master_TruckInfo_TruckInfoId",
                table: "COM_BBLC_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_BBLC_Master_UserAccount_LuserId",
                table: "COM_BBLC_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_CommercialInvoice_COM_BBLC_Master_BBLCId",
                table: "COM_CommercialInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_DocumentAcceptance_Master_COM_BBLC_Master_BBLCId",
                table: "COM_DocumentAcceptance_Master");

            migrationBuilder.DropPrimaryKey(
                name: "PK_COM_BBLC_Master",
                table: "COM_BBLC_Master");

            migrationBuilder.RenameTable(
                name: "COM_BBLC_Master",
                newName: "Com_BBLCMaster");

            migrationBuilder.RenameIndex(
                name: "IX_COM_BBLC_Master_TruckInfoId",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_TruckInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_COM_BBLC_Master_TradeTermId",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_TradeTermId");

            migrationBuilder.RenameIndex(
                name: "IX_COM_BBLC_Master_SupplierId",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_COM_BBLC_Master_ShipModeId",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_ShipModeId");

            migrationBuilder.RenameIndex(
                name: "IX_COM_BBLC_Master_PortOfLoadingId",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_PortOfLoadingId");

            migrationBuilder.RenameIndex(
                name: "IX_COM_BBLC_Master_PortOfDischargeId",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_PortOfDischargeId");

            migrationBuilder.RenameIndex(
                name: "IX_COM_BBLC_Master_PaymentTermsId",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_PaymentTermsId");

            migrationBuilder.RenameIndex(
                name: "IX_COM_BBLC_Master_OpeningBankId",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_OpeningBankId");

            migrationBuilder.RenameIndex(
                name: "IX_COM_BBLC_Master_LuserId",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_LuserId");

            migrationBuilder.RenameIndex(
                name: "IX_COM_BBLC_Master_LienBankId",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_LienBankId");

            migrationBuilder.RenameIndex(
                name: "IX_COM_BBLC_Master_ItemGroupId",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_ItemGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_COM_BBLC_Master_GroupLCId",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_GroupLCId");

            migrationBuilder.RenameIndex(
                name: "IX_COM_BBLC_Master_DestinationID",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_DestinationID");

            migrationBuilder.RenameIndex(
                name: "IX_COM_BBLC_Master_DayListTermId",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_DayListTermId");

            migrationBuilder.RenameIndex(
                name: "IX_COM_BBLC_Master_DayListId",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_DayListId");

            migrationBuilder.RenameIndex(
                name: "IX_COM_BBLC_Master_CurrencyId",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_COM_BBLC_Master_CommercialCompanyId",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_CommercialCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_COM_BBLC_Master_ComId",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_ComId");

            migrationBuilder.RenameIndex(
                name: "IX_COM_BBLC_Master_COM_MasterLCId",
                table: "Com_BBLCMaster",
                newName: "IX_Com_BBLCMaster_COM_MasterLCId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Com_BBLCMaster",
                table: "Com_BBLCMaster",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_BBLC_Details_Com_BBLCMaster_BBLCMainId",
                table: "Com_BBLC_Details",
                column: "BBLCMainId",
                principalTable: "Com_BBLCMaster",
                principalColumn: "Id");

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
    }
}
