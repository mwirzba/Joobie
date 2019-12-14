using Joobie.Models;
using Joobie.Models.JobModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Joobie.Data
{
    public class ApplicationContext : IdentityDbContext
    {
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<TypeOfContract> TypeOfContracts { get; set; }
        public DbSet<WorkingHours> WorkingHours { get; set; }
        public DbSet<Company> Companies { get; set; }
        public ApplicationContext(DbContextOptions options) : base(options) {}
       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "IT-Software_Development" },
                new Category { Id = 2, Name = "IT-Administration" },
                new Category { Id = 3, Name = "Banking" }
            );
           modelBuilder.Entity<TypeOfContract>().HasData(
               new TypeOfContract { Id = 1, Name = "Contract_Of_Employment" },
               new TypeOfContract { Id = 2, Name = "Contract_Of_Mandate" },
               new TypeOfContract { Id = 3, Name = "Contract_Of_Commission" },
               new TypeOfContract { Id = 4, Name = "B2B_Contract" }
           );
           
           modelBuilder.Entity<Company>().HasData(
               new Company {Id=1, Name = "IHS Markit" },
               new Company {Id=2, Name = "Solvit" }
           );
           
           modelBuilder.Entity<WorkingHours>().HasData(
               new WorkingHours { Id = 1, Name = "Full_Time" },
               new WorkingHours { Id = 2, Name = "Part_Time" }
           );

            modelBuilder.Entity<Job>().HasData(
                new Job { Id=1, Name = ".NET Developer", TypeOfContractId = 1, CompanyId = 1, WorkingHoursId = 1 , CategoryId =1},
                new Job { Id=2, Name = "Junior .NET Developer", TypeOfContractId = 1, CompanyId = 2, WorkingHoursId = 2 , CategoryId =1},
                new Job { Id=3, Name = "Senior .NET Developer", TypeOfContractId = 1, CompanyId = 2, WorkingHoursId = 2 , CategoryId = 1}
           );
       }
    }
}
