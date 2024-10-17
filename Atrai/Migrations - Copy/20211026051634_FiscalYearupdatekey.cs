using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class FiscalYearupdatekey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FiscalMonthId",
                table: "Acc_VoucherMain",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FiscalYearId",
                table: "Acc_VoucherMain",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Acc_FiscalHalfYear",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    HyearName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HyearNameBangla = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dtFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dtTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FYId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_FiscalHalfYear", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acc_FiscalHalfYear_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acc_FiscalHalfYear_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Acc_FiscalMonth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MonthName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonthNameBangla = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dtFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dtTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpeningdtFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosingdtTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FYId = table.Column<int>(type: "int", nullable: false),
                    HYearId = table.Column<int>(type: "int", nullable: false),
                    QtrId = table.Column<int>(type: "int", nullable: false),
                    isLocked = table.Column<bool>(type: "bit", nullable: false),
                    isLockedStore = table.Column<bool>(type: "bit", nullable: false),
                    isLockedAccounts = table.Column<bool>(type: "bit", nullable: false),
                    isLockedAttendance = table.Column<bool>(type: "bit", nullable: false),
                    isLockedSalary = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_FiscalMonth", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acc_FiscalMonth_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acc_FiscalMonth_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Acc_FiscalQtr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    QtrName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QtrNameBangla = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dtFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dtTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FYId = table.Column<int>(type: "int", nullable: false),
                    HYearId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_FiscalQtr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acc_FiscalQtr_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acc_FiscalQtr_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Acc_FiscalYear",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FYName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FYNameBangla = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpeningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isWorking = table.Column<bool>(type: "bit", nullable: false),
                    isRunning = table.Column<bool>(type: "bit", nullable: false),
                    RowNo = table.Column<int>(type: "int", nullable: true),
                    isLocked = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_FiscalYear", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acc_FiscalYear_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acc_FiscalYear_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherMain_FiscalMonthId",
                table: "Acc_VoucherMain",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherMain_FiscalYearId",
                table: "Acc_VoucherMain",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_FiscalHalfYear_ComId",
                table: "Acc_FiscalHalfYear",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_FiscalHalfYear_LuserId",
                table: "Acc_FiscalHalfYear",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_FiscalMonth_ComId",
                table: "Acc_FiscalMonth",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_FiscalMonth_LuserId",
                table: "Acc_FiscalMonth",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_FiscalQtr_ComId",
                table: "Acc_FiscalQtr",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_FiscalQtr_LuserId",
                table: "Acc_FiscalQtr",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_FiscalYear_ComId",
                table: "Acc_FiscalYear",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_FiscalYear_LuserId",
                table: "Acc_FiscalYear",
                column: "LuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherMain_Acc_FiscalMonth_FiscalMonthId",
                table: "Acc_VoucherMain",
                column: "FiscalMonthId",
                principalTable: "Acc_FiscalMonth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherMain_Acc_FiscalYear_FiscalYearId",
                table: "Acc_VoucherMain",
                column: "FiscalYearId",
                principalTable: "Acc_FiscalYear",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherMain_Acc_FiscalMonth_FiscalMonthId",
                table: "Acc_VoucherMain");

            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherMain_Acc_FiscalYear_FiscalYearId",
                table: "Acc_VoucherMain");

            migrationBuilder.DropTable(
                name: "Acc_FiscalHalfYear");

            migrationBuilder.DropTable(
                name: "Acc_FiscalMonth");

            migrationBuilder.DropTable(
                name: "Acc_FiscalQtr");

            migrationBuilder.DropTable(
                name: "Acc_FiscalYear");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherMain_FiscalMonthId",
                table: "Acc_VoucherMain");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherMain_FiscalYearId",
                table: "Acc_VoucherMain");

            migrationBuilder.DropColumn(
                name: "FiscalMonthId",
                table: "Acc_VoucherMain");

            migrationBuilder.DropColumn(
                name: "FiscalYearId",
                table: "Acc_VoucherMain");
        }
    }
}
