using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class avgcostpriceissueanddamage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AvgCostPrice",
                table: "IssueItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AvgCostPrice",
                table: "DamageItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvgCostPrice",
                table: "IssueItems");

            migrationBuilder.DropColumn(
                name: "AvgCostPrice",
                table: "DamageItems");
        }
    }
}
