using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class distancename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WeightName",
                table: "DeliveryServiceDistance",
                newName: "DistanceName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DistanceName",
                table: "DeliveryServiceDistance",
                newName: "WeightName");
        }
    }
}
