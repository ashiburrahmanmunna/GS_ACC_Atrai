using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class commercialmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commercial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FactoryPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Web = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TradeLicenceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TINNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IRCNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BKMEARegNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPersonDesignation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commercial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commercial_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commercial_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commercial_ComId",
                table: "Commercial",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Commercial_LuserId",
                table: "Commercial",
                column: "LuserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commercial");
        }
    }
}
