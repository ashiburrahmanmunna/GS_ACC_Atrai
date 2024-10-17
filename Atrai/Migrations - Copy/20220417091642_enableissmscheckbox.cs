using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class enableissmscheckbox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isEmailSerivce",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isSMSService",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isEmailSerivce",
                table: "Company",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isSMSService",
                table: "Company",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isEmailSerivce",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "isSMSService",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "isEmailSerivce",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "isSMSService",
                table: "Company");
        }
    }
}
