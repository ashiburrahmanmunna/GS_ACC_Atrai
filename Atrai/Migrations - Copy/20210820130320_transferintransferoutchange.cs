using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class transferintransferoutchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransferOut",
                table: "CostCalculated",
                newName: "TransferOutId");

            migrationBuilder.RenameColumn(
                name: "TransferIn",
                table: "CostCalculated",
                newName: "TransferInId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransferOutId",
                table: "CostCalculated",
                newName: "TransferOut");

            migrationBuilder.RenameColumn(
                name: "TransferInId",
                table: "CostCalculated",
                newName: "TransferIn");
        }
    }
}
