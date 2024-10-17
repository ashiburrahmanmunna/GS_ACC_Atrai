using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class accountsdailytransactionTransferInandout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostCalculated_InternalTransfer_InternalTransferModelId",
                table: "CostCalculated");

            migrationBuilder.DropIndex(
                name: "IX_CostCalculated_InternalTransferModelId",
                table: "CostCalculated");

            migrationBuilder.DropColumn(
                name: "InternalTransferModelId",
                table: "CostCalculated");

            migrationBuilder.RenameColumn(
                name: "TransferOutId",
                table: "CostCalculated",
                newName: "InternalTransferInId");

            migrationBuilder.AddColumn<int>(
                name: "TransferInId",
                table: "AccountsDailyTransaction",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransferOutId",
                table: "AccountsDailyTransaction",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CostCalculated_InternalTransferInId",
                table: "CostCalculated",
                column: "InternalTransferInId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsDailyTransaction_TransferInId",
                table: "AccountsDailyTransaction",
                column: "TransferInId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsDailyTransaction_TransferOutId",
                table: "AccountsDailyTransaction",
                column: "TransferOutId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_InternalTransfer_TransferInId",
                table: "AccountsDailyTransaction",
                column: "TransferInId",
                principalTable: "InternalTransfer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_InternalTransfer_TransferOutId",
                table: "AccountsDailyTransaction",
                column: "TransferOutId",
                principalTable: "InternalTransfer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CostCalculated_InternalTransfer_InternalTransferInId",
                table: "CostCalculated",
                column: "InternalTransferInId",
                principalTable: "InternalTransfer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_InternalTransfer_TransferInId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_InternalTransfer_TransferOutId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_CostCalculated_InternalTransfer_InternalTransferInId",
                table: "CostCalculated");

            migrationBuilder.DropIndex(
                name: "IX_CostCalculated_InternalTransferInId",
                table: "CostCalculated");

            migrationBuilder.DropIndex(
                name: "IX_AccountsDailyTransaction_TransferInId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropIndex(
                name: "IX_AccountsDailyTransaction_TransferOutId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropColumn(
                name: "TransferInId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropColumn(
                name: "TransferOutId",
                table: "AccountsDailyTransaction");

            migrationBuilder.RenameColumn(
                name: "InternalTransferInId",
                table: "CostCalculated",
                newName: "TransferOutId");

            migrationBuilder.AddColumn<int>(
                name: "InternalTransferModelId",
                table: "CostCalculated",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CostCalculated_InternalTransferModelId",
                table: "CostCalculated",
                column: "InternalTransferModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_CostCalculated_InternalTransfer_InternalTransferModelId",
                table: "CostCalculated",
                column: "InternalTransferModelId",
                principalTable: "InternalTransfer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
