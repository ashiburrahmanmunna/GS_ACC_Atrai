using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class CommercialModelUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destination_Country_CountrysId",
                table: "Destination");

            migrationBuilder.DropForeignKey(
                name: "FK_ExportInvoiceMaster_Customer_BuyerInformationId",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_ExportInvoiceMaster_MasterLC_COM_MasterLCId",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemDescription_ItemGroup_ItemGroupsId",
                table: "ItemDescription");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_BankAccountNo_BankAccountNosId",
                table: "MasterLC");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_Commercial_CommercialCompaniesId",
                table: "MasterLC");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_Customer_BuyerInformationsId",
                table: "MasterLC");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_PaymentTermss_PaymentTermsId",
                table: "MasterLC");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_UnitMaster_UnitMasterId1",
                table: "MasterLC");

            migrationBuilder.DropForeignKey(
                name: "FK_PortOfDischarge_Country_CountrysId",
                table: "PortOfDischarge");

            migrationBuilder.DropForeignKey(
                name: "FK_PortOfLoading_Country_CountrysId",
                table: "PortOfLoading");

            migrationBuilder.DropIndex(
                name: "IX_PortOfLoading_CountrysId",
                table: "PortOfLoading");

            migrationBuilder.DropIndex(
                name: "IX_PortOfDischarge_CountrysId",
                table: "PortOfDischarge");

            migrationBuilder.DropIndex(
                name: "IX_MasterLC_BankAccountNosId",
                table: "MasterLC");

            migrationBuilder.DropIndex(
                name: "IX_MasterLC_BuyerInformationsId",
                table: "MasterLC");

            migrationBuilder.DropIndex(
                name: "IX_MasterLC_CommercialCompaniesId",
                table: "MasterLC");

            migrationBuilder.DropIndex(
                name: "IX_MasterLC_UnitMasterId1",
                table: "MasterLC");

            migrationBuilder.DropIndex(
                name: "IX_ItemDescription_ItemGroupsId",
                table: "ItemDescription");

            migrationBuilder.DropIndex(
                name: "IX_ExportInvoiceMaster_BuyerInformationId",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropIndex(
                name: "IX_ExportInvoiceMaster_COM_MasterLCId",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropIndex(
                name: "IX_Destination_CountrysId",
                table: "Destination");

            migrationBuilder.DropColumn(
                name: "CountrysId",
                table: "PortOfLoading");

            migrationBuilder.DropColumn(
                name: "CountrysId",
                table: "PortOfDischarge");

            migrationBuilder.DropColumn(
                name: "BankAccountNosId",
                table: "MasterLC");

            migrationBuilder.DropColumn(
                name: "BuyerInformationsId",
                table: "MasterLC");

            migrationBuilder.DropColumn(
                name: "CommercialCompaniesId",
                table: "MasterLC");

            migrationBuilder.DropColumn(
                name: "UnitMasterId1",
                table: "MasterLC");

            migrationBuilder.DropColumn(
                name: "ItemGroupsId",
                table: "ItemDescription");

            migrationBuilder.DropColumn(
                name: "BuyerInformationId",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropColumn(
                name: "COM_MasterLCId",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropColumn(
                name: "CountrysId",
                table: "Destination");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentTermsId",
                table: "MasterLC",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_PortOfLoading_CountryId",
                table: "PortOfLoading",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PortOfDischarge_CountryId",
                table: "PortOfDischarge",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterLC_BankAccountId",
                table: "MasterLC",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterLC_BuyerID",
                table: "MasterLC",
                column: "BuyerID");

            migrationBuilder.CreateIndex(
                name: "IX_MasterLC_CommercialCompanyId",
                table: "MasterLC",
                column: "CommercialCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterLC_unitId",
                table: "MasterLC",
                column: "unitId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDescription_ItemGroupId",
                table: "ItemDescription",
                column: "ItemGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoiceMaster_BuyerId",
                table: "ExportInvoiceMaster",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoiceMaster_MasterLCId",
                table: "ExportInvoiceMaster",
                column: "MasterLCId");

            migrationBuilder.CreateIndex(
                name: "IX_Destination_CountryId",
                table: "Destination",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Destination_Country_CountryId",
                table: "Destination",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportInvoiceMaster_Customer_BuyerId",
                table: "ExportInvoiceMaster",
                column: "BuyerId",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportInvoiceMaster_MasterLC_MasterLCId",
                table: "ExportInvoiceMaster",
                column: "MasterLCId",
                principalTable: "MasterLC",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemDescription_ItemGroup_ItemGroupId",
                table: "ItemDescription",
                column: "ItemGroupId",
                principalTable: "ItemGroup",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_BankAccountNo_BankAccountId",
                table: "MasterLC",
                column: "BankAccountId",
                principalTable: "BankAccountNo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_Commercial_CommercialCompanyId",
                table: "MasterLC",
                column: "CommercialCompanyId",
                principalTable: "Commercial",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_Customer_BuyerID",
                table: "MasterLC",
                column: "BuyerID",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_PaymentTermss_PaymentTermsId",
                table: "MasterLC",
                column: "PaymentTermsId",
                principalTable: "PaymentTermss",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_UnitMaster_unitId",
                table: "MasterLC",
                column: "unitId",
                principalTable: "UnitMaster",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PortOfDischarge_Country_CountryId",
                table: "PortOfDischarge",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PortOfLoading_Country_CountryId",
                table: "PortOfLoading",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destination_Country_CountryId",
                table: "Destination");

            migrationBuilder.DropForeignKey(
                name: "FK_ExportInvoiceMaster_Customer_BuyerId",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_ExportInvoiceMaster_MasterLC_MasterLCId",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemDescription_ItemGroup_ItemGroupId",
                table: "ItemDescription");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_BankAccountNo_BankAccountId",
                table: "MasterLC");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_Commercial_CommercialCompanyId",
                table: "MasterLC");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_Customer_BuyerID",
                table: "MasterLC");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_PaymentTermss_PaymentTermsId",
                table: "MasterLC");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_UnitMaster_unitId",
                table: "MasterLC");

            migrationBuilder.DropForeignKey(
                name: "FK_PortOfDischarge_Country_CountryId",
                table: "PortOfDischarge");

            migrationBuilder.DropForeignKey(
                name: "FK_PortOfLoading_Country_CountryId",
                table: "PortOfLoading");

            migrationBuilder.DropIndex(
                name: "IX_PortOfLoading_CountryId",
                table: "PortOfLoading");

            migrationBuilder.DropIndex(
                name: "IX_PortOfDischarge_CountryId",
                table: "PortOfDischarge");

            migrationBuilder.DropIndex(
                name: "IX_MasterLC_BankAccountId",
                table: "MasterLC");

            migrationBuilder.DropIndex(
                name: "IX_MasterLC_BuyerID",
                table: "MasterLC");

            migrationBuilder.DropIndex(
                name: "IX_MasterLC_CommercialCompanyId",
                table: "MasterLC");

            migrationBuilder.DropIndex(
                name: "IX_MasterLC_unitId",
                table: "MasterLC");

            migrationBuilder.DropIndex(
                name: "IX_ItemDescription_ItemGroupId",
                table: "ItemDescription");

            migrationBuilder.DropIndex(
                name: "IX_ExportInvoiceMaster_BuyerId",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropIndex(
                name: "IX_ExportInvoiceMaster_MasterLCId",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropIndex(
                name: "IX_Destination_CountryId",
                table: "Destination");

            migrationBuilder.AddColumn<int>(
                name: "CountrysId",
                table: "PortOfLoading",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountrysId",
                table: "PortOfDischarge",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PaymentTermsId",
                table: "MasterLC",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BankAccountNosId",
                table: "MasterLC",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BuyerInformationsId",
                table: "MasterLC",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommercialCompaniesId",
                table: "MasterLC",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitMasterId1",
                table: "MasterLC",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemGroupsId",
                table: "ItemDescription",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BuyerInformationId",
                table: "ExportInvoiceMaster",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "COM_MasterLCId",
                table: "ExportInvoiceMaster",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountrysId",
                table: "Destination",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PortOfLoading_CountrysId",
                table: "PortOfLoading",
                column: "CountrysId");

            migrationBuilder.CreateIndex(
                name: "IX_PortOfDischarge_CountrysId",
                table: "PortOfDischarge",
                column: "CountrysId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterLC_BankAccountNosId",
                table: "MasterLC",
                column: "BankAccountNosId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterLC_BuyerInformationsId",
                table: "MasterLC",
                column: "BuyerInformationsId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterLC_CommercialCompaniesId",
                table: "MasterLC",
                column: "CommercialCompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterLC_UnitMasterId1",
                table: "MasterLC",
                column: "UnitMasterId1");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDescription_ItemGroupsId",
                table: "ItemDescription",
                column: "ItemGroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoiceMaster_BuyerInformationId",
                table: "ExportInvoiceMaster",
                column: "BuyerInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoiceMaster_COM_MasterLCId",
                table: "ExportInvoiceMaster",
                column: "COM_MasterLCId");

            migrationBuilder.CreateIndex(
                name: "IX_Destination_CountrysId",
                table: "Destination",
                column: "CountrysId");

            migrationBuilder.AddForeignKey(
                name: "FK_Destination_Country_CountrysId",
                table: "Destination",
                column: "CountrysId",
                principalTable: "Country",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportInvoiceMaster_Customer_BuyerInformationId",
                table: "ExportInvoiceMaster",
                column: "BuyerInformationId",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportInvoiceMaster_MasterLC_COM_MasterLCId",
                table: "ExportInvoiceMaster",
                column: "COM_MasterLCId",
                principalTable: "MasterLC",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemDescription_ItemGroup_ItemGroupsId",
                table: "ItemDescription",
                column: "ItemGroupsId",
                principalTable: "ItemGroup",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_BankAccountNo_BankAccountNosId",
                table: "MasterLC",
                column: "BankAccountNosId",
                principalTable: "BankAccountNo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_Commercial_CommercialCompaniesId",
                table: "MasterLC",
                column: "CommercialCompaniesId",
                principalTable: "Commercial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_Customer_BuyerInformationsId",
                table: "MasterLC",
                column: "BuyerInformationsId",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_PaymentTermss_PaymentTermsId",
                table: "MasterLC",
                column: "PaymentTermsId",
                principalTable: "PaymentTermss",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_UnitMaster_UnitMasterId1",
                table: "MasterLC",
                column: "UnitMasterId1",
                principalTable: "UnitMaster",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PortOfDischarge_Country_CountrysId",
                table: "PortOfDischarge",
                column: "CountrysId",
                principalTable: "Country",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PortOfLoading_Country_CountrysId",
                table: "PortOfLoading",
                column: "CountrysId",
                principalTable: "Country",
                principalColumn: "Id");
        }
    }
}
