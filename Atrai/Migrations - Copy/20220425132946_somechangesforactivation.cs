using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class somechangesforactivation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComId",
                table: "SubscriptionActivation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SMSUsedQuantity",
                table: "SMSBalance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionActivation_ComId",
                table: "SubscriptionActivation",
                column: "ComId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionActivation_Company_ComId",
                table: "SubscriptionActivation",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionActivation_Company_ComId",
                table: "SubscriptionActivation");

            migrationBuilder.DropIndex(
                name: "IX_SubscriptionActivation_ComId",
                table: "SubscriptionActivation");

            migrationBuilder.DropColumn(
                name: "ComId",
                table: "SubscriptionActivation");

            migrationBuilder.DropColumn(
                name: "SMSUsedQuantity",
                table: "SMSBalance");
        }
    }
}
