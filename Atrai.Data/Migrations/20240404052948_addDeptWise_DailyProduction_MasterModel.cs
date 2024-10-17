using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class addDeptWise_DailyProduction_MasterModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeptWise_DailyProduction_Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StyleId = table.Column<int>(type: "int", nullable: true),
                    BuyerPOId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_DeptWise_DailyProduction_Master", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeptWise_DailyProduction_Master_BuyerPO_Master_BuyerPOId",
                        column: x => x.BuyerPOId,
                        principalTable: "BuyerPO_Master",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DeptWise_DailyProduction_Master_Cat_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Cat_Department",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DeptWise_DailyProduction_Master_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeptWise_DailyProduction_Master_Style_StyleId",
                        column: x => x.StyleId,
                        principalTable: "Style",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DeptWise_DailyProduction_Master_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DeptWise_DailyProduction_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DailyProductionId = table.Column<int>(type: "int", nullable: false),
                    StyleId = table.Column<int>(type: "int", nullable: true),
                    BuyerPOId = table.Column<int>(type: "int", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    SizeId = table.Column<int>(type: "int", nullable: true),
                    TQty = table.Column<int>(type: "int", nullable: false),
                    CQty = table.Column<int>(type: "int", nullable: false),
                    SWQty = table.Column<int>(type: "int", nullable: false),
                    WQty = table.Column<int>(type: "int", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WNo = table.Column<int>(type: "int", nullable: false),
                    WSlipNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WQty2 = table.Column<int>(type: "int", nullable: false),
                    SNo = table.Column<int>(type: "int", nullable: false),
                    SSlipNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SQty2 = table.Column<int>(type: "int", nullable: false),
                    CNo = table.Column<int>(type: "int", nullable: false),
                    CSlipNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CQty2 = table.Column<int>(type: "int", nullable: false),
                    FNo = table.Column<int>(type: "int", nullable: false),
                    FQty2 = table.Column<int>(type: "int", nullable: false),
                    QtyB = table.Column<int>(type: "int", nullable: false),
                    QtyC = table.Column<int>(type: "int", nullable: false),
                    GradeAQty = table.Column<int>(type: "int", nullable: false),
                    GradeBQty = table.Column<int>(type: "int", nullable: false),
                    GradeCQty = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_DeptWise_DailyProduction_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeptWise_DailyProduction_Details_BuyerPO_Master_BuyerPOId",
                        column: x => x.BuyerPOId,
                        principalTable: "BuyerPO_Master",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DeptWise_DailyProduction_Details_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DeptWise_DailyProduction_Details_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DeptWise_DailyProduction_Details_DeptWise_DailyProduction_Master_DailyProductionId",
                        column: x => x.DailyProductionId,
                        principalTable: "DeptWise_DailyProduction_Master",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeptWise_DailyProduction_Details_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DeptWise_DailyProduction_Details_Style_StyleId",
                        column: x => x.StyleId,
                        principalTable: "Style",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DeptWise_DailyProduction_Details_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeptWise_DailyProduction_Details_BuyerPOId",
                table: "DeptWise_DailyProduction_Details",
                column: "BuyerPOId");

            migrationBuilder.CreateIndex(
                name: "IX_DeptWise_DailyProduction_Details_ColorId",
                table: "DeptWise_DailyProduction_Details",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_DeptWise_DailyProduction_Details_ComId",
                table: "DeptWise_DailyProduction_Details",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_DeptWise_DailyProduction_Details_DailyProductionId",
                table: "DeptWise_DailyProduction_Details",
                column: "DailyProductionId");

            migrationBuilder.CreateIndex(
                name: "IX_DeptWise_DailyProduction_Details_LuserId",
                table: "DeptWise_DailyProduction_Details",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_DeptWise_DailyProduction_Details_SizeId",
                table: "DeptWise_DailyProduction_Details",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_DeptWise_DailyProduction_Details_StyleId",
                table: "DeptWise_DailyProduction_Details",
                column: "StyleId");

            migrationBuilder.CreateIndex(
                name: "IX_DeptWise_DailyProduction_Master_BuyerPOId",
                table: "DeptWise_DailyProduction_Master",
                column: "BuyerPOId");

            migrationBuilder.CreateIndex(
                name: "IX_DeptWise_DailyProduction_Master_ComId",
                table: "DeptWise_DailyProduction_Master",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_DeptWise_DailyProduction_Master_DepartmentId",
                table: "DeptWise_DailyProduction_Master",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DeptWise_DailyProduction_Master_LuserId",
                table: "DeptWise_DailyProduction_Master",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_DeptWise_DailyProduction_Master_StyleId",
                table: "DeptWise_DailyProduction_Master",
                column: "StyleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeptWise_DailyProduction_Details");

            migrationBuilder.DropTable(
                name: "DeptWise_DailyProduction_Master");
        }
    }
}
