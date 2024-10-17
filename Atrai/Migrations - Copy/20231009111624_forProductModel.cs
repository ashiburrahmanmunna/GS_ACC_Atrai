using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class forProductModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EANCode",
                table: "Product",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ProductProfitPer",
                table: "Product",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<double>(
                name: "RunTimeLiveStock",
                table: "Product",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EANCode",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductProfitPer",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "RunTimeLiveStock",
                table: "Product");
        }
    }
}
