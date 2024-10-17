using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class hrvriablefrommunna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Cat_Emp_Type_EmpTypeId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "Salary",
                table: "Employee",
                newName: "ProductionRate");

            migrationBuilder.RenameColumn(
                name: "EmpTypeId",
                table: "Employee",
                newName: "EmployeeTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_EmpTypeId",
                table: "Employee",
                newName: "IX_Employee_EmployeeTypeId");

            migrationBuilder.AlterColumn<string>(
                name: "WorkLocation",
                table: "Employee",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PresentAddress",
                table: "Employee",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PositionTitle",
                table: "Employee",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PermanentAddress",
                table: "Employee",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NID",
                table: "Employee",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MobileNo",
                table: "Employee",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IntroducerName",
                table: "Employee",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IntroducerContctNo",
                table: "Employee",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IntroducerAddress",
                table: "Employee",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FathersName",
                table: "Employee",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeName",
                table: "Employee",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeCode",
                table: "Employee",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EmergencyMobileNo",
                table: "Employee",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmergencyContactRelationship",
                table: "Employee",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmergencyContactName",
                table: "Employee",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Basic",
                table: "Employee",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtPF",
                table: "Employee",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtReleased",
                table: "Employee",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "EmpAdvanceBalance",
                table: "Employee",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "EmpLoanBalance",
                table: "Employee",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "GrossSalary",
                table: "Employee",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "HR",
                table: "Employee",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "HoursRate",
                table: "Employee",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "MA",
                table: "Employee",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "OthersAllowance",
                table: "Employee",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "SLNo",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Cat_EmployeeType_EmployeeTypeId",
                table: "Employee",
                column: "EmployeeTypeId",
                principalTable: "Cat_EmployeeType",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Cat_EmployeeType_EmployeeTypeId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Basic",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DtPF",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DtReleased",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmpAdvanceBalance",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmpLoanBalance",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "GrossSalary",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "HR",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "HoursRate",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "MA",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "OthersAllowance",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "SLNo",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "ProductionRate",
                table: "Employee",
                newName: "Salary");

            migrationBuilder.RenameColumn(
                name: "EmployeeTypeId",
                table: "Employee",
                newName: "EmpTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_EmployeeTypeId",
                table: "Employee",
                newName: "IX_Employee_EmpTypeId");

            migrationBuilder.AlterColumn<string>(
                name: "WorkLocation",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PresentAddress",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PositionTitle",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PermanentAddress",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NID",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MobileNo",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IntroducerName",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IntroducerContctNo",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IntroducerAddress",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FathersName",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeName",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeCode",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "EmergencyMobileNo",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmergencyContactRelationship",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmergencyContactName",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Cat_Emp_Type_EmpTypeId",
                table: "Employee",
                column: "EmpTypeId",
                principalTable: "Cat_Emp_Type",
                principalColumn: "Id");
        }
    }
}
