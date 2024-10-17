using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class StyleModelAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Style",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StyleNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BuyerId = table.Column<int>(type: "int", nullable: false),
                    BuyersId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Style", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Style_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Style_Customer_BuyersId",
                        column: x => x.BuyersId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Style_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColorChild",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    ColorsId = table.Column<int>(type: "int", nullable: true),
                    StyleId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorChild", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColorChild_Colors_ColorsId",
                        column: x => x.ColorsId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ColorChild_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColorChild_Style_StyleId",
                        column: x => x.StyleId,
                        principalTable: "Style",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ColorChild_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SizeChild",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    SizesId = table.Column<int>(type: "int", nullable: true),
                    StyleId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeChild", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SizeChild_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SizeChild_Sizes_SizesId",
                        column: x => x.SizesId,
                        principalTable: "Sizes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SizeChild_Style_StyleId",
                        column: x => x.StyleId,
                        principalTable: "Style",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SizeChild_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColorChild_ColorsId",
                table: "ColorChild",
                column: "ColorsId");

            migrationBuilder.CreateIndex(
                name: "IX_ColorChild_ComId",
                table: "ColorChild",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_ColorChild_LuserId",
                table: "ColorChild",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_ColorChild_StyleId",
                table: "ColorChild",
                column: "StyleId");

            migrationBuilder.CreateIndex(
                name: "IX_SizeChild_ComId",
                table: "SizeChild",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_SizeChild_LuserId",
                table: "SizeChild",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_SizeChild_SizesId",
                table: "SizeChild",
                column: "SizesId");

            migrationBuilder.CreateIndex(
                name: "IX_SizeChild_StyleId",
                table: "SizeChild",
                column: "StyleId");

            migrationBuilder.CreateIndex(
                name: "IX_Style_BuyersId",
                table: "Style",
                column: "BuyersId");

            migrationBuilder.CreateIndex(
                name: "IX_Style_ComId",
                table: "Style",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Style_LuserId",
                table: "Style",
                column: "LuserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColorChild");

            migrationBuilder.DropTable(
                name: "SizeChild");

            migrationBuilder.DropTable(
                name: "Style");
        }
    }
}
