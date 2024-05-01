using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Lab3_OOP.Models;

namespace Lab3_OOP.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Lab3_OOP.Models.Human> Human { get; set; } = null!;
        public DbSet<Lab3_OOP.Models.Profession> Profession { get; set; } = null!;
        public DbSet<Lab3_OOP.Models.HumansProf> HumansProf { get; set; } = null!;
    }
}
