using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class addedGroupLC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupLC_Main",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Margin = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FreightChargePer = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CommercialCompanyId = table.Column<int>(type: "int", nullable: false),
                    BuyerId = table.Column<int>(type: "int", nullable: false),
                    GroupLCRefName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TotalGroupLCValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalGroupLCValueManual = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalGroupLCQty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FirstShipDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastShipDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GroupLCAmdNo = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupLC_Main", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupLC_Main_Commercial_CommercialCompanyId",
                        column: x => x.CommercialCompanyId,
                        principalTable: "Commercial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupLC_Main_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_GroupLC_Main_Customer_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_GroupLC_Main_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupLC_Main_BuyerId",
                table: "GroupLC_Main",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupLC_Main_ComId",
                table: "GroupLC_Main",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupLC_Main_CommercialCompanyId",
                table: "GroupLC_Main",
                column: "CommercialCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupLC_Main_LuserId",
                table: "GroupLC_Main",
                column: "LuserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupLC_Main");
        }
    }
}
