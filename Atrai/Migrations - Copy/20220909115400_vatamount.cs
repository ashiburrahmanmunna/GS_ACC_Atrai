using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    public partial class vatamount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "VATAmount",
                table: "AccountsDailyTransaction",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "AITAmount",
                table: "AccountsDailyTransaction",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "VATAmount",
                table: "AccountsDailyTransaction",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AITAmount",
                table: "AccountsDailyTransaction",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);
        }
    }
}
