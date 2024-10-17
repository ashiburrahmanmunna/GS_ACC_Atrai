using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class addrealizaiton : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExportRealization_Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExportFormNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FileNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MasterLCId = table.Column<int>(type: "int", nullable: true),
                    FBPNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FBPDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BankRef = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true),
                    CourierNo = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true),
                    CourierDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RealizationAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RealizationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalInvoiceQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReceivingVlaue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BankCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remarks = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportRealization_Master", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExportRealization_Master_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExportRealization_Master_MasterLC_MasterLCId",
                        column: x => x.MasterLCId,
                        principalTable: "MasterLC",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExportRealization_Master_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExportRealization_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RealizationId = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    TotalQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReceivingValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BankCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportRealization_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExportRealization_Details_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ExportRealization_Details_ExportInvoiceMaster_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "ExportInvoiceMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ExportRealization_Details_ExportRealization_Master_RealizationId",
                        column: x => x.RealizationId,
                        principalTable: "ExportRealization_Master",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExportRealization_Details_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExportRealization_Details_ComId",
                table: "ExportRealization_Details",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportRealization_Details_InvoiceId",
                table: "ExportRealization_Details",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportRealization_Details_LuserId",
                table: "ExportRealization_Details",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportRealization_Details_RealizationId",
                table: "ExportRealization_Details",
                column: "RealizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportRealization_Master_ComId",
                table: "ExportRealization_Master",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportRealization_Master_LuserId",
                table: "ExportRealization_Master",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportRealization_Master_MasterLCId",
                table: "ExportRealization_Master",
                column: "MasterLCId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExportRealization_Details");

            migrationBuilder.DropTable(
                name: "ExportRealization_Master");
        }
    }
}
