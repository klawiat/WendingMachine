using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WendingMachine.Data.Entities;

namespace WendingMachine.Infrastructure
{
    public class WendingDbContext : DbContext
    {
        public DbSet<Coin> Coins { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public WendingDbContext(DbContextOptions<WendingDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
