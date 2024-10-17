using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class primaryaddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Customer",
                newName: "SecoundaryAddress");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimaryAddress",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "PrimaryAddress",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "SecoundaryAddress",
                table: "Customer",
                newName: "Address");
        }
    }
}
