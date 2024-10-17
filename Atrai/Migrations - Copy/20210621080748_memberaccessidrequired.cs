using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class memberaccessidrequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemberFileExtension",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "MemberImage",
                table: "Member");

            migrationBuilder.AddColumn<bool>(
                name: "IsExistImage",
                table: "Member",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsExistImage",
                table: "Member");

            migrationBuilder.AddColumn<string>(
                name: "MemberFileExtension",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "MemberImage",
                table: "Member",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
