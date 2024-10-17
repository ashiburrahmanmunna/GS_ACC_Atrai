using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class addProformainvoiceId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProformaInvoiceId",
                table: "TransactionApprovalStatus",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionApprovalStatus_ProformaInvoiceId",
                table: "TransactionApprovalStatus",
                column: "ProformaInvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionApprovalStatus_Com_proformaInvoice_ProformaInvoiceId",
                table: "TransactionApprovalStatus",
                column: "ProformaInvoiceId",
                principalTable: "Com_proformaInvoice",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionApprovalStatus_Com_proformaInvoice_ProformaInvoiceId",
                table: "TransactionApprovalStatus");

            migrationBuilder.DropIndex(
                name: "IX_TransactionApprovalStatus_ProformaInvoiceId",
                table: "TransactionApprovalStatus");

            migrationBuilder.DropColumn(
                name: "ProformaInvoiceId",
                table: "TransactionApprovalStatus");
        }
    }
}
