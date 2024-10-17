using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSalesReturnVoucher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "IndDiscountProportionRtn",
                table: "SalesReturnItems",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApprovalStatus",
                table: "Acc_VoucherMain",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IndDiscountProportionRtn",
                table: "SalesReturnItems");

            migrationBuilder.DropColumn(
                name: "ApprovalStatus",
                table: "Acc_VoucherMain");
        }
    }
}
