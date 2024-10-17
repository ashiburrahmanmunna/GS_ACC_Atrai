using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class employeelinkwithuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "UserAccount",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_EmployeeId",
                table: "UserAccount",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccount_Employee_EmployeeId",
                table: "UserAccount",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccount_Employee_EmployeeId",
                table: "UserAccount");

            migrationBuilder.DropIndex(
                name: "IX_UserAccount_EmployeeId",
                table: "UserAccount");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "UserAccount");
        }
    }
}
