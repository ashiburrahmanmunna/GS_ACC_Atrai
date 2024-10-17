using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class createupdatedeletepermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsUpdate",
                table: "MenuPermission",
                newName: "IsUpdatePermission");

            migrationBuilder.RenameColumn(
                name: "IsCreate",
                table: "MenuPermission",
                newName: "IsDeletePermission");

            migrationBuilder.AddColumn<bool>(
                name: "IsCreatePermission",
                table: "MenuPermission",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCreatePermission",
                table: "MenuPermission");

            migrationBuilder.RenameColumn(
                name: "IsUpdatePermission",
                table: "MenuPermission",
                newName: "IsUpdate");

            migrationBuilder.RenameColumn(
                name: "IsDeletePermission",
                table: "MenuPermission",
                newName: "IsCreate");
        }
    }
}
