using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class CommercialModelUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_GroupLC_Main_BuyerId",
                table: "GroupLC_Main",
                column: "BuyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupLC_Main_Customer_BuyerId",
                table: "GroupLC_Main",
                column: "BuyerId",
                principalTable: "Customer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupLC_Main_Customer_BuyerId",
                table: "GroupLC_Main");

            migrationBuilder.DropIndex(
                name: "IX_GroupLC_Main_BuyerId",
                table: "GroupLC_Main");
        }
    }
}
