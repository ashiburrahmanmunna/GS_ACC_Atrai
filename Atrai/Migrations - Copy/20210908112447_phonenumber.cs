using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class phonenumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccount_Warehouse_WarehouseId",
                table: "UserAccount");

            migrationBuilder.DropIndex(
                name: "IX_UserAccount_WarehouseId",
                table: "UserAccount");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "UserAccount");

            migrationBuilder.AddColumn<bool>(
                name: "IsEmailVerified",
                table: "UserAccount",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPhoneVerified",
                table: "UserAccount",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "UserAccount",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEmailVerified",
                table: "UserAccount");

            migrationBuilder.DropColumn(
                name: "IsPhoneVerified",
                table: "UserAccount");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "UserAccount");

            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "UserAccount",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_WarehouseId",
                table: "UserAccount",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccount_Warehouse_WarehouseId",
                table: "UserAccount",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
