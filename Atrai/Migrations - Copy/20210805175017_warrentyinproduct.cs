using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class warrentyinproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WarrentyId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleteP",
                table: "MenuPermission_Details",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Product_WarrentyId",
                table: "Product",
                column: "WarrentyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Warrenty_WarrentyId",
                table: "Product",
                column: "WarrentyId",
                principalTable: "Warrenty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Warrenty_WarrentyId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_WarrentyId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "WarrentyId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IsDeleteP",
                table: "MenuPermission_Details");
        }
    }
}
