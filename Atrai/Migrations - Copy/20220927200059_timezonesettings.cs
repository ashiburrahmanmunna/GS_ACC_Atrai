using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class timezonesettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimeZoneSettingsId",
                table: "StoreSetting",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TimeZoneSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeZoneName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    UTCTime = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    isInactive = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeZoneSettings", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoreSetting_TimeZoneSettingsId",
                table: "StoreSetting",
                column: "TimeZoneSettingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreSetting_TimeZoneSettings_TimeZoneSettingsId",
                table: "StoreSetting",
                column: "TimeZoneSettingsId",
                principalTable: "TimeZoneSettings",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreSetting_TimeZoneSettings_TimeZoneSettingsId",
                table: "StoreSetting");

            migrationBuilder.DropTable(
                name: "TimeZoneSettings");

            migrationBuilder.DropIndex(
                name: "IX_StoreSetting_TimeZoneSettingsId",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "TimeZoneSettingsId",
                table: "StoreSetting");
        }
    }
}
