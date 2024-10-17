using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Migrations
{
    /// <inheritdoc />
    public partial class changetablename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterPO_Details_OrderAllocationMaster_BuyerPOId",
                table: "MasterPO_Details");

            migrationBuilder.DropTable(
                name: "BOMOrder_Consumption");

            migrationBuilder.DropTable(
                name: "MASTERPO_BOMOrder_Consumption");

            migrationBuilder.DropTable(
                name: "OrderAllocationDetails");

            migrationBuilder.DropTable(
                name: "OrderAllocationMaster");

            migrationBuilder.CreateTable(
                name: "BuyerPO_Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StyleId = table.Column<int>(type: "int", nullable: true),
                    BuyerId = table.Column<int>(type: "int", nullable: true),
                    TotalQuantity = table.Column<double>(type: "float", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    BuyerPO = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerPO_Master", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuyerPO_Master_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BuyerPO_Master_Customer_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BuyerPO_Master_Style_StyleId",
                        column: x => x.StyleId,
                        principalTable: "Style",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BuyerPO_Master_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuyerPO_Consumption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerPOId = table.Column<int>(type: "int", nullable: false),
                    BOMMasterId = table.Column<int>(type: "int", nullable: false),
                    Remarks1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Remarks2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
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
                    table.PrimaryKey("PK_BuyerPO_Consumption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuyerPO_Consumption_BOMAllocationCategory_BOMAllocationCategoryId",
                        column: x => x.BOMAllocationCategoryId,
                        principalTable: "BOMAllocationCategory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BuyerPO_Consumption_BOMMaster_BOMMasterId",
                        column: x => x.BOMMasterId,
                        principalTable: "BOMMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BuyerPO_Consumption_BuyerPO_Master_BuyerPOId",
                        column: x => x.BuyerPOId,
                        principalTable: "BuyerPO_Master",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuyerPO_Consumption_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BuyerPO_Consumption_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BuyerPO_Consumption_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BuyerPO_Consumption_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BuyerPO_Consumption_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "BuyerPO_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerPOId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    SizeId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerPO_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuyerPO_Details_BuyerPO_Master_BuyerPOId",
                        column: x => x.BuyerPOId,
                        principalTable: "BuyerPO_Master",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuyerPO_Details_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BuyerPO_Details_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BuyerPO_Details_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BuyerPO_Details_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MASTERPO_Consumption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterPOId = table.Column<int>(type: "int", nullable: false),
                    BuyerPOId = table.Column<int>(type: "int", nullable: false),
                    BOMMasterId = table.Column<int>(type: "int", nullable: false),
                    Remarks1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Remarks2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
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
                    table.PrimaryKey("PK_MASTERPO_Consumption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MASTERPO_Consumption_BOMAllocationCategory_BOMAllocationCategoryId",
                        column: x => x.BOMAllocationCategoryId,
                        principalTable: "BOMAllocationCategory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MASTERPO_Consumption_BOMMaster_BOMMasterId",
                        column: x => x.BOMMasterId,
                        principalTable: "BOMMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MASTERPO_Consumption_BuyerPO_Master_BuyerPOId",
                        column: x => x.BuyerPOId,
                        principalTable: "BuyerPO_Master",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MASTERPO_Consumption_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MASTERPO_Consumption_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MASTERPO_Consumption_MasterPO_Master_MasterPOId",
                        column: x => x.MasterPOId,
                        principalTable: "MasterPO_Master",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MASTERPO_Consumption_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MASTERPO_Consumption_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MASTERPO_Consumption_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyerPO_Consumption_BOMAllocationCategoryId",
                table: "BuyerPO_Consumption",
                column: "BOMAllocationCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyerPO_Consumption_BOMMasterId",
                table: "BuyerPO_Consumption",
                column: "BOMMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyerPO_Consumption_BuyerPOId",
                table: "BuyerPO_Consumption",
                column: "BuyerPOId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyerPO_Consumption_ColorId",
                table: "BuyerPO_Consumption",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyerPO_Consumption_ComId",
                table: "BuyerPO_Consumption",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyerPO_Consumption_LuserId",
                table: "BuyerPO_Consumption",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyerPO_Consumption_ProductId",
                table: "BuyerPO_Consumption",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyerPO_Consumption_SizeId",
                table: "BuyerPO_Consumption",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyerPO_Details_BuyerPOId",
                table: "BuyerPO_Details",
                column: "BuyerPOId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyerPO_Details_ColorId",
                table: "BuyerPO_Details",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyerPO_Details_ComId",
                table: "BuyerPO_Details",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyerPO_Details_LuserId",
                table: "BuyerPO_Details",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyerPO_Details_SizeId",
                table: "BuyerPO_Details",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyerPO_Master_BuyerId",
                table: "BuyerPO_Master",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyerPO_Master_ComId",
                table: "BuyerPO_Master",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyerPO_Master_LuserId",
                table: "BuyerPO_Master",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyerPO_Master_StyleId",
                table: "BuyerPO_Master",
                column: "StyleId");

            migrationBuilder.CreateIndex(
                name: "IX_MASTERPO_Consumption_BOMAllocationCategoryId",
                table: "MASTERPO_Consumption",
                column: "BOMAllocationCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MASTERPO_Consumption_BOMMasterId",
                table: "MASTERPO_Consumption",
                column: "BOMMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_MASTERPO_Consumption_BuyerPOId",
                table: "MASTERPO_Consumption",
                column: "BuyerPOId");

            migrationBuilder.CreateIndex(
                name: "IX_MASTERPO_Consumption_ColorId",
                table: "MASTERPO_Consumption",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_MASTERPO_Consumption_ComId",
                table: "MASTERPO_Consumption",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_MASTERPO_Consumption_LuserId",
                table: "MASTERPO_Consumption",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_MASTERPO_Consumption_MasterPOId",
                table: "MASTERPO_Consumption",
                column: "MasterPOId");

            migrationBuilder.CreateIndex(
                name: "IX_MASTERPO_Consumption_ProductId",
                table: "MASTERPO_Consumption",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MASTERPO_Consumption_SizeId",
                table: "MASTERPO_Consumption",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterPO_Details_BuyerPO_Master_BuyerPOId",
                table: "MasterPO_Details",
                column: "BuyerPOId",
                principalTable: "BuyerPO_Master",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterPO_Details_BuyerPO_Master_BuyerPOId",
                table: "MasterPO_Details");

            migrationBuilder.DropTable(
                name: "BuyerPO_Consumption");

            migrationBuilder.DropTable(
                name: "BuyerPO_Details");

            migrationBuilder.DropTable(
                name: "MASTERPO_Consumption");

            migrationBuilder.DropTable(
                name: "BuyerPO_Master");

            migrationBuilder.CreateTable(
                name: "OrderAllocationMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerId = table.Column<int>(type: "int", nullable: true),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    StyleId = table.Column<int>(type: "int", nullable: true),
                    BuyerPO = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    TotalQuantity = table.Column<double>(type: "float", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderAllocationMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderAllocationMaster_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderAllocationMaster_Customer_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderAllocationMaster_Style_StyleId",
                        column: x => x.StyleId,
                        principalTable: "Style",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderAllocationMaster_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BOMOrder_Consumption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BOMAllocationCategoryId = table.Column<int>(type: "int", nullable: true),
                    BOMMasterId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    OrderAllocationId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Remarks1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Remarks2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOMOrder_Consumption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BOMOrder_Consumption_BOMAllocationCategory_BOMAllocationCategoryId",
                        column: x => x.BOMAllocationCategoryId,
                        principalTable: "BOMAllocationCategory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BOMOrder_Consumption_BOMMaster_BOMMasterId",
                        column: x => x.BOMMasterId,
                        principalTable: "BOMMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BOMOrder_Consumption_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BOMOrder_Consumption_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BOMOrder_Consumption_OrderAllocationMaster_OrderAllocationId",
                        column: x => x.OrderAllocationId,
                        principalTable: "OrderAllocationMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BOMOrder_Consumption_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BOMOrder_Consumption_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BOMOrder_Consumption_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MASTERPO_BOMOrder_Consumption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BOMAllocationCategoryId = table.Column<int>(type: "int", nullable: true),
                    BOMMasterId = table.Column<int>(type: "int", nullable: false),
                    BuyerPOId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    MasterPOId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Remarks1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Remarks2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MASTERPO_BOMOrder_Consumption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MASTERPO_BOMOrder_Consumption_BOMAllocationCategory_BOMAllocationCategoryId",
                        column: x => x.BOMAllocationCategoryId,
                        principalTable: "BOMAllocationCategory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MASTERPO_BOMOrder_Consumption_BOMMaster_BOMMasterId",
                        column: x => x.BOMMasterId,
                        principalTable: "BOMMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MASTERPO_BOMOrder_Consumption_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MASTERPO_BOMOrder_Consumption_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MASTERPO_BOMOrder_Consumption_MasterPO_Master_MasterPOId",
                        column: x => x.MasterPOId,
                        principalTable: "MasterPO_Master",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MASTERPO_BOMOrder_Consumption_OrderAllocationMaster_BuyerPOId",
                        column: x => x.BuyerPOId,
                        principalTable: "OrderAllocationMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MASTERPO_BOMOrder_Consumption_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MASTERPO_BOMOrder_Consumption_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MASTERPO_BOMOrder_Consumption_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderAllocationDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    OrderAllocationId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderAllocationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderAllocationDetails_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderAllocationDetails_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderAllocationDetails_OrderAllocationMaster_OrderAllocationId",
                        column: x => x.OrderAllocationId,
                        principalTable: "OrderAllocationMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderAllocationDetails_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderAllocationDetails_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BOMOrder_Consumption_BOMAllocationCategoryId",
                table: "BOMOrder_Consumption",
                column: "BOMAllocationCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BOMOrder_Consumption_BOMMasterId",
                table: "BOMOrder_Consumption",
                column: "BOMMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_BOMOrder_Consumption_ColorId",
                table: "BOMOrder_Consumption",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_BOMOrder_Consumption_ComId",
                table: "BOMOrder_Consumption",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_BOMOrder_Consumption_LuserId",
                table: "BOMOrder_Consumption",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_BOMOrder_Consumption_OrderAllocationId",
                table: "BOMOrder_Consumption",
                column: "OrderAllocationId");

            migrationBuilder.CreateIndex(
                name: "IX_BOMOrder_Consumption_ProductId",
                table: "BOMOrder_Consumption",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BOMOrder_Consumption_SizeId",
                table: "BOMOrder_Consumption",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_MASTERPO_BOMOrder_Consumption_BOMAllocationCategoryId",
                table: "MASTERPO_BOMOrder_Consumption",
                column: "BOMAllocationCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MASTERPO_BOMOrder_Consumption_BOMMasterId",
                table: "MASTERPO_BOMOrder_Consumption",
                column: "BOMMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_MASTERPO_BOMOrder_Consumption_BuyerPOId",
                table: "MASTERPO_BOMOrder_Consumption",
                column: "BuyerPOId");

            migrationBuilder.CreateIndex(
                name: "IX_MASTERPO_BOMOrder_Consumption_ColorId",
                table: "MASTERPO_BOMOrder_Consumption",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_MASTERPO_BOMOrder_Consumption_ComId",
                table: "MASTERPO_BOMOrder_Consumption",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_MASTERPO_BOMOrder_Consumption_LuserId",
                table: "MASTERPO_BOMOrder_Consumption",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_MASTERPO_BOMOrder_Consumption_MasterPOId",
                table: "MASTERPO_BOMOrder_Consumption",
                column: "MasterPOId");

            migrationBuilder.CreateIndex(
                name: "IX_MASTERPO_BOMOrder_Consumption_ProductId",
                table: "MASTERPO_BOMOrder_Consumption",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MASTERPO_BOMOrder_Consumption_SizeId",
                table: "MASTERPO_BOMOrder_Consumption",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAllocationDetails_ColorId",
                table: "OrderAllocationDetails",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAllocationDetails_ComId",
                table: "OrderAllocationDetails",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAllocationDetails_LuserId",
                table: "OrderAllocationDetails",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAllocationDetails_OrderAllocationId",
                table: "OrderAllocationDetails",
                column: "OrderAllocationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAllocationDetails_SizeId",
                table: "OrderAllocationDetails",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAllocationMaster_BuyerId",
                table: "OrderAllocationMaster",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAllocationMaster_ComId",
                table: "OrderAllocationMaster",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAllocationMaster_LuserId",
                table: "OrderAllocationMaster",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAllocationMaster_StyleId",
                table: "OrderAllocationMaster",
                column: "StyleId");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterPO_Details_OrderAllocationMaster_BuyerPOId",
                table: "MasterPO_Details",
                column: "BuyerPOId",
                principalTable: "OrderAllocationMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
