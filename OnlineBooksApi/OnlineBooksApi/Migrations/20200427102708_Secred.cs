using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineBooksApi.Migrations
{
    public partial class Secred : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Secred",
                table: "Author",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Secred",
                table: "Author");
        }
    }
}
