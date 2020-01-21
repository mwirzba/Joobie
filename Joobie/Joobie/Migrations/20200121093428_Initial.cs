using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Joobie.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfContract",
                columns: table => new
                {
                    Id = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfContract", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkingHours",
                columns: table => new
                {
                    Id = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingHours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Job",
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
                    table.PrimaryKey("PK_Job", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Job_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Job_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Job_TypeOfContract_TypeOfContractId",
                        column: x => x.TypeOfContractId,
                        principalTable: "TypeOfContract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Job_WorkingHours_WorkingHoursId",
                        column: x => x.WorkingHoursId,
                        principalTable: "WorkingHours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
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
                table: "Company",
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
                table: "TypeOfContract",
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
                table: "Job",
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Job_CategoryId",
                table: "Job",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_CompanyId",
                table: "Job",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_TypeOfContractId",
                table: "Job",
                column: "TypeOfContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_WorkingHoursId",
                table: "Job",
                column: "WorkingHoursId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "TypeOfContract");

            migrationBuilder.DropTable(
                name: "WorkingHours");
        }
    }
}
