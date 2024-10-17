using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class costcalcualtedtransferinfinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostCalculated_InternalTransfer_TransferOutId",
                table: "CostCalculated");

            migrationBuilder.RenameColumn(
                name: "TransferOutId",
                table: "CostCalculated",
                newName: "InternalTransferId");

            migrationBuilder.RenameIndex(
                name: "IX_CostCalculated_TransferOutId",
                table: "CostCalculated",
                newName: "IX_CostCalculated_InternalTransferId");

            migrationBuilder.AddColumn<bool>(
                name: "IsTransferIn",
                table: "CostCalculated",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTransferOut",
                table: "CostCalculated",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_CostCalculated_InternalTransfer_InternalTransferId",
                table: "CostCalculated",
                column: "InternalTransferId",
                principalTable: "InternalTransfer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostCalculated_InternalTransfer_InternalTransferId",
                table: "CostCalculated");

            migrationBuilder.DropColumn(
                name: "IsTransferIn",
                table: "CostCalculated");

            migrationBuilder.DropColumn(
                name: "IsTransferOut",
                table: "CostCalculated");

            migrationBuilder.RenameColumn(
                name: "InternalTransferId",
                table: "CostCalculated",
                newName: "TransferOutId");

            migrationBuilder.RenameIndex(
                name: "IX_CostCalculated_InternalTransferId",
                table: "CostCalculated",
                newName: "IX_CostCalculated_TransferOutId");

            migrationBuilder.AddForeignKey(
                name: "FK_CostCalculated_InternalTransfer_TransferOutId",
                table: "CostCalculated",
                column: "TransferOutId",
                principalTable: "InternalTransfer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
