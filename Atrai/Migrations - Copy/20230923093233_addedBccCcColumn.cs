using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    public partial class addedBccCcColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bcc",
                table: "Purchase",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cc",
                table: "Purchase",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bcc",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "Cc",
                table: "Purchase");
        }
    }
}
