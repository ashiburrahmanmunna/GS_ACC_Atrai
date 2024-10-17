using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class masterPoModelCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MasterPO_Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterPONo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterPO_Master", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterPO_Master_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasterPO_Master_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MasterPO_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterPOId = table.Column<int>(type: "int", nullable: false),
                    BuyerPOId = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<double>(type: "float", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterPO_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterPO_Details_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasterPO_Details_MasterPO_Master_MasterPOId",
                        column: x => x.MasterPOId,
                        principalTable: "MasterPO_Master",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MasterPO_Details_OrderAllocationMaster_BuyerPOId",
                        column: x => x.BuyerPOId,
                        principalTable: "OrderAllocationMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MasterPO_Details_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MasterPO_Details_BuyerPOId",
                table: "MasterPO_Details",
                column: "BuyerPOId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterPO_Details_ComId",
                table: "MasterPO_Details",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterPO_Details_LuserId",
                table: "MasterPO_Details",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterPO_Details_MasterPOId",
                table: "MasterPO_Details",
                column: "MasterPOId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterPO_Master_ComId",
                table: "MasterPO_Master",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterPO_Master_LuserId",
                table: "MasterPO_Master",
                column: "LuserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasterPO_Details");

            migrationBuilder.DropTable(
                name: "MasterPO_Master");
        }
    }
}
