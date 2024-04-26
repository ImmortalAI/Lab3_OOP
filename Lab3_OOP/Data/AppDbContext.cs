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
        public DbSet<Lab3_OOP.Models.Human> Human { get; set; } = default!;
        public DbSet<Lab3_OOP.Models.Klempner> Klempner { get; set; } = default!;
        public DbSet<Lab3_OOP.Models.Student> Student { get; set; } = default!;
    }
}
