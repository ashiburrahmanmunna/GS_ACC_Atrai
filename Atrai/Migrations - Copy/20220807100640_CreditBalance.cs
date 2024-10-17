using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class CreditBalance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "RechargeAmount",
                table: "SMSBalance",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "UsedAmount",
                table: "SMSBalance",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "UsedValue",
                table: "SendSMS",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "SummaryView",
                table: "MenuPermission_Master",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RechargeAmount",
                table: "SMSBalance");

            migrationBuilder.DropColumn(
                name: "UsedAmount",
                table: "SMSBalance");

            migrationBuilder.DropColumn(
                name: "UsedValue",
                table: "SendSMS");

            migrationBuilder.DropColumn(
                name: "SummaryView",
                table: "MenuPermission_Master");
        }
    }
}
