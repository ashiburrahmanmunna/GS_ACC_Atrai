using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class suppliermodelandrelatedmodelupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Supplier",
                newName: "PrimaryAddress");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Supplier",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecoundaryAddress",
                table: "Supplier",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupParentId",
                table: "Supplier",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupType",
                table: "Supplier",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_SupParentId",
                table: "Supplier",
                column: "SupParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Supplier_SupParentId",
                table: "Supplier",
                column: "SupParentId",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Supplier_SupParentId",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_SupParentId",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "SecoundaryAddress",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "SupParentId",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "SupType",
                table: "Supplier");

            migrationBuilder.RenameColumn(
                name: "PrimaryAddress",
                table: "Supplier",
                newName: "Address");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
