using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Joobie.Models;
using Joobie.Models.JobModels;

namespace Joobie.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Job> Job { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<TypeOfContract> TypeOfContract { get; set; }
        public DbSet<WorkingHours> WorkingHours { get; set; }
        public DbSet<Company> Company { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Administracja biurowa" },
                new Category { Id = 2, Name = "Doradztwo / Konsulting" },
                new Category { Id = 3, Name = "Badania i rozwój" },
                new Category { Id = 4, Name = "Bankowość" },
                new Category { Id = 5, Name = "BHP / Ochrona środowiska" },
                new Category { Id = 6, Name = "Budownictwo" },
                new Category { Id = 7, Name = "Call Center" },
                new Category { Id = 8, Name = "Edukacja / Szkolenia" },
                new Category { Id = 9, Name = "Finanse / Ekonomia" },
                new Category { Id = 10, Name = "Franczyzna / Własny biznes" },
                new Category { Id = 11, Name = "Hotelarstwo / Gastronomia / Turystyka" },
                new Category { Id = 12, Name = "Human Resources / Zasoby ludzkie" },
                new Category { Id = 13, Name = "Internet / e-Commerce / Nowe media" },
                new Category { Id = 14, Name = "Inżynieria" },
                new Category { Id = 15, Name = "IT - Administracja" },
                new Category { Id = 16, Name = "IT - Rozwój oprogramowania" },
                new Category { Id = 17, Name = "Łańcuch dostaw" },
                new Category { Id = 18, Name = "Marketing" },
                new Category { Id = 19, Name = "Media / Sztuka / Rozrywka" },
                new Category { Id = 20, Name = "Nieruchomości" },
                new Category { Id = 21, Name = "Obsługa klienta" },
                new Category { Id = 22, Name = "Praca fizyczna" },
                new Category { Id = 23, Name = "Prawo" },
                new Category { Id = 24, Name = "Produkcja" },
                new Category { Id = 25, Name = "Public Relations" },
                new Category { Id = 26, Name = "Reklama / Grafika / Kreacja / Fotografia" },
                new Category { Id = 27, Name = "Sektor publiczny" },
                new Category { Id = 28, Name = "Sprzedaż" },
                new Category { Id = 29, Name = "Transport / Spedycja" },
                new Category { Id = 30, Name = "Ubezpieczenia" },
                new Category { Id = 31, Name = "Zakupy" },
                new Category { Id = 32, Name = "Kontrola jakości" },
                new Category { Id = 33, Name = "Zdrowie / Uroda / Rekreacja" },
                new Category { Id = 34, Name = "Energetyka" },
                new Category { Id = 35, Name = "Inne" }
            );
            modelBuilder.Entity<TypeOfContract>().HasData(
                new TypeOfContract { Id = 1, Name = "Umowa o pracę" },
                new TypeOfContract { Id = 2, Name = "Umowa o dzieło" },
                new TypeOfContract { Id = 3, Name = "Umowa zlecenie" },
                new TypeOfContract { Id = 5, Name = "Kontrakt B2B" },
                new TypeOfContract { Id = 6, Name = "Umowa na zastępstwo" },
                new TypeOfContract { Id = 7, Name = "Umowa agencyjna" }
            );

            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "IHS Markit" },
                new Company { Id = 2, Name = "Solvit" },
                new Company { Id = 3, Name = "Capgemini Software Solutions Center" },
                new Company { Id = 4, Name = "EcoVadis Polska Sp. z o. o." },
                new Company { Id = 5, Name = "CBG International Sp. z o.o." },
                new Company { Id = 6, Name = "ING Tech Poland" },
                new Company { Id = 7, Name = "Ericsson" },
                new Company { Id = 8, Name = "Tronel Sp. z o.o." },
                new Company { Id = 9, Name = "PwC" },
                new Company { Id = 10, Name = "OPONEO.PL S.A." },
                new Company { Id = 11, Name = "Nokia Networks" }
            );

            modelBuilder.Entity<WorkingHours>().HasData(
                new WorkingHours { Id = 1, Name = "Pełny etat" },
                new WorkingHours { Id = 2, Name = "Część etatu" },
                new WorkingHours { Id = 3, Name = "Tymczasowa" }
            );

            modelBuilder.Entity<Job>().HasData(
                new Job { Id = 1, Name = ".NET Developer", TypeOfContractId = 1, CompanyId = 1, WorkingHoursId = 1, CategoryId = 16 },
                new Job { Id = 2, Name = "Junior .NET Developer", TypeOfContractId = 1, CompanyId = 2, WorkingHoursId = 2, CategoryId = 1 },
                new Job { Id = 3, Name = "Senior .NET Developer", TypeOfContractId = 1, CompanyId = 2, WorkingHoursId = 1, CategoryId = 1 },
                new Job { Id = 4, Name = "Starszy Inżynier Oprogramowania .NET", TypeOfContractId = 1, CompanyId = 3, WorkingHoursId = 1, CategoryId = 16 },
                new Job { Id = 5, Name = "Programista .NET", TypeOfContractId = 1, CompanyId = 2, WorkingHoursId = 3, CategoryId = 16 },
                new Job { Id = 6, Name = "C# .Net developer", TypeOfContractId = 3, CompanyId = 5, WorkingHoursId = 1, CategoryId = 16 },
                new Job { Id = 7, Name = ".NET Developer", TypeOfContractId = 5, CompanyId = 6, WorkingHoursId = 1, CategoryId = 15 },
                new Job { Id = 8, Name = ".NET Developer", TypeOfContractId = 3, CompanyId = 7, WorkingHoursId = 1, CategoryId = 12 },
                new Job { Id = 9, Name = "Software Engineer C#", TypeOfContractId = 3, CompanyId = 8, WorkingHoursId = 3, CategoryId = 13 },
                new Job { Id = 10, Name = "Quality Assurance", TypeOfContractId = 1, CompanyId = 7, WorkingHoursId = 3, CategoryId = 11 },
                new Job { Id = 11, Name = "Programista .NET", TypeOfContractId = 5, CompanyId = 9, WorkingHoursId = 1, CategoryId = 15 },
                new Job { Id = 12, Name = "Junior .NET Developer", TypeOfContractId = 5, CompanyId = 10, WorkingHoursId = 2, CategoryId = 16 },
                new Job { Id = 13, Name = "Azure DevOps", TypeOfContractId = 1, CompanyId = 11, WorkingHoursId = 3, CategoryId = 16 }
           );
        }
    }
}
