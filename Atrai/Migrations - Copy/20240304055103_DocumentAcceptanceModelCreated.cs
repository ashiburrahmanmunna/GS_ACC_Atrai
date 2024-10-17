using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class DocumentAcceptanceModelCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COM_DocumentAcceptance_Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillOfExchangeRef = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    BillDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BillMaturityDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BillPaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CommercialCompanyId = table.Column<int>(type: "int", nullable: true),
                    BuyerId = table.Column<int>(type: "int", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    BBLCId = table.Column<int>(type: "int", nullable: true),
                    GroupLCId = table.Column<int>(type: "int", nullable: true),
                    MasterLCRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalBBLCAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
                    PaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayableAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AcceptedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NewCIAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ConversionRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COM_DocumentAcceptance_Master", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COM_DocumentAcceptance_Master_BBLCMaster_BBLCId",
                        column: x => x.BBLCId,
                        principalTable: "BBLCMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_DocumentAcceptance_Master_Commercial_CommercialCompanyId",
                        column: x => x.CommercialCompanyId,
                        principalTable: "Commercial",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_DocumentAcceptance_Master_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_COM_DocumentAcceptance_Master_Country_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Country",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_DocumentAcceptance_Master_Customer_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_DocumentAcceptance_Master_GroupLC_Main_GroupLCId",
                        column: x => x.GroupLCId,
                        principalTable: "GroupLC_Main",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_DocumentAcceptance_Master_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_DocumentAcceptance_Master_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "COM_DocumentAcceptance_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommercialInvoiceId = table.Column<int>(type: "int", nullable: true),
                    DocumentAcceptanceMasterId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COM_DocumentAcceptance_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COM_DocumentAcceptance_Details_COM_CommercialInvoice_CommercialInvoiceId",
                        column: x => x.CommercialInvoiceId,
                        principalTable: "COM_CommercialInvoice",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_DocumentAcceptance_Details_COM_DocumentAcceptance_Master_DocumentAcceptanceMasterId",
                        column: x => x.DocumentAcceptanceMasterId,
                        principalTable: "COM_DocumentAcceptance_Master",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_DocumentAcceptance_Details_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_COM_DocumentAcceptance_Details_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_COM_DocumentAcceptance_Details_ComId",
                table: "COM_DocumentAcceptance_Details",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_DocumentAcceptance_Details_CommercialInvoiceId",
                table: "COM_DocumentAcceptance_Details",
                column: "CommercialInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_DocumentAcceptance_Details_DocumentAcceptanceMasterId",
                table: "COM_DocumentAcceptance_Details",
                column: "DocumentAcceptanceMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_DocumentAcceptance_Details_LuserId",
                table: "COM_DocumentAcceptance_Details",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_DocumentAcceptance_Master_BBLCId",
                table: "COM_DocumentAcceptance_Master",
                column: "BBLCId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_DocumentAcceptance_Master_BuyerId",
                table: "COM_DocumentAcceptance_Master",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_DocumentAcceptance_Master_ComId",
                table: "COM_DocumentAcceptance_Master",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_DocumentAcceptance_Master_CommercialCompanyId",
                table: "COM_DocumentAcceptance_Master",
                column: "CommercialCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_DocumentAcceptance_Master_CurrencyId",
                table: "COM_DocumentAcceptance_Master",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_DocumentAcceptance_Master_GroupLCId",
                table: "COM_DocumentAcceptance_Master",
                column: "GroupLCId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_DocumentAcceptance_Master_LuserId",
                table: "COM_DocumentAcceptance_Master",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_DocumentAcceptance_Master_SupplierId",
                table: "COM_DocumentAcceptance_Master",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COM_DocumentAcceptance_Details");

            migrationBuilder.DropTable(
                name: "COM_DocumentAcceptance_Master");
        }
    }
}
