using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class BOMAllocationCategoryModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BOMAllocationCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOMAllocationCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BOMAllocationCategory_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BOMAllocationCategory_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "BOMMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BOMCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StyleId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    SizeId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOMMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BOMMaster_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BOMMaster_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BOMMaster_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BOMMaster_Style_StyleId",
                        column: x => x.StyleId,
                        principalTable: "Style",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BOMMaster_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "BOMDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Remarks1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Remarks2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BOMMasterId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    SizeId = table.Column<int>(type: "int", nullable: true),
                    BOMAllocationCategoryId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOMDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BOMDetails_BOMAllocationCategory_BOMAllocationCategoryId",
                        column: x => x.BOMAllocationCategoryId,
                        principalTable: "BOMAllocationCategory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BOMDetails_BOMMaster_BOMMasterId",
                        column: x => x.BOMMasterId,
                        principalTable: "BOMMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BOMDetails_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BOMDetails_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BOMDetails_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BOMDetails_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BOMDetails_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BOMAllocationCategory_ComId",
                table: "BOMAllocationCategory",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_BOMAllocationCategory_LuserId",
                table: "BOMAllocationCategory",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_BOMDetails_BOMAllocationCategoryId",
                table: "BOMDetails",
                column: "BOMAllocationCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BOMDetails_BOMMasterId",
                table: "BOMDetails",
                column: "BOMMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_BOMDetails_ColorId",
                table: "BOMDetails",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_BOMDetails_ComId",
                table: "BOMDetails",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_BOMDetails_LuserId",
                table: "BOMDetails",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_BOMDetails_ProductId",
                table: "BOMDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BOMDetails_SizeId",
                table: "BOMDetails",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_BOMMaster_ColorId",
                table: "BOMMaster",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_BOMMaster_ComId",
                table: "BOMMaster",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_BOMMaster_LuserId",
                table: "BOMMaster",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_BOMMaster_SizeId",
                table: "BOMMaster",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_BOMMaster_StyleId",
                table: "BOMMaster",
                column: "StyleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BOMDetails");

            migrationBuilder.DropTable(
                name: "BOMAllocationCategory");

            migrationBuilder.DropTable(
                name: "BOMMaster");
        }
    }
}
