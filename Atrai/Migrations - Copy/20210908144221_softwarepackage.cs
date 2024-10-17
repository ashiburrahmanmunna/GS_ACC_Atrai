using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class softwarepackage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DamageModelId",
                table: "CostCalculated",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Damage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DamageDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DamageCode = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ReferanceOne = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ReferanceTwo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    isPosted = table.Column<bool>(type: "bit", nullable: false),
                    InternetUserId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Damage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Damage_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Damage_InternetUser_InternetUserId",
                        column: x => x.InternetUserId,
                        principalTable: "InternetUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Damage_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoftwarePackage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoftwarePackageCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftwarePackageDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    LinkAdd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackagePrice = table.Column<float>(type: "real", nullable: false),
                    DiscountPercentage = table.Column<float>(type: "real", nullable: false),
                    Duration = table.Column<float>(type: "real", nullable: false),
                    UserCount = table.Column<int>(type: "int", nullable: false),
                    SoftwarePackageImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoftwarePackageFileExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActiveYesNo = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwarePackage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DamageItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DamageId = table.Column<int>(type: "int", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: true),
                    SerialItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamageItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DamageItems_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DamageItems_Damage_DamageId",
                        column: x => x.DamageId,
                        principalTable: "Damage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DamageItems_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DamageItems_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DamageItems_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DamageBatchItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DamageItemId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PurchaseBatchId = table.Column<int>(type: "int", nullable: false),
                    BatchSerialNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false),
                    LuserIdUpdate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamageBatchItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DamageBatchItems_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DamageBatchItems_DamageItems_DamageItemId",
                        column: x => x.DamageItemId,
                        principalTable: "DamageItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DamageBatchItems_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DamageBatchItems_PurchaseBatchItems_PurchaseBatchId",
                        column: x => x.PurchaseBatchId,
                        principalTable: "PurchaseBatchItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DamageBatchItems_UserAccount_LuserId",
                        column: x => x.LuserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CostCalculated_DamageModelId",
                table: "CostCalculated",
                column: "DamageModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Damage_ComId_DamageCode",
                table: "Damage",
                columns: new[] { "ComId", "DamageCode" },
                unique: true,
                filter: "[DamageCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Damage_InternetUserId",
                table: "Damage",
                column: "InternetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Damage_LuserId",
                table: "Damage",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageBatchItems_ComId",
                table: "DamageBatchItems",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageBatchItems_DamageItemId",
                table: "DamageBatchItems",
                column: "DamageItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageBatchItems_LuserId",
                table: "DamageBatchItems",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageBatchItems_ProductId",
                table: "DamageBatchItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageBatchItems_PurchaseBatchId",
                table: "DamageBatchItems",
                column: "PurchaseBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageItems_ComId",
                table: "DamageItems",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageItems_DamageId",
                table: "DamageItems",
                column: "DamageId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageItems_LuserId",
                table: "DamageItems",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageItems_ProductId",
                table: "DamageItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageItems_WarehouseId",
                table: "DamageItems",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CostCalculated_Damage_DamageModelId",
                table: "CostCalculated",
                column: "DamageModelId",
                principalTable: "Damage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostCalculated_Damage_DamageModelId",
                table: "CostCalculated");

            migrationBuilder.DropTable(
                name: "DamageBatchItems");

            migrationBuilder.DropTable(
                name: "SoftwarePackage");

            migrationBuilder.DropTable(
                name: "DamageItems");

            migrationBuilder.DropTable(
                name: "Damage");

            migrationBuilder.DropIndex(
                name: "IX_CostCalculated_DamageModelId",
                table: "CostCalculated");

            migrationBuilder.DropColumn(
                name: "DamageModelId",
                table: "CostCalculated");
        }
    }
}
