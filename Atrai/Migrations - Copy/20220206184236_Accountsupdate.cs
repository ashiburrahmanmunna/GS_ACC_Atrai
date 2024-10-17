using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class Accountsupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccumulatedDepId",
                table: "AccountHead",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "AccountHead",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepExpenseId",
                table: "AccountHead",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepreciationRate",
                table: "AccountHead",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OpCredit",
                table: "AccountHead",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OpDebit",
                table: "AccountHead",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "isInactive",
                table: "AccountHead",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_AccountHead_CountryId",
                table: "AccountHead",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountHead_Country_CountryId",
                table: "AccountHead",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountHead_Country_CountryId",
                table: "AccountHead");

            migrationBuilder.DropIndex(
                name: "IX_AccountHead_CountryId",
                table: "AccountHead");

            migrationBuilder.DropColumn(
                name: "AccumulatedDepId",
                table: "AccountHead");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "AccountHead");

            migrationBuilder.DropColumn(
                name: "DepExpenseId",
                table: "AccountHead");

            migrationBuilder.DropColumn(
                name: "DepreciationRate",
                table: "AccountHead");

            migrationBuilder.DropColumn(
                name: "OpCredit",
                table: "AccountHead");

            migrationBuilder.DropColumn(
                name: "OpDebit",
                table: "AccountHead");

            migrationBuilder.DropColumn(
                name: "isInactive",
                table: "AccountHead");
        }
    }
}
