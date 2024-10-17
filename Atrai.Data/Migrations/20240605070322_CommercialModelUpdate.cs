using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class CommercialModelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PortOfDestinationId",
                table: "ImportCI_Master",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PortOfOriginId",
                table: "ImportCI_Master",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "ImportCI_Master",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingMarks",
                table: "CommercialCompanies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImportCI_Master_PortOfDestinationId",
                table: "ImportCI_Master",
                column: "PortOfDestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportCI_Master_PortOfOriginId",
                table: "ImportCI_Master",
                column: "PortOfOriginId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImportCI_Master_Destination_PortOfDestinationId",
                table: "ImportCI_Master",
                column: "PortOfDestinationId",
                principalTable: "Destination",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImportCI_Master_PortOfLoading_PortOfOriginId",
                table: "ImportCI_Master",
                column: "PortOfOriginId",
                principalTable: "PortOfLoading",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImportCI_Master_Destination_PortOfDestinationId",
                table: "ImportCI_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_ImportCI_Master_PortOfLoading_PortOfOriginId",
                table: "ImportCI_Master");

            migrationBuilder.DropIndex(
                name: "IX_ImportCI_Master_PortOfDestinationId",
                table: "ImportCI_Master");

            migrationBuilder.DropIndex(
                name: "IX_ImportCI_Master_PortOfOriginId",
                table: "ImportCI_Master");

            migrationBuilder.DropColumn(
                name: "PortOfDestinationId",
                table: "ImportCI_Master");

            migrationBuilder.DropColumn(
                name: "PortOfOriginId",
                table: "ImportCI_Master");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "ImportCI_Master");

            migrationBuilder.DropColumn(
                name: "ShippingMarks",
                table: "CommercialCompanies");
        }
    }
}
