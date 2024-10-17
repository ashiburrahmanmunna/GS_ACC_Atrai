using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateProforma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BBLC_Details_COM_ProformaInvoices_PIId",
                table: "BBLC_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_MachinaryLC_Details_COM_ProformaInvoices_PIId",
                table: "COM_MachinaryLC_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_ProformaInvoice_Sub_COM_ProformaInvoices_PIId",
                table: "COM_ProformaInvoice_Sub");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_ProformaInvoices_BankAccountNoLienBank_BankAccountNoLienBankId",
                table: "COM_ProformaInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_ProformaInvoices_BankAccountNo_BankAccountId",
                table: "COM_ProformaInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_ProformaInvoices_Commercial_CommercialCompanyId",
                table: "COM_ProformaInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_ProformaInvoices_Company_ComId",
                table: "COM_ProformaInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_ProformaInvoices_Country_CurrencyId",
                table: "COM_ProformaInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_ProformaInvoices_DayList_DayListId",
                table: "COM_ProformaInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_ProformaInvoices_Destination_PortOfDestinationId",
                table: "COM_ProformaInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_ProformaInvoices_Employee_EmployeeId",
                table: "COM_ProformaInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_ProformaInvoices_GroupLC_Main_GroupLCId",
                table: "COM_ProformaInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_ProformaInvoices_ItemDescription_ItemDescId",
                table: "COM_ProformaInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_ProformaInvoices_ItemGroup_ItemGroupId",
                table: "COM_ProformaInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_ProformaInvoices_LienBank_LienBankId",
                table: "COM_ProformaInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_ProformaInvoices_OpeningBank_OpeningBankId",
                table: "COM_ProformaInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_ProformaInvoices_PIType_PITypeId",
                table: "COM_ProformaInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_ProformaInvoices_PaymentTermss_PaymentTermsId",
                table: "COM_ProformaInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_ProformaInvoices_PortOfLoading_PortOfLoadingCountryOfOriginId",
                table: "COM_ProformaInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_ProformaInvoices_PortOfLoading_PortOfLoadingDestinationId",
                table: "COM_ProformaInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_ProformaInvoices_PortOfLoading_PortOfLoadingId",
                table: "COM_ProformaInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_ProformaInvoices_Supplier_SupplierId",
                table: "COM_ProformaInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_ProformaInvoices_Unit_UnitId",
                table: "COM_ProformaInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_ProformaInvoices_UserAccount_LuserId",
                table: "COM_ProformaInvoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_COM_ProformaInvoices",
                table: "COM_ProformaInvoices");

            migrationBuilder.RenameTable(
                name: "COM_ProformaInvoices",
                newName: "Com_proformaInvoice");

            migrationBuilder.RenameIndex(
                name: "IX_COM_ProformaInvoices_UnitId",
                table: "Com_proformaInvoice",
                newName: "IX_Com_proformaInvoice_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_COM_ProformaInvoices_SupplierId",
                table: "Com_proformaInvoice",
                newName: "IX_Com_proformaInvoice_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_COM_ProformaInvoices_PortOfLoadingId",
                table: "Com_proformaInvoice",
                newName: "IX_Com_proformaInvoice_PortOfLoadingId");

            migrationBuilder.RenameIndex(
                name: "IX_COM_ProformaInvoices_PortOfLoadingDestinationId",
                table: "Com_proformaInvoice",
                newName: "IX_Com_proformaInvoice_PortOfLoadingDestinationId");

            migrationBuilder.RenameIndex(
                name: "IX_COM_ProformaInvoices_PortOfLoadingCountryOfOriginId",
                table: "Com_proformaInvoice",
                newName: "IX_Com_proformaInvoice_PortOfLoadingCountryOfOriginId");

            migrationBuilder.RenameIndex(
                name: "IX_COM_ProformaInvoices_PortOfDestinationId",
                table: "Com_proformaInvoice",
                newName: "IX_Com_proformaInvoice_PortOfDestinationId");

            migrationBuilder.RenameIndex(
                name: "IX_COM_ProformaInvoices_PITypeId",
                table: "Com_proformaInvoice",
                newName: "IX_Com_proformaInvoice_PITypeId");

            migrationBuilder.RenameIndex(
                name: "IX_COM_ProformaInvoices_PaymentTermsId",
                table: "Com_proformaInvoice",
                newName: "IX_Com_proformaInvoice_PaymentTermsId");

            migrationBuilder.RenameIndex(
                name: "IX_COM_ProformaInvoices_OpeningBankId",
                table: "Com_proformaInvoice",
                newName: "IX_Com_proformaInvoice_OpeningBankId");

            migrationBuilder.RenameIndex(
                name: "IX_COM_ProformaInvoices_LuserId",
                table: "Com_proformaInvoice",
                newName: "IX_Com_proformaInvoice_LuserId");

            migrationBuilder.RenameIndex(
                name: "IX_COM_ProformaInvoices_LienBankId",
                table: "Com_proformaInvoice",
                newName: "IX_Com_proformaInvoice_LienBankId");

            migrationBuilder.RenameIndex(
                name: "IX_COM_ProformaInvoices_ItemGroupId",
                table: "Com_proformaInvoice",
                newName: "IX_Com_proformaInvoice_ItemGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_COM_ProformaInvoices_ItemDescId",
                table: "Com_proformaInvoice",
                newName: "IX_Com_proformaInvoice_ItemDescId");

            migrationBuilder.RenameIndex(
                name: "IX_COM_ProformaInvoices_GroupLCId",
                table: "Com_proformaInvoice",
                newName: "IX_Com_proformaInvoice_GroupLCId");

            migrationBuilder.RenameIndex(
                name: "IX_COM_ProformaInvoices_EmployeeId",
                table: "Com_proformaInvoice",
                newName: "IX_Com_proformaInvoice_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_COM_ProformaInvoices_DayListId",
                table: "Com_proformaInvoice",
                newName: "IX_Com_proformaInvoice_DayListId");

            migrationBuilder.RenameIndex(
                name: "IX_COM_ProformaInvoices_CurrencyId",
                table: "Com_proformaInvoice",
                newName: "IX_Com_proformaInvoice_CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_COM_ProformaInvoices_CommercialCompanyId",
                table: "Com_proformaInvoice",
                newName: "IX_Com_proformaInvoice_CommercialCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_COM_ProformaInvoices_ComId",
                table: "Com_proformaInvoice",
                newName: "IX_Com_proformaInvoice_ComId");

            migrationBuilder.RenameIndex(
                name: "IX_COM_ProformaInvoices_BankAccountNoLienBankId",
                table: "Com_proformaInvoice",
                newName: "IX_Com_proformaInvoice_BankAccountNoLienBankId");

            migrationBuilder.RenameIndex(
                name: "IX_COM_ProformaInvoices_BankAccountId",
                table: "Com_proformaInvoice",
                newName: "IX_Com_proformaInvoice_BankAccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Com_proformaInvoice",
                table: "Com_proformaInvoice",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BBLC_Details_Com_proformaInvoice_PIId",
                table: "BBLC_Details",
                column: "PIId",
                principalTable: "Com_proformaInvoice",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_MachinaryLC_Details_Com_proformaInvoice_PIId",
                table: "COM_MachinaryLC_Details",
                column: "PIId",
                principalTable: "Com_proformaInvoice",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_proformaInvoice_BankAccountNoLienBank_BankAccountNoLienBankId",
                table: "Com_proformaInvoice",
                column: "BankAccountNoLienBankId",
                principalTable: "BankAccountNoLienBank",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_proformaInvoice_BankAccountNo_BankAccountId",
                table: "Com_proformaInvoice",
                column: "BankAccountId",
                principalTable: "BankAccountNo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_proformaInvoice_Commercial_CommercialCompanyId",
                table: "Com_proformaInvoice",
                column: "CommercialCompanyId",
                principalTable: "Commercial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_proformaInvoice_Company_ComId",
                table: "Com_proformaInvoice",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Com_proformaInvoice_Country_CurrencyId",
                table: "Com_proformaInvoice",
                column: "CurrencyId",
                principalTable: "Country",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_proformaInvoice_DayList_DayListId",
                table: "Com_proformaInvoice",
                column: "DayListId",
                principalTable: "DayList",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_proformaInvoice_Destination_PortOfDestinationId",
                table: "Com_proformaInvoice",
                column: "PortOfDestinationId",
                principalTable: "Destination",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_proformaInvoice_Employee_EmployeeId",
                table: "Com_proformaInvoice",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_proformaInvoice_GroupLC_Main_GroupLCId",
                table: "Com_proformaInvoice",
                column: "GroupLCId",
                principalTable: "GroupLC_Main",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_proformaInvoice_ItemDescription_ItemDescId",
                table: "Com_proformaInvoice",
                column: "ItemDescId",
                principalTable: "ItemDescription",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_proformaInvoice_ItemGroup_ItemGroupId",
                table: "Com_proformaInvoice",
                column: "ItemGroupId",
                principalTable: "ItemGroup",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_proformaInvoice_LienBank_LienBankId",
                table: "Com_proformaInvoice",
                column: "LienBankId",
                principalTable: "LienBank",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_proformaInvoice_OpeningBank_OpeningBankId",
                table: "Com_proformaInvoice",
                column: "OpeningBankId",
                principalTable: "OpeningBank",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_proformaInvoice_PIType_PITypeId",
                table: "Com_proformaInvoice",
                column: "PITypeId",
                principalTable: "PIType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_proformaInvoice_PaymentTermss_PaymentTermsId",
                table: "Com_proformaInvoice",
                column: "PaymentTermsId",
                principalTable: "PaymentTermss",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_proformaInvoice_PortOfLoading_PortOfLoadingCountryOfOriginId",
                table: "Com_proformaInvoice",
                column: "PortOfLoadingCountryOfOriginId",
                principalTable: "PortOfLoading",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_proformaInvoice_PortOfLoading_PortOfLoadingDestinationId",
                table: "Com_proformaInvoice",
                column: "PortOfLoadingDestinationId",
                principalTable: "PortOfLoading",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_proformaInvoice_PortOfLoading_PortOfLoadingId",
                table: "Com_proformaInvoice",
                column: "PortOfLoadingId",
                principalTable: "PortOfLoading",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_proformaInvoice_Supplier_SupplierId",
                table: "Com_proformaInvoice",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_proformaInvoice_Unit_UnitId",
                table: "Com_proformaInvoice",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_proformaInvoice_UserAccount_LuserId",
                table: "Com_proformaInvoice",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_ProformaInvoice_Sub_Com_proformaInvoice_PIId",
                table: "COM_ProformaInvoice_Sub",
                column: "PIId",
                principalTable: "Com_proformaInvoice",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BBLC_Details_Com_proformaInvoice_PIId",
                table: "BBLC_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_MachinaryLC_Details_Com_proformaInvoice_PIId",
                table: "COM_MachinaryLC_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_proformaInvoice_BankAccountNoLienBank_BankAccountNoLienBankId",
                table: "Com_proformaInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_proformaInvoice_BankAccountNo_BankAccountId",
                table: "Com_proformaInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_proformaInvoice_Commercial_CommercialCompanyId",
                table: "Com_proformaInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_proformaInvoice_Company_ComId",
                table: "Com_proformaInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_proformaInvoice_Country_CurrencyId",
                table: "Com_proformaInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_proformaInvoice_DayList_DayListId",
                table: "Com_proformaInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_proformaInvoice_Destination_PortOfDestinationId",
                table: "Com_proformaInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_proformaInvoice_Employee_EmployeeId",
                table: "Com_proformaInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_proformaInvoice_GroupLC_Main_GroupLCId",
                table: "Com_proformaInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_proformaInvoice_ItemDescription_ItemDescId",
                table: "Com_proformaInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_proformaInvoice_ItemGroup_ItemGroupId",
                table: "Com_proformaInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_proformaInvoice_LienBank_LienBankId",
                table: "Com_proformaInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_proformaInvoice_OpeningBank_OpeningBankId",
                table: "Com_proformaInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_proformaInvoice_PIType_PITypeId",
                table: "Com_proformaInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_proformaInvoice_PaymentTermss_PaymentTermsId",
                table: "Com_proformaInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_proformaInvoice_PortOfLoading_PortOfLoadingCountryOfOriginId",
                table: "Com_proformaInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_proformaInvoice_PortOfLoading_PortOfLoadingDestinationId",
                table: "Com_proformaInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_proformaInvoice_PortOfLoading_PortOfLoadingId",
                table: "Com_proformaInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_proformaInvoice_Supplier_SupplierId",
                table: "Com_proformaInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_proformaInvoice_Unit_UnitId",
                table: "Com_proformaInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_proformaInvoice_UserAccount_LuserId",
                table: "Com_proformaInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_ProformaInvoice_Sub_Com_proformaInvoice_PIId",
                table: "COM_ProformaInvoice_Sub");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Com_proformaInvoice",
                table: "Com_proformaInvoice");

            migrationBuilder.RenameTable(
                name: "Com_proformaInvoice",
                newName: "COM_ProformaInvoices");

            migrationBuilder.RenameIndex(
                name: "IX_Com_proformaInvoice_UnitId",
                table: "COM_ProformaInvoices",
                newName: "IX_COM_ProformaInvoices_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_proformaInvoice_SupplierId",
                table: "COM_ProformaInvoices",
                newName: "IX_COM_ProformaInvoices_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_proformaInvoice_PortOfLoadingId",
                table: "COM_ProformaInvoices",
                newName: "IX_COM_ProformaInvoices_PortOfLoadingId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_proformaInvoice_PortOfLoadingDestinationId",
                table: "COM_ProformaInvoices",
                newName: "IX_COM_ProformaInvoices_PortOfLoadingDestinationId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_proformaInvoice_PortOfLoadingCountryOfOriginId",
                table: "COM_ProformaInvoices",
                newName: "IX_COM_ProformaInvoices_PortOfLoadingCountryOfOriginId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_proformaInvoice_PortOfDestinationId",
                table: "COM_ProformaInvoices",
                newName: "IX_COM_ProformaInvoices_PortOfDestinationId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_proformaInvoice_PITypeId",
                table: "COM_ProformaInvoices",
                newName: "IX_COM_ProformaInvoices_PITypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_proformaInvoice_PaymentTermsId",
                table: "COM_ProformaInvoices",
                newName: "IX_COM_ProformaInvoices_PaymentTermsId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_proformaInvoice_OpeningBankId",
                table: "COM_ProformaInvoices",
                newName: "IX_COM_ProformaInvoices_OpeningBankId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_proformaInvoice_LuserId",
                table: "COM_ProformaInvoices",
                newName: "IX_COM_ProformaInvoices_LuserId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_proformaInvoice_LienBankId",
                table: "COM_ProformaInvoices",
                newName: "IX_COM_ProformaInvoices_LienBankId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_proformaInvoice_ItemGroupId",
                table: "COM_ProformaInvoices",
                newName: "IX_COM_ProformaInvoices_ItemGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_proformaInvoice_ItemDescId",
                table: "COM_ProformaInvoices",
                newName: "IX_COM_ProformaInvoices_ItemDescId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_proformaInvoice_GroupLCId",
                table: "COM_ProformaInvoices",
                newName: "IX_COM_ProformaInvoices_GroupLCId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_proformaInvoice_EmployeeId",
                table: "COM_ProformaInvoices",
                newName: "IX_COM_ProformaInvoices_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_proformaInvoice_DayListId",
                table: "COM_ProformaInvoices",
                newName: "IX_COM_ProformaInvoices_DayListId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_proformaInvoice_CurrencyId",
                table: "COM_ProformaInvoices",
                newName: "IX_COM_ProformaInvoices_CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_proformaInvoice_CommercialCompanyId",
                table: "COM_ProformaInvoices",
                newName: "IX_COM_ProformaInvoices_CommercialCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_proformaInvoice_ComId",
                table: "COM_ProformaInvoices",
                newName: "IX_COM_ProformaInvoices_ComId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_proformaInvoice_BankAccountNoLienBankId",
                table: "COM_ProformaInvoices",
                newName: "IX_COM_ProformaInvoices_BankAccountNoLienBankId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_proformaInvoice_BankAccountId",
                table: "COM_ProformaInvoices",
                newName: "IX_COM_ProformaInvoices_BankAccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_COM_ProformaInvoices",
                table: "COM_ProformaInvoices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BBLC_Details_COM_ProformaInvoices_PIId",
                table: "BBLC_Details",
                column: "PIId",
                principalTable: "COM_ProformaInvoices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_MachinaryLC_Details_COM_ProformaInvoices_PIId",
                table: "COM_MachinaryLC_Details",
                column: "PIId",
                principalTable: "COM_ProformaInvoices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_ProformaInvoice_Sub_COM_ProformaInvoices_PIId",
                table: "COM_ProformaInvoice_Sub",
                column: "PIId",
                principalTable: "COM_ProformaInvoices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_ProformaInvoices_BankAccountNoLienBank_BankAccountNoLienBankId",
                table: "COM_ProformaInvoices",
                column: "BankAccountNoLienBankId",
                principalTable: "BankAccountNoLienBank",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_ProformaInvoices_BankAccountNo_BankAccountId",
                table: "COM_ProformaInvoices",
                column: "BankAccountId",
                principalTable: "BankAccountNo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_ProformaInvoices_Commercial_CommercialCompanyId",
                table: "COM_ProformaInvoices",
                column: "CommercialCompanyId",
                principalTable: "Commercial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_ProformaInvoices_Company_ComId",
                table: "COM_ProformaInvoices",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_ProformaInvoices_Country_CurrencyId",
                table: "COM_ProformaInvoices",
                column: "CurrencyId",
                principalTable: "Country",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_ProformaInvoices_DayList_DayListId",
                table: "COM_ProformaInvoices",
                column: "DayListId",
                principalTable: "DayList",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_ProformaInvoices_Destination_PortOfDestinationId",
                table: "COM_ProformaInvoices",
                column: "PortOfDestinationId",
                principalTable: "Destination",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_ProformaInvoices_Employee_EmployeeId",
                table: "COM_ProformaInvoices",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_ProformaInvoices_GroupLC_Main_GroupLCId",
                table: "COM_ProformaInvoices",
                column: "GroupLCId",
                principalTable: "GroupLC_Main",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_ProformaInvoices_ItemDescription_ItemDescId",
                table: "COM_ProformaInvoices",
                column: "ItemDescId",
                principalTable: "ItemDescription",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_ProformaInvoices_ItemGroup_ItemGroupId",
                table: "COM_ProformaInvoices",
                column: "ItemGroupId",
                principalTable: "ItemGroup",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_ProformaInvoices_LienBank_LienBankId",
                table: "COM_ProformaInvoices",
                column: "LienBankId",
                principalTable: "LienBank",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_ProformaInvoices_OpeningBank_OpeningBankId",
                table: "COM_ProformaInvoices",
                column: "OpeningBankId",
                principalTable: "OpeningBank",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_ProformaInvoices_PIType_PITypeId",
                table: "COM_ProformaInvoices",
                column: "PITypeId",
                principalTable: "PIType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_ProformaInvoices_PaymentTermss_PaymentTermsId",
                table: "COM_ProformaInvoices",
                column: "PaymentTermsId",
                principalTable: "PaymentTermss",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_ProformaInvoices_PortOfLoading_PortOfLoadingCountryOfOriginId",
                table: "COM_ProformaInvoices",
                column: "PortOfLoadingCountryOfOriginId",
                principalTable: "PortOfLoading",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_ProformaInvoices_PortOfLoading_PortOfLoadingDestinationId",
                table: "COM_ProformaInvoices",
                column: "PortOfLoadingDestinationId",
                principalTable: "PortOfLoading",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_ProformaInvoices_PortOfLoading_PortOfLoadingId",
                table: "COM_ProformaInvoices",
                column: "PortOfLoadingId",
                principalTable: "PortOfLoading",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_ProformaInvoices_Supplier_SupplierId",
                table: "COM_ProformaInvoices",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_ProformaInvoices_Unit_UnitId",
                table: "COM_ProformaInvoices",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_ProformaInvoices_UserAccount_LuserId",
                table: "COM_ProformaInvoices",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
