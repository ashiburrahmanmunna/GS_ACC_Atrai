using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Invoice.Migrations
{
    public partial class rawdataapps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PcName",
                table: "Cat_Shift");

            migrationBuilder.AddColumn<string>(
                name: "ShiftType",
                table: "HR_ProcessedData",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HR_AttFixed",
                columns: table => new
                {
                    AttId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    DtPunchDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    TimeIn = table.Column<TimeSpan>(type: "time", nullable: false),
                    TimeOut = table.Column<TimeSpan>(type: "time", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OTHour = table.Column<float>(type: "real", nullable: false),
                    OTHourInTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    OT = table.Column<float>(type: "real", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsInactive = table.Column<bool>(type: "bit", nullable: false),
                    TimeInPrev = table.Column<TimeSpan>(type: "time", nullable: false),
                    TimeOutPrev = table.Column<TimeSpan>(type: "time", nullable: false),
                    StatusPrev = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OTHourPrev = table.Column<float>(type: "real", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    DtTran = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_AttFixed", x => x.AttId);
                    table.ForeignKey(
                        name: "FK_HR_AttFixed_Employee_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HR_Emp_Released",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    DtReleased = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    RelType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    DtPresentLast = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtSubmit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Emp_Released", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Released_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Released_Employee_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Released_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HR_RawData_App",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CardNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    FPId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EmpId = table.Column<int>(type: "int", nullable: true),
                    dtPunchDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    dtPunchTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StNo = table.Column<int>(type: "int", nullable: true),
                    InOut = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OvNMark = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsNew = table.Column<byte>(type: "tinyint", nullable: true),
                    wId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    PCName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    LUserId = table.Column<int>(type: "int", nullable: true),
                    DeviceType = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    QRData = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Imei = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LocationName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PicBack = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PicFront = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeModelId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_RawData_App", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HR_RawData_App_Employee_EmployeeModelId",
                        column: x => x.EmployeeModelId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HR_AttFixed_EmpId",
                table: "HR_AttFixed",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Released_ComId",
                table: "HR_Emp_Released",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Released_EmpId",
                table: "HR_Emp_Released",
                column: "EmpId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Released_LuserId",
                table: "HR_Emp_Released",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_RawData_App_EmployeeModelId",
                table: "HR_RawData_App",
                column: "EmployeeModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HR_AttFixed");

            migrationBuilder.DropTable(
                name: "HR_Emp_Released");

            migrationBuilder.DropTable(
                name: "HR_RawData_App");

            migrationBuilder.DropColumn(
                name: "ShiftType",
                table: "HR_ProcessedData");

            migrationBuilder.AddColumn<string>(
                name: "PcName",
                table: "Cat_Shift",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
