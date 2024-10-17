using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class basemodelfromwarehous : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComId",
                table: "ToWarehousePermission",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserIdUpdate",
                table: "ToWarehousePermission",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComId",
                table: "FromWarehousePermission",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuserIdUpdate",
                table: "FromWarehousePermission",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToWarehousePermission_ComId",
                table: "ToWarehousePermission",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_FromWarehousePermission_ComId",
                table: "FromWarehousePermission",
                column: "ComId");

            migrationBuilder.AddForeignKey(
                name: "FK_FromWarehousePermission_Company_ComId",
                table: "FromWarehousePermission",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToWarehousePermission_Company_ComId",
                table: "ToWarehousePermission",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FromWarehousePermission_Company_ComId",
                table: "FromWarehousePermission");

            migrationBuilder.DropForeignKey(
                name: "FK_ToWarehousePermission_Company_ComId",
                table: "ToWarehousePermission");

            migrationBuilder.DropIndex(
                name: "IX_ToWarehousePermission_ComId",
                table: "ToWarehousePermission");

            migrationBuilder.DropIndex(
                name: "IX_FromWarehousePermission_ComId",
                table: "FromWarehousePermission");

            migrationBuilder.DropColumn(
                name: "ComId",
                table: "ToWarehousePermission");

            migrationBuilder.DropColumn(
                name: "LuserIdUpdate",
                table: "ToWarehousePermission");

            migrationBuilder.DropColumn(
                name: "ComId",
                table: "FromWarehousePermission");

            migrationBuilder.DropColumn(
                name: "LuserIdUpdate",
                table: "FromWarehousePermission");
        }
    }
}
