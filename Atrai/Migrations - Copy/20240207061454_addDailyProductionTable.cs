using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class addDailyProductionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyProduction_Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StyleId = table.Column<int>(type: "int", nullable: true),
                    BuyerId = table.Column<int>(type: "int", nullable: true),
                    TotalQuantity = table.Column<double>(type: "float", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyProduction_Master", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyProduction_Master_Cat_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Cat_Department",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DailyProduction_Master_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DailyProduction_Master_Customer_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DailyProduction_Master_Style_StyleId",
                        column: x => x.StyleId,
                        principalTable: "Style",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DailyProduction_Master_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyProduction_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DailyProductionId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    SizeId = table.Column<int>(type: "int", nullable: true),
                    ReceivedQuantity = table.Column<double>(type: "float", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyProduction_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyProduction_Details_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DailyProduction_Details_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DailyProduction_Details_DailyProduction_Master_DailyProductionId",
                        column: x => x.DailyProductionId,
                        principalTable: "DailyProduction_Master",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyProduction_Details_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DailyProduction_Details_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyProduction_Details_ColorId",
                table: "DailyProduction_Details",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyProduction_Details_ComId",
                table: "DailyProduction_Details",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyProduction_Details_DailyProductionId",
                table: "DailyProduction_Details",
                column: "DailyProductionId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyProduction_Details_LuserId",
                table: "DailyProduction_Details",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyProduction_Details_SizeId",
                table: "DailyProduction_Details",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyProduction_Master_BuyerId",
                table: "DailyProduction_Master",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyProduction_Master_ComId",
                table: "DailyProduction_Master",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyProduction_Master_DepartmentId",
                table: "DailyProduction_Master",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyProduction_Master_LuserId",
                table: "DailyProduction_Master",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyProduction_Master_StyleId",
                table: "DailyProduction_Master",
                column: "StyleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyProduction_Details");

            migrationBuilder.DropTable(
                name: "DailyProduction_Master");
        }
    }
}
