using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class ComercialModelMigrationextended : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COM_CommercialInvoice_Commercial_CommercialCompanyID",
                table: "COM_CommercialInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_CommercialInvoice_Country_CurrencyId",
                table: "COM_CommercialInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_CommercialInvoice_DocumentStatus_DocumentStatusId",
                table: "COM_CommercialInvoice");

            migrationBuilder.AlterColumn<int>(
                name: "DocumentStatusId",
                table: "COM_CommercialInvoice",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CurrencyId",
                table: "COM_CommercialInvoice",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CommercialCompanyID",
                table: "COM_CommercialInvoice",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_CommercialInvoice_Commercial_CommercialCompanyID",
                table: "COM_CommercialInvoice",
                column: "CommercialCompanyID",
                principalTable: "Commercial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_CommercialInvoice_Country_CurrencyId",
                table: "COM_CommercialInvoice",
                column: "CurrencyId",
                principalTable: "Country",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_CommercialInvoice_DocumentStatus_DocumentStatusId",
                table: "COM_CommercialInvoice",
                column: "DocumentStatusId",
                principalTable: "DocumentStatus",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COM_CommercialInvoice_Commercial_CommercialCompanyID",
                table: "COM_CommercialInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_CommercialInvoice_Country_CurrencyId",
                table: "COM_CommercialInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_CommercialInvoice_DocumentStatus_DocumentStatusId",
                table: "COM_CommercialInvoice");

            migrationBuilder.AlterColumn<int>(
                name: "DocumentStatusId",
                table: "COM_CommercialInvoice",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CurrencyId",
                table: "COM_CommercialInvoice",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CommercialCompanyID",
                table: "COM_CommercialInvoice",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_CommercialInvoice_Commercial_CommercialCompanyID",
                table: "COM_CommercialInvoice",
                column: "CommercialCompanyID",
                principalTable: "Commercial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_CommercialInvoice_Country_CurrencyId",
                table: "COM_CommercialInvoice",
                column: "CurrencyId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_CommercialInvoice_DocumentStatus_DocumentStatusId",
                table: "COM_CommercialInvoice",
                column: "DocumentStatusId",
                principalTable: "DocumentStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
