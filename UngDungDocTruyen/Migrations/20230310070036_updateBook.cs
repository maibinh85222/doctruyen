using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UngDungDocTruyen.Migrations
{
    /// <inheritdoc />
    public partial class updateBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_book",
                table: "book");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "book");

            migrationBuilder.AlterColumn<string>(
                name: "MaBook",
                table: "book",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_book",
                table: "book",
                column: "MaBook");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_book",
                table: "book");

            migrationBuilder.AlterColumn<string>(
                name: "MaBook",
                table: "book",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "book",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_book",
                table: "book",
                column: "ID");
        }
    }
}
