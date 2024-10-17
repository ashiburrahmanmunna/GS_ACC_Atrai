using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class CommerialModelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExportInvoiceDetails_UnitMaster_UnitMasterId1",
                table: "ExportInvoiceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupLC_Main_Commercial_CommercialCompanyId",
                table: "GroupLC_Main");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_GroupLC_Main_Customer_BuyerId",
            //    table: "GroupLC_Main");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_Commercial_CommercialCompanyId",
                table: "MasterLC");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_Customer_BuyerID",
                table: "MasterLC");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_DayList_DayListId",
                table: "MasterLC");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_Destination_DestinationId",
                table: "MasterLC");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_LCStatus_LCStatusId",
                table: "MasterLC");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_LCType_LCTypeId",
                table: "MasterLC");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_LienBank_LienBankId",
                table: "MasterLC");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_ShipMode_ShipModeId",
                table: "MasterLC");

            migrationBuilder.DropIndex(
                name: "IX_GroupLC_Main_BuyerId",
                table: "GroupLC_Main");

            migrationBuilder.AlterColumn<int>(
                name: "ShipModeId",
                table: "MasterLC",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "MasterLCValueManual",
                table: "MasterLC",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "LienBankId",
                table: "MasterLC",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LCTypeId",
                table: "MasterLC",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LCStatusId",
                table: "MasterLC",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "LCMargin",
                table: "MasterLC",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "ExportLCValueManual",
                table: "MasterLC",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "DestinationId",
                table: "MasterLC",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DestinationContract",
                table: "MasterLC",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "DayListId",
                table: "MasterLC",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CommercialCompanyId",
                table: "MasterLC",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BuyerID",
                table: "MasterLC",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CommercialCompanyId",
                table: "GroupLC_Main",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BuyerId",
                table: "GroupLC_Main",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DestinationID",
                table: "ExportOrder",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UnitMasterId1",
                table: "ExportInvoiceDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportInvoiceDetails_UnitMaster_UnitMasterId1",
                table: "ExportInvoiceDetails",
                column: "UnitMasterId1",
                principalTable: "UnitMaster",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupLC_Main_Commercial_CommercialCompanyId",
                table: "GroupLC_Main",
                column: "CommercialCompanyId",
                principalTable: "Commercial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_Commercial_CommercialCompanyId",
                table: "MasterLC",
                column: "CommercialCompanyId",
                principalTable: "Commercial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_Customer_BuyerID",
                table: "MasterLC",
                column: "BuyerID",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_DayList_DayListId",
                table: "MasterLC",
                column: "DayListId",
                principalTable: "DayList",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_Destination_DestinationId",
                table: "MasterLC",
                column: "DestinationId",
                principalTable: "Destination",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_LCStatus_LCStatusId",
                table: "MasterLC",
                column: "LCStatusId",
                principalTable: "LCStatus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_LCType_LCTypeId",
                table: "MasterLC",
                column: "LCTypeId",
                principalTable: "LCType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_LienBank_LienBankId",
                table: "MasterLC",
                column: "LienBankId",
                principalTable: "LienBank",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_ShipMode_ShipModeId",
                table: "MasterLC",
                column: "ShipModeId",
                principalTable: "ShipMode",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExportInvoiceDetails_UnitMaster_UnitMasterId1",
                table: "ExportInvoiceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupLC_Main_Commercial_CommercialCompanyId",
                table: "GroupLC_Main");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_Commercial_CommercialCompanyId",
                table: "MasterLC");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_Customer_BuyerID",
                table: "MasterLC");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_DayList_DayListId",
                table: "MasterLC");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_Destination_DestinationId",
                table: "MasterLC");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_LCStatus_LCStatusId",
                table: "MasterLC");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_LCType_LCTypeId",
                table: "MasterLC");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_LienBank_LienBankId",
                table: "MasterLC");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_ShipMode_ShipModeId",
                table: "MasterLC");

            migrationBuilder.AlterColumn<int>(
                name: "ShipModeId",
                table: "MasterLC",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MasterLCValueManual",
                table: "MasterLC",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LienBankId",
                table: "MasterLC",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LCTypeId",
                table: "MasterLC",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LCStatusId",
                table: "MasterLC",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "LCMargin",
                table: "MasterLC",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ExportLCValueManual",
                table: "MasterLC",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DestinationId",
                table: "MasterLC",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DestinationContract",
                table: "MasterLC",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DayListId",
                table: "MasterLC",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CommercialCompanyId",
                table: "MasterLC",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BuyerID",
                table: "MasterLC",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CommercialCompanyId",
                table: "GroupLC_Main",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BuyerId",
                table: "GroupLC_Main",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DestinationID",
                table: "ExportOrder",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UnitMasterId1",
                table: "ExportInvoiceDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupLC_Main_BuyerId",
                table: "GroupLC_Main",
                column: "BuyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportInvoiceDetails_UnitMaster_UnitMasterId1",
                table: "ExportInvoiceDetails",
                column: "UnitMasterId1",
                principalTable: "UnitMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupLC_Main_Commercial_CommercialCompanyId",
                table: "GroupLC_Main",
                column: "CommercialCompanyId",
                principalTable: "Commercial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupLC_Main_Customer_BuyerId",
                table: "GroupLC_Main",
                column: "BuyerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_Commercial_CommercialCompanyId",
                table: "MasterLC",
                column: "CommercialCompanyId",
                principalTable: "Commercial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_Customer_BuyerID",
                table: "MasterLC",
                column: "BuyerID",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_DayList_DayListId",
                table: "MasterLC",
                column: "DayListId",
                principalTable: "DayList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_Destination_DestinationId",
                table: "MasterLC",
                column: "DestinationId",
                principalTable: "Destination",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_LCStatus_LCStatusId",
                table: "MasterLC",
                column: "LCStatusId",
                principalTable: "LCStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_LCType_LCTypeId",
                table: "MasterLC",
                column: "LCTypeId",
                principalTable: "LCType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_LienBank_LienBankId",
                table: "MasterLC",
                column: "LienBankId",
                principalTable: "LienBank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_ShipMode_ShipModeId",
                table: "MasterLC",
                column: "ShipModeId",
                principalTable: "ShipMode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
