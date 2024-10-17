using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Invoice.Migrations
{
    public partial class shiftinputhr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HR_Emp_ShiftInput",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DtDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Emp_ShiftInput", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HR_Emp_ShiftInput_Cat_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Cat_Shift",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HR_Emp_ShiftInput_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HR_Emp_ShiftInput_Employee_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HR_Emp_ShiftInput_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HR_OverTimeSetting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsAllowMinute = table.Column<bool>(type: "bit", nullable: false),
                    GraceTimeFrom = table.Column<int>(type: "int", nullable: false),
                    GraceTimeTo = table.Column<int>(type: "int", nullable: false),
                    From1 = table.Column<int>(type: "int", nullable: false),
                    To1 = table.Column<int>(type: "int", nullable: false),
                    OT1 = table.Column<float>(type: "real", nullable: false),
                    From2 = table.Column<int>(type: "int", nullable: false),
                    To2 = table.Column<int>(type: "int", nullable: false),
                    OT2 = table.Column<float>(type: "real", nullable: false),
                    From3 = table.Column<int>(type: "int", nullable: false),
                    To3 = table.Column<int>(type: "int", nullable: false),
                    OT3 = table.Column<float>(type: "real", nullable: false),
                    From4 = table.Column<int>(type: "int", nullable: false),
                    To4 = table.Column<int>(type: "int", nullable: false),
                    OT4 = table.Column<float>(type: "real", nullable: false),
                    OTStart = table.Column<int>(type: "int", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_OverTimeSetting", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_ShiftInput_ComId",
                table: "HR_Emp_ShiftInput",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_ShiftInput_EmpId",
                table: "HR_Emp_ShiftInput",
                column: "EmpId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_ShiftInput_LuserId",
                table: "HR_Emp_ShiftInput",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_ShiftInput_ShiftId",
                table: "HR_Emp_ShiftInput",
                column: "ShiftId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HR_Emp_ShiftInput");

            migrationBuilder.DropTable(
                name: "HR_OverTimeSetting");
        }
    }
}
