using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class ComercialModelMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COM_MachinaryLC_Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachinaryLCNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UDNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommercialCompanyId = table.Column<int>(type: "int", nullable: true),
                    ShipModeId = table.Column<int>(type: "int", nullable: true),
                    TotalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tenor = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaymentTerm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTermsId = table.Column<int>(type: "int", nullable: true),
                    DayListId = table.Column<int>(type: "int", nullable: true),
                    Insurance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
                    PortOfLoadingId = table.Column<int>(type: "int", nullable: true),
                    PortOfDischargeId = table.Column<int>(type: "int", nullable: true),
                    OpeningBankId = table.Column<int>(type: "int", nullable: true),
                    LienBankId = table.Column<int>(type: "int", nullable: true),
                    TradeTermId = table.Column<int>(type: "int", nullable: true),
                    LcOpeningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UDDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstShipmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastShipmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DestinationID = table.Column<int>(type: "int", nullable: true),
                    ConvertRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MachinaryLCValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MachinaryLCQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IncreaseValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DecreaseValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GroupLCAverage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MachinaryLCPrintDocRef = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MachinaryLCPrintDocDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemGroupId = table.Column<int>(type: "int", nullable: true),
                    ItemGroupsId = table.Column<int>(type: "int", nullable: true),
                    LCAmdNo = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    LCAmdNote = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COM_MachinaryLC_Master", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COM_MachinaryLC_Master_Commercial_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Commercial",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_MachinaryLC_Master_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_COM_MachinaryLC_Master_Country_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Country",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_MachinaryLC_Master_DayList_DayListId",
                        column: x => x.DayListId,
                        principalTable: "DayList",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_MachinaryLC_Master_Destination_DestinationID",
                        column: x => x.DestinationID,
                        principalTable: "Destination",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_MachinaryLC_Master_ItemGroup_ItemGroupsId",
                        column: x => x.ItemGroupsId,
                        principalTable: "ItemGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_MachinaryLC_Master_LienBank_LienBankId",
                        column: x => x.LienBankId,
                        principalTable: "LienBank",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_MachinaryLC_Master_OpeningBank_OpeningBankId",
                        column: x => x.OpeningBankId,
                        principalTable: "OpeningBank",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_MachinaryLC_Master_PaymentTermss_PaymentTermsId",
                        column: x => x.PaymentTermsId,
                        principalTable: "PaymentTermss",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_MachinaryLC_Master_PortOfDischarge_PortOfDischargeId",
                        column: x => x.PortOfDischargeId,
                        principalTable: "PortOfDischarge",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_MachinaryLC_Master_PortOfLoading_PortOfLoadingId",
                        column: x => x.PortOfLoadingId,
                        principalTable: "PortOfLoading",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_MachinaryLC_Master_ShipMode_ShipModeId",
                        column: x => x.ShipModeId,
                        principalTable: "ShipMode",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_MachinaryLC_Master_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_MachinaryLC_Master_TradeTerm_TradeTermId",
                        column: x => x.TradeTermId,
                        principalTable: "TradeTerm",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_MachinaryLC_Master_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CommercialLCType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommercialLCTypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CommercialLCTypeShortName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommercialLCType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentStatusName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DocumentStatusShortName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentStatus", x => x.Id);
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
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDesc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemDesc_ItemGroup_ItemGroupId",
                        column: x => x.ItemGroupId,
                        principalTable: "ItemGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "COM_MachinaryLC_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachinaryLCMasterID = table.Column<int>(type: "int", nullable: true),
                    PIId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COM_MachinaryLC_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COM_MachinaryLC_Details_COM_MachinaryLC_Master_MachinaryLCMasterID",
                        column: x => x.MachinaryLCMasterID,
                        principalTable: "COM_MachinaryLC_Master",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_MachinaryLC_Details_COM_ProformaInvoices_PIId",
                        column: x => x.PIId,
                        principalTable: "COM_ProformaInvoices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_MachinaryLC_Details_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_COM_MachinaryLC_Details_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "COM_CommercialInvoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommercialInvoiceNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CommercialInvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CommercialCompanyID = table.Column<int>(type: "int", nullable: false),
                    BBLCId = table.Column<int>(type: "int", nullable: true),
                    SupplierID = table.Column<int>(type: "int", nullable: true),
                    TotalPI = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DocumentReceiptDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    UnitMasterId = table.Column<int>(type: "int", nullable: true),
                    ConversionRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ItemGroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemGroupId = table.Column<int>(type: "int", nullable: true),
                    ItemDescId = table.Column<int>(type: "int", nullable: true),
                    BLNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BLDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DocumentStatusId = table.Column<int>(type: "int", nullable: false),
                    DocumentAssesmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BillOfEntryNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillOfEntryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomAssesmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VasselETADate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ETBDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GoodsInhouseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MotherVassel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FidderVasel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LCType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommercialLCTypeId = table.Column<int>(type: "int", nullable: true),
                    MachinaryLCId = table.Column<int>(type: "int", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COM_CommercialInvoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COM_CommercialInvoice_BBLCMaster_BBLCId",
                        column: x => x.BBLCId,
                        principalTable: "BBLCMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_CommercialInvoice_COM_MachinaryLC_Master_MachinaryLCId",
                        column: x => x.MachinaryLCId,
                        principalTable: "COM_MachinaryLC_Master",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_CommercialInvoice_CommercialLCType_CommercialLCTypeId",
                        column: x => x.CommercialLCTypeId,
                        principalTable: "CommercialLCType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_CommercialInvoice_Commercial_CommercialCompanyID",
                        column: x => x.CommercialCompanyID,
                        principalTable: "Commercial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_COM_CommercialInvoice_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_COM_CommercialInvoice_Country_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_COM_CommercialInvoice_DocumentStatus_DocumentStatusId",
                        column: x => x.DocumentStatusId,
                        principalTable: "DocumentStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_COM_CommercialInvoice_ItemDesc_ItemDescId",
                        column: x => x.ItemDescId,
                        principalTable: "ItemDesc",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_CommercialInvoice_ItemGroup_ItemGroupId",
                        column: x => x.ItemGroupId,
                        principalTable: "ItemGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_CommercialInvoice_Supplier_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Supplier",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_CommercialInvoice_UnitMaster_UnitMasterId",
                        column: x => x.UnitMasterId,
                        principalTable: "UnitMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_CommercialInvoice_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "COM_CommercialInvoice_Sub",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemDescId = table.Column<int>(type: "int", nullable: false),
                    CommercialInvoiceId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COM_CommercialInvoice_Sub", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COM_CommercialInvoice_Sub_COM_CommercialInvoice_CommercialInvoiceId",
                        column: x => x.CommercialInvoiceId,
                        principalTable: "COM_CommercialInvoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_COM_CommercialInvoice_Sub_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_COM_CommercialInvoice_Sub_ItemDesc_ItemDescId",
                        column: x => x.ItemDescId,
                        principalTable: "ItemDesc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_COM_CommercialInvoice_Sub_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_COM_CommercialInvoice_BBLCId",
                table: "COM_CommercialInvoice",
                column: "BBLCId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_CommercialInvoice_ComId",
                table: "COM_CommercialInvoice",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_CommercialInvoice_CommercialCompanyID",
                table: "COM_CommercialInvoice",
                column: "CommercialCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_COM_CommercialInvoice_CommercialLCTypeId",
                table: "COM_CommercialInvoice",
                column: "CommercialLCTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_CommercialInvoice_CurrencyId",
                table: "COM_CommercialInvoice",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_CommercialInvoice_DocumentStatusId",
                table: "COM_CommercialInvoice",
                column: "DocumentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_CommercialInvoice_ItemDescId",
                table: "COM_CommercialInvoice",
                column: "ItemDescId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_CommercialInvoice_ItemGroupId",
                table: "COM_CommercialInvoice",
                column: "ItemGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_CommercialInvoice_LuserId",
                table: "COM_CommercialInvoice",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_CommercialInvoice_MachinaryLCId",
                table: "COM_CommercialInvoice",
                column: "MachinaryLCId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_CommercialInvoice_SupplierID",
                table: "COM_CommercialInvoice",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_COM_CommercialInvoice_UnitMasterId",
                table: "COM_CommercialInvoice",
                column: "UnitMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_CommercialInvoice_Sub_ComId",
                table: "COM_CommercialInvoice_Sub",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_CommercialInvoice_Sub_CommercialInvoiceId",
                table: "COM_CommercialInvoice_Sub",
                column: "CommercialInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_CommercialInvoice_Sub_ItemDescId",
                table: "COM_CommercialInvoice_Sub",
                column: "ItemDescId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_CommercialInvoice_Sub_LuserId",
                table: "COM_CommercialInvoice_Sub",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_MachinaryLC_Details_ComId",
                table: "COM_MachinaryLC_Details",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_MachinaryLC_Details_LuserId",
                table: "COM_MachinaryLC_Details",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_MachinaryLC_Details_MachinaryLCMasterID",
                table: "COM_MachinaryLC_Details",
                column: "MachinaryLCMasterID");

            migrationBuilder.CreateIndex(
                name: "IX_COM_MachinaryLC_Details_PIId",
                table: "COM_MachinaryLC_Details",
                column: "PIId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_MachinaryLC_Master_ComId",
                table: "COM_MachinaryLC_Master",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_MachinaryLC_Master_CompanyId",
                table: "COM_MachinaryLC_Master",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_MachinaryLC_Master_CurrencyId",
                table: "COM_MachinaryLC_Master",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_MachinaryLC_Master_DayListId",
                table: "COM_MachinaryLC_Master",
                column: "DayListId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_MachinaryLC_Master_DestinationID",
                table: "COM_MachinaryLC_Master",
                column: "DestinationID");

            migrationBuilder.CreateIndex(
                name: "IX_COM_MachinaryLC_Master_ItemGroupsId",
                table: "COM_MachinaryLC_Master",
                column: "ItemGroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_MachinaryLC_Master_LienBankId",
                table: "COM_MachinaryLC_Master",
                column: "LienBankId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_MachinaryLC_Master_LuserId",
                table: "COM_MachinaryLC_Master",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_MachinaryLC_Master_OpeningBankId",
                table: "COM_MachinaryLC_Master",
                column: "OpeningBankId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_MachinaryLC_Master_PaymentTermsId",
                table: "COM_MachinaryLC_Master",
                column: "PaymentTermsId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_MachinaryLC_Master_PortOfDischargeId",
                table: "COM_MachinaryLC_Master",
                column: "PortOfDischargeId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_MachinaryLC_Master_PortOfLoadingId",
                table: "COM_MachinaryLC_Master",
                column: "PortOfLoadingId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_MachinaryLC_Master_ShipModeId",
                table: "COM_MachinaryLC_Master",
                column: "ShipModeId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_MachinaryLC_Master_SupplierId",
                table: "COM_MachinaryLC_Master",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_MachinaryLC_Master_TradeTermId",
                table: "COM_MachinaryLC_Master",
                column: "TradeTermId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDesc_ItemGroupId",
                table: "ItemDesc",
                column: "ItemGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COM_CommercialInvoice_Sub");

            migrationBuilder.DropTable(
                name: "COM_MachinaryLC_Details");

            migrationBuilder.DropTable(
                name: "COM_CommercialInvoice");

            migrationBuilder.DropTable(
                name: "COM_MachinaryLC_Master");

            migrationBuilder.DropTable(
                name: "CommercialLCType");

            migrationBuilder.DropTable(
                name: "DocumentStatus");

            migrationBuilder.DropTable(
                name: "ItemDesc");
        }
    }
}
