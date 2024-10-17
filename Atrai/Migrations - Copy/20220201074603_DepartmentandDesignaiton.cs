using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Invoice.Migrations
{
    public partial class DepartmentandDesignaiton : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Designation",
                table: "Employee");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Designationid",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AccCode",
                table: "AccountHead",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Cat_Designation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesigName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    DesigNameB = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Designation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cat_Designation_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cat_Designation_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employee",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Designationid",
                table: "Employee",
                column: "Designationid");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Designation_ComId",
                table: "Cat_Designation",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Designation_LuserId",
                table: "Cat_Designation",
                column: "LuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Cat_Department_DepartmentId",
                table: "Employee",
                column: "DepartmentId",
                principalTable: "Cat_Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Cat_Designation_Designationid",
                table: "Employee",
                column: "Designationid",
                principalTable: "Cat_Designation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Cat_Department_DepartmentId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Cat_Designation_Designationid",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "Cat_Designation");

            migrationBuilder.DropIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_Designationid",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Designationid",
                table: "Employee");

            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AccCode",
                table: "AccountHead",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
