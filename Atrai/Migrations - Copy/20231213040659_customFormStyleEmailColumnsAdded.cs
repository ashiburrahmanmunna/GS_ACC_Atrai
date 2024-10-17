using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class customFormStyleEmailColumnsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFullDetails",
                table: "CustomFormStyle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPdfAttached",
                table: "CustomFormStyle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReiminderEmailGreetingUsed",
                table: "CustomFormStyle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsStandardEmialGreetingUsed",
                table: "CustomFormStyle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSummarizedDetails",
                table: "CustomFormStyle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ReiminderEmailGreetingFullName",
                table: "CustomFormStyle",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReiminderEmailGreetingsAppeal",
                table: "CustomFormStyle",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReiminderEmailMsgToCustomer",
                table: "CustomFormStyle",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReiminderEmailSubject",
                table: "CustomFormStyle",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StandardEmailGreetingFullName",
                table: "CustomFormStyle",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StandardEmailGreetingsAppeal",
                table: "CustomFormStyle",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StandardEmailMsgToCustomer",
                table: "CustomFormStyle",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StandardEmailSubject",
                table: "CustomFormStyle",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFullDetails",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "IsPdfAttached",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "IsReiminderEmailGreetingUsed",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "IsStandardEmialGreetingUsed",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "IsSummarizedDetails",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "ReiminderEmailGreetingFullName",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "ReiminderEmailGreetingsAppeal",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "ReiminderEmailMsgToCustomer",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "ReiminderEmailSubject",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "StandardEmailGreetingFullName",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "StandardEmailGreetingsAppeal",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "StandardEmailMsgToCustomer",
                table: "CustomFormStyle");

            migrationBuilder.DropColumn(
                name: "StandardEmailSubject",
                table: "CustomFormStyle");
        }
    }
}
