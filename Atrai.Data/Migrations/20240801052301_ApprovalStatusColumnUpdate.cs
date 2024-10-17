using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class ApprovalStatusColumnUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ApprovalStatus",
                table: "AccountsDailyTransaction",
                newName: "ApprovalStage");

            migrationBuilder.RenameColumn(
                name: "ApprovalStatus",
                table: "Acc_VoucherMain",
                newName: "ApprovalStage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ApprovalStage",
                table: "AccountsDailyTransaction",
                newName: "ApprovalStatus");

            migrationBuilder.RenameColumn(
                name: "ApprovalStage",
                table: "Acc_VoucherMain",
                newName: "ApprovalStatus");
        }
    }
}
