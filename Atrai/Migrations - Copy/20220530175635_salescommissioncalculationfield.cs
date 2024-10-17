using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class salescommissioncalculationfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CustomerCommissionAmount",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SRCommissionAmount",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerCommissionAmount",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "SRCommissionAmount",
                table: "Sales");
        }
    }
}
