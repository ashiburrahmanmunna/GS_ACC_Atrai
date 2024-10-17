using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateBOMMaster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LienBank_Country_CountryId",
                table: "LienBank");

            migrationBuilder.DropForeignKey(
                name: "FK_OpeningBank_Country_CountryId",
                table: "OpeningBank");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "OpeningBank",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "LienBank",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsRevised",
                table: "BOMMaster",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "BOMMaster",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BOMMaster_ParentId",
                table: "BOMMaster",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_BOMMaster_BOMMaster_ParentId",
                table: "BOMMaster",
                column: "ParentId",
                principalTable: "BOMMaster",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LienBank_Country_CountryId",
                table: "LienBank",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OpeningBank_Country_CountryId",
                table: "OpeningBank",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BOMMaster_BOMMaster_ParentId",
                table: "BOMMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_LienBank_Country_CountryId",
                table: "LienBank");

            migrationBuilder.DropForeignKey(
                name: "FK_OpeningBank_Country_CountryId",
                table: "OpeningBank");

            migrationBuilder.DropIndex(
                name: "IX_BOMMaster_ParentId",
                table: "BOMMaster");

            migrationBuilder.DropColumn(
                name: "IsRevised",
                table: "BOMMaster");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "BOMMaster");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "OpeningBank",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "LienBank",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LienBank_Country_CountryId",
                table: "LienBank",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OpeningBank_Country_CountryId",
                table: "OpeningBank",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
