using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class createeditdeleteview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCreateAction",
                table: "Menu",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleteAction",
                table: "Menu",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEditAction",
                table: "Menu",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsListAction",
                table: "Menu",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReportAction",
                table: "Menu",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsViewAction",
                table: "Menu",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCreateAction",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "IsDeleteAction",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "IsEditAction",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "IsListAction",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "IsReportAction",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "IsViewAction",
                table: "Menu");
        }
    }
}
