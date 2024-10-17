using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class transactiondamage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DamageId",
                table: "AccountsDailyTransaction",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountsDailyTransaction_DamageId",
                table: "AccountsDailyTransaction",
                column: "DamageId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_Damage_DamageId",
                table: "AccountsDailyTransaction",
                column: "DamageId",
                principalTable: "Damage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_Damage_DamageId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropIndex(
                name: "IX_AccountsDailyTransaction_DamageId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropColumn(
                name: "DamageId",
                table: "AccountsDailyTransaction");
        }
    }
}
