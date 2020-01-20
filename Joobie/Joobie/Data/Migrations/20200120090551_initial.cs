using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Joobie.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfContracts",
                columns: table => new
                {
                    Id = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfContracts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkingHours",
                columns: table => new
                {
                    Id = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingHours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Localization = table.Column<string>(nullable: true),
                    AddedDate = table.Column<DateTime>(nullable: true),
                    ExpirationDate = table.Column<DateTime>(nullable: true),
                    Salary = table.Column<string>(nullable: true),
                    CategoryId = table.Column<byte>(nullable: false),
                    TypeOfContractId = table.Column<byte>(nullable: false),
                    WorkingHoursId = table.Column<byte>(nullable: false),
                    CompanyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_TypeOfContracts_TypeOfContractId",
                        column: x => x.TypeOfContractId,
                        principalTable: "TypeOfContracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_WorkingHours_WorkingHoursId",
                        column: x => x.WorkingHoursId,
                        principalTable: "WorkingHours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { (byte)1, "Administracja biurowa" },
                    { (byte)21, "Obsługa klienta" },
                    { (byte)22, "Praca fizyczna" },
                    { (byte)23, "Prawo" },
                    { (byte)24, "Produkcja" },
                    { (byte)25, "Public Relations" },
                    { (byte)26, "Reklama / Grafika / Kreacja / Fotografia" },
                    { (byte)20, "Nieruchomości" },
                    { (byte)27, "Sektor publiczny" },
                    { (byte)30, "Ubezpieczenia" },
                    { (byte)31, "Zakupy" },
                    { (byte)32, "Kontrola jakości" },
                    { (byte)33, "Zdrowie / Uroda / Rekreacja" },
                    { (byte)34, "Energetyka" },
                    { (byte)35, "Inne" },
                    { (byte)29, "Transport / Spedycja" },
                    { (byte)19, "Media / Sztuka / Rozrywka" },
                    { (byte)28, "Sprzedaż" },
                    { (byte)17, "Łańcuch dostaw" },
                    { (byte)18, "Marketing" },
                    { (byte)2, "Doradztwo / Konsulting" },
                    { (byte)3, "Badania i rozwój" },
                    { (byte)4, "Bankowość" },
                    { (byte)5, "BHP / Ochrona środowiska" },
                    { (byte)6, "Budownictwo" },
                    { (byte)7, "Call Center" },
                    { (byte)8, "Edukacja / Szkolenia" },
                    { (byte)10, "Franczyzna / Własny biznes" },
                    { (byte)11, "Hotelarstwo / Gastronomia / Turystyka" },
                    { (byte)12, "Human Resources / Zasoby ludzkie" },
                    { (byte)13, "Internet / e-Commerce / Nowe media" },
                    { (byte)14, "Inżynieria" },
                    { (byte)15, "IT - Administracja" },
                    { (byte)16, "IT - Rozwój oprogramowania" },
                    { (byte)9, "Finanse / Ekonomia" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 11L, "Nokia Networks" },
                    { 8L, "Tronel Sp. z o.o." },
                    { 10L, "OPONEO.PL S.A." },
                    { 9L, "PwC" },
                    { 7L, "Ericsson" },
                    { 2L, "Solvit" },
                    { 5L, "CBG International Sp. z o.o." },
                    { 4L, "EcoVadis Polska Sp. z o. o." },
                    { 3L, "Capgemini Software Solutions Center" },
                    { 1L, "IHS Markit" },
                    { 6L, "ING Tech Poland" }
                });

            migrationBuilder.InsertData(
                table: "TypeOfContracts",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { (byte)1, "Umowa o pracę" },
                    { (byte)2, "Umowa o dzieło" },
                    { (byte)3, "Umowa zlecenie" },
                    { (byte)5, "Kontrakt B2B" },
                    { (byte)6, "Umowa na zastępstwo" },
                    { (byte)7, "Umowa agencyjna" }
                });

            migrationBuilder.InsertData(
                table: "WorkingHours",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { (byte)2, "Część etatu" },
                    { (byte)1, "Pełny etat" },
                    { (byte)3, "Tymczasowa" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "AddedDate", "CategoryId", "CompanyId", "Description", "ExpirationDate", "Localization", "Name", "Salary", "TypeOfContractId", "WorkingHoursId" },
                values: new object[,]
                {
                    { 1L, null, (byte)16, 1L, null, null, null, ".NET Developer", null, (byte)1, (byte)1 },
                    { 3L, null, (byte)1, 2L, null, null, null, "Senior .NET Developer", null, (byte)1, (byte)1 },
                    { 4L, null, (byte)16, 3L, null, null, null, "Starszy Inżynier Oprogramowania .NET", null, (byte)1, (byte)1 },
                    { 6L, null, (byte)16, 5L, null, null, null, "C# .Net developer", null, (byte)3, (byte)1 },
                    { 7L, null, (byte)15, 6L, null, null, null, ".NET Developer", null, (byte)5, (byte)1 },
                    { 8L, null, (byte)12, 7L, null, null, null, ".NET Developer", null, (byte)3, (byte)1 },
                    { 11L, null, (byte)15, 9L, null, null, null, "Programista .NET", null, (byte)5, (byte)1 },
                    { 2L, null, (byte)1, 2L, null, null, null, "Junior .NET Developer", null, (byte)1, (byte)2 },
                    { 12L, null, (byte)16, 10L, null, null, null, "Junior .NET Developer", null, (byte)5, (byte)2 },
                    { 5L, null, (byte)16, 2L, null, null, null, "Programista .NET", null, (byte)1, (byte)3 },
                    { 9L, null, (byte)13, 8L, null, null, null, "Software Engineer C#", null, (byte)3, (byte)3 },
                    { 10L, null, (byte)11, 7L, null, null, null, "Quality Assurance", null, (byte)1, (byte)3 },
                    { 13L, null, (byte)16, 11L, null, null, null, "Azure DevOps", null, (byte)1, (byte)3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CategoryId",
                table: "Jobs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CompanyId",
                table: "Jobs",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_TypeOfContractId",
                table: "Jobs",
                column: "TypeOfContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_WorkingHoursId",
                table: "Jobs",
                column: "WorkingHoursId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "TypeOfContracts");

            migrationBuilder.DropTable(
                name: "WorkingHours");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
