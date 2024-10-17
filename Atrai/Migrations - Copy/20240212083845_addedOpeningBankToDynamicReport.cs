using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class addedOpeningBankToDynamicReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OpeningBankId",
                table: "MasterLC",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "COM_MasterLC_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SL = table.Column<int>(type: "int", nullable: true),
                    ExportPONo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    StyleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HSCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fabrication = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    OrderQty = table.Column<float>(type: "real", nullable: false),
                    Factor = table.Column<float>(type: "real", nullable: false),
                    QtyInPcs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ShipmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Destination = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContractNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OrderType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CatNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DeliveryNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DestinationPO = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Kimball = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ColorCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContractDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MasterLCID = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COM_MasterLC_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COM_MasterLC_Details_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_COM_MasterLC_Details_MasterLC_MasterLCID",
                        column: x => x.MasterLCID,
                        principalTable: "MasterLC",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_MasterLC_Details_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "COM_MasterLCExport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExportOrderID = table.Column<int>(type: "int", nullable: false),
                    ExportPONo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExportOrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COM_MasterLCExport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COM_MasterLCExport_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_COM_MasterLCExport_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DynamicReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DynamicReportName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DynamicReportPackingListName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DynamicReportPackingDetailsName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DynamicReportCaption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DynamicReportActionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportDesignByPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportController = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifiedByPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isVerified = table.Column<bool>(type: "bit", nullable: false),
                    CompletePercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuyerId = table.Column<int>(type: "int", nullable: true),
                    BuyerInformationsId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DynamicReport_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DynamicReport_Customer_BuyerInformationsId",
                        column: x => x.BuyerInformationsId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DynamicReport_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ExportInvoiceMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNo = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryTerm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalShipped = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BalanceShip = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MasterLCId = table.Column<int>(type: "int", nullable: true),
                    COM_MasterLCId = table.Column<int>(type: "int", nullable: true),
                    BuyerId = table.Column<int>(type: "int", nullable: true),
                    BuyerInformationId = table.Column<int>(type: "int", nullable: true),
                    ManufactureId = table.Column<int>(type: "int", nullable: true),
                    CommercialCompanyId = table.Column<int>(type: "int", nullable: true),
                    PortOfLoadingId = table.Column<int>(type: "int", nullable: true),
                    PortOfDischargeId = table.Column<int>(type: "int", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    ExfactoryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OnboardDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ExpDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BLNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BLDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BookingNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GoodsDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CartonMeasurement = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    VesselName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ShipmentAuthorization = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    VoyageNo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MainMark = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NetWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GrossWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CBM = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalCartonQty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PackingType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTermsManual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Session = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalInvoiceQty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalInvoiceQtyPcs = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CMPPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CMPValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CargoHandoverDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContainerNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingBillNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingBillDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRevised = table.Column<bool>(type: "bit", nullable: false),
                    RevisedNo = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportInvoiceMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExportInvoiceMaster_Commercial_CommercialCompanyId",
                        column: x => x.CommercialCompanyId,
                        principalTable: "Commercial",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExportInvoiceMaster_Commercial_ManufactureId",
                        column: x => x.ManufactureId,
                        principalTable: "Commercial",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExportInvoiceMaster_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ExportInvoiceMaster_Customer_BuyerInformationId",
                        column: x => x.BuyerInformationId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExportInvoiceMaster_MasterLC_COM_MasterLCId",
                        column: x => x.COM_MasterLCId,
                        principalTable: "MasterLC",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExportInvoiceMaster_PortOfDischarge_PortOfDischargeId",
                        column: x => x.PortOfDischargeId,
                        principalTable: "PortOfDischarge",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExportInvoiceMaster_PortOfLoading_PortOfLoadingId",
                        column: x => x.PortOfLoadingId,
                        principalTable: "PortOfLoading",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExportInvoiceMaster_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExportInvoiceMaster_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ExportInvoicePackingList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExportInvoiceDetailsId = table.Column<int>(type: "int", nullable: false),
                    ExportPoNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CartonQty = table.Column<int>(type: "int", nullable: true),
                    GrossWeightLinePacking = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetWeightLinePacking = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BoxLengthLinePacking = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BoxWidthLinePacking = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BoxHeightLinePacking = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CBMLinePacking = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SLNOLinePacking = table.Column<int>(type: "int", nullable: true),
                    ItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UPCNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ColorPL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ttlPcsPL = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    remainingPL = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    netPcsPL = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PcsCTN = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CtnNoFromPL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CtnNoToPL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalNetWeightPL = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalGrossWeightPL = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportInvoicePackingList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExportInvoicePackingList_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ExportInvoicePackingList_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ExportOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerContactPONo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POLineNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DestinationID = table.Column<int>(type: "int", nullable: false),
                    OrderQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CM = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OrderValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ShipModelId = table.Column<int>(type: "int", nullable: true),
                    ExFactoryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShipDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExportOrderStatusId = table.Column<int>(type: "int", nullable: true),
                    ExportOrderCategoryId = table.Column<int>(type: "int", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StyleId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExportOrder_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ExportOrder_Style_StyleId",
                        column: x => x.StyleId,
                        principalTable: "Style",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExportOrder_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "NotifyParty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotifyPartyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotifyPartyNameSearch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuyerId = table.Column<int>(type: "int", nullable: true),
                    BuyerInformationsId = table.Column<int>(type: "int", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    CountrysId = table.Column<int>(type: "int", nullable: true),
                    PortOfDischargeId = table.Column<int>(type: "int", nullable: true),
                    ShopCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippedTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SLNO = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotifyParty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotifyParty_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_NotifyParty_Country_CountrysId",
                        column: x => x.CountrysId,
                        principalTable: "Country",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotifyParty_Customer_BuyerInformationsId",
                        column: x => x.BuyerInformationsId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotifyParty_PortOfDischarge_PortOfDischargeId",
                        column: x => x.PortOfDischargeId,
                        principalTable: "PortOfDischarge",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotifyParty_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OpeningBank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpeningBankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    SwiftCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchAddress2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpeningBank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpeningBank_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OpeningBank_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OpeningBank_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UnitMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitMasterId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelativeFactor = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsBaseUOM = table.Column<bool>(type: "bit", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitMaster_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UnitMaster_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ExportInvoiceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    MasterLCDetailsID = table.Column<int>(type: "int", nullable: false),
                    StyleNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExportPoNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Destination = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LCQty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UnitMasterId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitMasterId1 = table.Column<int>(type: "int", nullable: true),
                    InvoiceQty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InvoiceRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InvoiceValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ShipmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NetWeightLine = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GrossWeightLine = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CBMLine = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CartonQty = table.Column<int>(type: "int", nullable: true),
                    DocumentSendDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BillReceiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ColorCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PODate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BoxLength = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BoxWidth = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BoxHeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SLNO = table.Column<int>(type: "int", nullable: true),
                    InvoiceFactor = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InvoiceQtyInPcs = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ExportInvoiceMasterId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportInvoiceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExportInvoiceDetails_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ExportInvoiceDetails_ExportInvoiceMaster_ExportInvoiceMasterId",
                        column: x => x.ExportInvoiceMasterId,
                        principalTable: "ExportInvoiceMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExportInvoiceDetails_UnitMaster_UnitMasterId1",
                        column: x => x.UnitMasterId1,
                        principalTable: "UnitMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExportInvoiceDetails_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MasterLC_OpeningBankId",
                table: "MasterLC",
                column: "OpeningBankId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountNo_OpeningBankId",
                table: "BankAccountNo",
                column: "OpeningBankId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_MasterLC_Details_ComId",
                table: "COM_MasterLC_Details",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_MasterLC_Details_LuserId",
                table: "COM_MasterLC_Details",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_MasterLC_Details_MasterLCID",
                table: "COM_MasterLC_Details",
                column: "MasterLCID");

            migrationBuilder.CreateIndex(
                name: "IX_COM_MasterLCExport_ComId",
                table: "COM_MasterLCExport",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_MasterLCExport_LuserId",
                table: "COM_MasterLCExport",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_DynamicReport_BuyerInformationsId",
                table: "DynamicReport",
                column: "BuyerInformationsId");

            migrationBuilder.CreateIndex(
                name: "IX_DynamicReport_ComId",
                table: "DynamicReport",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_DynamicReport_LuserId",
                table: "DynamicReport",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoiceDetails_ComId",
                table: "ExportInvoiceDetails",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoiceDetails_ExportInvoiceMasterId",
                table: "ExportInvoiceDetails",
                column: "ExportInvoiceMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoiceDetails_LuserId",
                table: "ExportInvoiceDetails",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoiceDetails_UnitMasterId1",
                table: "ExportInvoiceDetails",
                column: "UnitMasterId1");

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoiceMaster_BuyerInformationId",
                table: "ExportInvoiceMaster",
                column: "BuyerInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoiceMaster_COM_MasterLCId",
                table: "ExportInvoiceMaster",
                column: "COM_MasterLCId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoiceMaster_ComId",
                table: "ExportInvoiceMaster",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoiceMaster_CommercialCompanyId",
                table: "ExportInvoiceMaster",
                column: "CommercialCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoiceMaster_LuserId",
                table: "ExportInvoiceMaster",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoiceMaster_ManufactureId",
                table: "ExportInvoiceMaster",
                column: "ManufactureId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoiceMaster_PortOfDischargeId",
                table: "ExportInvoiceMaster",
                column: "PortOfDischargeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoiceMaster_PortOfLoadingId",
                table: "ExportInvoiceMaster",
                column: "PortOfLoadingId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoiceMaster_SupplierId",
                table: "ExportInvoiceMaster",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoicePackingList_ComId",
                table: "ExportInvoicePackingList",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoicePackingList_LuserId",
                table: "ExportInvoicePackingList",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportOrder_ComId",
                table: "ExportOrder",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportOrder_LuserId",
                table: "ExportOrder",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportOrder_StyleId",
                table: "ExportOrder",
                column: "StyleId");

            migrationBuilder.CreateIndex(
                name: "IX_NotifyParty_BuyerInformationsId",
                table: "NotifyParty",
                column: "BuyerInformationsId");

            migrationBuilder.CreateIndex(
                name: "IX_NotifyParty_ComId",
                table: "NotifyParty",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_NotifyParty_CountrysId",
                table: "NotifyParty",
                column: "CountrysId");

            migrationBuilder.CreateIndex(
                name: "IX_NotifyParty_LuserId",
                table: "NotifyParty",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_NotifyParty_PortOfDischargeId",
                table: "NotifyParty",
                column: "PortOfDischargeId");

            migrationBuilder.CreateIndex(
                name: "IX_OpeningBank_ComId",
                table: "OpeningBank",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_OpeningBank_CountryId",
                table: "OpeningBank",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_OpeningBank_LuserId",
                table: "OpeningBank",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitMaster_ComId",
                table: "UnitMaster",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitMaster_LuserId",
                table: "UnitMaster",
                column: "LuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccountNo_OpeningBank_OpeningBankId",
                table: "BankAccountNo",
                column: "OpeningBankId",
                principalTable: "OpeningBank",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_OpeningBank_OpeningBankId",
                table: "MasterLC",
                column: "OpeningBankId",
                principalTable: "OpeningBank",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccountNo_OpeningBank_OpeningBankId",
                table: "BankAccountNo");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_OpeningBank_OpeningBankId",
                table: "MasterLC");

            migrationBuilder.DropTable(
                name: "COM_MasterLC_Details");

            migrationBuilder.DropTable(
                name: "COM_MasterLCExport");

            migrationBuilder.DropTable(
                name: "DynamicReport");

            migrationBuilder.DropTable(
                name: "ExportInvoiceDetails");

            migrationBuilder.DropTable(
                name: "ExportInvoicePackingList");

            migrationBuilder.DropTable(
                name: "ExportOrder");

            migrationBuilder.DropTable(
                name: "NotifyParty");

            migrationBuilder.DropTable(
                name: "OpeningBank");

            migrationBuilder.DropTable(
                name: "ExportInvoiceMaster");

            migrationBuilder.DropTable(
                name: "UnitMaster");

            migrationBuilder.DropIndex(
                name: "IX_MasterLC_OpeningBankId",
                table: "MasterLC");

            migrationBuilder.DropIndex(
                name: "IX_BankAccountNo_OpeningBankId",
                table: "BankAccountNo");

            migrationBuilder.DropColumn(
                name: "OpeningBankId",
                table: "MasterLC");
        }
    }
}
