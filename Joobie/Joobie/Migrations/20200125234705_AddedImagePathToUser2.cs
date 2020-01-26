using Microsoft.EntityFrameworkCore.Migrations;

namespace Joobie.Migrations
{
    public partial class AddedImagePathToUser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyImagePath",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyImagePath",
                table: "AspNetUsers");
        }
    }
}
