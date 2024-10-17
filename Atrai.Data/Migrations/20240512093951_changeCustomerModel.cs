using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeCustomerModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuyerGroupId",
                table: "Customer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_BuyerGroupId",
                table: "Customer",
                column: "BuyerGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_BuyerGroup_BuyerGroupId",
                table: "Customer",
                column: "BuyerGroupId",
                principalTable: "BuyerGroup",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_BuyerGroup_BuyerGroupId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_BuyerGroupId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "BuyerGroupId",
                table: "Customer");
        }
    }
}
