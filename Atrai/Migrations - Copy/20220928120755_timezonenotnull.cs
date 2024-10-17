using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class timezonenotnull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreSetting_TimeZoneSettings_TimeZoneSettingsId",
                table: "StoreSetting");

            migrationBuilder.AlterColumn<int>(
                name: "TimeZoneSettingsId",
                table: "StoreSetting",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreSetting_TimeZoneSettings_TimeZoneSettingsId",
                table: "StoreSetting",
                column: "TimeZoneSettingsId",
                principalTable: "TimeZoneSettings",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreSetting_TimeZoneSettings_TimeZoneSettingsId",
                table: "StoreSetting");

            migrationBuilder.AlterColumn<int>(
                name: "TimeZoneSettingsId",
                table: "StoreSetting",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreSetting_TimeZoneSettings_TimeZoneSettingsId",
                table: "StoreSetting",
                column: "TimeZoneSettingsId",
                principalTable: "TimeZoneSettings",
                principalColumn: "Id");
        }
    }
}
