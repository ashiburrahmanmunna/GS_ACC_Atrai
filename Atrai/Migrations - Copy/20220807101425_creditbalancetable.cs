using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class creditbalancetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SendSMS_Company_ComId",
                table: "SendSMS");

            migrationBuilder.DropForeignKey(
                name: "FK_SendSMS_UserAccount_LuserId",
                table: "SendSMS");

            migrationBuilder.DropForeignKey(
                name: "FK_SMSBalance_Company_ComId",
                table: "SMSBalance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SMSBalance",
                table: "SMSBalance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SendSMS",
                table: "SendSMS");

            migrationBuilder.RenameTable(
                name: "SMSBalance",
                newName: "CreditBalance");

            migrationBuilder.RenameTable(
                name: "SendSMS",
                newName: "CreditUsed");

            migrationBuilder.RenameIndex(
                name: "IX_SMSBalance_ComId",
                table: "CreditBalance",
                newName: "IX_CreditBalance_ComId");

            migrationBuilder.RenameIndex(
                name: "IX_SendSMS_LuserId",
                table: "CreditUsed",
                newName: "IX_CreditUsed_LuserId");

            migrationBuilder.RenameIndex(
                name: "IX_SendSMS_ComId",
                table: "CreditUsed",
                newName: "IX_CreditUsed_ComId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreditBalance",
                table: "CreditBalance",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreditUsed",
                table: "CreditUsed",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditBalance_Company_ComId",
                table: "CreditBalance",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditUsed_Company_ComId",
                table: "CreditUsed",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditUsed_UserAccount_LuserId",
                table: "CreditUsed",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditBalance_Company_ComId",
                table: "CreditBalance");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditUsed_Company_ComId",
                table: "CreditUsed");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditUsed_UserAccount_LuserId",
                table: "CreditUsed");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CreditUsed",
                table: "CreditUsed");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CreditBalance",
                table: "CreditBalance");

            migrationBuilder.RenameTable(
                name: "CreditUsed",
                newName: "SendSMS");

            migrationBuilder.RenameTable(
                name: "CreditBalance",
                newName: "SMSBalance");

            migrationBuilder.RenameIndex(
                name: "IX_CreditUsed_LuserId",
                table: "SendSMS",
                newName: "IX_SendSMS_LuserId");

            migrationBuilder.RenameIndex(
                name: "IX_CreditUsed_ComId",
                table: "SendSMS",
                newName: "IX_SendSMS_ComId");

            migrationBuilder.RenameIndex(
                name: "IX_CreditBalance_ComId",
                table: "SMSBalance",
                newName: "IX_SMSBalance_ComId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SendSMS",
                table: "SendSMS",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SMSBalance",
                table: "SMSBalance",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SendSMS_Company_ComId",
                table: "SendSMS",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SendSMS_UserAccount_LuserId",
                table: "SendSMS",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SMSBalance_Company_ComId",
                table: "SMSBalance",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
