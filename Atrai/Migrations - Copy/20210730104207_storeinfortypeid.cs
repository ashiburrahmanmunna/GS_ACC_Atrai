using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class storeinfortypeid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubscriptionTypeId",
                table: "StoreSetting",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoreSetting_SubscriptionTypeId",
                table: "StoreSetting",
                column: "SubscriptionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreSetting_SubscriptionType_SubscriptionTypeId",
                table: "StoreSetting",
                column: "SubscriptionTypeId",
                principalTable: "SubscriptionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreSetting_SubscriptionType_SubscriptionTypeId",
                table: "StoreSetting");

            migrationBuilder.DropIndex(
                name: "IX_StoreSetting_SubscriptionTypeId",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "SubscriptionTypeId",
                table: "StoreSetting");
        }
    }
}
