using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class proformaInvoiceModelCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankAccountNoLienBank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SwiftCodeBankAccountNoLienBank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommercialCompanyId = table.Column<int>(type: "int", nullable: true),
                    CommercialCompanysId = table.Column<int>(type: "int", nullable: true),
                    LienBankId = table.Column<int>(type: "int", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    CountrysId = table.Column<int>(type: "int", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    BuyerId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccountNoLienBank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccountNoLienBank_Commercial_CommercialCompanysId",
                        column: x => x.CommercialCompanysId,
                        principalTable: "Commercial",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BankAccountNoLienBank_Country_CountrysId",
                        column: x => x.CountrysId,
                        principalTable: "Country",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BankAccountNoLienBank_Customer_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BankAccountNoLienBank_LienBank_LienBankId",
                        column: x => x.LienBankId,
                        principalTable: "LienBank",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BankAccountNoLienBank_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItemDesc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemDescCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescHSCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ItemDescShortName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ItemGroupId = table.Column<int>(type: "int", nullable: true),
                    ItemGroupsId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDesc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemDesc_ItemGroup_ItemGroupsId",
                        column: x => x.ItemGroupsId,
                        principalTable: "ItemGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PINature",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PINatureName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PINatureShortName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PINature", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "COM_ProformaInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PINo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PIDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PIReceivingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CommercialCompanyId = table.Column<int>(type: "int", nullable: true),
                    CommercialCompaniesId = table.Column<int>(type: "int", nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
                    CurrenciesId = table.Column<int>(type: "int", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    SuppliersId = table.Column<int>(type: "int", nullable: true),
                    ImportPONo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FileNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LCAF = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ItemGroupId = table.Column<int>(type: "int", nullable: true),
                    ItemDescList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemGroupsId = table.Column<int>(type: "int", nullable: true),
                    GroupLCId = table.Column<int>(type: "int", nullable: true),
                    COM_GroupLC_MainsId = table.Column<int>(type: "int", nullable: true),
                    ItemGroupName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ItemDescId = table.Column<int>(type: "int", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Remarks = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: true),
                    ImportQty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UnitMasterId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImportRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CartonRollQty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    HSCode = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    employeesId = table.Column<int>(type: "int", nullable: true),
                    MerchandiserName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    RevNo = table.Column<string>(type: "VARCHAR(300)", maxLength: 300, nullable: true),
                    UnitMasterId1 = table.Column<int>(type: "int", nullable: true),
                    PaymentTermsId = table.Column<int>(type: "int", nullable: true),
                    DayListId = table.Column<int>(type: "int", nullable: true),
                    OpeningBankId = table.Column<int>(type: "int", nullable: true),
                    BankAccountId = table.Column<int>(type: "int", nullable: true),
                    BankAccountNosId = table.Column<int>(type: "int", nullable: true),
                    LienBankAccountId = table.Column<int>(type: "int", nullable: true),
                    BankAccountNoLienBanksId = table.Column<int>(type: "int", nullable: true),
                    PINatureId = table.Column<int>(type: "int", nullable: true),
                    PortOfLoadingId = table.Column<int>(type: "int", nullable: true),
                    PortOfLoadingDestinationId = table.Column<int>(type: "int", nullable: true),
                    PortOfLoadingCountryOfOriginId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COM_ProformaInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COM_ProformaInvoices_BankAccountNoLienBank_BankAccountNoLienBanksId",
                        column: x => x.BankAccountNoLienBanksId,
                        principalTable: "BankAccountNoLienBank",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_ProformaInvoices_BankAccountNo_BankAccountNosId",
                        column: x => x.BankAccountNosId,
                        principalTable: "BankAccountNo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_ProformaInvoices_Commercial_CommercialCompaniesId",
                        column: x => x.CommercialCompaniesId,
                        principalTable: "Commercial",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_ProformaInvoices_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_COM_ProformaInvoices_Country_CurrenciesId",
                        column: x => x.CurrenciesId,
                        principalTable: "Country",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_ProformaInvoices_DayList_DayListId",
                        column: x => x.DayListId,
                        principalTable: "DayList",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_ProformaInvoices_Employee_employeesId",
                        column: x => x.employeesId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_ProformaInvoices_GroupLC_Main_COM_GroupLC_MainsId",
                        column: x => x.COM_GroupLC_MainsId,
                        principalTable: "GroupLC_Main",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_ProformaInvoices_ItemDesc_ItemDescId",
                        column: x => x.ItemDescId,
                        principalTable: "ItemDesc",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_ProformaInvoices_ItemGroup_ItemGroupsId",
                        column: x => x.ItemGroupsId,
                        principalTable: "ItemGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_ProformaInvoices_OpeningBank_OpeningBankId",
                        column: x => x.OpeningBankId,
                        principalTable: "OpeningBank",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_ProformaInvoices_PINature_PINatureId",
                        column: x => x.PINatureId,
                        principalTable: "PINature",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_ProformaInvoices_PaymentTermss_PaymentTermsId",
                        column: x => x.PaymentTermsId,
                        principalTable: "PaymentTermss",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_ProformaInvoices_PortOfLoading_PortOfLoadingCountryOfOriginId",
                        column: x => x.PortOfLoadingCountryOfOriginId,
                        principalTable: "PortOfLoading",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_ProformaInvoices_PortOfLoading_PortOfLoadingDestinationId",
                        column: x => x.PortOfLoadingDestinationId,
                        principalTable: "PortOfLoading",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_ProformaInvoices_PortOfLoading_PortOfLoadingId",
                        column: x => x.PortOfLoadingId,
                        principalTable: "PortOfLoading",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_ProformaInvoices_Supplier_SuppliersId",
                        column: x => x.SuppliersId,
                        principalTable: "Supplier",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_ProformaInvoices_UnitMaster_UnitMasterId1",
                        column: x => x.UnitMasterId1,
                        principalTable: "UnitMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_ProformaInvoices_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountNoLienBank_BuyerId",
                table: "BankAccountNoLienBank",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountNoLienBank_CommercialCompanysId",
                table: "BankAccountNoLienBank",
                column: "CommercialCompanysId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountNoLienBank_CountrysId",
                table: "BankAccountNoLienBank",
                column: "CountrysId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountNoLienBank_LienBankId",
                table: "BankAccountNoLienBank",
                column: "LienBankId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountNoLienBank_SupplierId",
                table: "BankAccountNoLienBank",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_ProformaInvoices_BankAccountNoLienBanksId",
                table: "COM_ProformaInvoices",
                column: "BankAccountNoLienBanksId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_ProformaInvoices_BankAccountNosId",
                table: "COM_ProformaInvoices",
                column: "BankAccountNosId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_ProformaInvoices_COM_GroupLC_MainsId",
                table: "COM_ProformaInvoices",
                column: "COM_GroupLC_MainsId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_ProformaInvoices_ComId",
                table: "COM_ProformaInvoices",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_ProformaInvoices_CommercialCompaniesId",
                table: "COM_ProformaInvoices",
                column: "CommercialCompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_ProformaInvoices_CurrenciesId",
                table: "COM_ProformaInvoices",
                column: "CurrenciesId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_ProformaInvoices_DayListId",
                table: "COM_ProformaInvoices",
                column: "DayListId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_ProformaInvoices_employeesId",
                table: "COM_ProformaInvoices",
                column: "employeesId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_ProformaInvoices_ItemDescId",
                table: "COM_ProformaInvoices",
                column: "ItemDescId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_ProformaInvoices_ItemGroupsId",
                table: "COM_ProformaInvoices",
                column: "ItemGroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_ProformaInvoices_LuserId",
                table: "COM_ProformaInvoices",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_ProformaInvoices_OpeningBankId",
                table: "COM_ProformaInvoices",
                column: "OpeningBankId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_ProformaInvoices_PaymentTermsId",
                table: "COM_ProformaInvoices",
                column: "PaymentTermsId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_ProformaInvoices_PINatureId",
                table: "COM_ProformaInvoices",
                column: "PINatureId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_ProformaInvoices_PortOfLoadingCountryOfOriginId",
                table: "COM_ProformaInvoices",
                column: "PortOfLoadingCountryOfOriginId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_ProformaInvoices_PortOfLoadingDestinationId",
                table: "COM_ProformaInvoices",
                column: "PortOfLoadingDestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_ProformaInvoices_PortOfLoadingId",
                table: "COM_ProformaInvoices",
                column: "PortOfLoadingId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_ProformaInvoices_SuppliersId",
                table: "COM_ProformaInvoices",
                column: "SuppliersId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_ProformaInvoices_UnitMasterId1",
                table: "COM_ProformaInvoices",
                column: "UnitMasterId1");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDesc_ItemGroupsId",
                table: "ItemDesc",
                column: "ItemGroupsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COM_ProformaInvoices");

            migrationBuilder.DropTable(
                name: "BankAccountNoLienBank");

            migrationBuilder.DropTable(
                name: "ItemDesc");

            migrationBuilder.DropTable(
                name: "PINature");
        }
    }
}
