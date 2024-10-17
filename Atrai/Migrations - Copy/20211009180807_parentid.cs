using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class parentid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustParentId",
                table: "Customer",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustType",
                table: "Customer",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryParentId",
                table: "Category",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CustParentId",
                table: "Customer",
                column: "CustParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_CategoryParentId",
                table: "Category",
                column: "CategoryParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Category_CategoryParentId",
                table: "Category",
                column: "CategoryParentId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Customer_CustParentId",
                table: "Customer",
                column: "CustParentId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Category_CategoryParentId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Customer_CustParentId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_CustParentId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Category_CategoryParentId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "CustParentId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "CustType",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "CategoryParentId",
                table: "Category");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
