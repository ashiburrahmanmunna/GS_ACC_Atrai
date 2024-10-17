using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class accountheadidchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesPayment_AccountHead_AccId",
                table: "SalesPayment");

            migrationBuilder.DropIndex(
                name: "IX_SalesPayment_AccId",
                table: "SalesPayment");

            migrationBuilder.DropColumn(
                name: "AccId",
                table: "SalesPayment");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPayment_AccountHeadId",
                table: "SalesPayment",
                column: "AccountHeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPayment_AccountHead_AccountHeadId",
                table: "SalesPayment",
                column: "AccountHeadId",
                principalTable: "AccountHead",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesPayment_AccountHead_AccountHeadId",
                table: "SalesPayment");

            migrationBuilder.DropIndex(
                name: "IX_SalesPayment_AccountHeadId",
                table: "SalesPayment");

            migrationBuilder.AddColumn<int>(
                name: "AccId",
                table: "SalesPayment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesPayment_AccId",
                table: "SalesPayment",
                column: "AccId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPayment_AccountHead_AccId",
                table: "SalesPayment",
                column: "AccId",
                principalTable: "AccountHead",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
