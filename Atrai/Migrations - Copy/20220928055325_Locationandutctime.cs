using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class Locationandutctime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UTCTime",
                table: "TimeZoneSettings",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TimeZoneName",
                table: "TimeZoneSettings",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80);

            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "Acc_VoucherMain",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherMain_WarehouseId",
                table: "Acc_VoucherMain",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherMain_Warehouse_WarehouseId",
                table: "Acc_VoucherMain",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherMain_Warehouse_WarehouseId",
                table: "Acc_VoucherMain");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherMain_WarehouseId",
                table: "Acc_VoucherMain");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "Acc_VoucherMain");

            migrationBuilder.AlterColumn<string>(
                name: "UTCTime",
                table: "TimeZoneSettings",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TimeZoneName",
                table: "TimeZoneSettings",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);
        }
    }
}
