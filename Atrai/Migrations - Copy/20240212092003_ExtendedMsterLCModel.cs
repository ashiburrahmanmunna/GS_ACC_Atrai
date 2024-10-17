using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedMsterLCModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_LienBank_LienBankId",
                table: "MasterLC");

            migrationBuilder.AlterColumn<int>(
                name: "LienBankId",
                table: "MasterLC",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BankAccountId",
                table: "MasterLC",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BankAccountNosId",
                table: "MasterLC",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MasterLCModelId",
                table: "MasterLC",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MasterLCModelId",
                table: "COM_MasterLCExport",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MasterLC_BankAccountNosId",
                table: "MasterLC",
                column: "BankAccountNosId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterLC_MasterLCModelId",
                table: "MasterLC",
                column: "MasterLCModelId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_MasterLCExport_MasterLCModelId",
                table: "COM_MasterLCExport",
                column: "MasterLCModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_MasterLCExport_MasterLC_MasterLCModelId",
                table: "COM_MasterLCExport",
                column: "MasterLCModelId",
                principalTable: "MasterLC",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_BankAccountNo_BankAccountNosId",
                table: "MasterLC",
                column: "BankAccountNosId",
                principalTable: "BankAccountNo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_LienBank_LienBankId",
                table: "MasterLC",
                column: "LienBankId",
                principalTable: "LienBank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_MasterLC_MasterLCModelId",
                table: "MasterLC",
                column: "MasterLCModelId",
                principalTable: "MasterLC",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COM_MasterLCExport_MasterLC_MasterLCModelId",
                table: "COM_MasterLCExport");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_BankAccountNo_BankAccountNosId",
                table: "MasterLC");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_LienBank_LienBankId",
                table: "MasterLC");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_MasterLC_MasterLCModelId",
                table: "MasterLC");

            migrationBuilder.DropIndex(
                name: "IX_MasterLC_BankAccountNosId",
                table: "MasterLC");

            migrationBuilder.DropIndex(
                name: "IX_MasterLC_MasterLCModelId",
                table: "MasterLC");

            migrationBuilder.DropIndex(
                name: "IX_COM_MasterLCExport_MasterLCModelId",
                table: "COM_MasterLCExport");

            migrationBuilder.DropColumn(
                name: "BankAccountId",
                table: "MasterLC");

            migrationBuilder.DropColumn(
                name: "BankAccountNosId",
                table: "MasterLC");

            migrationBuilder.DropColumn(
                name: "MasterLCModelId",
                table: "MasterLC");

            migrationBuilder.DropColumn(
                name: "MasterLCModelId",
                table: "COM_MasterLCExport");

            migrationBuilder.AlterColumn<int>(
                name: "LienBankId",
                table: "MasterLC",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_LienBank_LienBankId",
                table: "MasterLC",
                column: "LienBankId",
                principalTable: "LienBank",
                principalColumn: "Id");
        }
    }
}
