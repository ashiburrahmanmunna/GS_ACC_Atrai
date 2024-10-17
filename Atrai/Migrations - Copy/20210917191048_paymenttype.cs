using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class paymenttype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentType_Company_ComId",
                table: "PaymentType");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentType_UserAccount_LuserId",
                table: "PaymentType");

            migrationBuilder.DropIndex(
                name: "IX_PaymentType_ComId",
                table: "PaymentType");

            migrationBuilder.DropIndex(
                name: "IX_PaymentType_LuserId",
                table: "PaymentType");

            migrationBuilder.DropColumn(
                name: "LuserId",
                table: "PaymentType");

            migrationBuilder.DropColumn(
                name: "LuserIdUpdate",
                table: "PaymentType");

            migrationBuilder.AlterColumn<int>(
                name: "ComId",
                table: "PaymentType",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeliveryService",
                table: "PaymentType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTrading",
                table: "PaymentType",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeliveryService",
                table: "PaymentType");

            migrationBuilder.DropColumn(
                name: "IsTrading",
                table: "PaymentType");

            migrationBuilder.AlterColumn<int>(
                name: "ComId",
                table: "PaymentType",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LuserId",
                table: "PaymentType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserIdUpdate",
                table: "PaymentType",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentType_ComId",
                table: "PaymentType",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentType_LuserId",
                table: "PaymentType",
                column: "LuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentType_Company_ComId",
                table: "PaymentType",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentType_UserAccount_LuserId",
                table: "PaymentType",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
