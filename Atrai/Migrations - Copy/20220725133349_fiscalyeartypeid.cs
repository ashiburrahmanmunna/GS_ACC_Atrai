using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class fiscalyeartypeid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FYStartMonth",
                table: "FiscalYearType",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FYStartDate",
                table: "FiscalYearType",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FYEndMonth",
                table: "FiscalYearType",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FYEndDate",
                table: "FiscalYearType",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FiscalYearTypeId",
                table: "Company",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Company_FiscalYearTypeId",
                table: "Company",
                column: "FiscalYearTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_FiscalYearType_FiscalYearTypeId",
                table: "Company",
                column: "FiscalYearTypeId",
                principalTable: "FiscalYearType",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_FiscalYearType_FiscalYearTypeId",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_FiscalYearTypeId",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "FiscalYearTypeId",
                table: "Company");

            migrationBuilder.AlterColumn<int>(
                name: "FYStartMonth",
                table: "FiscalYearType",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FYStartDate",
                table: "FiscalYearType",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FYEndMonth",
                table: "FiscalYearType",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FYEndDate",
                table: "FiscalYearType",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
