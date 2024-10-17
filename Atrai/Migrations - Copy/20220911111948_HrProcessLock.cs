using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class HrProcessLock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HR_ProcessLock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LockType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DtDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FiscalYearId = table.Column<int>(type: "int", nullable: true),
                    FiscalMonthId = table.Column<int>(type: "int", nullable: true),
                    IsLock = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_ProcessLock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HR_ProcessLock_Acc_FiscalMonth_FiscalMonthId",
                        column: x => x.FiscalMonthId,
                        principalTable: "Acc_FiscalMonth",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_ProcessLock_Acc_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "Acc_FiscalYear",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_ProcessLock_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HR_ProcessLock_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HR_ProcessLock_ComId",
                table: "HR_ProcessLock",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_ProcessLock_FiscalMonthId",
                table: "HR_ProcessLock",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_ProcessLock_FiscalYearId",
                table: "HR_ProcessLock",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_ProcessLock_LuserId",
                table: "HR_ProcessLock",
                column: "LuserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HR_ProcessLock");
        }
    }
}
