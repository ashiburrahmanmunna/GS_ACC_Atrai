using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class productbatchinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SerialNo",
                table: "PurchaseBatchItems",
                newName: "BatchSerialNo");

            migrationBuilder.RenameColumn(
                name: "SecUnitRemarks",
                table: "PurchaseBatchItems",
                newName: "BatchRemarks");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "PurchaseBatchItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SLNo",
                table: "PurchaseBatchItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseBatchItems_ProductId",
                table: "PurchaseBatchItems",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseBatchItems_Product_ProductId",
                table: "PurchaseBatchItems",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseBatchItems_Product_ProductId",
                table: "PurchaseBatchItems");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseBatchItems_ProductId",
                table: "PurchaseBatchItems");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "PurchaseBatchItems");

            migrationBuilder.DropColumn(
                name: "SLNo",
                table: "PurchaseBatchItems");

            migrationBuilder.RenameColumn(
                name: "BatchSerialNo",
                table: "PurchaseBatchItems",
                newName: "SerialNo");

            migrationBuilder.RenameColumn(
                name: "BatchRemarks",
                table: "PurchaseBatchItems",
                newName: "SecUnitRemarks");
        }
    }
}
