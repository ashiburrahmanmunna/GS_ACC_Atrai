using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class PurchaseStatusSupplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StatusRemarks",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DocTypeId",
                table: "Status",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Purchase",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Status_DocTypeId",
                table: "Status",
                column: "DocTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_StatusId",
                table: "Purchase",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Status_StatusId",
                table: "Purchase",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Status_DocType_DocTypeId",
                table: "Status",
                column: "DocTypeId",
                principalTable: "DocType",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Status_StatusId",
                table: "Purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_Status_DocType_DocTypeId",
                table: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Status_DocTypeId",
                table: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_StatusId",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "StatusRemarks",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "DocTypeId",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Purchase");
        }
    }
}
