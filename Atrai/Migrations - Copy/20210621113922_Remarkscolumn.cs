using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class Remarkscolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApprovalRemarks",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CheckedRemarks",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecommendedRemarks",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovalRemarks",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "CheckedRemarks",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "RecommendedRemarks",
                table: "Member");
        }
    }
}
