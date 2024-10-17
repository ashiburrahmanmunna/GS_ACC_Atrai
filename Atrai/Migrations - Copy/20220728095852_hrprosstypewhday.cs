﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Invoice.Migrations
{
    public partial class hrprosstypewhday : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HR_ProssType_WHDay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dtPunchDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DaySts = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DayStsB = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_ProssType_WHDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HR_ProssType_WHDay_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HR_ProssType_WHDay_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HR_ProssType_WHDay_ComId",
                table: "HR_ProssType_WHDay",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_ProssType_WHDay_LuserId",
                table: "HR_ProssType_WHDay",
                column: "LuserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HR_ProssType_WHDay");
        }
    }
}
