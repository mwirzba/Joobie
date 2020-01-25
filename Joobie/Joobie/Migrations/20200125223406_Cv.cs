using Microsoft.EntityFrameworkCore.Migrations;

namespace Joobie.Migrations
{
    public partial class Cv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CVJobApplicationUser",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(nullable: false),
                    JobsId = table.Column<long>(nullable: false),
                    JobId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CvName = table.Column<string>(nullable: true),
                    JobId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVJobApplicationUser", x => new { x.ApplicationUserId, x.JobsId });
                    table.UniqueConstraint("AK_CVJobApplicationUser_JobId", x => x.JobId);
                    table.ForeignKey(
                        name: "FK_CVJobApplicationUser_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CVJobApplicationUser_Job_JobId1",
                        column: x => x.JobId1,
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CVJobApplicationUser_JobId1",
                table: "CVJobApplicationUser",
                column: "JobId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CVJobApplicationUser");
        }
    }
}
