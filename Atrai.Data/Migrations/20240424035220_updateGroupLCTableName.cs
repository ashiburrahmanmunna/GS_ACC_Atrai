using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateGroupLCTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BBLCMaster_GroupLC_Main_GroupLCId",
                table: "BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_DocumentAcceptance_Master_GroupLC_Main_GroupLCId",
                table: "COM_DocumentAcceptance_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_proformaInvoice_GroupLC_Main_GroupLCId",
                table: "Com_proformaInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupLC_Main_CommercialCompanies_CommercialCompanyId",
                table: "GroupLC_Main");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupLC_Main_Company_ComId",
                table: "GroupLC_Main");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupLC_Main_Customer_BuyerId",
                table: "GroupLC_Main");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupLC_Main_UserAccount_LuserId",
                table: "GroupLC_Main");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupLC_Sub_Company_ComId",
                table: "GroupLC_Sub");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupLC_Sub_GroupLC_Main_GroupLCId",
                table: "GroupLC_Sub");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupLC_Sub_MasterLC_MasterLCID",
                table: "GroupLC_Sub");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupLC_Sub_UserAccount_LuserId",
                table: "GroupLC_Sub");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupLC_Sub",
                table: "GroupLC_Sub");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupLC_Main",
                table: "GroupLC_Main");

            migrationBuilder.RenameTable(
                name: "GroupLC_Sub",
                newName: "Com_GroupLC_Sub");

            migrationBuilder.RenameTable(
                name: "GroupLC_Main",
                newName: "Com_GroupLC_Main");

            migrationBuilder.RenameIndex(
                name: "IX_GroupLC_Sub_MasterLCID",
                table: "Com_GroupLC_Sub",
                newName: "IX_Com_GroupLC_Sub_MasterLCID");

            migrationBuilder.RenameIndex(
                name: "IX_GroupLC_Sub_LuserId",
                table: "Com_GroupLC_Sub",
                newName: "IX_Com_GroupLC_Sub_LuserId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupLC_Sub_GroupLCId",
                table: "Com_GroupLC_Sub",
                newName: "IX_Com_GroupLC_Sub_GroupLCId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupLC_Sub_ComId",
                table: "Com_GroupLC_Sub",
                newName: "IX_Com_GroupLC_Sub_ComId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupLC_Main_LuserId",
                table: "Com_GroupLC_Main",
                newName: "IX_Com_GroupLC_Main_LuserId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupLC_Main_CommercialCompanyId",
                table: "Com_GroupLC_Main",
                newName: "IX_Com_GroupLC_Main_CommercialCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupLC_Main_ComId",
                table: "Com_GroupLC_Main",
                newName: "IX_Com_GroupLC_Main_ComId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupLC_Main_BuyerId",
                table: "Com_GroupLC_Main",
                newName: "IX_Com_GroupLC_Main_BuyerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Com_GroupLC_Sub",
                table: "Com_GroupLC_Sub",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Com_GroupLC_Main",
                table: "Com_GroupLC_Main",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BBLCMaster_Com_GroupLC_Main_GroupLCId",
                table: "BBLCMaster",
                column: "GroupLCId",
                principalTable: "Com_GroupLC_Main",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_DocumentAcceptance_Master_Com_GroupLC_Main_GroupLCId",
                table: "COM_DocumentAcceptance_Master",
                column: "GroupLCId",
                principalTable: "Com_GroupLC_Main",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_GroupLC_Main_CommercialCompanies_CommercialCompanyId",
                table: "Com_GroupLC_Main",
                column: "CommercialCompanyId",
                principalTable: "CommercialCompanies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_GroupLC_Main_Company_ComId",
                table: "Com_GroupLC_Main",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Com_GroupLC_Main_Customer_BuyerId",
                table: "Com_GroupLC_Main",
                column: "BuyerId",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_GroupLC_Main_UserAccount_LuserId",
                table: "Com_GroupLC_Main",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Com_GroupLC_Sub_Com_GroupLC_Main_GroupLCId",
                table: "Com_GroupLC_Sub",
                column: "GroupLCId",
                principalTable: "Com_GroupLC_Main",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_GroupLC_Sub_Company_ComId",
                table: "Com_GroupLC_Sub",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Com_GroupLC_Sub_MasterLC_MasterLCID",
                table: "Com_GroupLC_Sub",
                column: "MasterLCID",
                principalTable: "MasterLC",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_GroupLC_Sub_UserAccount_LuserId",
                table: "Com_GroupLC_Sub",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Com_proformaInvoice_Com_GroupLC_Main_GroupLCId",
                table: "Com_proformaInvoice",
                column: "GroupLCId",
                principalTable: "Com_GroupLC_Main",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BBLCMaster_Com_GroupLC_Main_GroupLCId",
                table: "BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_DocumentAcceptance_Master_Com_GroupLC_Main_GroupLCId",
                table: "COM_DocumentAcceptance_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_GroupLC_Main_CommercialCompanies_CommercialCompanyId",
                table: "Com_GroupLC_Main");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_GroupLC_Main_Company_ComId",
                table: "Com_GroupLC_Main");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_GroupLC_Main_Customer_BuyerId",
                table: "Com_GroupLC_Main");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_GroupLC_Main_UserAccount_LuserId",
                table: "Com_GroupLC_Main");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_GroupLC_Sub_Com_GroupLC_Main_GroupLCId",
                table: "Com_GroupLC_Sub");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_GroupLC_Sub_Company_ComId",
                table: "Com_GroupLC_Sub");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_GroupLC_Sub_MasterLC_MasterLCID",
                table: "Com_GroupLC_Sub");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_GroupLC_Sub_UserAccount_LuserId",
                table: "Com_GroupLC_Sub");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_proformaInvoice_Com_GroupLC_Main_GroupLCId",
                table: "Com_proformaInvoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Com_GroupLC_Sub",
                table: "Com_GroupLC_Sub");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Com_GroupLC_Main",
                table: "Com_GroupLC_Main");

            migrationBuilder.RenameTable(
                name: "Com_GroupLC_Sub",
                newName: "GroupLC_Sub");

            migrationBuilder.RenameTable(
                name: "Com_GroupLC_Main",
                newName: "GroupLC_Main");

            migrationBuilder.RenameIndex(
                name: "IX_Com_GroupLC_Sub_MasterLCID",
                table: "GroupLC_Sub",
                newName: "IX_GroupLC_Sub_MasterLCID");

            migrationBuilder.RenameIndex(
                name: "IX_Com_GroupLC_Sub_LuserId",
                table: "GroupLC_Sub",
                newName: "IX_GroupLC_Sub_LuserId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_GroupLC_Sub_GroupLCId",
                table: "GroupLC_Sub",
                newName: "IX_GroupLC_Sub_GroupLCId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_GroupLC_Sub_ComId",
                table: "GroupLC_Sub",
                newName: "IX_GroupLC_Sub_ComId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_GroupLC_Main_LuserId",
                table: "GroupLC_Main",
                newName: "IX_GroupLC_Main_LuserId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_GroupLC_Main_CommercialCompanyId",
                table: "GroupLC_Main",
                newName: "IX_GroupLC_Main_CommercialCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_GroupLC_Main_ComId",
                table: "GroupLC_Main",
                newName: "IX_GroupLC_Main_ComId");

            migrationBuilder.RenameIndex(
                name: "IX_Com_GroupLC_Main_BuyerId",
                table: "GroupLC_Main",
                newName: "IX_GroupLC_Main_BuyerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupLC_Sub",
                table: "GroupLC_Sub",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupLC_Main",
                table: "GroupLC_Main",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BBLCMaster_GroupLC_Main_GroupLCId",
                table: "BBLCMaster",
                column: "GroupLCId",
                principalTable: "GroupLC_Main",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_DocumentAcceptance_Master_GroupLC_Main_GroupLCId",
                table: "COM_DocumentAcceptance_Master",
                column: "GroupLCId",
                principalTable: "GroupLC_Main",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_proformaInvoice_GroupLC_Main_GroupLCId",
                table: "Com_proformaInvoice",
                column: "GroupLCId",
                principalTable: "GroupLC_Main",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupLC_Main_CommercialCompanies_CommercialCompanyId",
                table: "GroupLC_Main",
                column: "CommercialCompanyId",
                principalTable: "CommercialCompanies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupLC_Main_Company_ComId",
                table: "GroupLC_Main",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupLC_Main_Customer_BuyerId",
                table: "GroupLC_Main",
                column: "BuyerId",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupLC_Main_UserAccount_LuserId",
                table: "GroupLC_Main",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupLC_Sub_Company_ComId",
                table: "GroupLC_Sub",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupLC_Sub_GroupLC_Main_GroupLCId",
                table: "GroupLC_Sub",
                column: "GroupLCId",
                principalTable: "GroupLC_Main",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupLC_Sub_MasterLC_MasterLCID",
                table: "GroupLC_Sub",
                column: "MasterLCID",
                principalTable: "MasterLC",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupLC_Sub_UserAccount_LuserId",
                table: "GroupLC_Sub",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
