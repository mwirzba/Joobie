using Microsoft.EntityFrameworkCore.Migrations;

namespace Joobie.Migrations
{
    public partial class Cv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Job",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Job",
                keyColumn: "Id",
                keyValue: 1L,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Job",
                keyColumn: "Id",
                keyValue: 2L,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Job",
                keyColumn: "Id",
                keyValue: 3L,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Job",
                keyColumn: "Id",
                keyValue: 4L,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Job",
                keyColumn: "Id",
                keyValue: 5L,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Job",
                keyColumn: "Id",
                keyValue: 6L,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Job",
                keyColumn: "Id",
                keyValue: 7L,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Job",
                keyColumn: "Id",
                keyValue: 8L,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Job",
                keyColumn: "Id",
                keyValue: 9L,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Job",
                keyColumn: "Id",
                keyValue: 10L,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Job",
                keyColumn: "Id",
                keyValue: 11L,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Job",
                keyColumn: "Id",
                keyValue: 12L,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Job",
                keyColumn: "Id",
                keyValue: 13L,
                column: "isActive",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Job");
        }
    }
}
