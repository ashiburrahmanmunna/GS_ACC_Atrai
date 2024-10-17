using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class locationaddedforalldocuments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Warehouse_WarehouseId",
                table: "Sales");

            migrationBuilder.RenameColumn(
                name: "WarehouseId",
                table: "Sales",
                newName: "WarehouseIdMain");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_WarehouseId",
                table: "Sales",
                newName: "IX_Sales_WarehouseIdMain");

            migrationBuilder.AddColumn<int>(
                name: "WarehouseIdMain",
                table: "SalesReturn",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarehouseIdMain",
                table: "PurchaseReturn",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarehouseIdMain",
                table: "Purchase",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarehouseIdMain",
                table: "Issue",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarehouseIdMain",
                table: "InternalTransfer",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarehouseIdMain",
                table: "Damage",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturn_WarehouseIdMain",
                table: "SalesReturn",
                column: "WarehouseIdMain");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturn_WarehouseIdMain",
                table: "PurchaseReturn",
                column: "WarehouseIdMain");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_WarehouseIdMain",
                table: "Purchase",
                column: "WarehouseIdMain");

            migrationBuilder.CreateIndex(
                name: "IX_Issue_WarehouseIdMain",
                table: "Issue",
                column: "WarehouseIdMain");

            migrationBuilder.CreateIndex(
                name: "IX_InternalTransfer_WarehouseIdMain",
                table: "InternalTransfer",
                column: "WarehouseIdMain");

            migrationBuilder.CreateIndex(
                name: "IX_Damage_WarehouseIdMain",
                table: "Damage",
                column: "WarehouseIdMain");

            migrationBuilder.AddForeignKey(
                name: "FK_Damage_Warehouse_WarehouseIdMain",
                table: "Damage",
                column: "WarehouseIdMain",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InternalTransfer_Warehouse_WarehouseIdMain",
                table: "InternalTransfer",
                column: "WarehouseIdMain",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Issue_Warehouse_WarehouseIdMain",
                table: "Issue",
                column: "WarehouseIdMain",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Warehouse_WarehouseIdMain",
                table: "Purchase",
                column: "WarehouseIdMain",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReturn_Warehouse_WarehouseIdMain",
                table: "PurchaseReturn",
                column: "WarehouseIdMain",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Warehouse_WarehouseIdMain",
                table: "Sales",
                column: "WarehouseIdMain",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesReturn_Warehouse_WarehouseIdMain",
                table: "SalesReturn",
                column: "WarehouseIdMain",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Damage_Warehouse_WarehouseIdMain",
                table: "Damage");

            migrationBuilder.DropForeignKey(
                name: "FK_InternalTransfer_Warehouse_WarehouseIdMain",
                table: "InternalTransfer");

            migrationBuilder.DropForeignKey(
                name: "FK_Issue_Warehouse_WarehouseIdMain",
                table: "Issue");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Warehouse_WarehouseIdMain",
                table: "Purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseReturn_Warehouse_WarehouseIdMain",
                table: "PurchaseReturn");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Warehouse_WarehouseIdMain",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesReturn_Warehouse_WarehouseIdMain",
                table: "SalesReturn");

            migrationBuilder.DropIndex(
                name: "IX_SalesReturn_WarehouseIdMain",
                table: "SalesReturn");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseReturn_WarehouseIdMain",
                table: "PurchaseReturn");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_WarehouseIdMain",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Issue_WarehouseIdMain",
                table: "Issue");

            migrationBuilder.DropIndex(
                name: "IX_InternalTransfer_WarehouseIdMain",
                table: "InternalTransfer");

            migrationBuilder.DropIndex(
                name: "IX_Damage_WarehouseIdMain",
                table: "Damage");

            migrationBuilder.DropColumn(
                name: "WarehouseIdMain",
                table: "SalesReturn");

            migrationBuilder.DropColumn(
                name: "WarehouseIdMain",
                table: "PurchaseReturn");

            migrationBuilder.DropColumn(
                name: "WarehouseIdMain",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "WarehouseIdMain",
                table: "Issue");

            migrationBuilder.DropColumn(
                name: "WarehouseIdMain",
                table: "InternalTransfer");

            migrationBuilder.DropColumn(
                name: "WarehouseIdMain",
                table: "Damage");

            migrationBuilder.RenameColumn(
                name: "WarehouseIdMain",
                table: "Sales",
                newName: "WarehouseId");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_WarehouseIdMain",
                table: "Sales",
                newName: "IX_Sales_WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Warehouse_WarehouseId",
                table: "Sales",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
