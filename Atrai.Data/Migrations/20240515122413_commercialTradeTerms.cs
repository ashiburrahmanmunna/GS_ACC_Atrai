using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class commercialTradeTerms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COM_BBLC_Master_PaymentTermss_PaymentTermsId",
                table: "COM_BBLC_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_BBLC_Master_TradeTerm_TradeTermId",
                table: "COM_BBLC_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_MachinaryLC_Master_PaymentTermss_PaymentTermsId",
                table: "COM_MachinaryLC_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_MachinaryLC_Master_TradeTerm_TradeTermId",
                table: "COM_MachinaryLC_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_proformaInvoice_PaymentTermss_PaymentTermsId",
                table: "Com_proformaInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_ExportInvoiceMaster_TradeTerm_TradeTermId",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_PaymentTermss_PaymentTermsId",
                table: "MasterLC");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_TradeTerm_TradeTermId",
                table: "MasterLC");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOCOM_MachineryLCMasterrderMaster_PaymentTermss_PaymentTermsId",
                table: "WorkOCOM_MachineryLCMasterrderMaster");

            migrationBuilder.DropTable(
                name: "PaymentTermss");

            migrationBuilder.DropTable(
                name: "TradeTerm");

            migrationBuilder.DropIndex(
                name: "IX_ExportInvoiceMaster_TradeTermId",
                table: "ExportInvoiceMaster");

            migrationBuilder.AddColumn<int>(
                name: "TradetermsId",
                table: "ExportInvoiceMaster",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Com_PaymentTerms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentTermsName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PaymentTermsShortName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Days = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Com_PaymentTerms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommercialTradeTerm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TradeTermName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TradeTermShortName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommercialTradeTerm", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoiceMaster_TradetermsId",
                table: "ExportInvoiceMaster",
                column: "TradetermsId");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_BBLC_Master_Com_PaymentTerms_PaymentTermsId",
                table: "COM_BBLC_Master",
                column: "PaymentTermsId",
                principalTable: "Com_PaymentTerms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_BBLC_Master_CommercialTradeTerm_TradeTermId",
                table: "COM_BBLC_Master",
                column: "TradeTermId",
                principalTable: "CommercialTradeTerm",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_MachinaryLC_Master_Com_PaymentTerms_PaymentTermsId",
                table: "COM_MachinaryLC_Master",
                column: "PaymentTermsId",
                principalTable: "Com_PaymentTerms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_MachinaryLC_Master_CommercialTradeTerm_TradeTermId",
                table: "COM_MachinaryLC_Master",
                column: "TradeTermId",
                principalTable: "CommercialTradeTerm",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_proformaInvoice_Com_PaymentTerms_PaymentTermsId",
                table: "Com_proformaInvoice",
                column: "PaymentTermsId",
                principalTable: "Com_PaymentTerms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportInvoiceMaster_CommercialTradeTerm_TradetermsId",
                table: "ExportInvoiceMaster",
                column: "TradetermsId",
                principalTable: "CommercialTradeTerm",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_Com_PaymentTerms_PaymentTermsId",
                table: "MasterLC",
                column: "PaymentTermsId",
                principalTable: "Com_PaymentTerms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_CommercialTradeTerm_TradeTermId",
                table: "MasterLC",
                column: "TradeTermId",
                principalTable: "CommercialTradeTerm",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOCOM_MachineryLCMasterrderMaster_Com_PaymentTerms_PaymentTermsId",
                table: "WorkOCOM_MachineryLCMasterrderMaster",
                column: "PaymentTermsId",
                principalTable: "Com_PaymentTerms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COM_BBLC_Master_Com_PaymentTerms_PaymentTermsId",
                table: "COM_BBLC_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_BBLC_Master_CommercialTradeTerm_TradeTermId",
                table: "COM_BBLC_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_MachinaryLC_Master_Com_PaymentTerms_PaymentTermsId",
                table: "COM_MachinaryLC_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_MachinaryLC_Master_CommercialTradeTerm_TradeTermId",
                table: "COM_MachinaryLC_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_Com_proformaInvoice_Com_PaymentTerms_PaymentTermsId",
                table: "Com_proformaInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_ExportInvoiceMaster_CommercialTradeTerm_TradetermsId",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_Com_PaymentTerms_PaymentTermsId",
                table: "MasterLC");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterLC_CommercialTradeTerm_TradeTermId",
                table: "MasterLC");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOCOM_MachineryLCMasterrderMaster_Com_PaymentTerms_PaymentTermsId",
                table: "WorkOCOM_MachineryLCMasterrderMaster");

            migrationBuilder.DropTable(
                name: "Com_PaymentTerms");

            migrationBuilder.DropTable(
                name: "CommercialTradeTerm");

            migrationBuilder.DropIndex(
                name: "IX_ExportInvoiceMaster_TradetermsId",
                table: "ExportInvoiceMaster");

            migrationBuilder.DropColumn(
                name: "TradetermsId",
                table: "ExportInvoiceMaster");

            migrationBuilder.CreateTable(
                name: "PaymentTermss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Days = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    PaymentTermsName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PaymentTermsShortName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTermss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TradeTerm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    TradeTermName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TradeTermShortName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeTerm", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoiceMaster_TradeTermId",
                table: "ExportInvoiceMaster",
                column: "TradeTermId");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_BBLC_Master_PaymentTermss_PaymentTermsId",
                table: "COM_BBLC_Master",
                column: "PaymentTermsId",
                principalTable: "PaymentTermss",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_BBLC_Master_TradeTerm_TradeTermId",
                table: "COM_BBLC_Master",
                column: "TradeTermId",
                principalTable: "TradeTerm",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_MachinaryLC_Master_PaymentTermss_PaymentTermsId",
                table: "COM_MachinaryLC_Master",
                column: "PaymentTermsId",
                principalTable: "PaymentTermss",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_MachinaryLC_Master_TradeTerm_TradeTermId",
                table: "COM_MachinaryLC_Master",
                column: "TradeTermId",
                principalTable: "TradeTerm",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_proformaInvoice_PaymentTermss_PaymentTermsId",
                table: "Com_proformaInvoice",
                column: "PaymentTermsId",
                principalTable: "PaymentTermss",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportInvoiceMaster_TradeTerm_TradeTermId",
                table: "ExportInvoiceMaster",
                column: "TradeTermId",
                principalTable: "TradeTerm",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_PaymentTermss_PaymentTermsId",
                table: "MasterLC",
                column: "PaymentTermsId",
                principalTable: "PaymentTermss",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterLC_TradeTerm_TradeTermId",
                table: "MasterLC",
                column: "TradeTermId",
                principalTable: "TradeTerm",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOCOM_MachineryLCMasterrderMaster_PaymentTermss_PaymentTermsId",
                table: "WorkOCOM_MachineryLCMasterrderMaster",
                column: "PaymentTermsId",
                principalTable: "PaymentTermss",
                principalColumn: "Id");
        }
    }
}
