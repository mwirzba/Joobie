using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Joobie.Migrations
{
    public partial class databaseRecords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Job",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ExpirationDate",
                value: new DateTime(2020, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Job",
                columns: new[] { "Id", "AddedDate", "CategoryId", "Description", "ExpirationDate", "Localization", "Name", "Salary", "TypeOfContractId", "UserId", "WorkingHoursId", "isActive" },
                values: new object[,]
                {
                    { 2L, new DateTime(2020, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)1, "", new DateTime(2020, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gdynia", "Junior .NET Developer", "5300", (byte)1, "69dacfbb-ce2f-4782-9ddc-8bc5fce20784", (byte)2, true },
                    { 3L, new DateTime(2020, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)1, "", new DateTime(2020, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sopot", "Senior .NET Developer", "4000", (byte)1, "69dacfbb-ce2f-4782-9ddc-8bc5fce20784", (byte)1, true },
                    { 4L, new DateTime(2020, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)16, "", new DateTime(2020, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Koszalin", "Starszy Inżynier Oprogramowania .NET", "5000", (byte)1, "31d98481-9339-4e36-b3d4-c8f7e7ab3256", (byte)1, true },
                    { 5L, new DateTime(2020, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)16, "", new DateTime(2020, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Warszawa", "Programista .NET", "5900", (byte)1, "7c76f70b-fe41-4c9c-82b8-eac1ceb588c6", (byte)3, true },
                    { 6L, new DateTime(2020, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)16, "", new DateTime(2020, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gdańsk", "C# .Net developer", "200", (byte)3, "69dacfbb-ce2f-4782-9ddc-8bc5fce20784", (byte)1, true },
                    { 7L, new DateTime(2020, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)15, "", new DateTime(2020, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lębork", ".NET Developer", "6000", (byte)5, "31d98481-9339-4e36-b3d4-c8f7e7ab3256", (byte)1, true },
                    { 8L, new DateTime(2020, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)12, "", new DateTime(2020, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gdańsk", ".NET Developer", "9000", (byte)3, "7c76f70b-fe41-4c9c-82b8-eac1ceb588c6", (byte)1, true },
                    { 9L, new DateTime(2020, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)13, "", new DateTime(2020, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gdańsk", "Software Engineer C#", "5300", (byte)3, "31d98481-9339-4e36-b3d4-c8f7e7ab3256", (byte)3, true },
                    { 10L, new DateTime(2020, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)11, "", new DateTime(2020, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gdynia", "Quality Assurance", "5300", (byte)1, "7c76f70b-fe41-4c9c-82b8-eac1ceb588c6", (byte)3, true },
                    { 11L, new DateTime(2020, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)15, "", new DateTime(2020, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gdańsk", "Programista .NET", "3333", (byte)5, "69dacfbb-ce2f-4782-9ddc-8bc5fce20784", (byte)1, true },
                    { 12L, new DateTime(2020, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)16, "", new DateTime(2020, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gdańsk", "Junior .NET Developer", "5300", (byte)5, "31d98481-9339-4e36-b3d4-c8f7e7ab3256", (byte)2, true },
                    { 13L, new DateTime(2020, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)16, "", new DateTime(2020, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gdańsk", "Azure DevOps", "4300", (byte)1, "69dacfbb-ce2f-4782-9ddc-8bc5fce20784", (byte)3, true },
                    { 14L, new DateTime(2020, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)12, "", new DateTime(2020, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gdańsk", ".NET Developer", "9000", (byte)3, "69dacfbb-ce2f-4782-9ddc-8bc5fce20784", (byte)1, true },
                    { 15L, new DateTime(2020, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)13, "", new DateTime(2020, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gdańsk", "Software Engineer C#", "5300", (byte)3, "31d98481-9339-4e36-b3d4-c8f7e7ab3256", (byte)3, true },
                    { 16L, new DateTime(2020, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)11, "", new DateTime(2020, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gdynia", "Quality Assurance", "5300", (byte)1, "7c76f70b-fe41-4c9c-82b8-eac1ceb588c6", (byte)3, true },
                    { 17L, new DateTime(2020, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)15, "", new DateTime(2020, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gdańsk", "Programista .NET", "3333", (byte)5, "69dacfbb-ce2f-4782-9ddc-8bc5fce20784", (byte)1, true },
                    { 18L, new DateTime(2020, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)16, "", new DateTime(2020, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gdańsk", "Junior .NET Developer", "5300", (byte)5, "69dacfbb-ce2f-4782-9ddc-8bc5fce20784", (byte)2, true },
                    { 19L, new DateTime(2020, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)16, "", new DateTime(2020, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gdańsk", "Azure DevOps", "4300", (byte)1, "31d98481-9339-4e36-b3d4-c8f7e7ab3256", (byte)3, true },
                    { 20L, new DateTime(2020, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)1, "", new DateTime(2020, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sopot", "Senior .NET Developer", "4000", (byte)1, "69dacfbb-ce2f-4782-9ddc-8bc5fce20784", (byte)1, true },
                    { 21L, new DateTime(2020, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)16, "", new DateTime(2020, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Koszalin", "Starszy Inżynier Oprogramowania .NET", "5000", (byte)1, "7c76f70b-fe41-4c9c-82b8-eac1ceb588c6", (byte)1, true },
                    { 22L, new DateTime(2020, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)16, "", new DateTime(2020, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Warszawa", "Programista .NET", "5900", (byte)1, "31d98481-9339-4e36-b3d4-c8f7e7ab3256", (byte)3, true },
                    { 23L, new DateTime(2020, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)16, "", new DateTime(2020, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gdańsk", "C# .Net developer", "200", (byte)3, "69dacfbb-ce2f-4782-9ddc-8bc5fce20784", (byte)1, true },
                    { 24L, new DateTime(2020, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)15, "", new DateTime(2020, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lębork", ".NET Developer", "6000", (byte)5, "7c76f70b-fe41-4c9c-82b8-eac1ceb588c6", (byte)1, true },
                    { 25L, new DateTime(2020, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)12, "", new DateTime(2020, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wrocław", ".NET Developer", "9000", (byte)3, "31d98481-9339-4e36-b3d4-c8f7e7ab3256", (byte)1, true },
                    { 26L, new DateTime(2020, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)13, "", new DateTime(2020, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gdańsk", "Software Engineer C#", "5300", (byte)3, "7c76f70b-fe41-4c9c-82b8-eac1ceb588c6", (byte)3, true },
                    { 27L, new DateTime(2020, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)11, "", new DateTime(2020, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gdynia", "Quality Assurance", "5300", (byte)1, "31d98481-9339-4e36-b3d4-c8f7e7ab3256", (byte)3, true },
                    { 28L, new DateTime(2020, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)15, "", new DateTime(2020, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gdańsk", "Programista .NET", "3333", (byte)5, "69dacfbb-ce2f-4782-9ddc-8bc5fce20784", (byte)1, true },
                    { 29L, new DateTime(2020, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)16, "", new DateTime(2020, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gdańsk", "Junior .NET Developer", "5300", (byte)5, "31d98481-9339-4e36-b3d4-c8f7e7ab3256", (byte)2, true },
                    { 30L, new DateTime(2020, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)16, "", new DateTime(2020, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gdańsk", "Azure DevOps", "4300", (byte)1, "69dacfbb-ce2f-4782-9ddc-8bc5fce20784", (byte)3, true },
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Job",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Job",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Job",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Job",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Job",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Job",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Job",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Job",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Job",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Job",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Job",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Job",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.UpdateData(
                table: "Job",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ExpirationDate",
                value: new DateTime(2020, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
