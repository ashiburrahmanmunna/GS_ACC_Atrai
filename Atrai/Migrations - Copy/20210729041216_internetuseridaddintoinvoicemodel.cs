using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class internetuseridaddintoinvoicemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpireDateExtend_InternetUser_InternetUserId",
                table: "ExpireDateExtend");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTerminate_InternetUser_InternetUserId",
                table: "UserTerminate");

            migrationBuilder.AlterColumn<int>(
                name: "InternetUserId",
                table: "UserTerminate",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InternetUserId",
                table: "InvoiceBill",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InternetUserId",
                table: "ExpireDateExtend",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceBill_InternetUserId",
                table: "InvoiceBill",
                column: "InternetUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpireDateExtend_InternetUser_InternetUserId",
                table: "ExpireDateExtend",
                column: "InternetUserId",
                principalTable: "InternetUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceBill_InternetUser_InternetUserId",
                table: "InvoiceBill",
                column: "InternetUserId",
                principalTable: "InternetUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTerminate_InternetUser_InternetUserId",
                table: "UserTerminate",
                column: "InternetUserId",
                principalTable: "InternetUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpireDateExtend_InternetUser_InternetUserId",
                table: "ExpireDateExtend");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceBill_InternetUser_InternetUserId",
                table: "InvoiceBill");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTerminate_InternetUser_InternetUserId",
                table: "UserTerminate");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceBill_InternetUserId",
                table: "InvoiceBill");

            migrationBuilder.DropColumn(
                name: "InternetUserId",
                table: "InvoiceBill");

            migrationBuilder.AlterColumn<int>(
                name: "InternetUserId",
                table: "UserTerminate",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "InternetUserId",
                table: "ExpireDateExtend",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpireDateExtend_InternetUser_InternetUserId",
                table: "ExpireDateExtend",
                column: "InternetUserId",
                principalTable: "InternetUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTerminate_InternetUser_InternetUserId",
                table: "UserTerminate",
                column: "InternetUserId",
                principalTable: "InternetUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
