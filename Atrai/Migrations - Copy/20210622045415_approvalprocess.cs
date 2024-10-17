using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class approvalprocess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isRecommended",
                table: "Member",
                newName: "isVerified");

            migrationBuilder.RenameColumn(
                name: "RecommendedRemarks",
                table: "Member",
                newName: "VerifiedRemarks");

            migrationBuilder.AddColumn<string>(
                name: "AppliedRemarks",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CanceledRemarks",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApplied",
                table: "Member",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isCanceled",
                table: "Member",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppliedRemarks",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "CanceledRemarks",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "IsApplied",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "isCanceled",
                table: "Member");

            migrationBuilder.RenameColumn(
                name: "isVerified",
                table: "Member",
                newName: "isRecommended");

            migrationBuilder.RenameColumn(
                name: "VerifiedRemarks",
                table: "Member",
                newName: "RecommendedRemarks");
        }
    }
}
