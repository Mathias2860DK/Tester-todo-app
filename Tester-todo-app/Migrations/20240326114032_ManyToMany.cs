using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tester_todo_app.Migrations
{
    /// <inheritdoc />
    public partial class ManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Todos_TodoId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_TodoId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "TodoId",
                table: "Tags");

            migrationBuilder.CreateTable(
                name: "TagTodo",
                columns: table => new
                {
                    TagsId = table.Column<int>(type: "int", nullable: false),
                    todosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagTodo", x => new { x.TagsId, x.todosId });
                    table.ForeignKey(
                        name: "FK_TagTodo_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagTodo_Todos_todosId",
                        column: x => x.todosId,
                        principalTable: "Todos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TagTodo_todosId",
                table: "TagTodo",
                column: "todosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagTodo");

            migrationBuilder.AddColumn<int>(
                name: "TodoId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_TodoId",
                table: "Tags",
                column: "TodoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Todos_TodoId",
                table: "Tags",
                column: "TodoId",
                principalTable: "Todos",
                principalColumn: "Id");
        }
    }
}
