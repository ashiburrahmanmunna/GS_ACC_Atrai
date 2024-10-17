using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class smssettingschanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isInactive",
                table: "SmsSetting");

            migrationBuilder.DropColumn(
                name: "smsAbsent",
                table: "SmsSetting");

            migrationBuilder.DropColumn(
                name: "smsCollection",
                table: "SmsSetting");

            migrationBuilder.DropColumn(
                name: "smsLate",
                table: "SmsSetting");

            migrationBuilder.RenameColumn(
                name: "smsPresent",
                table: "SmsSetting",
                newName: "SmsProvider");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "SmsSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "SmsSetting");

            migrationBuilder.RenameColumn(
                name: "SmsProvider",
                table: "SmsSetting",
                newName: "smsPresent");

            migrationBuilder.AddColumn<string>(
                name: "isInactive",
                table: "SmsSetting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "smsAbsent",
                table: "SmsSetting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "smsCollection",
                table: "SmsSetting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "smsLate",
                table: "SmsSetting",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
