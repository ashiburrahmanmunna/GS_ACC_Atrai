using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Invoice.Migrations
{
    public partial class luseridnullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesPaymentModel");

            migrationBuilder.DropTable(
                name: "PaymentTypeModel");

            migrationBuilder.AlterColumn<int>(
                name: "LuserIdUpdate",
                table: "Warehouse",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LuserIdUpdate",
                table: "VGM",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LuserIdUpdate",
                table: "UserAccount",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LuserIdUpdate",
                table: "StoreSetting",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LuserIdUpdate",
                table: "SalesItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LuserIdUpdate",
                table: "Sales",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LuserIdUpdate",
                table: "Product",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LuserIdUpdate",
                table: "Customer",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LuserIdUpdate",
                table: "Category",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LuserIdUpdate",
                table: "AccountsDailyTransaction",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "InputDate",
                table: "AccountsDailyTransaction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "LuserIdUpdate",
                table: "AccountHead",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InputDate",
                table: "AccountsDailyTransaction");

            migrationBuilder.AlterColumn<int>(
                name: "LuserIdUpdate",
                table: "Warehouse",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LuserIdUpdate",
                table: "VGM",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LuserIdUpdate",
                table: "UserAccount",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LuserIdUpdate",
                table: "StoreSetting",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LuserIdUpdate",
                table: "SalesItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LuserIdUpdate",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LuserIdUpdate",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LuserIdUpdate",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LuserIdUpdate",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LuserIdUpdate",
                table: "AccountsDailyTransaction",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LuserIdUpdate",
                table: "AccountHead",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "PaymentTypeModel",
                columns: table => new
                {
                    PaymentTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TypeShortName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypeModel", x => x.PaymentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "SalesPaymentModel",
                columns: table => new
                {
                    SalesId = table.Column<int>(type: "int", nullable: false),
                    AccId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentCardNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: false),
                    RowNo = table.Column<int>(type: "int", nullable: true),
                    isPosted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPaymentModel", x => x.SalesId);
                    table.ForeignKey(
                        name: "FK_SalesPaymentModel_AccountHead_AccId",
                        column: x => x.AccId,
                        principalTable: "AccountHead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesPaymentModel_PaymentTypeModel_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypeModel",
                        principalColumn: "PaymentTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesPaymentModel_Sales_SalesId",
                        column: x => x.SalesId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesPaymentModel_AccId",
                table: "SalesPaymentModel",
                column: "AccId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPaymentModel_PaymentTypeId",
                table: "SalesPaymentModel",
                column: "PaymentTypeId");
        }
    }
}
