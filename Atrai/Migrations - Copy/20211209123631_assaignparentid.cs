using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class assaignparentid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AssaignToPerson",
                table: "TaskToDo",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskToDoParentId",
                table: "TaskToDo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskToDo_TaskToDoParentId",
                table: "TaskToDo",
                column: "TaskToDoParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskToDo_TaskToDo_TaskToDoParentId",
                table: "TaskToDo",
                column: "TaskToDoParentId",
                principalTable: "TaskToDo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskToDo_TaskToDo_TaskToDoParentId",
                table: "TaskToDo");

            migrationBuilder.DropIndex(
                name: "IX_TaskToDo_TaskToDoParentId",
                table: "TaskToDo");

            migrationBuilder.DropColumn(
                name: "AssaignToPerson",
                table: "TaskToDo");

            migrationBuilder.DropColumn(
                name: "TaskToDoParentId",
                table: "TaskToDo");
        }
    }
}
