using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class salescommission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_AccountHead_AccountPayTypeId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesPayment_PaymentType_PaymentTypeId",
                table: "SalesPayment");

            migrationBuilder.DropIndex(
                name: "IX_Sales_AccountPayTypeId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "AccountPayTypeId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "CardNo",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "ttlCountQty",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "ttlIndDisAmt",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "ttlIndPrice",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "ttlIndVat",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "ttlSumAmt",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "ttlSumQty",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "ttlUnitPrice",
                table: "Sales");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentTypeId",
                table: "SalesPayment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "CommissionAmount",
                table: "SalesItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalCommisionAmount",
                table: "Sales",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPayment_PaymentType_PaymentTypeId",
                table: "SalesPayment",
                column: "PaymentTypeId",
                principalTable: "PaymentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesPayment_PaymentType_PaymentTypeId",
                table: "SalesPayment");

            migrationBuilder.DropColumn(
                name: "CommissionAmount",
                table: "SalesItems");

            migrationBuilder.DropColumn(
                name: "TotalCommisionAmount",
                table: "Sales");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentTypeId",
                table: "SalesPayment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountPayTypeId",
                table: "Sales",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardNo",
                table: "Sales",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "Sales",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "Sales",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ttlCountQty",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ttlIndDisAmt",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ttlIndPrice",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ttlIndVat",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ttlSumAmt",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ttlSumQty",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ttlUnitPrice",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_AccountPayTypeId",
                table: "Sales",
                column: "AccountPayTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_AccountHead_AccountPayTypeId",
                table: "Sales",
                column: "AccountPayTypeId",
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
        }
    }
}
