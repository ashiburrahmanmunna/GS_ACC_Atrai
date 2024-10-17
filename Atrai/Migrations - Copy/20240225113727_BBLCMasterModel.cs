using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class BBLCMasterModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BBLCMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BBLCNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BBLCAmdNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UDNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmdNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tenor = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaymentTerm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LcOpeningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UDDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstShipmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastShipmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConvertRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BBLCValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BBLCQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GroupLCAverage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrevBBLCValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IncreaseValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DecreaseValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BBLCPrintDocRef = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BBLCPrintDocDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovalPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateApproval = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrintDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Percentage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BBLCMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BBLCMaster_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BBLCMaster_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BBLCMaster_ComId",
                table: "BBLCMaster",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_BBLCMaster_LuserId",
                table: "BBLCMaster",
                column: "LuserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BBLCMaster");
        }
    }
}
