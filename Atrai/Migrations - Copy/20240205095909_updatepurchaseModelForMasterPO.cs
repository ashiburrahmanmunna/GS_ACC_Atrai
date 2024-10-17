using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class updatepurchaseModelForMasterPO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MasterPOId",
                table: "Purchase",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_MasterPOId",
                table: "Purchase",
                column: "MasterPOId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_MasterPO_Master_MasterPOId",
                table: "Purchase",
                column: "MasterPOId",
                principalTable: "MasterPO_Master",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_MasterPO_Master_MasterPOId",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_MasterPOId",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "MasterPOId",
                table: "Purchase");
        }
    }
}
