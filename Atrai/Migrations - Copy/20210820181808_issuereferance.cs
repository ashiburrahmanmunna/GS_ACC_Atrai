using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class issuereferance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrimaryAddress",
                table: "Issue",
                newName: "ReferanceTwo");

            migrationBuilder.RenameColumn(
                name: "CustomerName",
                table: "Issue",
                newName: "ReferanceOne");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReferanceTwo",
                table: "Issue",
                newName: "PrimaryAddress");

            migrationBuilder.RenameColumn(
                name: "ReferanceOne",
                table: "Issue",
                newName: "CustomerName");
        }
    }
}
