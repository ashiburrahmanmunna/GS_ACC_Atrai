using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class paymenttypemodeladded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_PurchaseItemsCategory_Purchase_PurchaseModelId",
            //    table: "PurchaseItemsCategory");

            //migrationBuilder.RenameColumn(
            //    name: "PurchaseModelId",
            //    table: "PurchaseItemsCategory",
            //    newName: "PurchaseId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_PurchaseItemsCategory_PurchaseModelId",
            //    table: "PurchaseItemsCategory",
            //    newName: "IX_PurchaseItemsCategory_PurchaseId");

            //migrationBuilder.AddColumn<string>(
            //    name: "Bcc",
            //    table: "Purchase",
            //    type: "nvarchar(max)",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "Cc",
            //    table: "Purchase",
            //    type: "nvarchar(max)",
            //    nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentTypeId",
                table: "AccountsDailyTransaction",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountsDailyTransaction_PaymentTypeId",
                table: "AccountsDailyTransaction",
                column: "PaymentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_PaymentType_PaymentTypeId",
                table: "AccountsDailyTransaction",
                column: "PaymentTypeId",
                principalTable: "PaymentType",
                principalColumn: "Id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_PurchaseItemsCategory_Purchase_PurchaseId",
            //    table: "PurchaseItemsCategory",
            //    column: "PurchaseId",
            //    principalTable: "Purchase",
            //    principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_PaymentType_PaymentTypeId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItemsCategory_Purchase_PurchaseId",
                table: "PurchaseItemsCategory");

            migrationBuilder.DropIndex(
                name: "IX_AccountsDailyTransaction_PaymentTypeId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropColumn(
                name: "Bcc",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "Cc",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "PaymentTypeId",
                table: "AccountsDailyTransaction");

            migrationBuilder.RenameColumn(
                name: "PurchaseId",
                table: "PurchaseItemsCategory",
                newName: "PurchaseModelId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseItemsCategory_PurchaseId",
                table: "PurchaseItemsCategory",
                newName: "IX_PurchaseItemsCategory_PurchaseModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItemsCategory_Purchase_PurchaseModelId",
                table: "PurchaseItemsCategory",
                column: "PurchaseModelId",
                principalTable: "Purchase",
                principalColumn: "Id");
        }
    }
}
