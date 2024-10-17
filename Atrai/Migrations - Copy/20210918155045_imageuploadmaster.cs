using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class imageuploadmaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImageUploadMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UploadName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ViewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageUploadMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageUploadMaster_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageUploadMaster_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageUploadDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterId = table.Column<int>(type: "int", nullable: false),
                    ImageUploadMasterId = table.Column<int>(type: "int", nullable: true),
                    DBFile = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageUploadDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageUploadDetails_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageUploadDetails_ImageUploadMaster_ImageUploadMasterId",
                        column: x => x.ImageUploadMasterId,
                        principalTable: "ImageUploadMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImageUploadDetails_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageUploadDetails_ComId",
                table: "ImageUploadDetails",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageUploadDetails_ImageUploadMasterId",
                table: "ImageUploadDetails",
                column: "ImageUploadMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageUploadDetails_LuserId",
                table: "ImageUploadDetails",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageUploadMaster_ComId",
                table: "ImageUploadMaster",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageUploadMaster_LuserId",
                table: "ImageUploadMaster",
                column: "LuserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageUploadDetails");

            migrationBuilder.DropTable(
                name: "ImageUploadMaster");
        }
    }
}
