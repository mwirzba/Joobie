﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Joobie.Migrations
{
    public partial class init : Migration
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
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Nip = table.Column<string>(nullable: true),
                    CompanyImagePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<byte>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfContract",
                columns: table => new
                {
                    Id = table.Column<byte>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Id = table.Column<byte>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
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
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
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
                    Name = table.Column<string>(nullable: false),
                    isActive = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Localization = table.Column<string>(nullable: false),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    Salary = table.Column<string>(nullable: false),
                    CategoryId = table.Column<byte>(nullable: false),
                    TypeOfContractId = table.Column<byte>(nullable: false),
                    WorkingHoursId = table.Column<byte>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
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
                        name: "FK_Job_TypeOfContract_TypeOfContractId",
                        column: x => x.TypeOfContractId,
                        principalTable: "TypeOfContract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Job_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Job_WorkingHours_WorkingHoursId",
                        column: x => x.WorkingHoursId,
                        principalTable: "WorkingHours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CVJobApplicationUser",
                columns: table => new
                {
                    JobInMiddleTableId = table.Column<long>(nullable: false),
                    EmployeeUserId = table.Column<string>(nullable: false),
                    CvName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVJobApplicationUser", x => new { x.JobInMiddleTableId, x.EmployeeUserId });
                    table.ForeignKey(
                        name: "FK_CVJobApplicationUser_AspNetUsers_EmployeeUserId",
                        column: x => x.EmployeeUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CVJobApplicationUser_Job_JobInMiddleTableId",
                        column: x => x.JobInMiddleTableId,
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "CompanyImagePath", "Name", "Nip" },
                values: new object[,]{
                    { "31d98481-9339-4e36-b3d4-c8f7e7ab3256", 0, "e5fbd409-c106-4492-8ed1-deeb2da3a7af", "ApplicationUser", "DefaultUser@gmail.com", true, true, null, null, "DEFAULTUSER@GMAIL.COM", "AQAAAAEAACcQAAAAEKQK0227340I7E9mRrWOJJwBpOyDx6zuZ9iN06nmNGJZkEyHl7ZZdBgxhtulSzn69Q==", null, false, "PBSCMSVSUTGUUIVILSKHSXF2HIQ2OXW6", false, "DefaultUser@gmail.com", "qfnqqlmr.jpg", "Millenium", "5340135475" },
                    { "69dacfbb-ce2f-4782-9ddc-8bc5fce20784", 0, "16ba960a-e35d-4606-9068-b27daf171409", "ApplicationUser", "ing@joobie.com", true, true, null, "ING@JOOBIE.COM", "ING@JOOBIE.COM", "AQAAAAEAACcQAAAAEJEaFHdgx+/dqxRoPYL6gwMTaEsHj5ewG/y6YUMpjfQuhBg1ivsHx/9//4kpfYWkVA==", null, false, "MWZDLJCRUDAYEF4YFQYBJO7VWGJUMTBL", false, "ing@joobie.com", "ing.jpg", "ING Bank Śląski", "6340135475" },
                    { "7c76f70b-fe41-4c9c-82b8-eac1ceb588c6", 0, "b107eb62-afcf-4d1b-b890-b92a3227dea4", "ApplicationUser", "sii@joobie.com", true, true, null, "SII@JOOBIE.COM", "SII@JOOBIE.COM", "AQAAAAEAACcQAAAAEJjEJ7glArsfmJ+e2cZNTd9glkbyJSMGl8ZOazdqADF9TXFTcJo3mBFuXa0g+vatBA==", null, false, "E2TRNHI2AURTC4T66DBYKAOJ5WMHIBEF", false, "sii@joobie.com", "sii.jpg", "SII", "5252352907" }  }
                );
            //hasło dla ing to 123456
            //hasło dla default usera to Admin123!

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { (byte)20, "Nieruchomości" },
                    { (byte)21, "Obsługa klienta" },
                    { (byte)23, "Prawo" },
                    { (byte)24, "Produkcja" },
                    { (byte)25, "Public Relations" },
                    { (byte)26, "Reklama / Grafika / Kreacja / Fotografia" },
                    { (byte)27, "Sektor publiczny" },
                    { (byte)28, "Sprzedaż" },
                    { (byte)29, "Transport / Spedycja" },
                    { (byte)30, "Ubezpieczenia" },
                    { (byte)31, "Zakupy" },
                    { (byte)32, "Kontrola jakości" },
                    { (byte)33, "Zdrowie / Uroda / Rekreacja" },
                    { (byte)34, "Energetyka" },
                    { (byte)35, "Inne" },
                    { (byte)19, "Media / Sztuka / Rozrywka" },
                    { (byte)18, "Marketing" },
                    { (byte)22, "Praca fizyczna" },
                    { (byte)16, "IT - Rozwój oprogramowania" },
                    { (byte)1, "Administracja biurowa" },
                    { (byte)2, "Doradztwo / Konsulting" },
                    { (byte)3, "Badania i rozwój" },
                    { (byte)4, "Bankowość" },
                    { (byte)17, "Łańcuch dostaw" },
                    { (byte)6, "Budownictwo" },
                    { (byte)7, "Call Center" },
                    { (byte)8, "Edukacja / Szkolenia" },
                    { (byte)5, "BHP / Ochrona środowiska" },
                    { (byte)10, "Franczyzna / Własny biznes" },
                    { (byte)11, "Hotelarstwo / Gastronomia / Turystyka" },
                    { (byte)12, "Human Resources / Zasoby ludzkie" },
                    { (byte)13, "Internet / e-Commerce / Nowe media" },
                    { (byte)14, "Inżynieria" },
                    { (byte)15, "IT - Administracja" },
                    { (byte)9, "Finanse / Ekonomia" }
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
                columns: new[] { "Id", "AddedDate", "CategoryId", "Description", "ExpirationDate", "Localization", "Name", "Salary", "TypeOfContractId", "UserId", "WorkingHoursId", "isActive" },
                values: new object[] { 1L, new DateTime(2020, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)16, ":)", new DateTime(2020, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gdańsk", ".NET Developer", "5000", (byte)1, "31d98481-9339-4e36-b3d4-c8f7e7ab3256", (byte)1, true });

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
                name: "IX_CVJobApplicationUser_EmployeeUserId",
                table: "CVJobApplicationUser",
                column: "EmployeeUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_CategoryId",
                table: "Job",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_TypeOfContractId",
                table: "Job",
                column: "TypeOfContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_UserId",
                table: "Job",
                column: "UserId");

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
                name: "CVJobApplicationUser");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "TypeOfContract");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "WorkingHours");
        }
    }
}
