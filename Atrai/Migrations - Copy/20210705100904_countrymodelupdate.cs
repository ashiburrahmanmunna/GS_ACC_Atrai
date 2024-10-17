using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class countrymodelupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Company",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Company_CountryId",
                table: "Company",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Country_CountryId",
                table: "Company",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Country_CountryId",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_CountryId",
                table: "Company");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Company",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
