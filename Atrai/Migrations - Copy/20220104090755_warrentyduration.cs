using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class warrentyduration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayMonthYear",
                table: "Warrenty");

            migrationBuilder.DropColumn(
                name: "DayMonthYear",
                table: "DurationTime");

            migrationBuilder.AddColumn<int>(
                name: "DurationTimeId",
                table: "Warrenty",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Days",
                table: "StoreSetting",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isBackDatePermission",
                table: "StoreSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Warrenty_DurationTimeId",
                table: "Warrenty",
                column: "DurationTimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Warrenty_DurationTime_DurationTimeId",
                table: "Warrenty",
                column: "DurationTimeId",
                principalTable: "DurationTime",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warrenty_DurationTime_DurationTimeId",
                table: "Warrenty");

            migrationBuilder.DropIndex(
                name: "IX_Warrenty_DurationTimeId",
                table: "Warrenty");

            migrationBuilder.DropColumn(
                name: "DurationTimeId",
                table: "Warrenty");

            migrationBuilder.DropColumn(
                name: "Days",
                table: "StoreSetting");

            migrationBuilder.DropColumn(
                name: "isBackDatePermission",
                table: "StoreSetting");

            migrationBuilder.AddColumn<string>(
                name: "DayMonthYear",
                table: "Warrenty",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DayMonthYear",
                table: "DurationTime",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);
        }
    }
}
