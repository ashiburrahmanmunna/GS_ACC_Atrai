using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class barcodeprefixforweightscale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BarcodePrefixForWeightScale",
                table: "StoreSetting",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BarcodePrefixForWeightScale",
                table: "StoreSetting");
        }
    }
}
