using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tester_todo_app.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIsCompletedColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsComplted",
                table: "Todos",
                newName: "IsCompleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsCompleted",
                table: "Todos",
                newName: "IsComplted");
        }
    }
}
