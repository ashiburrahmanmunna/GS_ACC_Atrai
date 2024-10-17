using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class changesforsmsbalance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SMSBalance_UserAccount_LuserId",
                table: "SMSBalance");

            migrationBuilder.DropIndex(
                name: "IX_SMSBalance_LuserId",
                table: "SMSBalance");

            migrationBuilder.DropColumn(
                name: "LuserId",
                table: "SMSBalance");

            migrationBuilder.DropColumn(
                name: "LuserIdUpdate",
                table: "SMSBalance");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LuserId",
                table: "SMSBalance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserIdUpdate",
                table: "SMSBalance",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SMSBalance_LuserId",
                table: "SMSBalance",
                column: "LuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SMSBalance_UserAccount_LuserId",
                table: "SMSBalance",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
