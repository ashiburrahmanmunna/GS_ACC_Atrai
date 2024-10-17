using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Invoice.Migrations
{
    public partial class rawandprocesseddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HR_Emp_Released");

            migrationBuilder.AlterColumn<int>(
                name: "LinkUserId",
                table: "Employee",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "HR_ProcessedData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    EmpCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    DtPunchDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    DeptId = table.Column<int>(type: "int", nullable: false),
                    SectId = table.Column<int>(type: "int", nullable: false),
                    TimeIn = table.Column<TimeSpan>(type: "time", nullable: false),
                    TimeOut = table.Column<TimeSpan>(type: "time", nullable: false),
                    Late = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    RegHour = table.Column<float>(type: "real", nullable: false),
                    OTHour = table.Column<float>(type: "real", nullable: false),
                    OT = table.Column<float>(type: "real", nullable: true),
                    OTHourDed = table.Column<float>(type: "real", nullable: false),
                    ROT = table.Column<float>(type: "real", nullable: false),
                    EOT = table.Column<float>(type: "real", nullable: false),
                    StaffOT = table.Column<float>(type: "real", nullable: false),
                    IsLunchDay = table.Column<float>(type: "real", nullable: false),
                    IsNightShift = table.Column<float>(type: "real", nullable: false),
                    ShiftIn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AdJusted = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmployeeModelId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_ProcessedData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HR_ProcessedData_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HR_ProcessedData_Employee_EmployeeModelId",
                        column: x => x.EmployeeModelId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_ProcessedData_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hr_RawData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CardNo = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    FPId = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    EmpId = table.Column<int>(type: "int", nullable: true),
                    DtPunchDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtPunchTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StNo = table.Column<int>(type: "int", nullable: true),
                    InOut = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    OvNMark = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    IsNew = table.Column<int>(type: "int", nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    QRData = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Imei = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LocationName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PicFront = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PicBack = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hr_RawData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hr_RawData_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hr_RawData_Employee_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hr_RawData_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HR_ProcessedData_ComId",
                table: "HR_ProcessedData",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_ProcessedData_EmployeeModelId",
                table: "HR_ProcessedData",
                column: "EmployeeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_ProcessedData_LuserId",
                table: "HR_ProcessedData",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_RawData_ComId",
                table: "Hr_RawData",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_RawData_EmpId",
                table: "Hr_RawData",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_RawData_LuserId",
                table: "Hr_RawData",
                column: "LuserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HR_ProcessedData");

            migrationBuilder.DropTable(
                name: "Hr_RawData");

            migrationBuilder.AlterColumn<string>(
                name: "LinkUserId",
                table: "Employee",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "HR_Emp_Released",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtPresentLast = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtReleased = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtSubmit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true),
                    RelType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Emp_Released", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Released_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                });

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
        }
    }
}
