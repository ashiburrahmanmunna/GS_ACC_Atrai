using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Invoice.Migrations
{
    public partial class hremployeecheck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BloodId",
                table: "Employee",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeptId",
                table: "Employee",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DesigId",
                table: "Employee",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtBirth",
                table: "Employee",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtConfirm",
                table: "Employee",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtIncrement",
                table: "Employee",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtJoin",
                table: "Employee",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtLocalJoin",
                table: "Employee",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtPromotion",
                table: "Employee",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpCode",
                table: "Employee",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpEmail",
                table: "Employee",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpName",
                table: "Employee",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmpNameB",
                table: "Employee",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpPerZip",
                table: "Employee",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpPhone1",
                table: "Employee",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpPhone2",
                table: "Employee",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpRemarks",
                table: "Employee",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmpTypeId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FingerId",
                table: "Employee",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FloorId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAllowOT",
                table: "Employee",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCasual",
                table: "Employee",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirm",
                table: "Employee",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsInactive",
                table: "Employee",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsIncentiveBns",
                table: "Employee",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LineId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkUserId",
                table: "Employee",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ManageType",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RelgionId",
                table: "Employee",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SectId",
                table: "Employee",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShiftId",
                table: "Employee",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SkillId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubSectId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "Employee",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cat_AccountType",
                columns: table => new
                {
                    AccTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccTypeName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_AccountType", x => x.AccTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Cat_Bank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    BankShortName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    BankAddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Bank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cat_Bank_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Cat_Bank_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Cat_BankBranch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    BranchAddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_BankBranch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cat_BankBranch_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Cat_BankBranch_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Cat_BloodGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    BloodNameB = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PcName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtInput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_BloodGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cat_BloodGroup_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Cat_BloodGroup_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Cat_BuildingType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    BuildingShortName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    BuildingNameB = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PcName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    DtInput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_BuildingType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cat_BuildingType_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Cat_BuildingType_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Cat_District",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    DistNameB = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    DistNameShort = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    SL = table.Column<int>(type: "int", nullable: true),
                    PcName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DtInput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_District", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cat_District_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Cat_District_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Cat_Emp_Type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpTypeName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    EmpTypeNameB = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    TtlManpower = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Emp_Type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cat_Floor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FloorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FloorNameB = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PcName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtInput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Floor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cat_Floor_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Cat_Floor_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Cat_Gender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    GenderNameB = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cat_Leave_Type",
                columns: table => new
                {
                    LTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LTypeName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LTypeNameShort = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    LDays = table.Column<float>(type: "real", nullable: true),
                    ComId = table.Column<int>(type: "int", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Leave_Type", x => x.LTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Cat_Line",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LineName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LineNameB = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PcName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtInput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Line", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cat_Line_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Cat_Line_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Cat_PayMode",
                columns: table => new
                {
                    PayModeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayModeName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_PayMode", x => x.PayModeId);
                });

            migrationBuilder.CreateTable(
                name: "Cat_Religion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReligionName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ReligionNameB = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PcName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtInput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Religion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cat_Religion_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Cat_Religion_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Cat_Shift",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ShiftCode = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ShiftDesc = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ShiftIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShiftOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShiftLate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LunchTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LunchIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LunchOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TiffinTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TiffinIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TiffinOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegHour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShiftType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShiftCat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsInactive = table.Column<bool>(type: "bit", nullable: false),
                    TiffinTime1 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TiffinTimeIn1 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TiffinTime2 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TiffinTimeIn2 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PcName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtInput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Shift", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cat_Shift_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Cat_Shift_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Cat_Skill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    SkillNameB = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Skill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cat_Skill_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Cat_Skill_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Cat_Unit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UnitShortName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UnitNameB = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PcName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtInput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Unit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cat_Unit_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Cat_Unit_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HR_Emp_Education",
                columns: table => new
                {
                    EmpEduId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    ExamName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ExamResult = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MajorSub = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    InstituteName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    BoardName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PassingYear = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ComId = table.Column<int>(type: "int", maxLength: 128, nullable: false),
                    PcName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LuserId = table.Column<int>(type: "int", maxLength: 128, nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Certificate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Emp_Education", x => x.EmpEduId);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Education_Employee_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HR_Emp_Experience",
                columns: table => new
                {
                    EmpExpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    PrevCompany = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PrevDesignation = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PrevSalary = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DtFromJob = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtToJob = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpYear = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    PcName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Emp_Experience", x => x.EmpExpId);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Experience_Employee_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HR_Emp_Family",
                columns: table => new
                {
                    EmpFamilyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    EmpFather = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    EmpFatherB = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    EmpFatherNID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    EmpFatherMobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EmpMother = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    EmpMotherB = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    EmpMotherNID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    EmpMotherMobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EmpSpouse = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    EmpSpouseB = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    EmpSpouseNID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    EmpSpouseMobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EmpChildName1 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    EmpChildDOB1 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmpChildEdu1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EmpChildBirthCer1 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    EmpChildName2 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    EmpChildDOB2 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmpChildEdu2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EmpChildBirthCer2 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    EmpChildName3 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    EmpChildDOB3 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmpChildEdu3 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EmpChildBirthCer3 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    EmpChildName4 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    EmpChildDOB4 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmpChildEdu4 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EmpChildBirthCer4 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ComId = table.Column<int>(type: "int", maxLength: 80, nullable: false),
                    PcName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LuserId = table.Column<int>(type: "int", maxLength: 80, nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Emp_Family", x => x.EmpFamilyId);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Family_Employee_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HR_Emp_Image",
                columns: table => new
                {
                    EmpImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    EmpImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EmpImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpImageExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpSign = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EmpSignPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpSignExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComId = table.Column<int>(type: "int", maxLength: 80, nullable: false),
                    PcName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    LuserId = table.Column<int>(type: "int", maxLength: 80, nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Emp_Image", x => x.EmpImageId);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Image_Employee_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HR_Emp_Nominee",
                columns: table => new
                {
                    EmpNomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    EmpNomineeName1 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    EmpNomineeDOB1 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmpNomineeJobType1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmpNomineeMobile1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EmpNomineeNID1 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    EmpNomineeRelation1 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    EmpNomineePercentage1 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    EmpNomineeAddress1 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    EmpNomineeName2 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    EmpNomineeDOB2 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmpNomineeJobType2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmpNomineeMobile2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EmpNomineeNID2 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    EmpNomineeRelation2 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    EmpNomineePercentage2 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    EmpNomineeAddress2 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    PcName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Emp_Nominee", x => x.EmpNomId);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Nominee_Employee_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HR_IncType",
                columns: table => new
                {
                    IncTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    IncType = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    DtTran = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_IncType", x => x.IncTypeId);
                });

            migrationBuilder.CreateTable(
                name: "HR_Leave_Balance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    DtOpeningBalance = table.Column<int>(type: "int", nullable: false),
                    CL = table.Column<float>(type: "real", nullable: false),
                    ACL = table.Column<float>(type: "real", nullable: true),
                    SL = table.Column<float>(type: "real", nullable: false),
                    ASL = table.Column<float>(type: "real", nullable: true),
                    EL = table.Column<float>(type: "real", nullable: false),
                    AEL = table.Column<float>(type: "real", nullable: true),
                    ML = table.Column<float>(type: "real", nullable: true),
                    AML = table.Column<float>(type: "real", nullable: true),
                    LWP = table.Column<float>(type: "real", nullable: true),
                    ALWP = table.Column<float>(type: "real", nullable: true),
                    ACCL = table.Column<float>(type: "real", nullable: true),
                    AACCL = table.Column<float>(type: "real", nullable: true),
                    SPL = table.Column<float>(type: "real", nullable: true),
                    ASPL = table.Column<float>(type: "real", nullable: true),
                    TL = table.Column<float>(type: "real", nullable: true),
                    ATL = table.Column<float>(type: "real", nullable: true),
                    BL = table.Column<float>(type: "real", nullable: true),
                    ABL = table.Column<float>(type: "real", nullable: true),
                    IsELPaid = table.Column<bool>(type: "bit", nullable: false),
                    DtInput = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Leave_Balance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HR_Leave_Balance_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HR_Leave_Balance_Employee_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HR_Leave_Balance_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HR_Emp_PersonalInfo",
                columns: table => new
                {
                    EmpPersInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    PassportNo = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    BirthCertificate = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    TINNo = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    MaritalStatus = table.Column<bool>(type: "bit", nullable: false),
                    ChildNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Caste = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IdentificationSign = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<float>(type: "real", nullable: true),
                    IsUsingHouse = table.Column<bool>(type: "bit", nullable: false),
                    BId = table.Column<int>(type: "int", nullable: true),
                    EmpFileNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MedicalBookNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    EmergencyContactName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    EmergencyContactNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    RelationEmerContact = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    EmployeeCodeBCIC = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Grade = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PoliceVerificationStatus = table.Column<bool>(type: "bit", nullable: false),
                    PFFileNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IsAllowPF = table.Column<bool>(type: "bit", nullable: false),
                    DtPF = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPFFinal = table.Column<bool>(type: "bit", nullable: false),
                    PFFinalYId = table.Column<int>(type: "int", nullable: true),
                    IsPFFundTransfer = table.Column<bool>(type: "bit", nullable: false),
                    PFFundTransferYId = table.Column<int>(type: "int", nullable: true),
                    IsWFFinal = table.Column<bool>(type: "bit", nullable: false),
                    WFFinalYId = table.Column<int>(type: "int", nullable: true),
                    IsWFFundTransfer = table.Column<bool>(type: "bit", nullable: false),
                    WFFundTransferYId = table.Column<int>(type: "int", nullable: true),
                    IsGratuityFinal = table.Column<bool>(type: "bit", nullable: false),
                    GratuityFinalYId = table.Column<int>(type: "int", nullable: true),
                    IsGratuityFundTransfer = table.Column<bool>(type: "bit", nullable: false),
                    GratuityFundTransferYId = table.Column<int>(type: "int", nullable: true),
                    ComId = table.Column<int>(type: "int", maxLength: 80, nullable: false),
                    PcName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    LuserId = table.Column<int>(type: "int", maxLength: 80, nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WeekDay = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Emp_PersonalInfo", x => x.EmpPersInfoId);
                    table.ForeignKey(
                        name: "FK_HR_Emp_PersonalInfo_Acc_FiscalYear_GratuityFinalYId",
                        column: x => x.GratuityFinalYId,
                        principalTable: "Acc_FiscalYear",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_PersonalInfo_Acc_FiscalYear_GratuityFundTransferYId",
                        column: x => x.GratuityFundTransferYId,
                        principalTable: "Acc_FiscalYear",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_PersonalInfo_Acc_FiscalYear_PFFinalYId",
                        column: x => x.PFFinalYId,
                        principalTable: "Acc_FiscalYear",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_PersonalInfo_Acc_FiscalYear_PFFundTransferYId",
                        column: x => x.PFFundTransferYId,
                        principalTable: "Acc_FiscalYear",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_PersonalInfo_Acc_FiscalYear_WFFinalYId",
                        column: x => x.WFFinalYId,
                        principalTable: "Acc_FiscalYear",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_PersonalInfo_Acc_FiscalYear_WFFundTransferYId",
                        column: x => x.WFFundTransferYId,
                        principalTable: "Acc_FiscalYear",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_PersonalInfo_Cat_BuildingType_BId",
                        column: x => x.BId,
                        principalTable: "Cat_BuildingType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_PersonalInfo_Employee_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cat_PoliceStation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PStationName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PStationNameB = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DistId = table.Column<int>(type: "int", nullable: false),
                    PcName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtInput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_PoliceStation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cat_PoliceStation_Cat_District_DistId",
                        column: x => x.DistId,
                        principalTable: "Cat_District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cat_PoliceStation_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Cat_PoliceStation_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HR_Leave_Avail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    LTypeId = table.Column<int>(type: "int", nullable: false),
                    DtLvInput = table.Column<DateTime>(type: "date", nullable: false),
                    DtFrom = table.Column<DateTime>(type: "date", nullable: false),
                    DtTo = table.Column<DateTime>(type: "date", nullable: false),
                    InputType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalDay = table.Column<float>(type: "real", nullable: true),
                    LvType = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    LvApp = table.Column<float>(type: "real", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Leave_Avail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HR_Leave_Avail_Cat_Leave_Type_LTypeId",
                        column: x => x.LTypeId,
                        principalTable: "Cat_Leave_Type",
                        principalColumn: "LTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HR_Leave_Avail_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HR_Leave_Avail_Employee_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HR_Leave_Avail_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HR_Emp_BankInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    PayModeId = table.Column<int>(type: "int", nullable: true),
                    AccTypeId = table.Column<int>(type: "int", nullable: true),
                    BankId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    RoutingNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    AccountNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Emp_BankInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HR_Emp_BankInfo_Cat_AccountType_AccTypeId",
                        column: x => x.AccTypeId,
                        principalTable: "Cat_AccountType",
                        principalColumn: "AccTypeId");
                    table.ForeignKey(
                        name: "FK_HR_Emp_BankInfo_Cat_Bank_BankId",
                        column: x => x.BankId,
                        principalTable: "Cat_Bank",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_BankInfo_Cat_BankBranch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Cat_BankBranch",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_BankInfo_Cat_PayMode_PayModeId",
                        column: x => x.PayModeId,
                        principalTable: "Cat_PayMode",
                        principalColumn: "PayModeId");
                    table.ForeignKey(
                        name: "FK_HR_Emp_BankInfo_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HR_Emp_BankInfo_Employee_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HR_Emp_BankInfo_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HR_Emp_Increment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(type: "int", nullable: true),
                    DtIncrement = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtPromotion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    Percentage = table.Column<float>(type: "real", nullable: true),
                    OldSalary = table.Column<double>(type: "float", nullable: true),
                    NewSalary = table.Column<double>(type: "float", nullable: true),
                    OldBS = table.Column<double>(type: "float", nullable: true),
                    NewBS = table.Column<double>(type: "float", nullable: true),
                    NewHR = table.Column<double>(type: "float", nullable: true),
                    OldHR = table.Column<double>(type: "float", nullable: true),
                    NewHRExp = table.Column<double>(type: "float", nullable: true),
                    OldHRExp = table.Column<double>(type: "float", nullable: true),
                    NewHRExpOther = table.Column<double>(type: "float", nullable: true),
                    OldHRExpOther = table.Column<double>(type: "float", nullable: true),
                    OldMA = table.Column<double>(type: "float", nullable: true),
                    NewMA = table.Column<double>(type: "float", nullable: true),
                    NewTA = table.Column<double>(type: "float", nullable: true),
                    OldTA = table.Column<double>(type: "float", nullable: true),
                    NewFA = table.Column<double>(type: "float", nullable: true),
                    OldFA = table.Column<double>(type: "float", nullable: true),
                    OldPA = table.Column<double>(type: "float", nullable: true),
                    NewPA = table.Column<double>(type: "float", nullable: true),
                    OldDA = table.Column<double>(type: "float", nullable: true),
                    NewDA = table.Column<double>(type: "float", nullable: true),
                    BSDiff = table.Column<float>(type: "real", nullable: true),
                    HRDiff = table.Column<float>(type: "real", nullable: true),
                    HRExpDiff = table.Column<float>(type: "real", nullable: true),
                    HRExpOtherDiff = table.Column<float>(type: "real", nullable: true),
                    MADiff = table.Column<float>(type: "real", nullable: true),
                    OldUnitId = table.Column<int>(type: "int", nullable: true),
                    NewUnitId = table.Column<int>(type: "int", nullable: true),
                    OldDeptId = table.Column<int>(type: "int", nullable: true),
                    NewDeptId = table.Column<int>(type: "int", nullable: true),
                    OldSectId = table.Column<int>(type: "int", nullable: true),
                    NewSectId = table.Column<int>(type: "int", nullable: true),
                    OldDesigId = table.Column<int>(type: "int", nullable: true),
                    NewDesigId = table.Column<int>(type: "int", nullable: true),
                    IncTypeId = table.Column<int>(type: "int", nullable: true),
                    OldEmpTypeId = table.Column<int>(type: "int", nullable: true),
                    NewEmpTypeId = table.Column<int>(type: "int", nullable: true),
                    OldGenderId = table.Column<int>(type: "int", nullable: true),
                    NewGenderId = table.Column<int>(type: "int", nullable: true),
                    PcName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtInput = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    UserAccountListId = table.Column<int>(type: "int", nullable: true),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Emp_Increment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Increment_Cat_Department_NewDeptId",
                        column: x => x.NewDeptId,
                        principalTable: "Cat_Department",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_Increment_Cat_Department_OldDeptId",
                        column: x => x.OldDeptId,
                        principalTable: "Cat_Department",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_Increment_Cat_Designation_NewDesigId",
                        column: x => x.NewDesigId,
                        principalTable: "Cat_Designation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_Increment_Cat_Designation_OldDesigId",
                        column: x => x.OldDesigId,
                        principalTable: "Cat_Designation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_Increment_Cat_Emp_Type_NewEmpTypeId",
                        column: x => x.NewEmpTypeId,
                        principalTable: "Cat_Emp_Type",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_Increment_Cat_Emp_Type_OldEmpTypeId",
                        column: x => x.OldEmpTypeId,
                        principalTable: "Cat_Emp_Type",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_Increment_Cat_Gender_NewGenderId",
                        column: x => x.NewGenderId,
                        principalTable: "Cat_Gender",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_Increment_Cat_Gender_OldGenderId",
                        column: x => x.OldGenderId,
                        principalTable: "Cat_Gender",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_Increment_Cat_Section_NewSectId",
                        column: x => x.NewSectId,
                        principalTable: "Cat_Section",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_Increment_Cat_Section_OldSectId",
                        column: x => x.OldSectId,
                        principalTable: "Cat_Section",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_Increment_Cat_Unit_NewUnitId",
                        column: x => x.NewUnitId,
                        principalTable: "Cat_Unit",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_Increment_Cat_Unit_OldUnitId",
                        column: x => x.OldUnitId,
                        principalTable: "Cat_Unit",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_Increment_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Increment_Employee_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_Increment_HR_IncType_IncTypeId",
                        column: x => x.IncTypeId,
                        principalTable: "HR_IncType",
                        principalColumn: "IncTypeId");
                    table.ForeignKey(
                        name: "FK_HR_Emp_Increment_UserAccount_UserAccountListId",
                        column: x => x.UserAccountListId,
                        principalTable: "UserAccount",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cat_PostOffice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    POName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    POCode = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    PONameB = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    DistId = table.Column<int>(type: "int", nullable: false),
                    PStationId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_PostOffice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cat_PostOffice_Cat_District_DistId",
                        column: x => x.DistId,
                        principalTable: "Cat_District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cat_PostOffice_Cat_PoliceStation_PStationId",
                        column: x => x.PStationId,
                        principalTable: "Cat_PoliceStation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cat_PostOffice_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Cat_PostOffice_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HR_Emp_Address",
                columns: table => new
                {
                    EmpAddId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    EmpCurrCityVill = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    EmpPerCityVill = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    EmpRemarksCurr = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    EmpRemarksPer = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    EmpCurrPOId = table.Column<int>(type: "int", nullable: true),
                    EmpPerPOId = table.Column<int>(type: "int", nullable: true),
                    EmpCurrPSId = table.Column<int>(type: "int", nullable: true),
                    EmpPerPSId = table.Column<int>(type: "int", nullable: true),
                    EmpCurrDistId = table.Column<int>(type: "int", nullable: true),
                    EmpPerDistId = table.Column<int>(type: "int", nullable: true),
                    ComId = table.Column<int>(type: "int", maxLength: 80, nullable: false),
                    PcName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LuserId = table.Column<int>(type: "int", maxLength: 80, nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Emp_Address", x => x.EmpAddId);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Address_Cat_District_EmpCurrDistId",
                        column: x => x.EmpCurrDistId,
                        principalTable: "Cat_District",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_Address_Cat_District_EmpPerDistId",
                        column: x => x.EmpPerDistId,
                        principalTable: "Cat_District",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_Address_Cat_PoliceStation_EmpCurrPSId",
                        column: x => x.EmpCurrPSId,
                        principalTable: "Cat_PoliceStation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_Address_Cat_PoliceStation_EmpPerPSId",
                        column: x => x.EmpPerPSId,
                        principalTable: "Cat_PoliceStation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_Address_Cat_PostOffice_EmpCurrPOId",
                        column: x => x.EmpCurrPOId,
                        principalTable: "Cat_PostOffice",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_Address_Cat_PostOffice_EmpPerPOId",
                        column: x => x.EmpPerPOId,
                        principalTable: "Cat_PostOffice",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Emp_Address_Employee_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_BloodId",
                table: "Employee",
                column: "BloodId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DeptId",
                table: "Employee",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DesigId",
                table: "Employee",
                column: "DesigId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmpTypeId",
                table: "Employee",
                column: "EmpTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_FloorId",
                table: "Employee",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_GenderId",
                table: "Employee",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_GradeId",
                table: "Employee",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_LineId",
                table: "Employee",
                column: "LineId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_RelgionId",
                table: "Employee",
                column: "RelgionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_SectId",
                table: "Employee",
                column: "SectId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ShiftId",
                table: "Employee",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_SkillId",
                table: "Employee",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_SubSectId",
                table: "Employee",
                column: "SubSectId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_UnitId",
                table: "Employee",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Bank_ComId",
                table: "Cat_Bank",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Bank_LuserId",
                table: "Cat_Bank",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_BankBranch_ComId",
                table: "Cat_BankBranch",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_BankBranch_LuserId",
                table: "Cat_BankBranch",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_BloodGroup_ComId",
                table: "Cat_BloodGroup",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_BloodGroup_LuserId",
                table: "Cat_BloodGroup",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_BuildingType_ComId",
                table: "Cat_BuildingType",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_BuildingType_LuserId",
                table: "Cat_BuildingType",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_District_ComId",
                table: "Cat_District",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_District_LuserId",
                table: "Cat_District",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Floor_ComId",
                table: "Cat_Floor",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Floor_LuserId",
                table: "Cat_Floor",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Line_ComId",
                table: "Cat_Line",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Line_LuserId",
                table: "Cat_Line",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_PoliceStation_ComId",
                table: "Cat_PoliceStation",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_PoliceStation_DistId",
                table: "Cat_PoliceStation",
                column: "DistId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_PoliceStation_LuserId",
                table: "Cat_PoliceStation",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_PostOffice_ComId",
                table: "Cat_PostOffice",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_PostOffice_DistId",
                table: "Cat_PostOffice",
                column: "DistId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_PostOffice_LuserId",
                table: "Cat_PostOffice",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_PostOffice_PStationId",
                table: "Cat_PostOffice",
                column: "PStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Religion_ComId",
                table: "Cat_Religion",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Religion_LuserId",
                table: "Cat_Religion",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Shift_ComId",
                table: "Cat_Shift",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Shift_LuserId",
                table: "Cat_Shift",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Skill_ComId",
                table: "Cat_Skill",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Skill_LuserId",
                table: "Cat_Skill",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Unit_ComId",
                table: "Cat_Unit",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Unit_LuserId",
                table: "Cat_Unit",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Address_EmpCurrDistId",
                table: "HR_Emp_Address",
                column: "EmpCurrDistId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Address_EmpCurrPOId",
                table: "HR_Emp_Address",
                column: "EmpCurrPOId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Address_EmpCurrPSId",
                table: "HR_Emp_Address",
                column: "EmpCurrPSId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Address_EmpId",
                table: "HR_Emp_Address",
                column: "EmpId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Address_EmpPerDistId",
                table: "HR_Emp_Address",
                column: "EmpPerDistId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Address_EmpPerPOId",
                table: "HR_Emp_Address",
                column: "EmpPerPOId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Address_EmpPerPSId",
                table: "HR_Emp_Address",
                column: "EmpPerPSId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_BankInfo_AccTypeId",
                table: "HR_Emp_BankInfo",
                column: "AccTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_BankInfo_BankId",
                table: "HR_Emp_BankInfo",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_BankInfo_BranchId",
                table: "HR_Emp_BankInfo",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_BankInfo_ComId",
                table: "HR_Emp_BankInfo",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_BankInfo_EmpId",
                table: "HR_Emp_BankInfo",
                column: "EmpId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_BankInfo_LuserId",
                table: "HR_Emp_BankInfo",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_BankInfo_PayModeId",
                table: "HR_Emp_BankInfo",
                column: "PayModeId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Education_EmpId",
                table: "HR_Emp_Education",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Experience_EmpId",
                table: "HR_Emp_Experience",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Family_EmpId",
                table: "HR_Emp_Family",
                column: "EmpId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Image_EmpId",
                table: "HR_Emp_Image",
                column: "EmpId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Increment_ComId",
                table: "HR_Emp_Increment",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Increment_EmpId",
                table: "HR_Emp_Increment",
                column: "EmpId",
                unique: true,
                filter: "[EmpId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Increment_IncTypeId",
                table: "HR_Emp_Increment",
                column: "IncTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Increment_NewDeptId",
                table: "HR_Emp_Increment",
                column: "NewDeptId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Increment_NewDesigId",
                table: "HR_Emp_Increment",
                column: "NewDesigId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Increment_NewEmpTypeId",
                table: "HR_Emp_Increment",
                column: "NewEmpTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Increment_NewGenderId",
                table: "HR_Emp_Increment",
                column: "NewGenderId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Increment_NewSectId",
                table: "HR_Emp_Increment",
                column: "NewSectId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Increment_NewUnitId",
                table: "HR_Emp_Increment",
                column: "NewUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Increment_OldDeptId",
                table: "HR_Emp_Increment",
                column: "OldDeptId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Increment_OldDesigId",
                table: "HR_Emp_Increment",
                column: "OldDesigId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Increment_OldEmpTypeId",
                table: "HR_Emp_Increment",
                column: "OldEmpTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Increment_OldGenderId",
                table: "HR_Emp_Increment",
                column: "OldGenderId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Increment_OldSectId",
                table: "HR_Emp_Increment",
                column: "OldSectId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Increment_OldUnitId",
                table: "HR_Emp_Increment",
                column: "OldUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Increment_UserAccountListId",
                table: "HR_Emp_Increment",
                column: "UserAccountListId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Nominee_EmpId",
                table: "HR_Emp_Nominee",
                column: "EmpId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_PersonalInfo_BId",
                table: "HR_Emp_PersonalInfo",
                column: "BId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_PersonalInfo_EmpId",
                table: "HR_Emp_PersonalInfo",
                column: "EmpId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_PersonalInfo_GratuityFinalYId",
                table: "HR_Emp_PersonalInfo",
                column: "GratuityFinalYId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_PersonalInfo_GratuityFundTransferYId",
                table: "HR_Emp_PersonalInfo",
                column: "GratuityFundTransferYId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_PersonalInfo_PFFinalYId",
                table: "HR_Emp_PersonalInfo",
                column: "PFFinalYId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_PersonalInfo_PFFundTransferYId",
                table: "HR_Emp_PersonalInfo",
                column: "PFFundTransferYId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_PersonalInfo_WFFinalYId",
                table: "HR_Emp_PersonalInfo",
                column: "WFFinalYId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_PersonalInfo_WFFundTransferYId",
                table: "HR_Emp_PersonalInfo",
                column: "WFFundTransferYId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Leave_Avail_ComId",
                table: "HR_Leave_Avail",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Leave_Avail_EmpId",
                table: "HR_Leave_Avail",
                column: "EmpId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HR_Leave_Avail_LTypeId",
                table: "HR_Leave_Avail",
                column: "LTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Leave_Avail_LuserId",
                table: "HR_Leave_Avail",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Leave_Balance_ComId",
                table: "HR_Leave_Balance",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Leave_Balance_EmpId",
                table: "HR_Leave_Balance",
                column: "EmpId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HR_Leave_Balance_LuserId",
                table: "HR_Leave_Balance",
                column: "LuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Cat_BloodGroup_BloodId",
                table: "Employee",
                column: "BloodId",
                principalTable: "Cat_BloodGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Cat_Department_DeptId",
                table: "Employee",
                column: "DeptId",
                principalTable: "Cat_Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Cat_Designation_DesigId",
                table: "Employee",
                column: "DesigId",
                principalTable: "Cat_Designation",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Cat_Emp_Type_EmpTypeId",
                table: "Employee",
                column: "EmpTypeId",
                principalTable: "Cat_Emp_Type",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Cat_Floor_FloorId",
                table: "Employee",
                column: "FloorId",
                principalTable: "Cat_Floor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Cat_Gender_GenderId",
                table: "Employee",
                column: "GenderId",
                principalTable: "Cat_Gender",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Cat_Grade_GradeId",
                table: "Employee",
                column: "GradeId",
                principalTable: "Cat_Grade",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Cat_Line_LineId",
                table: "Employee",
                column: "LineId",
                principalTable: "Cat_Line",
                principalColumn: "Id");

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
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Cat_Shift_ShiftId",
                table: "Employee",
                column: "ShiftId",
                principalTable: "Cat_Shift",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Cat_Skill_SkillId",
                table: "Employee",
                column: "SkillId",
                principalTable: "Cat_Skill",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Cat_SubSection_SubSectId",
                table: "Employee",
                column: "SubSectId",
                principalTable: "Cat_SubSection",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Cat_Unit_UnitId",
                table: "Employee",
                column: "UnitId",
                principalTable: "Cat_Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
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
                name: "FK_Employee_Cat_Emp_Type_EmpTypeId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Cat_Floor_FloorId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Cat_Gender_GenderId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Cat_Grade_GradeId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Cat_Line_LineId",
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
                name: "FK_Employee_Cat_Skill_SkillId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Cat_SubSection_SubSectId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Cat_Unit_UnitId",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "Cat_BloodGroup");

            migrationBuilder.DropTable(
                name: "Cat_Floor");

            migrationBuilder.DropTable(
                name: "Cat_Line");

            migrationBuilder.DropTable(
                name: "Cat_Religion");

            migrationBuilder.DropTable(
                name: "Cat_Shift");

            migrationBuilder.DropTable(
                name: "Cat_Skill");

            migrationBuilder.DropTable(
                name: "HR_Emp_Address");

            migrationBuilder.DropTable(
                name: "HR_Emp_BankInfo");

            migrationBuilder.DropTable(
                name: "HR_Emp_Education");

            migrationBuilder.DropTable(
                name: "HR_Emp_Experience");

            migrationBuilder.DropTable(
                name: "HR_Emp_Family");

            migrationBuilder.DropTable(
                name: "HR_Emp_Image");

            migrationBuilder.DropTable(
                name: "HR_Emp_Increment");

            migrationBuilder.DropTable(
                name: "HR_Emp_Nominee");

            migrationBuilder.DropTable(
                name: "HR_Emp_PersonalInfo");

            migrationBuilder.DropTable(
                name: "HR_Leave_Avail");

            migrationBuilder.DropTable(
                name: "HR_Leave_Balance");

            migrationBuilder.DropTable(
                name: "Cat_PostOffice");

            migrationBuilder.DropTable(
                name: "Cat_AccountType");

            migrationBuilder.DropTable(
                name: "Cat_Bank");

            migrationBuilder.DropTable(
                name: "Cat_BankBranch");

            migrationBuilder.DropTable(
                name: "Cat_PayMode");

            migrationBuilder.DropTable(
                name: "Cat_Emp_Type");

            migrationBuilder.DropTable(
                name: "Cat_Gender");

            migrationBuilder.DropTable(
                name: "Cat_Unit");

            migrationBuilder.DropTable(
                name: "HR_IncType");

            migrationBuilder.DropTable(
                name: "Cat_BuildingType");

            migrationBuilder.DropTable(
                name: "Cat_Leave_Type");

            migrationBuilder.DropTable(
                name: "Cat_PoliceStation");

            migrationBuilder.DropTable(
                name: "Cat_District");

            migrationBuilder.DropIndex(
                name: "IX_Employee_BloodId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_DeptId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_DesigId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_EmpTypeId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_FloorId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_GenderId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_GradeId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_LineId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_RelgionId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_SectId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_ShiftId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_SkillId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_SubSectId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_UnitId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "BloodId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DeptId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DesigId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DtBirth",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DtConfirm",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DtIncrement",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DtJoin",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DtLocalJoin",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DtPromotion",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmpCode",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmpEmail",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmpName",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmpNameB",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmpPerZip",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmpPhone1",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmpPhone2",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmpRemarks",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmpTypeId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "FingerId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "FloorId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "IsAllowOT",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "IsCasual",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "IsConfirm",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "IsInactive",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "IsIncentiveBns",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "LineId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "LinkUserId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "ManageType",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "RelgionId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "SectId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "ShiftId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "SubSectId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "Employee");
        }
    }
}
