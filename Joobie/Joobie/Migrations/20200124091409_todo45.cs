using Microsoft.EntityFrameworkCore.Migrations;

namespace Joobie.Migrations
{
    public partial class todo45 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nip",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nip",
                table: "AspNetUsers");
        }
    }
}
