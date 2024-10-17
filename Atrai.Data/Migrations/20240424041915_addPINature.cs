using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class addPINature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PINatureId",
                table: "Com_proformaInvoice",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PINature",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PINatureName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PINatureShortName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PINature", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Com_proformaInvoice_PINatureId",
                table: "Com_proformaInvoice",
                column: "PINatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Com_proformaInvoice_PINature_PINatureId",
                table: "Com_proformaInvoice",
                column: "PINatureId",
                principalTable: "PINature",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Com_proformaInvoice_PINature_PINatureId",
                table: "Com_proformaInvoice");

            migrationBuilder.DropTable(
                name: "PINature");

            migrationBuilder.DropIndex(
                name: "IX_Com_proformaInvoice_PINatureId",
                table: "Com_proformaInvoice");

            migrationBuilder.DropColumn(
                name: "PINatureId",
                table: "Com_proformaInvoice");
        }
    }
}
