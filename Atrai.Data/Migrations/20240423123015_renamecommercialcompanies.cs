using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class renamecommercialcompanies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccountNo_Commercial_CommercialCompanyId",
                table: "BankAccountNo");

            migrationBuilder.DropForeignKey(
                name: "FK_BankAccountNoLienBank_Commercial_CommercialCompanyId",
                table: "BankAccountNoLienBank");

            migrationBuilder.DropForeignKey(
                name: "FK_BBLCMaster_Commercial_CommercialCompanyId",
                table: "BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_BuyerPO_Master_Commercial_CommercialCompanyId",
                table: "BuyerPO_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_CommercialInvoice_Commercial_CommercialCompanyID",
                table: "COM_CommercialInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_DocumentAcceptance_Master_Commercial_CommercialCompanyId",
                table: "COM_DocumentAcceptance_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_MachinaryLC_Master_Commercial_CompanyId",
                table: "COM_MachinaryLC_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_proformaInvoice_Commercial_CommercialCompanyId",
                table: "Com_proformaInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Commercial_Company_ComId",
                table: "Commercial");

            migrationBuilder.DropForeignKey(
                name: "FK_Commercial_UserAccount_LuserId",
                table: "Commercial");

            migrationBuilder.DropForeignKey(
                name: "FK_ExportInvoiceMaster_Commercial_CommercialCompanyId",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_ExportInvoiceMaster_Commercial_ManufactureId",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupLC_Main_Commercial_CommercialCompanyId",
                table: "GroupLC_Main");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_Commercial_CommercialCompanyId",
                table: "MasterLC");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrderMaster_Commercial_CommercialCompanyId",
                table: "WorkOrderMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Commercial",
                table: "Commercial");

            migrationBuilder.RenameTable(
                name: "Commercial",
                newName: "CommercialCompanies");

            migrationBuilder.RenameIndex(
                name: "IX_Commercial_LuserId",
                table: "CommercialCompanies",
                newName: "IX_CommercialCompanies_LuserId");

            migrationBuilder.RenameIndex(
                name: "IX_Commercial_ComId",
                table: "CommercialCompanies",
                newName: "IX_CommercialCompanies_ComId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommercialCompanies",
                table: "CommercialCompanies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccountNo_CommercialCompanies_CommercialCompanyId",
                table: "BankAccountNo",
                column: "CommercialCompanyId",
                principalTable: "CommercialCompanies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccountNoLienBank_CommercialCompanies_CommercialCompanyId",
                table: "BankAccountNoLienBank",
                column: "CommercialCompanyId",
                principalTable: "CommercialCompanies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BBLCMaster_CommercialCompanies_CommercialCompanyId",
                table: "BBLCMaster",
                column: "CommercialCompanyId",
                principalTable: "CommercialCompanies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BuyerPO_Master_CommercialCompanies_CommercialCompanyId",
                table: "BuyerPO_Master",
                column: "CommercialCompanyId",
                principalTable: "CommercialCompanies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_CommercialInvoice_CommercialCompanies_CommercialCompanyID",
                table: "COM_CommercialInvoice",
                column: "CommercialCompanyID",
                principalTable: "CommercialCompanies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_DocumentAcceptance_Master_CommercialCompanies_CommercialCompanyId",
                table: "COM_DocumentAcceptance_Master",
                column: "CommercialCompanyId",
                principalTable: "CommercialCompanies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_MachinaryLC_Master_CommercialCompanies_CompanyId",
                table: "COM_MachinaryLC_Master",
                column: "CompanyId",
                principalTable: "CommercialCompanies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_proformaInvoice_CommercialCompanies_CommercialCompanyId",
                table: "Com_proformaInvoice",
                column: "CommercialCompanyId",
                principalTable: "CommercialCompanies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommercialCompanies_Company_ComId",
                table: "CommercialCompanies",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommercialCompanies_UserAccount_LuserId",
                table: "CommercialCompanies",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ExportInvoiceMaster_CommercialCompanies_CommercialCompanyId",
                table: "ExportInvoiceMaster",
                column: "CommercialCompanyId",
                principalTable: "CommercialCompanies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportInvoiceMaster_CommercialCompanies_ManufactureId",
                table: "ExportInvoiceMaster",
                column: "ManufactureId",
                principalTable: "CommercialCompanies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupLC_Main_CommercialCompanies_CommercialCompanyId",
                table: "GroupLC_Main",
                column: "CommercialCompanyId",
                principalTable: "CommercialCompanies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_CommercialCompanies_CommercialCompanyId",
                table: "MasterLC",
                column: "CommercialCompanyId",
                principalTable: "CommercialCompanies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrderMaster_CommercialCompanies_CommercialCompanyId",
                table: "WorkOrderMaster",
                column: "CommercialCompanyId",
                principalTable: "CommercialCompanies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccountNo_CommercialCompanies_CommercialCompanyId",
                table: "BankAccountNo");

            migrationBuilder.DropForeignKey(
                name: "FK_BankAccountNoLienBank_CommercialCompanies_CommercialCompanyId",
                table: "BankAccountNoLienBank");

            migrationBuilder.DropForeignKey(
                name: "FK_BBLCMaster_CommercialCompanies_CommercialCompanyId",
                table: "BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_BuyerPO_Master_CommercialCompanies_CommercialCompanyId",
                table: "BuyerPO_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_CommercialInvoice_CommercialCompanies_CommercialCompanyID",
                table: "COM_CommercialInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_DocumentAcceptance_Master_CommercialCompanies_CommercialCompanyId",
                table: "COM_DocumentAcceptance_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_MachinaryLC_Master_CommercialCompanies_CompanyId",
                table: "COM_MachinaryLC_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_proformaInvoice_CommercialCompanies_CommercialCompanyId",
                table: "Com_proformaInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_CommercialCompanies_Company_ComId",
                table: "CommercialCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_CommercialCompanies_UserAccount_LuserId",
                table: "CommercialCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_ExportInvoiceMaster_CommercialCompanies_CommercialCompanyId",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_ExportInvoiceMaster_CommercialCompanies_ManufactureId",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupLC_Main_CommercialCompanies_CommercialCompanyId",
                table: "GroupLC_Main");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_CommercialCompanies_CommercialCompanyId",
                table: "MasterLC");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrderMaster_CommercialCompanies_CommercialCompanyId",
                table: "WorkOrderMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommercialCompanies",
                table: "CommercialCompanies");

            migrationBuilder.RenameTable(
                name: "CommercialCompanies",
                newName: "Commercial");

            migrationBuilder.RenameIndex(
                name: "IX_CommercialCompanies_LuserId",
                table: "Commercial",
                newName: "IX_Commercial_LuserId");

            migrationBuilder.RenameIndex(
                name: "IX_CommercialCompanies_ComId",
                table: "Commercial",
                newName: "IX_Commercial_ComId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commercial",
                table: "Commercial",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccountNo_Commercial_CommercialCompanyId",
                table: "BankAccountNo",
                column: "CommercialCompanyId",
                principalTable: "Commercial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccountNoLienBank_Commercial_CommercialCompanyId",
                table: "BankAccountNoLienBank",
                column: "CommercialCompanyId",
                principalTable: "Commercial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BBLCMaster_Commercial_CommercialCompanyId",
                table: "BBLCMaster",
                column: "CommercialCompanyId",
                principalTable: "Commercial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BuyerPO_Master_Commercial_CommercialCompanyId",
                table: "BuyerPO_Master",
                column: "CommercialCompanyId",
                principalTable: "Commercial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_CommercialInvoice_Commercial_CommercialCompanyID",
                table: "COM_CommercialInvoice",
                column: "CommercialCompanyID",
                principalTable: "Commercial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_DocumentAcceptance_Master_Commercial_CommercialCompanyId",
                table: "COM_DocumentAcceptance_Master",
                column: "CommercialCompanyId",
                principalTable: "Commercial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_MachinaryLC_Master_Commercial_CompanyId",
                table: "COM_MachinaryLC_Master",
                column: "CompanyId",
                principalTable: "Commercial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_proformaInvoice_Commercial_CommercialCompanyId",
                table: "Com_proformaInvoice",
                column: "CommercialCompanyId",
                principalTable: "Commercial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Commercial_Company_ComId",
                table: "Commercial",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Commercial_UserAccount_LuserId",
                table: "Commercial",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ExportInvoiceMaster_Commercial_CommercialCompanyId",
                table: "ExportInvoiceMaster",
                column: "CommercialCompanyId",
                principalTable: "Commercial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportInvoiceMaster_Commercial_ManufactureId",
                table: "ExportInvoiceMaster",
                column: "ManufactureId",
                principalTable: "Commercial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupLC_Main_Commercial_CommercialCompanyId",
                table: "GroupLC_Main",
                column: "CommercialCompanyId",
                principalTable: "Commercial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_Commercial_CommercialCompanyId",
                table: "MasterLC",
                column: "CommercialCompanyId",
                principalTable: "Commercial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrderMaster_Commercial_CommercialCompanyId",
                table: "WorkOrderMaster",
                column: "CommercialCompanyId",
                principalTable: "Commercial",
                principalColumn: "Id");
        }
    }
}
