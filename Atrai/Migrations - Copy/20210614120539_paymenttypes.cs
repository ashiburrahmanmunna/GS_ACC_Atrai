using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class paymenttypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesPaymentModel_AccountHead_AccId",
                table: "SalesPaymentModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesPaymentModel_PaymentTypeModel_PaymentTypeId",
                table: "SalesPaymentModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesPaymentModel_Sales_SalesId",
                table: "SalesPaymentModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesPaymentModel",
                table: "SalesPaymentModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentTypeModel",
                table: "PaymentTypeModel");

            migrationBuilder.RenameTable(
                name: "SalesPaymentModel",
                newName: "SalesPayment");

            migrationBuilder.RenameTable(
                name: "PaymentTypeModel",
                newName: "PaymentType");

            migrationBuilder.RenameIndex(
                name: "IX_SalesPaymentModel_SalesId",
                table: "SalesPayment",
                newName: "IX_SalesPayment_SalesId");

            migrationBuilder.RenameIndex(
                name: "IX_SalesPaymentModel_PaymentTypeId",
                table: "SalesPayment",
                newName: "IX_SalesPayment_PaymentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_SalesPaymentModel_AccId",
                table: "SalesPayment",
                newName: "IX_SalesPayment_AccId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesPayment",
                table: "SalesPayment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentType",
                table: "PaymentType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPayment_AccountHead_AccId",
                table: "SalesPayment",
                column: "AccId",
                principalTable: "AccountHead",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPayment_PaymentType_PaymentTypeId",
                table: "SalesPayment",
                column: "PaymentTypeId",
                principalTable: "PaymentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPayment_Sales_SalesId",
                table: "SalesPayment",
                column: "SalesId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesPayment_AccountHead_AccId",
                table: "SalesPayment");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesPayment_PaymentType_PaymentTypeId",
                table: "SalesPayment");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesPayment_Sales_SalesId",
                table: "SalesPayment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesPayment",
                table: "SalesPayment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentType",
                table: "PaymentType");

            migrationBuilder.RenameTable(
                name: "SalesPayment",
                newName: "SalesPaymentModel");

            migrationBuilder.RenameTable(
                name: "PaymentType",
                newName: "PaymentTypeModel");

            migrationBuilder.RenameIndex(
                name: "IX_SalesPayment_SalesId",
                table: "SalesPaymentModel",
                newName: "IX_SalesPaymentModel_SalesId");

            migrationBuilder.RenameIndex(
                name: "IX_SalesPayment_PaymentTypeId",
                table: "SalesPaymentModel",
                newName: "IX_SalesPaymentModel_PaymentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_SalesPayment_AccId",
                table: "SalesPaymentModel",
                newName: "IX_SalesPaymentModel_AccId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesPaymentModel",
                table: "SalesPaymentModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentTypeModel",
                table: "PaymentTypeModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPaymentModel_AccountHead_AccId",
                table: "SalesPaymentModel",
                column: "AccId",
                principalTable: "AccountHead",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPaymentModel_PaymentTypeModel_PaymentTypeId",
                table: "SalesPaymentModel",
                column: "PaymentTypeId",
                principalTable: "PaymentTypeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPaymentModel_Sales_SalesId",
                table: "SalesPaymentModel",
                column: "SalesId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
