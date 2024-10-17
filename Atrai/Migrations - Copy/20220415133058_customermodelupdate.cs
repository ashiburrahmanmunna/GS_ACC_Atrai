using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class customermodelupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LoginId",
                table: "Customer",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MonthlyTarget",
                table: "Customer",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "NextPaymentDate",
                table: "Customer",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Customer",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalesRepresentativeId",
                table: "Customer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_SalesRepresentativeId",
                table: "Customer",
                column: "SalesRepresentativeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Employee_SalesRepresentativeId",
                table: "Customer",
                column: "SalesRepresentativeId",
                principalTable: "Employee",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Employee_SalesRepresentativeId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_SalesRepresentativeId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "LoginId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "MonthlyTarget",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "NextPaymentDate",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "SalesRepresentativeId",
                table: "Customer");
        }
    }
}
