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
        public DbSet<Salary> Salaries{ get; set; }
        public DbSet<Company> Companies { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}
    }
}
