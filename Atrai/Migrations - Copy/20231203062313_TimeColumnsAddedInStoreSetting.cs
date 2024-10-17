using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class TimeColumnsAddedInStoreSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DefaultMessageForPurchase",
                table: "StoreSetting",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstDayOfWeek",
                table: "StoreSetting",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAllowTimeToBillable",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsShowBillingRateToUser",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsShowServiceField",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultMessageForPurchase",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "FirstDayOfWeek",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsAllowTimeToBillable",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsShowBillingRateToUser",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsShowServiceField",
                table: "StoreSetting");
        }
    }
}
