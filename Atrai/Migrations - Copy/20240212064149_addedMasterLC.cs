using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class addedMasterLC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuyerGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerGroupName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BuyerGroupCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuyerGroupShortName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuyerGroup_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuyerGroup_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MasterLC",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LCRefNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LCMargin = table.Column<float>(type: "real", nullable: false),
                    LCTypeId = table.Column<int>(type: "int", nullable: false),
                    BuyerLCRef = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LCNOforImport = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: true),
                    LCOpenDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SalesContractIssueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LCExpirydate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastShipmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalLCQty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UnitMasterId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LCValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MasterLCValueManual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExportLCValueManual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LCStatusId = table.Column<int>(type: "int", nullable: false),
                    LCNatureId = table.Column<int>(type: "int", nullable: false),
                    Tenor = table.Column<int>(type: "int", nullable: true),
                    ShipModelId = table.Column<int>(type: "int", nullable: false),
                    PaymentTermsId = table.Column<int>(type: "int", nullable: false),
                    DayListId = table.Column<int>(type: "int", nullable: false),
                    BuyerID = table.Column<int>(type: "int", nullable: false),
                    BuyerInformationsId = table.Column<int>(type: "int", nullable: true),
                    BuyerGroupID = table.Column<int>(type: "int", nullable: true),
                    DestinationContract = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommercialCompanyId = table.Column<int>(type: "int", nullable: false),
                    CommercialCompaniesId = table.Column<int>(type: "int", nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
                    Tolerance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    Insurance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstShipmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemarksOne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemarksTwo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemarksThree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemarksFour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemarksFive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterLC", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterLC_BuyerGroup_BuyerGroupID",
                        column: x => x.BuyerGroupID,
                        principalTable: "BuyerGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MasterLC_Commercial_CommercialCompaniesId",
                        column: x => x.CommercialCompaniesId,
                        principalTable: "Commercial",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MasterLC_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasterLC_Country_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Country",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MasterLC_Customer_BuyerInformationsId",
                        column: x => x.BuyerInformationsId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MasterLC_DayList_DayListId",
                        column: x => x.DayListId,
                        principalTable: "DayList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasterLC_LCNature_LCNatureId",
                        column: x => x.LCNatureId,
                        principalTable: "LCNature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasterLC_LCStatus_LCStatusId",
                        column: x => x.LCStatusId,
                        principalTable: "LCStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasterLC_LCType_LCTypeId",
                        column: x => x.LCTypeId,
                        principalTable: "LCType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasterLC_PaymentTermss_PaymentTermsId",
                        column: x => x.PaymentTermsId,
                        principalTable: "PaymentTermss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasterLC_ShipModel_ShipModelId",
                        column: x => x.ShipModelId,
                        principalTable: "ShipModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasterLC_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MasterLC_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyerGroup_ComId",
                table: "BuyerGroup",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyerGroup_LuserId",
                table: "BuyerGroup",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterLC_BuyerGroupID",
                table: "MasterLC",
                column: "BuyerGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_MasterLC_BuyerInformationsId",
                table: "MasterLC",
                column: "BuyerInformationsId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterLC_ComId",
                table: "MasterLC",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterLC_CommercialCompaniesId",
                table: "MasterLC",
                column: "CommercialCompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterLC_CurrencyId",
                table: "MasterLC",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterLC_DayListId",
                table: "MasterLC",
                column: "DayListId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterLC_LCNatureId",
                table: "MasterLC",
                column: "LCNatureId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterLC_LCStatusId",
                table: "MasterLC",
                column: "LCStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterLC_LCTypeId",
                table: "MasterLC",
                column: "LCTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterLC_LuserId",
                table: "MasterLC",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterLC_PaymentTermsId",
                table: "MasterLC",
                column: "PaymentTermsId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterLC_ShipModelId",
                table: "MasterLC",
                column: "ShipModelId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterLC_SupplierId",
                table: "MasterLC",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasterLC");

            migrationBuilder.DropTable(
                name: "BuyerGroup");
        }
    }
}
