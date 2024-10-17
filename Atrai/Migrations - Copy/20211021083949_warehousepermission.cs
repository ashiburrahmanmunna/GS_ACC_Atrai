using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class warehousepermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LuserIdAllow",
                table: "ToWarehousePermission",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserIdAllow",
                table: "FromWarehousePermission",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LuserIdAllow",
                table: "ToWarehousePermission");

            migrationBuilder.DropColumn(
                name: "LuserIdAllow",
                table: "FromWarehousePermission");
        }
    }
}
