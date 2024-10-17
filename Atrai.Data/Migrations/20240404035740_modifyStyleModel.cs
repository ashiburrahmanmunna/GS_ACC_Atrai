using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class modifyStyleModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BBLCMaster_MasterLC_COM_MasterLCId",
                table: "BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_MachinaryLC_Master_Commercial_CompanyId",
                table: "COM_MachinaryLC_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_MachinaryLC_Master_ItemGroup_ItemGroupsId",
                table: "COM_MachinaryLC_Master");

            migrationBuilder.AlterColumn<int>(
                name: "ItemGroupsId",
                table: "COM_MachinaryLC_Master",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "COM_MachinaryLC_Master",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CommercialCompanyId",
                table: "BuyerPO_Master",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "COM_MasterLCId",
                table: "BBLCMaster",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_BuyerPO_Master_CommercialCompanyId",
                table: "BuyerPO_Master",
                column: "CommercialCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_BBLCMaster_MasterLC_COM_MasterLCId",
                table: "BBLCMaster",
                column: "COM_MasterLCId",
                principalTable: "MasterLC",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BuyerPO_Master_Commercial_CommercialCompanyId",
                table: "BuyerPO_Master",
                column: "CommercialCompanyId",
                principalTable: "Commercial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_MachinaryLC_Master_Commercial_CompanyId",
                table: "COM_MachinaryLC_Master",
                column: "CompanyId",
                principalTable: "Commercial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_MachinaryLC_Master_ItemGroup_ItemGroupsId",
                table: "COM_MachinaryLC_Master",
                column: "ItemGroupsId",
                principalTable: "ItemGroup",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BBLCMaster_MasterLC_COM_MasterLCId",
                table: "BBLCMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_BuyerPO_Master_Commercial_CommercialCompanyId",
                table: "BuyerPO_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_MachinaryLC_Master_Commercial_CompanyId",
                table: "COM_MachinaryLC_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_MachinaryLC_Master_ItemGroup_ItemGroupsId",
                table: "COM_MachinaryLC_Master");

            migrationBuilder.DropIndex(
                name: "IX_BuyerPO_Master_CommercialCompanyId",
                table: "BuyerPO_Master");

            migrationBuilder.DropColumn(
                name: "CommercialCompanyId",
                table: "BuyerPO_Master");

            migrationBuilder.AlterColumn<int>(
                name: "ItemGroupsId",
                table: "COM_MachinaryLC_Master",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "COM_MachinaryLC_Master",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "COM_MasterLCId",
                table: "BBLCMaster",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BBLCMaster_MasterLC_COM_MasterLCId",
                table: "BBLCMaster",
                column: "COM_MasterLCId",
                principalTable: "MasterLC",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_MachinaryLC_Master_Commercial_CompanyId",
                table: "COM_MachinaryLC_Master",
                column: "CompanyId",
                principalTable: "Commercial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_MachinaryLC_Master_ItemGroup_ItemGroupsId",
                table: "COM_MachinaryLC_Master",
                column: "ItemGroupsId",
                principalTable: "ItemGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
