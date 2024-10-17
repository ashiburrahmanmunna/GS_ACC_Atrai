using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Invoice.Migrations
{
    public partial class vgmmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserAccount",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "VGM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VGANo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VGAMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContainerNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContainerType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContainerSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TareWeight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifiedGrossMass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviouslyDeclaredweight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VGMWeightbyCPA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameofShipper = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingAgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VGMPerformedShipperBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeightBridgeRegistrationNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressOfWeightBridge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssuedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    LuserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VGM", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_Email",
                table: "UserAccount",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesItems_ProductId",
                table: "SalesItems",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesItems_Product_ProductId",
                table: "SalesItems",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesItems_Product_ProductId",
                table: "SalesItems");

            migrationBuilder.DropTable(
                name: "VGM");

            migrationBuilder.DropIndex(
                name: "IX_UserAccount_Email",
                table: "UserAccount");

            migrationBuilder.DropIndex(
                name: "IX_SalesItems_ProductId",
                table: "SalesItems");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserAccount",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
