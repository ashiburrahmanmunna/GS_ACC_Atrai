using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class businessaddrsssbangla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BusinessAddress",
                table: "Member",
                newName: "BusinessAddressEng");

            migrationBuilder.AddColumn<string>(
                name: "BusinessAddressBng",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MemberBarcodeId",
                table: "Member",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessAddressBng",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "MemberBarcodeId",
                table: "Member");

            migrationBuilder.RenameColumn(
                name: "BusinessAddressEng",
                table: "Member",
                newName: "BusinessAddress");
        }
    }
}
