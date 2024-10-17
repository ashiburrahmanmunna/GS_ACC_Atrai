using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class addExportInvoiceTruckDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExportInvoiceTruckDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExportInvoiceMasterId = table.Column<int>(type: "int", nullable: false),
                    TruckNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DriverName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportInvoiceTruckDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExportInvoiceTruckDetails_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ExportInvoiceTruckDetails_ExportInvoiceMaster_ExportInvoiceMasterId",
                        column: x => x.ExportInvoiceMasterId,
                        principalTable: "ExportInvoiceMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExportInvoiceTruckDetails_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoiceTruckDetails_ComId",
                table: "ExportInvoiceTruckDetails",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoiceTruckDetails_ExportInvoiceMasterId",
                table: "ExportInvoiceTruckDetails",
                column: "ExportInvoiceMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoiceTruckDetails_LuserId",
                table: "ExportInvoiceTruckDetails",
                column: "LuserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExportInvoiceTruckDetails");
        }
    }
}
