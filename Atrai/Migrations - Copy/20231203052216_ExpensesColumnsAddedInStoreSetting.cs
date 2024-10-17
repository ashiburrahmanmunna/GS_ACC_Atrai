using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class ExpensesColumnsAddedInStoreSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBillableItemAndExpenses",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSalesCopyEmail",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSalesCustomtransactionNumber",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsShowItemsTablesOnForms",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsShowTagsOnFroms",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTrackedByCustomer",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SalesBcc",
                table: "StoreSetting",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SalesCc",
                table: "StoreSetting",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SalesEmailMessage",
                table: "StoreSetting",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SalesEmailSubjectLine",
                table: "StoreSetting",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SalesGreetingAppeal",
                table: "StoreSetting",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SalesGreetingNameFormat",
                table: "StoreSetting",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBillableItemAndExpenses",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsSalesCopyEmail",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsSalesCustomtransactionNumber",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsShowItemsTablesOnForms",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsShowTagsOnFroms",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "IsTrackedByCustomer",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "SalesBcc",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "SalesCc",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "SalesEmailMessage",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "SalesEmailSubjectLine",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "SalesGreetingAppeal",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "SalesGreetingNameFormat",
                table: "StoreSetting");
        }
    }
}
