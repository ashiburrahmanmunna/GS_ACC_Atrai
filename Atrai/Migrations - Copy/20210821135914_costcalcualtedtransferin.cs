using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class costcalcualtedtransferin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostCalculated_InternalTransfer_InternalTransferInId",
                table: "CostCalculated");

            migrationBuilder.DropIndex(
                name: "IX_CostCalculated_InternalTransferInId",
                table: "CostCalculated");

            migrationBuilder.DropColumn(
                name: "InternalTransferInId",
                table: "CostCalculated");

            migrationBuilder.RenameColumn(
                name: "TransferInId",
                table: "CostCalculated",
                newName: "TransferOutId");

            migrationBuilder.CreateIndex(
                name: "IX_CostCalculated_TransferOutId",
                table: "CostCalculated",
                column: "TransferOutId");

            migrationBuilder.AddForeignKey(
                name: "FK_CostCalculated_InternalTransfer_TransferOutId",
                table: "CostCalculated",
                column: "TransferOutId",
                principalTable: "InternalTransfer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostCalculated_InternalTransfer_TransferOutId",
                table: "CostCalculated");

            migrationBuilder.DropIndex(
                name: "IX_CostCalculated_TransferOutId",
                table: "CostCalculated");

            migrationBuilder.RenameColumn(
                name: "TransferOutId",
                table: "CostCalculated",
                newName: "TransferInId");

            migrationBuilder.AddColumn<int>(
                name: "InternalTransferInId",
                table: "CostCalculated",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CostCalculated_InternalTransferInId",
                table: "CostCalculated",
                column: "InternalTransferInId");

            migrationBuilder.AddForeignKey(
                name: "FK_CostCalculated_InternalTransfer_InternalTransferInId",
                table: "CostCalculated",
                column: "InternalTransferInId",
                principalTable: "InternalTransfer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
