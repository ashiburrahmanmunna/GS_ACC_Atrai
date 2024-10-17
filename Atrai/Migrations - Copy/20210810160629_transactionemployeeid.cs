using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class transactionemployeeid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "AccountsDailyTransaction",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountsDailyTransaction_EmployeeId",
                table: "AccountsDailyTransaction",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_Employee_EmployeeId",
                table: "AccountsDailyTransaction",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_Employee_EmployeeId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropIndex(
                name: "IX_AccountsDailyTransaction_EmployeeId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "AccountsDailyTransaction");
        }
    }
}
