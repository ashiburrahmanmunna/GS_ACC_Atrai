using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class employeeattendance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePathBack",
                table: "EmployeeAttendance",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePathFront",
                table: "EmployeeAttendance",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePathBack",
                table: "EmployeeAttendance");

            migrationBuilder.DropColumn(
                name: "ImagePathFront",
                table: "EmployeeAttendance");
        }
    }
}
