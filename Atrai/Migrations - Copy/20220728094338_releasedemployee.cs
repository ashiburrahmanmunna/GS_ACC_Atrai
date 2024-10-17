using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Invoice.Migrations
{
    public partial class releasedemployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Cat_BloodGroup_BloodId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Cat_Department_DeptId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Cat_Designation_DesigId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Cat_Religion_RelgionId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Cat_Section_SectId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Cat_Shift_ShiftId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Cat_Unit_UnitId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "BloodGroup",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmpCode",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmpName",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "JoiningDate",
                table: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "Employee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Employee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SectId",
                table: "Employee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RelgionId",
                table: "Employee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DesigId",
                table: "Employee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DeptId",
                table: "Employee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BloodId",
                table: "Employee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Cat_BloodGroup_BloodId",
                table: "Employee",
                column: "BloodId",
                principalTable: "Cat_BloodGroup",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Cat_Department_DeptId",
                table: "Employee",
                column: "DeptId",
                principalTable: "Cat_Department",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Cat_Designation_DesigId",
                table: "Employee",
                column: "DesigId",
                principalTable: "Cat_Designation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Cat_Religion_RelgionId",
                table: "Employee",
                column: "RelgionId",
                principalTable: "Cat_Religion",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Cat_Section_SectId",
                table: "Employee",
                column: "SectId",
                principalTable: "Cat_Section",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Cat_Shift_ShiftId",
                table: "Employee",
                column: "ShiftId",
                principalTable: "Cat_Shift",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Cat_Unit_UnitId",
                table: "Employee",
                column: "UnitId",
                principalTable: "Cat_Unit",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Cat_BloodGroup_BloodId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Cat_Department_DeptId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Cat_Designation_DesigId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Cat_Religion_RelgionId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Cat_Section_SectId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Cat_Shift_ShiftId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Cat_Unit_UnitId",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "HR_Emp_Released");

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SectId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RelgionId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DesigId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeptId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BloodId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BloodGroup",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "Employee",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EmpCode",
                table: "Employee",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpName",
                table: "Employee",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "JoiningDate",
                table: "Employee",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Cat_BloodGroup_BloodId",
                table: "Employee",
                column: "BloodId",
                principalTable: "Cat_BloodGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Cat_Department_DeptId",
                table: "Employee",
                column: "DeptId",
                principalTable: "Cat_Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Cat_Designation_DesigId",
                table: "Employee",
                column: "DesigId",
                principalTable: "Cat_Designation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Cat_Religion_RelgionId",
                table: "Employee",
                column: "RelgionId",
                principalTable: "Cat_Religion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Cat_Section_SectId",
                table: "Employee",
                column: "SectId",
                principalTable: "Cat_Section",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Cat_Shift_ShiftId",
                table: "Employee",
                column: "ShiftId",
                principalTable: "Cat_Shift",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Cat_Unit_UnitId",
                table: "Employee",
                column: "UnitId",
                principalTable: "Cat_Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
