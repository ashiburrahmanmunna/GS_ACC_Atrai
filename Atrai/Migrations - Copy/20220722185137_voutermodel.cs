using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Invoice.Migrations
{
    public partial class voutermodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "SMSBalance",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Voter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    voterNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    nameEn = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    father = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    mother = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    spouse = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    dob = table.Column<DateTime>(type: "datetime2", nullable: true),
                    permanentAddress = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    photoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    photoExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voter_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Voter_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Voter_ComId",
                table: "Voter",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Voter_LuserId",
                table: "Voter",
                column: "LuserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Voter");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "SMSBalance");
        }
    }
}
