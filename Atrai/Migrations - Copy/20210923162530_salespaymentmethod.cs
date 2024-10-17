using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class salespaymentmethod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesPayment_PaymentType_PaymentTypeId",
                table: "SalesPayment");

            migrationBuilder.RenameColumn(
                name: "PaymentTypeId",
                table: "SalesPayment",
                newName: "PaymentTypeModelId");

            migrationBuilder.RenameIndex(
                name: "IX_SalesPayment_PaymentTypeId",
                table: "SalesPayment",
                newName: "IX_SalesPayment_PaymentTypeModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPayment_PaymentType_PaymentTypeModelId",
                table: "SalesPayment",
                column: "PaymentTypeModelId",
                principalTable: "PaymentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesPayment_PaymentType_PaymentTypeModelId",
                table: "SalesPayment");

            migrationBuilder.RenameColumn(
                name: "PaymentTypeModelId",
                table: "SalesPayment",
                newName: "PaymentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_SalesPayment_PaymentTypeModelId",
                table: "SalesPayment",
                newName: "IX_SalesPayment_PaymentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPayment_PaymentType_PaymentTypeId",
                table: "SalesPayment",
                column: "PaymentTypeId",
                principalTable: "PaymentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
