using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class internetmemberimagechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InternetMember");

            migrationBuilder.DropTable(
                name: "InternetMemberStatus");

            migrationBuilder.CreateTable(
                name: "InternetUserStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserStatusLong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserStatusShort = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternetUserStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InternetUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LastBilledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    ONUMac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConnectionPointAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalIdCard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserStatusId = table.Column<int>(type: "int", nullable: true),
                    PackageId = table.Column<int>(type: "int", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternetUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternetUser_InternetPackage_PackageId",
                        column: x => x.PackageId,
                        principalTable: "InternetPackage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InternetUser_InternetUserStatus_UserStatusId",
                        column: x => x.UserStatusId,
                        principalTable: "InternetUserStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InternetUser_ComId_UserId",
                table: "InternetUser",
                columns: new[] { "ComId", "UserId" },
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InternetUser_PackageId",
                table: "InternetUser",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_InternetUser_UserStatusId",
                table: "InternetUser",
                column: "UserStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InternetUser");

            migrationBuilder.DropTable(
                name: "InternetUserStatus");

            migrationBuilder.CreateTable(
                name: "InternetMemberStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true),
                    MemberStatusLong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MemberStatusShort = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternetMemberStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InternetMember",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    ConnectionPointAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    LastBilledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true),
                    MemberStatusId = table.Column<int>(type: "int", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalIdCard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ONUMac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageId = table.Column<int>(type: "int", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternetMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternetMember_InternetMemberStatus_MemberStatusId",
                        column: x => x.MemberStatusId,
                        principalTable: "InternetMemberStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InternetMember_InternetPackage_PackageId",
                        column: x => x.PackageId,
                        principalTable: "InternetPackage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InternetMember_ComId_UserId",
                table: "InternetMember",
                columns: new[] { "ComId", "UserId" },
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InternetMember_MemberStatusId",
                table: "InternetMember",
                column: "MemberStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_InternetMember_PackageId",
                table: "InternetMember",
                column: "PackageId");
        }
    }
}
