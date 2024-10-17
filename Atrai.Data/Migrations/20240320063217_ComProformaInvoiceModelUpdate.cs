using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class ComProformaInvoiceModelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BankAccountNoLienBankId",
                table: "COM_ProformaInvoices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PortOfDestinationId",
                table: "COM_ProformaInvoices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BankAccountNoLienBank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SwiftCodeBankAccountNoLienBank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommercialCompanyId = table.Column<int>(type: "int", nullable: true),
                    LienBankId = table.Column<int>(type: "int", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    BuyerId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccountNoLienBank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccountNoLienBank_Commercial_CommercialCompanyId",
                        column: x => x.CommercialCompanyId,
                        principalTable: "Commercial",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BankAccountNoLienBank_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankAccountNoLienBank_Country_CountryId",
                        column: x => x.CountryId,
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
                    table.ForeignKey(
                        name: "FK_BankAccountNoLienBank_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_COM_ProformaInvoices_BankAccountNoLienBankId",
                table: "COM_ProformaInvoices",
                column: "BankAccountNoLienBankId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_ProformaInvoices_PortOfDestinationId",
                table: "COM_ProformaInvoices",
                column: "PortOfDestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountNoLienBank_BuyerId",
                table: "BankAccountNoLienBank",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountNoLienBank_ComId",
                table: "BankAccountNoLienBank",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountNoLienBank_CommercialCompanyId",
                table: "BankAccountNoLienBank",
                column: "CommercialCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountNoLienBank_CountryId",
                table: "BankAccountNoLienBank",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountNoLienBank_LienBankId",
                table: "BankAccountNoLienBank",
                column: "LienBankId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountNoLienBank_LuserId",
                table: "BankAccountNoLienBank",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountNoLienBank_SupplierId",
                table: "BankAccountNoLienBank",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_ProformaInvoices_BankAccountNoLienBank_BankAccountNoLienBankId",
                table: "COM_ProformaInvoices",
                column: "BankAccountNoLienBankId",
                principalTable: "BankAccountNoLienBank",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_ProformaInvoices_Destination_PortOfDestinationId",
                table: "COM_ProformaInvoices",
                column: "PortOfDestinationId",
                principalTable: "Destination",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COM_ProformaInvoices_BankAccountNoLienBank_BankAccountNoLienBankId",
                table: "COM_ProformaInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_ProformaInvoices_Destination_PortOfDestinationId",
                table: "COM_ProformaInvoices");

            migrationBuilder.DropTable(
                name: "BankAccountNoLienBank");

            migrationBuilder.DropIndex(
                name: "IX_COM_ProformaInvoices_BankAccountNoLienBankId",
                table: "COM_ProformaInvoices");

            migrationBuilder.DropIndex(
                name: "IX_COM_ProformaInvoices_PortOfDestinationId",
                table: "COM_ProformaInvoices");

            migrationBuilder.DropColumn(
                name: "BankAccountNoLienBankId",
                table: "COM_ProformaInvoices");

            migrationBuilder.DropColumn(
                name: "PortOfDestinationId",
                table: "COM_ProformaInvoices");
        }
    }
}
