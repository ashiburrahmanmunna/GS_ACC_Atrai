using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class AccBudgetMainAndSubModelCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acc_BudgetMain",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FiscalYearId = table.Column<int>(type: "int", nullable: true),
                    Interval = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreFillId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_BudgetMain", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acc_BudgetMain_Acc_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "Acc_FiscalYear",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Acc_BudgetMain_Acc_FiscalYear_PreFillId",
                        column: x => x.PreFillId,
                        principalTable: "Acc_FiscalYear",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Acc_BudgetMain_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acc_BudgetMain_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Acc_BudgetSub",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccId = table.Column<int>(type: "int", nullable: false),
                    Jan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Feb = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Mar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    April = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    May = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Jun = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Jul = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Aug = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sep = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Oct = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Nov = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Dec = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quarter1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quarter2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quarter3 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quarter4 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Yearly = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Acc_BudgetMainModelId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_BudgetSub", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acc_BudgetSub_Acc_BudgetMain_Acc_BudgetMainModelId",
                        column: x => x.Acc_BudgetMainModelId,
                        principalTable: "Acc_BudgetMain",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Acc_BudgetSub_AccountHead_AccId",
                        column: x => x.AccId,
                        principalTable: "AccountHead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acc_BudgetSub_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acc_BudgetSub_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acc_BudgetMain_ComId",
                table: "Acc_BudgetMain",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_BudgetMain_FiscalYearId",
                table: "Acc_BudgetMain",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_BudgetMain_LuserId",
                table: "Acc_BudgetMain",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_BudgetMain_PreFillId",
                table: "Acc_BudgetMain",
                column: "PreFillId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_BudgetSub_Acc_BudgetMainModelId",
                table: "Acc_BudgetSub",
                column: "Acc_BudgetMainModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_BudgetSub_AccId",
                table: "Acc_BudgetSub",
                column: "AccId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_BudgetSub_ComId",
                table: "Acc_BudgetSub",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_BudgetSub_LuserId",
                table: "Acc_BudgetSub",
                column: "LuserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acc_BudgetSub");

            migrationBuilder.DropTable(
                name: "Acc_BudgetMain");
        }
    }
}
