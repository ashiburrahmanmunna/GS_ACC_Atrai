using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class newchangenotnullbusinesstypeid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_BusinessType_BusinessTypeId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_Country_CountryId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuPermission_BusinessType_BusinessTypeid",
                table: "MenuPermission");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreSetting_BusinessType_BusinessTypeId",
                table: "StoreSetting");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreSetting_Country_CountryId",
                table: "StoreSetting");

            migrationBuilder.AddColumn<int>(
                name: "BusinessTypeid",
                table: "UserRole",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "StoreSetting",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessTypeId",
                table: "StoreSetting",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessTypeid",
                table: "MenuPermission",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Company",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessTypeId",
                table: "Company",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_BusinessTypeid",
                table: "UserRole",
                column: "BusinessTypeid");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_BusinessType_BusinessTypeId",
                table: "Company",
                column: "BusinessTypeId",
                principalTable: "BusinessType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Country_CountryId",
                table: "Company",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuPermission_BusinessType_BusinessTypeid",
                table: "MenuPermission",
                column: "BusinessTypeid",
                principalTable: "BusinessType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreSetting_BusinessType_BusinessTypeId",
                table: "StoreSetting",
                column: "BusinessTypeId",
                principalTable: "BusinessType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreSetting_Country_CountryId",
                table: "StoreSetting",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_BusinessType_BusinessTypeid",
                table: "UserRole",
                column: "BusinessTypeid",
                principalTable: "BusinessType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_BusinessType_BusinessTypeId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_Country_CountryId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuPermission_BusinessType_BusinessTypeid",
                table: "MenuPermission");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreSetting_BusinessType_BusinessTypeId",
                table: "StoreSetting");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreSetting_Country_CountryId",
                table: "StoreSetting");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_BusinessType_BusinessTypeid",
                table: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_UserRole_BusinessTypeid",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "BusinessTypeid",
                table: "UserRole");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "StoreSetting",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessTypeId",
                table: "StoreSetting",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessTypeid",
                table: "MenuPermission",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Company",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessTypeId",
                table: "Company",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_BusinessType_BusinessTypeId",
                table: "Company",
                column: "BusinessTypeId",
                principalTable: "BusinessType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Country_CountryId",
                table: "Company",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuPermission_BusinessType_BusinessTypeid",
                table: "MenuPermission",
                column: "BusinessTypeid",
                principalTable: "BusinessType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreSetting_BusinessType_BusinessTypeId",
                table: "StoreSetting",
                column: "BusinessTypeId",
                principalTable: "BusinessType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreSetting_Country_CountryId",
                table: "StoreSetting",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
