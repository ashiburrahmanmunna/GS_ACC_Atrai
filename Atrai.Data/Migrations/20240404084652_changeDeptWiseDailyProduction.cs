using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeDeptWiseDailyProduction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CQty",
                table: "DeptWise_DailyProduction_Details");

            migrationBuilder.DropColumn(
                name: "CQty2",
                table: "DeptWise_DailyProduction_Details");

            migrationBuilder.DropColumn(
                name: "FQty2",
                table: "DeptWise_DailyProduction_Details");

            migrationBuilder.DropColumn(
                name: "SQty2",
                table: "DeptWise_DailyProduction_Details");

            migrationBuilder.DropColumn(
                name: "SWQty",
                table: "DeptWise_DailyProduction_Details");

            migrationBuilder.DropColumn(
                name: "WQty",
                table: "DeptWise_DailyProduction_Details");

            migrationBuilder.RenameColumn(
                name: "WQty2",
                table: "DeptWise_DailyProduction_Details",
                newName: "TQty2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TQty2",
                table: "DeptWise_DailyProduction_Details",
                newName: "WQty2");

            migrationBuilder.AddColumn<int>(
                name: "CQty",
                table: "DeptWise_DailyProduction_Details",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CQty2",
                table: "DeptWise_DailyProduction_Details",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FQty2",
                table: "DeptWise_DailyProduction_Details",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SQty2",
                table: "DeptWise_DailyProduction_Details",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SWQty",
                table: "DeptWise_DailyProduction_Details",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WQty",
                table: "DeptWise_DailyProduction_Details",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
