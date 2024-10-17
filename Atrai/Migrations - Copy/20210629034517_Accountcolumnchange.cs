using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class Accountcolumnchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "AccountHead",
                newName: "AccType");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AccountHead",
                newName: "AccName");

            migrationBuilder.AddColumn<string>(
                name: "AccCode",
                table: "AccountHead",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccCode",
                table: "AccountHead");

            migrationBuilder.RenameColumn(
                name: "AccType",
                table: "AccountHead",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "AccName",
                table: "AccountHead",
                newName: "Name");
        }
    }
}
