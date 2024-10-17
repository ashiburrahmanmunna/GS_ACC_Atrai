using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class customercontactinfoandwebsitewithsupplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactPersonDesignation",
                table: "Supplier",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactPersonName",
                table: "Supplier",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Supplier",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactPersonDesignation",
                table: "Customer",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactPersonName",
                table: "Customer",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Customer",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactPersonDesignation",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "ContactPersonName",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "ContactPersonDesignation",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "ContactPersonName",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Customer");
        }
    }
}
