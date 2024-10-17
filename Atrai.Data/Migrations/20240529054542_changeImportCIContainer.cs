using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrai.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeImportCIContainer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImportCI_DetailsId",
                table: "ImportCI_Container",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImportCI_Container_ImportCI_DetailsId",
                table: "ImportCI_Container",
                column: "ImportCI_DetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImportCI_Container_ImportCI_Details_ImportCI_DetailsId",
                table: "ImportCI_Container",
                column: "ImportCI_DetailsId",
                principalTable: "ImportCI_Details",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImportCI_Container_ImportCI_Details_ImportCI_DetailsId",
                table: "ImportCI_Container");

            migrationBuilder.DropIndex(
                name: "IX_ImportCI_Container_ImportCI_DetailsId",
                table: "ImportCI_Container");

            migrationBuilder.DropColumn(
                name: "ImportCI_DetailsId",
                table: "ImportCI_Container");
        }
    }
}
