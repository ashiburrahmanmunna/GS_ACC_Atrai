using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Invoice.Migrations
{
    public partial class HrModuleadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SubSectNameB",
                table: "Cat_SubSection",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SubSectName",
                table: "Cat_SubSection",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AddColumn<string>(
                name: "PcName",
                table: "Cat_SubSection",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SectNameB",
                table: "Cat_Section",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SectName",
                table: "Cat_Section",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "DesigNameB",
                table: "Cat_Designation",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DesigName",
                table: "Cat_Designation",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AddColumn<decimal>(
                name: "AttBonus",
                table: "Cat_Designation",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtInput",
                table: "Cat_Designation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                table: "Cat_Designation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Gsmin",
                table: "Cat_Designation",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PcName",
                table: "Cat_Designation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProposedManPower",
                table: "Cat_Designation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SalaryRange",
                table: "Cat_Designation",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SlNo",
                table: "Cat_Designation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TtlManpower",
                table: "Cat_Designation",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeptName",
                table: "Cat_Department",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "DeptBangla",
                table: "Cat_Department",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PcName",
                table: "Cat_Department",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cat_Grade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    GradeNameB = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    MinGS = table.Column<double>(type: "float", nullable: true),
                    TtlManpower = table.Column<int>(type: "int", nullable: true),
                    SalaryRange = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    TtlManPowerWorker = table.Column<int>(type: "int", nullable: true),
                    SlNo = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_Cat_Grade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cat_Grade_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cat_Grade_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Designation_GradeId",
                table: "Cat_Designation",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Grade_ComId",
                table: "Cat_Grade",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Grade_LuserId",
                table: "Cat_Grade",
                column: "LuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cat_Designation_Cat_Grade_GradeId",
                table: "Cat_Designation",
                column: "GradeId",
                principalTable: "Cat_Grade",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cat_Designation_Cat_Grade_GradeId",
                table: "Cat_Designation");

            migrationBuilder.DropTable(
                name: "Cat_Grade");

            migrationBuilder.DropIndex(
                name: "IX_Cat_Designation_GradeId",
                table: "Cat_Designation");

            migrationBuilder.DropColumn(
                name: "PcName",
                table: "Cat_SubSection");

            migrationBuilder.DropColumn(
                name: "AttBonus",
                table: "Cat_Designation");

            migrationBuilder.DropColumn(
                name: "DtInput",
                table: "Cat_Designation");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "Cat_Designation");

            migrationBuilder.DropColumn(
                name: "Gsmin",
                table: "Cat_Designation");

            migrationBuilder.DropColumn(
                name: "PcName",
                table: "Cat_Designation");

            migrationBuilder.DropColumn(
                name: "ProposedManPower",
                table: "Cat_Designation");

            migrationBuilder.DropColumn(
                name: "SalaryRange",
                table: "Cat_Designation");

            migrationBuilder.DropColumn(
                name: "SlNo",
                table: "Cat_Designation");

            migrationBuilder.DropColumn(
                name: "TtlManpower",
                table: "Cat_Designation");

            migrationBuilder.DropColumn(
                name: "PcName",
                table: "Cat_Department");

            migrationBuilder.AlterColumn<string>(
                name: "SubSectNameB",
                table: "Cat_SubSection",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SubSectName",
                table: "Cat_SubSection",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "SectNameB",
                table: "Cat_Section",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SectName",
                table: "Cat_Section",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "DesigNameB",
                table: "Cat_Designation",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DesigName",
                table: "Cat_Designation",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "DeptName",
                table: "Cat_Department",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "DeptBangla",
                table: "Cat_Department",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
