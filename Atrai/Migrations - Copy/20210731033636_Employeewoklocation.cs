using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class Employeewoklocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WrokLocation",
                table: "Employee",
                newName: "WorkLocation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WorkLocation",
                table: "Employee",
                newName: "WrokLocation");
        }
    }
}
