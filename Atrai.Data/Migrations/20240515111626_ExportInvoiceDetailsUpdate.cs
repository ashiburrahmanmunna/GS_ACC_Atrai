using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExportInvoiceDetailsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExportInvoiceDetails_UnitMaster_UnitMasterId1",
                table: "ExportInvoiceDetails");

            migrationBuilder.DropIndex(
                name: "IX_ExportInvoiceDetails_UnitMasterId1",
                table: "ExportInvoiceDetails");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "ExportInvoiceDetails");

            migrationBuilder.DropColumn(
                name: "UnitMasterId1",
                table: "ExportInvoiceDetails");

            migrationBuilder.AlterColumn<int>(
                name: "UnitMasterId",
                table: "ExportInvoiceDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoiceDetails_MasterLCDetailsID",
                table: "ExportInvoiceDetails",
                column: "MasterLCDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoiceDetails_UnitMasterId",
                table: "ExportInvoiceDetails",
                column: "UnitMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportInvoiceDetails_COM_MasterLC_Details_MasterLCDetailsID",
                table: "ExportInvoiceDetails",
                column: "MasterLCDetailsID",
                principalTable: "COM_MasterLC_Details",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ExportInvoiceDetails_UnitMaster_UnitMasterId",
                table: "ExportInvoiceDetails",
                column: "UnitMasterId",
                principalTable: "UnitMaster",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExportInvoiceDetails_COM_MasterLC_Details_MasterLCDetailsID",
                table: "ExportInvoiceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ExportInvoiceDetails_UnitMaster_UnitMasterId",
                table: "ExportInvoiceDetails");

            migrationBuilder.DropIndex(
                name: "IX_ExportInvoiceDetails_MasterLCDetailsID",
                table: "ExportInvoiceDetails");

            migrationBuilder.DropIndex(
                name: "IX_ExportInvoiceDetails_UnitMasterId",
                table: "ExportInvoiceDetails");

            migrationBuilder.AlterColumn<string>(
                name: "UnitMasterId",
                table: "ExportInvoiceDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "ExportInvoiceDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnitMasterId1",
                table: "ExportInvoiceDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoiceDetails_UnitMasterId1",
                table: "ExportInvoiceDetails",
                column: "UnitMasterId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportInvoiceDetails_UnitMaster_UnitMasterId1",
                table: "ExportInvoiceDetails",
                column: "UnitMasterId1",
                principalTable: "UnitMaster",
                principalColumn: "Id");
        }
    }
}
