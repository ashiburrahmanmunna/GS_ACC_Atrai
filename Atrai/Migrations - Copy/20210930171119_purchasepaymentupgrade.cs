using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class purchasepaymentupgrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackageActivation_PackageActivation_PackageId",
                table: "PackageActivation");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasePayment_PaymentType_PaymentTypeId",
                table: "PurchasePayment");

            migrationBuilder.DropIndex(
                name: "IX_PurchasePayment_PaymentTypeId",
                table: "PurchasePayment");

            migrationBuilder.DropColumn(
                name: "PaymentTypeId",
                table: "PurchasePayment");

            migrationBuilder.AddForeignKey(
                name: "FK_PackageActivation_SoftwarePackage_PackageId",
                table: "PackageActivation",
                column: "PackageId",
                principalTable: "SoftwarePackage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackageActivation_SoftwarePackage_PackageId",
                table: "PackageActivation");

            migrationBuilder.AddColumn<int>(
                name: "PaymentTypeId",
                table: "PurchasePayment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePayment_PaymentTypeId",
                table: "PurchasePayment",
                column: "PaymentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PackageActivation_PackageActivation_PackageId",
                table: "PackageActivation",
                column: "PackageId",
                principalTable: "PackageActivation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasePayment_PaymentType_PaymentTypeId",
                table: "PurchasePayment",
                column: "PaymentTypeId",
                principalTable: "PaymentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
