using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class Employee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBaseUser",
                table: "UserAccount",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FathersName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PresentAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermanentAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyMobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyContactRelationship = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntroducerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntroducerContctNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntroducerAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<float>(type: "real", nullable: false),
                    WrokLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsExistImage = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropColumn(
                name: "IsBaseUser",
                table: "UserAccount");
        }
    }
}
