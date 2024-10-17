using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class warrentyclaimupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PrimaryAddress",
                table: "WarrentyItems",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "WarrentyItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WarrentyItems_SupplierId",
                table: "WarrentyItems",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_WarrentyItems_Supplier_SupplierId",
                table: "WarrentyItems",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WarrentyItems_Supplier_SupplierId",
                table: "WarrentyItems");

            migrationBuilder.DropIndex(
                name: "IX_WarrentyItems_SupplierId",
                table: "WarrentyItems");

            migrationBuilder.DropColumn(
                name: "PrimaryAddress",
                table: "WarrentyItems");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "WarrentyItems");
        }
    }
}
