using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class ttlsumdelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardNo",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "ttlCountQty",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "ttlIndDisAmt",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "ttlIndPrice",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "ttlIndVat",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "ttlSumAmt",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "ttlSumQty",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "ttlUnitPrice",
                table: "Purchase");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CardNo",
                table: "Purchase",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ttlCountQty",
                table: "Purchase",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ttlIndDisAmt",
                table: "Purchase",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ttlIndPrice",
                table: "Purchase",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ttlIndVat",
                table: "Purchase",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ttlSumAmt",
                table: "Purchase",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ttlSumQty",
                table: "Purchase",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ttlUnitPrice",
                table: "Purchase",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
