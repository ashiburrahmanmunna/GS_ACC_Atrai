using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class bookgallery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageUploadDetails");

            migrationBuilder.DropTable(
                name: "ImageUploadMaster");

            migrationBuilder.CreateTable(
                name: "MobileImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MobileImages_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MobileImages_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImagesGallery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookModelId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagesGallery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagesGallery_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImagesGallery_MobileImages_BookModelId",
                        column: x => x.BookModelId,
                        principalTable: "MobileImages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImagesGallery_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImagesGallery_BookModelId",
                table: "ImagesGallery",
                column: "BookModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagesGallery_ComId",
                table: "ImagesGallery",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagesGallery_LuserId",
                table: "ImagesGallery",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_MobileImages_ComId",
                table: "MobileImages",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_MobileImages_LuserId",
                table: "MobileImages",
                column: "LuserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagesGallery");

            migrationBuilder.DropTable(
                name: "MobileImages");

            migrationBuilder.CreateTable(
                name: "ImageUploadMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UploadName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ViewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    ComId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DBFile = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUploadMasterId = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true),
                    MasterId = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
    }
}
