using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class PorofromaInvoiceSub : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MasterLCId",
                table: "COM_DocumentAcceptance_Master",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "COM_ProformaInvoice_Sub",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemDescId = table.Column<int>(type: "int", nullable: true),
                    PIId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COM_ProformaInvoice_Sub", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COM_ProformaInvoice_Sub_COM_ProformaInvoices_PIId",
                        column: x => x.PIId,
                        principalTable: "COM_ProformaInvoices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_ProformaInvoice_Sub_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_COM_ProformaInvoice_Sub_ItemDesc_ItemDescId",
                        column: x => x.ItemDescId,
                        principalTable: "ItemDesc",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COM_ProformaInvoice_Sub_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_COM_DocumentAcceptance_Master_MasterLCId",
                table: "COM_DocumentAcceptance_Master",
                column: "MasterLCId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_ProformaInvoice_Sub_ComId",
                table: "COM_ProformaInvoice_Sub",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_ProformaInvoice_Sub_ItemDescId",
                table: "COM_ProformaInvoice_Sub",
                column: "ItemDescId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_ProformaInvoice_Sub_LuserId",
                table: "COM_ProformaInvoice_Sub",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_ProformaInvoice_Sub_PIId",
                table: "COM_ProformaInvoice_Sub",
                column: "PIId");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_DocumentAcceptance_Master_MasterLC_MasterLCId",
                table: "COM_DocumentAcceptance_Master",
                column: "MasterLCId",
                principalTable: "MasterLC",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COM_DocumentAcceptance_Master_MasterLC_MasterLCId",
                table: "COM_DocumentAcceptance_Master");

            migrationBuilder.DropTable(
                name: "COM_ProformaInvoice_Sub");

            migrationBuilder.DropIndex(
                name: "IX_COM_DocumentAcceptance_Master_MasterLCId",
                table: "COM_DocumentAcceptance_Master");

            migrationBuilder.DropColumn(
                name: "MasterLCId",
                table: "COM_DocumentAcceptance_Master");
        }
    }
}
