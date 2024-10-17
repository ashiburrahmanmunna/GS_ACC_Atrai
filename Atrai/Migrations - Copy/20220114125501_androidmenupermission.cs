using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Invoice.Migrations
{
    public partial class androidmenupermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeviceType",
                table: "ShortLinkHit",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IPAddress",
                table: "ShortLinkHit",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "ShortLinkHit",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LongString",
                table: "ShortLinkHit",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "ShortLinkHit",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Platform",
                table: "ShortLinkHit",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebBrowserName",
                table: "ShortLinkHit",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebLink",
                table: "ShortLinkHit",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AndroidMenuPermission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessTypeId = table.Column<int>(type: "int", nullable: false),
                    AndroidMenuId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AndroidMenuPermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AndroidMenuPermission_BusinessType_BusinessTypeId",
                        column: x => x.BusinessTypeId,
                        principalTable: "BusinessType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AndroidMenuPermission_Menu_AndroidMenuId",
                        column: x => x.AndroidMenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AndroidMenuPermission_AndroidMenuId",
                table: "AndroidMenuPermission",
                column: "AndroidMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_AndroidMenuPermission_BusinessTypeId",
                table: "AndroidMenuPermission",
                column: "BusinessTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AndroidMenuPermission");

            migrationBuilder.DropColumn(
                name: "DeviceType",
                table: "ShortLinkHit");

            migrationBuilder.DropColumn(
                name: "IPAddress",
                table: "ShortLinkHit");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "ShortLinkHit");

            migrationBuilder.DropColumn(
                name: "LongString",
                table: "ShortLinkHit");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "ShortLinkHit");

            migrationBuilder.DropColumn(
                name: "Platform",
                table: "ShortLinkHit");

            migrationBuilder.DropColumn(
                name: "WebBrowserName",
                table: "ShortLinkHit");

            migrationBuilder.DropColumn(
                name: "WebLink",
                table: "ShortLinkHit");
        }
    }
}
