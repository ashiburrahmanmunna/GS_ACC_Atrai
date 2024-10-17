using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class mobiletextanimation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MobileTextAnimation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TextMessageOne = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TextMessageTwo = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    TextMessageThree = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSeen = table.Column<bool>(type: "bit", nullable: false),
                    AnimationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileTextAnimation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MobileTextAnimation_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MobileTextAnimation_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskToDo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TaskDetails = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TaskRemarks = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    InputDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false),
                    TaskPercentage = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskToDo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskToDo_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskToDo_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MobileTextAnimation_ComId",
                table: "MobileTextAnimation",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_MobileTextAnimation_LuserId",
                table: "MobileTextAnimation",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskToDo_ComId",
                table: "TaskToDo",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskToDo_LuserId",
                table: "TaskToDo",
                column: "LuserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MobileTextAnimation");

            migrationBuilder.DropTable(
                name: "TaskToDo");
        }
    }
}
